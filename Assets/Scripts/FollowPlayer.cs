using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowPlayer : MonoBehaviour
{
    public float m_allowableDistance = 3f;
    public Rigidbody ball;
    public float m_followSpeed = 1f;

    Vector3 m_direction;
    bool following;

    private void Start()
    {
        ball = ball.GetComponent<Rigidbody>();
        ball.isKinematic = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Ball")
                {
                    Vector3 rayPoint = ray.GetPoint(Vector3.Distance(ball.position, transform.position));
                    ball.MovePosition(ball.transform.position + new Vector3(rayPoint.x, 0f, 0f));

                }
            }
        }

    }
}