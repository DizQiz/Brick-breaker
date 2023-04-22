using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class BallEngine : MonoBehaviour
{

    public Rigidbody2D rb;
    public int maxLife;
    public int breakCount;
    public GameObject life1;
    public GameObject life2;
    public GameObject life3;

    public TMP_Text scores;
    int score;
    
    
    bool isLife;
    
    // Start is called before the first frame update
    void Start()
    {
        isLife = false;
        score = 0;
        breakCount = 16;
        maxLife = 3;
        rb.gravityScale = 0;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = 2.5f;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }

        scores.text = "Score :"+ score.ToString();
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            rb.gravityScale = 0;
        }

        if(collision.gameObject.tag == "Wall")
        {
            transform.position = new Vector2(0,0);
            
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

            maxLife -= 1;


            LifeDown();

            if (maxLife == 0)
            {
                SceneManager.LoadScene("GameOver");
                print("work");
            }
        }

        if(collision.gameObject.tag == "Break")
        {
            Destroy(collision.gameObject);
            breakCount -= 1;
            score += 50;
            if(breakCount == 0)
            {
                SceneManager.LoadScene("Victory");
                print("victory");
            }
        }
        
    }

    public void LifeDown()
    {
        if(maxLife == 2)
        {
            Destroy(life1);
            isLife = true;
        }
        else if(maxLife == 1 && isLife == true)
        {
            Destroy(life2);
            
        }

    }
}
