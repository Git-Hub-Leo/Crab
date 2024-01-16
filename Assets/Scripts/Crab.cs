using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;
using System.Runtime.InteropServices;

public class Crab : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 4;
    [SerializeField]
    private TMP_Text scoreDisplay;
    private int score = 0;
    [SerializeField]
    private GameObject lobsterPrefab;
    [SerializeField]
    private GameObject wormPrefab;
    private int nextLobsterScore = 10;
    [SerializeField]
    private int crabSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float angleRadians = rb.rotation * Mathf.PI / 180f;
        float xSpeed = Mathf.Cos(angleRadians) * speed;
        float ySpeed = Mathf.Sin(angleRadians) * speed; 
        rb.velocity  =new Vector2 (xSpeed, ySpeed);

        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation += 180 * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.rotation -= 180 * Time.deltaTime;
        }
        
        //Imports new worm to random position
        if (Random.Range(0, 100) < 0.005)
        {
            float x = Random.Range(-11, 11);
            float y = Random.Range(-4, 4);
            Instantiate(wormPrefab, new Vector2(x, y), Quaternion.identity);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("worm"))
        {
            Destroy(collision.gameObject);
            score = score + 1;
            scoreDisplay.text = "Score: " + score;

            if (score == crabSpeed ) 
            { 
                if (crabSpeed < 15) 
                {
                    crabSpeed = crabSpeed + 5;
                    speed = speed + 1;
                }
            }

            //Calls a new lobster when points increase
            if (score == nextLobsterScore )
            {
                float x = 0;
                float y = 0;
                Instantiate(lobsterPrefab, new Vector2(x, y), Quaternion.identity);
               
                if (nextLobsterScore < 200) 
                {
                    nextLobsterScore = nextLobsterScore + 10;
                }
                
            }
            
           
        }
    }
}
