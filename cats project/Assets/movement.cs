using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float movx = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;

        Vector2 movedir = transform.right * movx;

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxspeed, maxspeed), Mathf.Clamp(rb.velocity.y, -10000, 10000));
        rb.AddForce(movedir);
    }
}
