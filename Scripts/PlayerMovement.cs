using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform Player;
    float xPos;
    float xDir;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 5;
       
        
           xPos = Player.transform.position.x;
        if(xPos> 7 )
        {
            speed = 0;
            transform.position =new Vector3( 6.99f,transform.position.y, 0 );

        }else if(xPos < -7 )
        {
            speed = 0;
            transform.position = new Vector3(-6.99f, transform.position.y, 0);
        }
        else
        {
            speed = 6f;
        }
          
        xDir =Input.GetAxis("Horizontal");
            transform.position = new Vector3(transform.position.x + xDir * speed *Time.deltaTime, transform.position.y, 0);

    }
}
