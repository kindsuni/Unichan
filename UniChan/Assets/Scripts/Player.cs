using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float Speed = 3.5f;
    public float RSpeed = 360.0f;
    public float gravity = 100f;
    //Jump
    public float JumpSpeed = 8f;
    public float Max;
    private float Maxhigh;
    Vector3 jumping;
    private float GroundState = 0f;
    bool isjumping = false;
    bool isground = true;

   
    CharacterController uni;
    Animator animator;
    Rigidbody rid;
    // Use this for initialization
    void Start()
    {
        
        
        uni = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        rid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
        Maxhigh = Max + GroundState;

        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GroundState = transform.position.y;
            if (uni.isGrounded == true)
            {
                
                isjumping = true;
                
            }
                      
        }
        if(uni.isGrounded ==true)
        {
            gravity = 100f;
        }
        
        if (isjumping == true)
        {
            gravity = 60f;
            Jump();

        }
        if (uni.transform.position.y > Maxhigh)
        {
            jumping.y = 0f;
            isjumping = false;
            animator.SetBool("Jump", false);

        }



        if (GameObject.FindGameObjectsWithTag("Dot").Length == 1)
        {
            SceneManager.LoadScene("Unichan");

        }
        
      
    }



    private void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction,
                RSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }
        direction.y -= gravity * Time.deltaTime; //중력 작용은 움직이는 방향 전에 작용.
        uni.Move(direction * Speed * Time.deltaTime);
        animator.SetFloat("Speed", uni.velocity.magnitude);
    }

    private void Jump()
    {



        animator.SetBool("Jump", true);

        jumping.y += JumpSpeed;
        uni.Move(jumping * (Time.deltaTime * 0.2f));
        
    }

    

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Dot")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            SceneManager.LoadScene("Unichan");
        }
    }
}
