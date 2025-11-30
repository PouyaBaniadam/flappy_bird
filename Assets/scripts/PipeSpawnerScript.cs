using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipe;
    public LogicManagerScript logic;
    private float lastSpawnTimer = 0;
    private float minSpawnRate = 2.85f;
    private float maxSpawnRate = 5;
    private float currentSpawnRate = 3.5f;
    private float heightOffset = 8;


    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
        calculateCurrentSpawneRate();
        spawnPipe();
    }

    void Update()
    {
        if (lastSpawnTimer < currentSpawnRate)
        {
            lastSpawnTimer += Time.deltaTime;
        }
        else
        {
            spawnPipe();
            lastSpawnTimer = 0;
            calculateCurrentSpawneRate();
        } 
    }

    void spawnPipe()
    {
        if (!logic.isGameOver)
        {
            float lowestPoint = transform.position.y - heightOffset;
            float highestPoint = transform.position.y + heightOffset;
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        }
    }

    void calculateCurrentSpawneRate() 
    {
        currentSpawnRate = Random.Range(minSpawnRate, maxSpawnRate);
    }
}