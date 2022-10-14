using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveRB : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 3.0f;


    private float horizontalInput;
    private float forwardInput;

    Rigidbody rigidbody => GetComponent<Rigidbody>();


    void Update()
    {
        TakeInput();
        Move();
    }


    void TakeInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");  // -1 =left ,0 = no motion ,1 = right
        forwardInput = Input.GetAxis("Vertical");       // -1 =back ,0 = no motion ,1 = forward
    }

    void Move()
    {
        Vector3 dir = transform.forward; // My Forward

        Vector3 motion = dir * moveSpeed * forwardInput * Time.deltaTime;
        Vector3 rotation = new Vector3(0, horizontalInput * rotateSpeed, 0);

        Vector3 movePos = transform.position + motion;

        rigidbody.MovePosition(movePos);
        transform.rotation = Quaternion.Euler(transform.eulerAngles + rotation);
    }
}
