using System;
using Unity.VisualScripting;
using UnityEngine;
public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 3000f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Start()
    {
        ResetPosition();
        AddStartingForce();
    }
    public void ResetPosition()
    {
        rb.position = Vector3.zero;
        rb.linearVelocity = Vector3.zero;
    }
    public void AddStartingForce()
    {
        float x = UnityEngine.Random.Range(0.5f, 1f)*UnityEngine.Random.value < 0.5f ? -1f : 1f;
        float y = UnityEngine.Random.Range(0.3f, 0.7f) * UnityEngine.Random.value < 0.5f ? UnityEngine.Random.Range(-1.0f, -0.5f) : UnityEngine.Random.Range(0.5f, 1.0f);
        Vector2 direction = new Vector2(x, y);
        rb.AddForce(direction * speed);
    }
    public void AddForce(Vector2 force)
    {
        rb.AddForce(force, ForceMode2D.Impulse);
    }

}
