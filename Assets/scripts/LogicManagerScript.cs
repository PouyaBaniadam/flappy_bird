using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public bool isGameOver = false;
    public GameObject startTheGameScreen;
    public GameObject gameOverScreen;
    public AudioSource soundEffectSource;
    public AudioClip jumpSound1;
    public AudioClip fartSound;
    private bool isFartSoundPlayed = false;
    public static bool isRestarting = false;

    private void Start()
    {
        if (isRestarting)
        {
            startTheGame();
        }
        else
        {
            Time.timeScale = 0;
            startTheGameScreen.SetActive(true);
        }
    }

    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void restartGame()
    {
        isRestarting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        isGameOver = true;

        if (!isFartSoundPlayed)
        {
            playSound("fart");
            isFartSoundPlayed = true;
        }

        Invoke("showScreen", 1f);
    }

    void showScreen()
    {
        gameOverScreen.SetActive(true);
    }

    public void playSound(string usecase)
    {
        switch (usecase)
        {
            case "jump":
                soundEffectSource.pitch = Random.Range(0.8f, 1.2f);
                soundEffectSource.PlayOneShot(jumpSound1);
                break;

            case "fart":
                soundEffectSource.pitch = 1f;
                soundEffectSource.PlayOneShot(fartSound);
                break;
        }
    }

    public void startTheGame()
    {
        Time.timeScale = 1;
        startTheGameScreen.SetActive(false);
    }
}