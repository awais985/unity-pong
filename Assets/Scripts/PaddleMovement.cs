    using UnityEngine;

    public class PaddleMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float speed = 5f;
        [SerializeField] private KeyCode upKey1 = KeyCode.UpArrow;
        [SerializeField] private KeyCode upKey2 = KeyCode.W;
        [SerializeField] private KeyCode downKey1 = KeyCode.DownArrow;
        [SerializeField] private KeyCode downKey2 = KeyCode.S;
    private Vector2 startPos;
        private bool canMove;
        private Vector2 direction;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            startPos = rb.position;
        }

        void Update()
        {
        if (!canMove) return;

        direction = Vector2.zero;
        if (Input.GetKey(upKey1) || Input.GetKey(upKey2))
            {
                direction = Vector2.up;
            }
            if(Input.GetKey(downKey1) || Input.GetKey(downKey2))
            {
                direction = Vector2.down;
            }
    }

    // Update is called once per frame
    void FixedUpdate()
        {
        if (!canMove) return;

        Vector2 newPos = rb.position + direction * speed * Time.fixedDeltaTime;

            if (newPos.y > 4f)
            {
                newPos.y = 4f;
            }
            if (newPos.y < -4f)
            {
                newPos.y = -4f;
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
