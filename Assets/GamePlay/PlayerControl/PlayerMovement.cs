using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerMovementSpeed;
    public float jumpHeight;
    public float distanceToGround;
    public float minTimeBetweenJumps;
    public bool isSprinting = false;
    public float sprintModifier = 2f;

    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    // Use this for initialization

    //KeyCode mapping
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode forwardKey = KeyCode.W;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode backKey = KeyCode.S;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode jumpKey = KeyCode.Space;

    new Rigidbody rigidbody;
    private float lastJump=0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // Make the rigid body not change rotation
        if (rigidbody)
        {
            rigidbody.freezeRotation = true;
        }
    }   

    void Update()
    {
        Move();
        Rotate();
        if(Input.GetKeyDown(sprintKey))
        {
            isSprinting = true;
        }
        if(Input.GetKeyUp(sprintKey))
        {
            isSprinting = false;
        }

    }
    bool canJump()
    {
        return Physics.Raycast(transform.position, -Vector3.up,distanceToGround) && (lastJump + minTimeBetweenJumps) < Time.time;
        
    }

    void Move()
     {
         Vector3 movement = new Vector3();
        if (Input.GetKey(forwardKey))
        {
             movement += Camera.main.transform.forward;
        }
        if (Input.GetKey(leftKey))
        {
             movement -= transform.right;
        }
        if (Input.GetKey(backKey))
        {
             movement -= Camera.main.transform.forward;
        }
        if (Input.GetKey(rightKey))
        {
            movement += transform.right;
        }

        if (Input.GetKey(jumpKey)&&canJump())
        {
            Jump();

        }
        movement.y = 0;
        movement.Normalize();
        if(isSprinting)
        {
            movement *= sprintModifier;
        }
        transform.Translate(movement * playerMovementSpeed * Time.deltaTime,Space.World);

     }
    void Jump()
    {
        rigidbody.AddForce(Vector3.up*jumpHeight, ForceMode.Impulse);
        lastJump = Time.time;
    }

    void Rotate()
    {
        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
    }

   
}
