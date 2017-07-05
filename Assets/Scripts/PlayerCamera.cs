using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
   public GameObject Cam;
   public GameObject Target;
    Vector3 Offset;
	// Use this for initialization
	void Start () {
       

        Offset = Cam.transform.position - Target.transform.position;


        }

    // Update is called once per frame
    void Update () {
        Cam.transform.position = Offset + Target.transform.position;
	}
}
