using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacles : MonoBehaviour
{
    public float moveSpeed = 1f;

    public float maxX = 11f;
    public float minX = -11f;
    
    void Update()
    {
        
        Vector3 curPos = gameObject.transform.localPosition;

        
        float currentX = curPos.x;

        if (currentX < minX)
        {
            currentX = maxX;
        }

        if (currentX > maxX)
        {
            currentX = minX;
        }

        
        gameObject.transform.localPosition = new Vector3(currentX + (moveSpeed * Time.deltaTime), curPos.y, curPos.z);
    }
}