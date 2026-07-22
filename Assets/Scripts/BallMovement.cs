using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float ballSpeed = 5f;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private GameManager gameManager;
    private Vector2 startPos;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
    }

    public void LaunchBall()
    {
        int direction = Random.Range(0, 2);
        rb.position = Vector2.zero;
        rb.linearVelocity = Vector2.zero;
        if (direction == 0)
        {
            Vector2 distance = new Vector2(1, 1);
            rb.linearVelocity = distance * ballSpeed;
        }
        else
        {
            Vector2 distance = new Vector2(1, -1);
            rb.linearVelocity = distance * ballSpeed;
        }

        //rb.linearVelocity = new Vector2(2, 1) * ballSpeed;
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector2.zero;
    }
    public void ResetBall()
    {
        rb.position = startPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LeftGoal"))
        {
            scoreManager.increaseRightPaddleScore();
            if (!gameManager.IsGameOver())
            {
                LaunchBall();
            }
        }
        if (other.CompareTag("RightGoal"))
        {
            scoreManager.increaseLeftPaddleScore();
            if (!gameManager.IsGameOver())
            {
                LaunchBall();
            }

        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    //transform.Translate(Vector2.left * ballSpeed * Time.deltaTime);
    //}
}