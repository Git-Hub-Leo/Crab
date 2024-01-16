using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Lobster : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3;
    [SerializeField]
    private float angularSpeed = 1000;
    [SerializeField]
    private int IncreaseLobstersize = 5;
    private int LobsterScore = 0;
    [SerializeField]
    private TMP_Text GameOverDisplay;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        GameOverDisplay.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 1% chance of turning 
        if (Random.Range(0, 100) < 1)
        {
            float angleRadians = rb.rotation * Mathf.PI / 180f;
            float xSpeed = Mathf.Cos(angleRadians) * speed;
            float ySpeed = Mathf.Sin(angleRadians) * speed;
            rb.velocity = new Vector2(xSpeed, ySpeed);
            // slumpa riktningsförändring
            float angle = Random.Range(-angularSpeed, angularSpeed) * Time.deltaTime;
       
            rb.rotation += angle;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.name.StartsWith("Crab"))
        {
            Destroy(collision.gameObject);
            Time.timeScale = 0;
            GameOverDisplay.enabled = true;
            GameOverDisplay.text = "GAME OVER";
            
        }

        if (collision.gameObject.name.StartsWith("worm"))
        {
            Destroy(collision.gameObject);
            LobsterScore = LobsterScore + 1;

            if (IncreaseLobstersize == LobsterScore )
            {
                if (IncreaseLobstersize < 20 ) 
                {
                    IncreaseLobstersize = IncreaseLobstersize + 5;
                    speed = speed + 1;
                }
            }

        }

        if (collision.gameObject.name.EndsWith("wall"))
        { 
            rb.rotation = Random.Range(-180, 180);
        }
    }
}
