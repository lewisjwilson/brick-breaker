using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool inPlay;
    public Transform paddle;
    public float speed;
    public Transform explosion;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

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
            gm.UpdateLives(-1); //reduce number of lives
            rb.velocity = Vector2.zero;
            inPlay = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("brick"))
        {
            Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            Destroy(other.gameObject);
            gm.UpdateBrickNumber();
            gm.UpdateScore(other.gameObject.GetComponent<BrickScript>().points); //get number of points that brick is worth
        }
    }
}
