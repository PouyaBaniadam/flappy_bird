using UnityEngine;
using UnityEngine.InputSystem;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbody2;
    private float jumpStrength = 8;
    public LogicManagerScript logic;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !logic.isGameOver)
        {
            rigidbody2.linearVelocity = Vector2.up * jumpStrength;
            logic.playSound("jump");
        }

        if (transform.position.y > 11 || transform.position.y < -11)
        {
            logic.gameOver();
        }

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
}