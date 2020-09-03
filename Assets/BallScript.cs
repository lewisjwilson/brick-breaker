using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inPlay)
        {
            transform.position = paddle.position;
        }

        if (Input.GetButton("Jump") && !inPlay) //otherwise velocity rapidly increases
        {
            inPlay = true;
            rb.AddForce(Vector2.up * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bottom")) //"bottom" is layer name where BottomScreenEdge resides
        {
            Debug.Log("Ball is out of bounds");
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }
}
