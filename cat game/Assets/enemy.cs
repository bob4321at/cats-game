using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool direction;
    private Transform playerpos;
    public float speed;
    public float maxspeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerpos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -maxspeed, maxspeed), Mathf.Clamp(rb.velocity.y, -10000, 10000));
        if (transform.position.x < playerpos.transform.position.x) {
            rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
        } else if (transform.position.x > playerpos.transform.position.x) {
            rb.AddForce(new Vector2(-speed * Time.deltaTime, 0));
        }
    }
}
