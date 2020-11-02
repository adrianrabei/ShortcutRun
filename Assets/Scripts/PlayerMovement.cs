using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody player;
    [SerializeField] private Camera cam;
    [SerializeField] private float moveSpeed = 10f, jumpForce = 10f;
    [SerializeField] private GameObject plancPrefab;
    [SerializeField] private int plancCount;
    [SerializeField] private GameObject plancPos;
    private bool canSpawn, canJump, isPlanc, isFirstPlanc, jumped, onGround, onPlanc;
    private RaycastHit hit;
    [SerializeField] private GameObject rayOriginPos;
    private float plancDistance;
    private GameObject currentPlancPos;

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

    private void Update()
    {
        if(onGround || onPlanc)
        {
            GroundCheck();
        }
    }



    private void GroundCheck()
    {
        if (Physics.Raycast(rayOriginPos.transform.position, Vector3.down, out hit) && hit.transform.tag == "Ground" || hit.transform != null && hit.transform.tag == "Planc")
        {
           
        }
        else
        {
            if (plancCount != 0)
            {
                if (!isFirstPlanc)
                {
                    SetPlanc();
                    isFirstPlanc = true;
                    return;
                }
                if (isFirstPlanc)
                {
                    plancDistance = Vector3.Distance(currentPlancPos.transform.position, plancPos.transform.position);
                    if (plancDistance > 1)
                    {
                        SetPlanc();
                    }
                }
            }
            else Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            onGround = true;
        }
        if(collision.transform.tag == "Planc")
        {
            onPlanc = true;
        }
    }

    public void GravityAmplification()
    {
        if(player.velocity.y < 0)
        {
            Physics.gravity = new Vector3(0, -15, 0);
        }
    }

    private void SetPlanc()
    {
        if (plancCount != 0)
        {
            currentPlancPos = Instantiate(plancPrefab, plancPos.transform.position, plancPos.transform.rotation);
            plancCount--;
        }
    }

    private void Jump()
    {
        Debug.Log("JUMP");
        player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        GravityAmplification();
        onGround = false;
        onPlanc = false;
    }

}
