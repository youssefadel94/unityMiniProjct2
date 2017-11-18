using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charectar_Controller : MonoBehaviour {


    private new Animator animation;
    private float speed;
    private bool isCrouching;
    private bool isPlaying;
    private bool isJumping;

    void donePlaying() {
        isPlaying = false;
    }

    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();
        speed = 3.0f;
        isCrouching = false;
        isPlaying = true;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //isPlaying || isCrouching || isJumping
        if (false) {
           // animation.Play("uncrouch");
          //  isCrouching = false;

        }
        else { 
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {

            animation.Play("walk");
            ; speed = 3.0f;
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
            {
                animation.Play("run");
                speed = 6.0f;
            }
            else
            {
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
                {
                    animation.Play("walk");
                }
                else
                {
                    if (Input.GetKey(KeyCode.S))
                    {
                        animation.Play("walk back");
                    }
                    else
                    {
                        if (Input.GetKey(KeyCode.Space) )
                        {
                            animation.Play("jump");//need new animation disabled for now
                                isJumping = true;
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.C) )
                            {

                                animation.Play("crouch");//need new animation disabled for now
                                    isCrouching = true;
                            }
                            else
                            {
                               // animation.Play("idle");//need fix wait till init animation finish playing
                            }
                        }
                    }
                }
            }

        }
    }
    }

}
