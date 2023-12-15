using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobster : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 3;


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
        
    }
}
