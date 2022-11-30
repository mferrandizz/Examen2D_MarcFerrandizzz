using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{

    public float vel = 3.5f;
    public float FuerzaSalto = 4f;
    private float horizontal;

    private Rigidbody2D rb;
    public Animator anim;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Correr", true);
        }
        else if (horizontal == -1)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Correr", true);
        }
        else 
        {
            anim.SetBool("Correr", false);
        }

        if(Input.GetButtonDown("Jump") && GroundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * FuerzaSalto, ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
        }
    }


    void FixedUpdate() {

        rb.velocity = new Vector2 (horizontal * vel, rb.velocity.y);
            
    }






}
