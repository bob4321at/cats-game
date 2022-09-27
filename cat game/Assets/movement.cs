using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float maxspeed;
    public float jumpheight;

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

        if (Physics2D.Raycast(transform.position, Vector2.down, 0.66f)) {
            if (Input.GetButtonDown("Jump")) {
                rb.AddForce(new Vector2(0, jumpheight));
            }
        }

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxspeed, maxspeed), Mathf.Clamp(rb.velocity.y, -10000, 10000));
        rb.AddForce(movedir);
    }
}