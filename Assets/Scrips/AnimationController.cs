using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Animator anim;
    public GameObject espadaDerecha;
    public GameObject espadaIzquierda;

    public GameObject espadaSkin1;
    public GameObject espadaSkin2;

    void Start()
    {
        anim = GetComponent<Animator>();
        espadaDerecha = GameObject.Find("Espada Derecha SA");
        espadaIzquierda = GameObject.Find("Espada Izquierda SA");

        espadaDerecha.SetActive(false);
        espadaIzquierda.SetActive(false);

        espadaSkin1 = GameObject.Find("Espada Derecha");
        espadaSkin2 = GameObject.Find("Espada Izquierda");

        espadaSkin1.SetActive(true);
        espadaSkin2.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetTrigger("Caminar");
        }
        else if (Input.GetKeyUp(KeyCode.W) && (anim.GetCurrentAnimatorStateInfo(0).IsName("Caminar") || anim.GetCurrentAnimatorStateInfo(0).IsName("Correr") || anim.GetCurrentAnimatorStateInfo(0).IsName("Agachado")))
        {
            anim.SetTrigger("EstaticaLoop");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            anim.SetTrigger("Correr");
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            anim.SetTrigger("Agachado");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetTrigger("BackFlip");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Patada1");
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            anim.SetTrigger("Patada2");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetTrigger("Ejercicio");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetTrigger("Ataque");
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Ataque"))
            {
                espadaDerecha.SetActive(true);
                espadaIzquierda.SetActive(true);

                espadaSkin1.SetActive(false);
                espadaSkin2.SetActive(false);
            }
            else
            {
                espadaDerecha.SetActive(false);
                espadaIzquierda.SetActive(false);

                espadaSkin1.SetActive(true);
                espadaSkin2.SetActive(true);
            }

            anim.SetTrigger("Estatica");
        }
    }
}
