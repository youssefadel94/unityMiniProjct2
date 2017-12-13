using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCharectar : MonoBehaviour {
    private float health;
    // Use this for initialization
    void Start() {
        health = 100;
    }

    // Update is called once per frame
    void Update() {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        Debug.Log(health);
        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
    public void hitByOrc() {

        health -= 5;
    }
}
