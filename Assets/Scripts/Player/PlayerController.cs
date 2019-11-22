using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Rigidbody _myBody;
    // Start is called before the first frame update
    void Start()
    {
        _myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovementWithKeyBoard();
        ChangeRotation();
    }

    void FixedUpdate()
    {
        MoveTank();
    }

    void MoveTank()
    {
        _myBody.MovePosition(_myBody.position + speed * Time.deltaTime);
    }

    void ControlMovementWithKeyBoard()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            MoveFast();
        }

        if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            MoveSlow();
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            MoveStraight();
        }

        if(Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            MoveStraight();
        }

        if(Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W))
        {
            MoveNormal();
        }

        if(Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S))
        {
            MoveNormal();
        }
    }

    void ChangeRotation()
    {
        if(speed.x > 0)
        {
            // Spherically rotate from current rotation to target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }

        else if(speed.x < 0)
        {
            // Spherically rotate from current rotation to target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, -maxAngle, 0f), Time.deltaTime * rotationSpeed);
        }

        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * rotationSpeed);
        }
    }
}
