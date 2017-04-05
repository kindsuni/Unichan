using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 360.0f;
    public float Jumpspeed = 280f;
    //private Vector3 moveDirection = Vector3.zero;
    GameObject Ch;
    Rigidbody jump;

    CharacterController con;
    Animator animator;
	// Use this for initialization
	void Start () {
        con = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        jump = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")); //방향키 세로, 가로
        if(direction.sqrMagnitude > 0.01f) //sqrMagnitude은 방향 벡터의 크기(길이)를 가르키는 것. 즉, 방향키를 눌렀다는 것을 확인.
        {
            //Slerp =구형 선형보간
            //LooAt = 바라보게 함.
              Vector3 forward = Vector3.Slerp(
                  transform.forward, //월드 스페이스에서의 캐릭터 z축값
                  direction, //위에서 입력 받은 방향키의 벡터 값.
               //한프레임 내에서   회전해야할 각도(360* 1/60)=6
               rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction) //0~1사이값의 보간
                  //
                  );
            transform.LookAt(transform.position + forward); //현재 위치에 포워드(방향벡터) 를 더해줌으로 현재위치가 포워드를 바라보게됨. 
        }


        con.Move(direction * moveSpeed * Time.deltaTime);//위치만 변화

        animator.SetFloat("Speed", con.velocity.magnitude);


        
    }
   
}
