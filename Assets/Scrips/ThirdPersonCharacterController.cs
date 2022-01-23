using System.Collections;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float speed;
    public Animator anim;

    public Rigidbody rb;
    public float speedJump = 5f;
    public bool canJumping;

    private void Start()
    {
        canJumping = true;
    }

    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(0f, 0f, 0f);
        if (ver < 0)
        {
            playerMovement = new Vector3(0f, 0f, 0f) * speed * Time.deltaTime;
        }
        else
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Correr"))
            {
                playerMovement = new Vector3(hor, 0f, ver) * (speed * 2.5f) * Time.deltaTime;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Agachado"))
            {
                playerMovement = new Vector3(hor, 0f, ver) * (speed * 0.5f) * Time.deltaTime;
            }
            else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Caminar"))
            {
                playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
            }
            else
            {
                playerMovement = new Vector3(0f, 0f, 0f) * speed * Time.deltaTime;
            }
        }
        transform.Translate(playerMovement, Space.Self);

        if (canJumping)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector3(0, speedJump, 0), ForceMode.Impulse);
            }
        }
    }
}
