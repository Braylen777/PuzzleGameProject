using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    Vector3 up = Vector3.zero,
        right = new Vector3(0, 90, 0),
        down = new Vector3(0, 180, 0),
        left = new Vector3(0, 270, 0),
        CurrentDirection = Vector3.zero;

    Vector3 NextPos, Destination, Direction;

    public float speed = 10f;
    float rayLength = 1f;
    bool CanMove;

    void Start()
    {
        CurrentDirection = up;
        NextPos = Vector3.forward;
        Destination = transform.position;
    }


    void Update()
    {
        Move();
    }

    void Move()
    {

        transform.position = Vector3.MoveTowards(transform.position, Destination, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            NextPos = Vector3.right;
            CurrentDirection = right;
            CanMove = true;
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            NextPos = Vector3.left;
            CurrentDirection = left;
            CanMove = true;
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            NextPos = Vector3.back;
            CurrentDirection = down;
            CanMove = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            NextPos = Vector3.forward;
            CurrentDirection = up;
            CanMove = true;
        }



        if (Vector3.Distance(Destination, transform.position) <= 0.0001f)
        {
            transform.localEulerAngles = CurrentDirection;
            if (CanMove)
            {
                if (Valid())
                {
                    Destination = transform.position + NextPos;
                    Direction = NextPos;
                    CanMove = false;
                }

            }

        }

        bool Valid()
        {
            Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
            RaycastHit hit;

            Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

            if (Physics.Raycast(myRay, out hit, rayLength))
            {
                if (hit.collider.tag == "Wall")
                {
                    return false;
                }
            }
            return true;
        }


    }
}
