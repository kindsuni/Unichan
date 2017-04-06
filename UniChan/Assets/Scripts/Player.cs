using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public float Speed = 3.5f;
    public float RSpeed = 360.0f;

    CharacterController uni;
    Animator animator;

	// Use this for initialization
	void Start () {

        uni = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if(direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(
                transform.forward,
                direction, 
                RSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            transform.LookAt(transform.position + forward);
        }

              uni.Move(direction * Speed * Time.deltaTime);
        animator.SetFloat("Speed", uni.velocity.magnitude);
              
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Dot")
        {
            Destroy(other.gameObject);
        }
        if(other.tag =="Enemy")
        {
            SceneManager.LoadScene("Main");
        }
    }
}
