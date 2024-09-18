using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveOffset = 1f;
    
    void Update()
    {
    float xOffset = 0;
    float zOffset = 0;

    bool hasMoved = false;

    if ((Input.GetKeyDown(KeyCode.A)) || Input.GetKeyDown(KeyCode.LeftArrow))
    {
        xOffset = -moveOffset;
        hasMoved = true;
    }
    if ((Input.GetKeyDown(KeyCode.D)) || Input.GetKeyDown(KeyCode.RightArrow))
    {
        xOffset = moveOffset;
        hasMoved = true;
    }
     if ((Input.GetKeyDown(KeyCode.W)) || Input.GetKeyDown(KeyCode.UpArrow))
    {
        zOffset = moveOffset;
        hasMoved = true;
    }
    if ((Input.GetKeyDown(KeyCode.S)) || Input.GetKeyDown(KeyCode.DownArrow))
    {
        zOffset = -moveOffset;
        hasMoved = true;
    }
    if (hasMoved == true)
    {
        Vector3 curPos = gameObject.transform.position;
        gameObject.transform.position = new Vector3(curPos.x + xOffset, curPos.y, curPos.z + zOffset);
    }
    }
}
