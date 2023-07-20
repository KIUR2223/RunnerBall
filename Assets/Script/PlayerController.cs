using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; //0:Left 1:middle 2:right
    public float laneDistance = 4; // hoyr egneenii hoorondoh zai

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        direction.z = forwardSpeed;

        if (DragManager.dragRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (DragManager.dragLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        //

        Vector3 targetposition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetposition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetposition += Vector3.right * laneDistance;
        }

        if (transform.position == targetposition)
            return;
        Vector3 diff = targetposition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else controller.Move(diff);
    }


    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            PlayerManager.gameOver = true;
        }

        if (hit.transform.tag == "NextLevel")
        {
            PlayerManager.nextLevel = true;
        }
    }   
}