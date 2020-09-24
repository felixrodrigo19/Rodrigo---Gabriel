using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 5f;
    Transform obj;

    Vector3 playerPosition;
    bool clicked;

    private void Update()
    {
        playerPosition = transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                // if (hit.transform.tag == "Agent")
                // {
                obj = hit.transform.GetComponent<Transform>();
                clicked = true;
                // }
            }
        }
        if (Input.GetButtonDown("E"))
        {
            clicked = false;
        }

        if (clicked == true)
        {
            obj.transform.position = Vector3.MoveTowards(obj.transform.position, playerPosition, speed * Time.deltaTime);
        }
    }
}