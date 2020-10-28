using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] private Camera cam;
    [SerializeField] private float moveSpeed = 10f;
    
    void Start()
    {
        player = GetComponent<Rigidbody>();
        
        
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            float rotationSpeed = Input.GetAxis("Mouse X") * 5f;
            transform.RotateAround(transform.position, Vector3.up, rotationSpeed);
        }

    }

}
