using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerPaddle : MonoBehaviour
{
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    Vector2 move;
    public float speeds = 5f;
    private void Update()
    {
        transform.position = transform.position + new Vector3(0, move.y, 0) * speeds * Time.deltaTime;
    }
    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        // This method will be called when the player moves
        Debug.Log(move);
    }
    public void ResetPosition()
    {
        rb.position= new Vector2(rb.position.x, 0.0f);
        rb.linearVelocity = Vector2.zero;
    }
}
