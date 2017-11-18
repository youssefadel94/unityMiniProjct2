using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour {

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private Quaternion rotation;
    // Use this for initialization
    void Start () {
        rotation = this.transform.rotation; 
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.anyKeyDown || !Input.anyKey) { 
       // yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");
        
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
        if (Input.anyKey || Input.anyKeyDown) {
          //  this.transform.rotation = rotation;
        }
    }
}
