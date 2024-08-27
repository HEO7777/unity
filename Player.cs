using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    float speed = 1.0f;
    float jump_speed = 150.0f;
    float sreen_sensitivity = 1.5f;
    Rigidbody p_rb;
    bool isGround = true;
    Vector3 mousePos;

    void Awake()
    {
        p_rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Jump();
        Screen_Rotation();
    }

    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.Translate(direction.normalized * speed * Time.deltaTime);
    }

    void Jump()
    {
        Vector3 jump_direction = new Vector3(0, Input.GetAxis("Jump"), 0);
        if (isGround && jump_direction.y > 0.0f)
        {
            p_rb.AddForce(jump_direction * jump_speed);
            isGround = false;
        }
    }

    void Screen_Rotation()
    {
        mousePos = Input.mousePosition;
        if (mousePos.x > Screen.safeArea.width / 2)
            this.transform.Rotate(0, sreen_sensitivity, 0);
        else if (mousePos.x < Screen.safeArea.width / 2)
            this.transform.Rotate(0, -sreen_sensitivity, 0);
        Mouse.current.WarpCursorPosition(new Vector2(Screen.safeArea.width / 2, Screen.safeArea.height / 2));
        // if (mousePos.y > Screen.safeArea.y / 2)
        // else
    }

    void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 물체의 태그가 "Ground"라면
        if (collision.gameObject.CompareTag("Ground"))
            isGround = true;
        // isGround를 true로 변경
    }
}
