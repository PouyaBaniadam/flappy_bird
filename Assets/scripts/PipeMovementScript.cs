using UnityEngine;

public class PipeMovementScript : MonoBehaviour
{
    private float movementSpeed = 3.5f;
    private int deadZone = -25;

    void Update()
    {
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
        transform.position = transform.position + (Vector3.left * movementSpeed) * Time.deltaTime;
    }
}
