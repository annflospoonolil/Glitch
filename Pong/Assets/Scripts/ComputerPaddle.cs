using UnityEngine;

public class ComputerPaddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        if (this.ball.linearVelocity.x > 0.0f)
        {
            if (this.ball.position.y > this.transform.position.y)
            {
                rb.AddForce(Vector2.up * 10.0f);
            }
            else if (this.ball.position.y < this.transform.position.y)
            {
                rb.AddForce(Vector2.down * 10.0f);
            }
        }
        else
        {
            if (this.transform.position.y > 0.0f)
            {
                rb.AddForce(Vector2.down * 10.0f);
            }
            else if (this.transform.position.y < 0.0f)
            {
                rb.AddForce(Vector2.up * 10.0f);
            }
        }
    }
        public void ResetPosition()
    {
        rb.position= new Vector2(rb.position.x, 0.0f);
        rb.linearVelocity = Vector2.zero;
    }
}
