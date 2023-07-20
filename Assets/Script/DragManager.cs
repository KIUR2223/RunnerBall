using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragManager : MonoBehaviour
{
    public static bool tap, dragLeft, dragRight;
    private bool isDraging = false;
    private Vector2 startClick, dragDelta;

    private void Update()
    {
        tap = dragLeft = dragRight = false;
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            startClick = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            Reset();
        }
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startClick = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        //Calculate the distance
        dragDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length < 0)
                dragDelta = Input.touches[0].position - startClick;
            else if (Input.GetMouseButton(0))
                dragDelta = (Vector2)Input.mousePosition - startClick;
        }

        //Did we cross the distance?
        if (dragDelta.magnitude > 100)
        {
            //Which direction?
            float x = dragDelta.x;
            float y = dragDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left or Right
                if (x < 0)
                    dragLeft = true;
                else
                    dragRight = true;
            }

            Reset();
        }

    }

    private void Reset()
    {
        startClick = dragDelta = Vector2.zero;
        isDraging = false;
    }
}
