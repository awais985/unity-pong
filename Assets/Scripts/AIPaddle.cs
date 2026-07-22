using UnityEngine;

public class AIPaddle : MonoBehaviour
{
    [SerializeField] private Transform ball;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float deadZone = 0.5f;
    private Rigidbody2D rb;
    private Vector2 direction;
    private Vector2 startPos;
    private bool canMove;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        startPos = rb.position;
    }

    void Update()
    {
        if (!canMove) return;
        direction = Vector2.zero;
        float difference = ball.position.y - transform.position.y;
        if (difference > deadZone)
        {
            direction = Vector2.up;
        }
        else if (difference < -deadZone)
        {
            direction = Vector2.down;
        }

    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + direction * speed * Time.fixedDeltaTime;
        if (!canMove) return;
        if (newPos.y > 4f)
        {
            newPos.y = 4f;
        }
        else if(newPos.y < -4)
        {
            newPos.y = -4;
        }
        rb.MovePosition(newPos);
    }
    public void StartPaddle()
    {
        canMove = true;
    }
    public void StopPaddle()
    {
        canMove = false;
        direction = Vector2.zero;
    }

    public void ResetPaddle()
    {
        rb.position = startPos;
    }
}