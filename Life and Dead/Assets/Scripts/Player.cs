//System
using System.Collections;
using System.Collections.Generic;

//Unity
using UnityEngine;

[DisallowMultipleComponent]
public class Player : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    private float hAxis;
    private float vAxis;

    private bool isRun;

    private Vector3 moveVector;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Input Move Key
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        isRun = Input.GetKey(KeyCode.LeftShift);

        // Vector Normalize
        moveVector = new Vector3(hAxis, 0, vAxis).normalized;

        // Move
        transform.position += moveVector * (isRun ? runSpeed : walkSpeed) * Time.deltaTime;

        // Animation
        animator.SetBool("walk", moveVector != Vector3.zero);
        animator.SetBool("run", isRun);

        // Rotation
        transform.LookAt(transform.position + moveVector);
    }
}
