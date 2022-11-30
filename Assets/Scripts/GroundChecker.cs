using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public static bool isGrounded;
    public MovimientoPlayer player;

    void Awake()
    {
        player = GameObject.Find("knight").GetComponent<MovimientoPlayer>();
    }

    void OnTriggerStay2D (Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
        isGrounded = true;
        player.anim.SetBool("Jump", false);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isGrounded = false;
    }
}