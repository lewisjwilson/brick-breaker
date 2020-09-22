using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public float speed;
    public float rightScreenEdge;
    public float leftScreenEdge;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.gameOver)
        {
            return;
        }

        Vector2 movement = Vector2.zero; //initialize direction as zero

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.position.x < Screen.width/2) //if touch is left side of screen
            {
                Debug.Log("LeftTouch");
                movement = Vector2.left; //movement direction = left
           

            } else if(touch.position.x > Screen.width/2)
            {
                Debug.Log("RightTouch");
                movement = Vector2.right; //movement direction = right
            }

            transform.Translate(movement * Time.deltaTime * speed, 0); //y axis = 0

        }


        //setting boundaries for the paddle (screen edges)
        if(transform.position.x < leftScreenEdge)
        {
            transform.position = new Vector2(leftScreenEdge, transform.position.y);
        }

        if(transform.position.x > rightScreenEdge)
        {
            transform.position = new Vector2(rightScreenEdge, transform.position.y);
        }
    }
}
