using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SocialPlatforms.Impl;

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

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("worm"))
        {
            Destroy(collision.gameObject);
            score = score + 1;
            scoreDisplay.text = "Score: " + score;

            if (score == 2 || score == 4 || score == 6)
            {
                float x = 5;
                float y = 5;
               Instantiate(lobsterPrefab, new Vector2(x, y),Quaternion.identity) ;
            }

            if (score == 2 || score == 4 || score == 6)
            {
                float x = Random.Range(-12, 12);
                float y = Random.Range(-5, 5);
                Instantiate(wormPrefab, new Vector2(x, y), Quaternion.identity);
            }
        }
    }
}
