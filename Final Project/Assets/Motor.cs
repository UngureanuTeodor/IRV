using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motor : MonoBehaviour {

    public float runSpeed = 10f;
    public float walkSpeed = 1.5f;
    public float rotateSpeed = 3.0f;

    private CharacterController controller;
    private Transform cameraTransform;
    private Animator anim;
    private Vector3 moveVector;

    public AudioSource footsteps;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        footsteps = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            anim.SetTrigger("Jump");
        }

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            footsteps.Play();
        }
        else if (! Input.GetButtonDown("Horizontal") && ! Input.GetButtonDown("Vertical") && footsteps.isPlaying)
        {
            footsteps.Stop();
        }

        float speed = (Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed);
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        anim.SetFloat("Speed", controller.velocity.magnitude);
    }

}
