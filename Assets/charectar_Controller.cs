using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charectar_Controller : MonoBehaviour {


    private new Animator animation;
    private float speed;
    private bool isCrouching;
    private bool isPlaying;
    private bool isPlaying2;
    private bool isJumping;

    void donePlaying() {
        isPlaying = false;
    }
    void donePlaying2()
    {
        isPlaying2 = false;
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
        Debug.Log("crouching"+isCrouching + " playing " +isPlaying+ " 2 "+ isPlaying2);


        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        //isPlaying || isCrouching || isJumping
        if ( isPlaying2 || isPlaying) {
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
                                isJumping = true;isPlaying = true;
                        }
                        else
                        {
                            if (Input.GetKey(KeyCode.C) && !isCrouching && !isPlaying2 && !isPlaying)
                            {

                                animation.Play("crouch");//need new animation disabled for now
                                    isCrouching = true; isPlaying = true;

                            }
                            else
                            {
                                    if (Input.GetKey(KeyCode.C) && isCrouching && !isPlaying2 && !isPlaying) {
                                        animation.Play("uncrouch");//need new animation disabled for now
                                        isCrouching = false; isPlaying2 = true;
                                    }
                                    else {
                                        if(!isPlaying && !isPlaying2 && !isCrouching) animation.Play("idle");//need fix wait till init animation finish playing
                                    }
                                }
                        }
                    }
                }
            }

        }
    }
    }

}
