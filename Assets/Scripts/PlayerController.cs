using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public float m_velocityMove = 10f;
    public float m_jumpHeight = 4f;

    CharacterController m_controller;
    bool m_isGrounded;
    float m_gravity = -9.80665f;
    Vector3 velocity;
    void Start()
    {
        m_controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Controller();
    }

    void Controller()
    {
        m_isGrounded = m_controller.isGrounded;
        float verticalSpeed = m_controller.velocity.y;
        if (m_isGrounded && verticalSpeed < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        bool jumped = Input.GetButtonDown("Jump");

        Vector3 move = (transform.right * horizontal + transform.forward * vertical) * m_velocityMove * Time.deltaTime;

        m_controller.Move(move);

        if (jumped && m_isGrounded)
        {
            velocity.y = (float)Math.Sqrt(m_jumpHeight * -2f * m_gravity);
        }

        velocity.y += m_gravity * Time.deltaTime;

        m_controller.Move(velocity * Time.deltaTime);
    }
}
