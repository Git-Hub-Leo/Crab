using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Lobster : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3;
    [SerializeField]
    private float angularSpeed = 1000;



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
        // 1% chans för sväng
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
        
        
        // går fram
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        

        if (collision.gameObject.name.StartsWith("Crab"))
        {
            Destroy(collision.gameObject);
            
        }

        if (collision.gameObject.name.EndsWith("wall"))
        { 
            rb.rotation = Random.Range(-180, 180);
        }
    }
}
