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
        player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetMouseButton(0))
        {
            float rotationSpeed = Input.GetAxis("Mouse X") * 5f;
            player.transform.RotateAround(player.transform.position, Vector3.up, rotationSpeed);
        }

        

    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("No more contact with " + collision.transform.name);
        player.AddForce(Vector3.up * 5, ForceMode.Impulse);
        Falling();
    }

    public void Falling()
    {
        if(player.velocity.y < 0)
        {
            Physics.gravity = new Vector3(0, -15, 0);
        }
    }

}
