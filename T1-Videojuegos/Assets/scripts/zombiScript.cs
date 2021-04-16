using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiScript : MonoBehaviour
{
    public float velocidad = 3;
    private bool EstaSaltando = false;
    private bool EstaMuerto = false;
    private bool EstaDestruido = false;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         Debug.Log("Esto se crea una unica vez");
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
         if (EstaMuerto != true & EstaDestruido==false)
         {
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                //CambiarAnimacion(ANIMATION_CORRER);
                spriteRenderer.flipX = true;
         }
    }
   
}
