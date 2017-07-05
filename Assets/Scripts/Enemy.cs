using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {
    public GameObject target; //타겟(플레이어)를 따라가게 만듬.
    NavMeshAgent agent;
    Animator animator;
    
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>(); //네비를 설정하면 에이전트를 생성해야함.
        animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.transform.position;
        animator.SetFloat("Speed", agent.velocity.magnitude);
	}
}
