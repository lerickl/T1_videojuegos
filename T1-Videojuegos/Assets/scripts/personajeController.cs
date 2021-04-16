using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personajeController : MonoBehaviour
{
    public float fuerzaSalto = 18;
    public float velocidad = 5;
    private bool EstaSaltando = false;
    private bool EstaMuerto = false;
    private bool EstaDestruido = false;
    private bool EstaCorriendo=true;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    
    private const int ANIMATION_QUIETO = 0;
    private const int ANIMATION_CORRER = 1;
    private const int ANIMATION_SALTAR = 2;   
    private const int ANIMATION_MORIR = 3;
    private int PasaZombi=0;
    
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
            if(EstaCorriendo==true)
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);//velocidad de mi objeto
                CambiarAnimacion(ANIMATION_CORRER);//Accion correr 
                spriteRenderer.flipX = false;
            }
            
            if (Input.GetKey(KeyCode.Space) && !EstaSaltando)
            {
                CambiarAnimacion(ANIMATION_SALTAR);
                Saltar();
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
                EstaSaltando = true;
                EstaCorriendo = false;
            }
        } else if(EstaMuerto==true)
        {
            CambiarAnimacion(ANIMATION_MORIR);
            rb.gravityScale = 1f;
            Destroy(this.gameObject, 1f);
            EstaDestruido = true;
            rb.gravityScale = 5;
        }
        

    }
    private void Saltar()
    {
         
        rb.velocity = Vector2.up * fuerzaSalto;//Vector 2.up es para que salte hacia arriba
    }

    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
      private void OnCollisionEnter2D(Collision2D collision)
    {
        EstaCorriendo = true;
        EstaSaltando = false;//Cuando choca con alguna colision lo cambie mi estado a false para que pueda nuevamente saltar
        CambiarAnimacion(ANIMATION_QUIETO);//Metodo donde mi objeto se va a quedar quieto
        if (collision.gameObject.name == "zombi_H")
        {
            EstaMuerto = true;
        }
          if (collision.gameObject.name == "zombi_M")
        {
            EstaMuerto = true;
        }
        if (collision.gameObject.name == "Capsule")
        {
            PasaZombi++;
            Debug.Log("cantidad de zombis pasados: "+PasaZombi);
           
            if(PasaZombi>=10 && PasaZombi<11)
            {
                velocidad=velocidad+5;   
            }if(PasaZombi>=20 && PasaZombi<31)
            {
                velocidad=velocidad+5;   
            }if(PasaZombi>=30 && PasaZombi<41)
            {
                velocidad=velocidad+5;   
            }if(PasaZombi>=40 && PasaZombi<51)
            {
                velocidad=velocidad+5;   
            }
        }
         

    }
}
