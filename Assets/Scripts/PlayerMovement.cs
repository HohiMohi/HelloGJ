using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, 90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 270, 0),
    currentDirection = Vector3.zero;

    Vector3 nextPos, destination, direction;

    public Animator anim;
    float speed = 5f;
    float rayLength = 1f;

    bool canMove;
    bool hasMovedAnim;

    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;
    }

    void Update()
    {
        hasMovedAnim = false;
        
        Move();

       
      
        anim.SetBool("hasMovedAnim", hasMovedAnim);
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed *Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            nextPos = Vector3.forward;
            currentDirection = up;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            nextPos = Vector3.back;
            currentDirection = down;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            nextPos = Vector3.left;
            currentDirection = left;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            nextPos = Vector3.right;
            currentDirection = right;
            canMove = true;
        }

        if (Vector3.Distance(destination, transform.position) <= 0.00001f)
        {
            transform.localEulerAngles = currentDirection;
            if(canMove)
            {
                if(Valid())
                {
                    destination = transform.position + nextPos;
                    direction = nextPos;
                    canMove = false;
                    hasMovedAnim = true;
                }
                
            }
        }
    }

    bool Valid()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.25f, 0), transform.forward);
        RaycastHit hit;

        Debug.DrawRay(myRay.origin, myRay.direction, Color.red);

        if(Physics.Raycast(myRay, out hit, rayLength))
        {
            if(hit.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }
}
