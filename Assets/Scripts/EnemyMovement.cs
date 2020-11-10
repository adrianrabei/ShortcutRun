using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody enemy;
    [SerializeField] private Transform navTarget;
    [SerializeField] private float moveSpeed = 10f, jumpForce = 10f;
    [SerializeField] private GameObject plancPrefab;
    public int plancCount, handPlancCount = 0;
    public GameObject plancPos, handPlancPos;
    private bool isFirstPlanc, onGround, onPlanc;
    private RaycastHit hit;
    [SerializeField] private GameObject rayOriginPos;
    private float plancDistance;
    private GameObject currentPlancPos, currentHandPlanc;
    private Animator animator;
    public bool destroyHandPlanc;

    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        GetComponent<NavMeshAgent>().SetDestination(navTarget.position);
    }

    void FixedUpdate()
    {
        enemy.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void Update()
    {
        if (onGround || onPlanc)
        {
            GroundCheck();
            if (plancCount == 0)
            {
                animator.SetBool("isPlanc", false);
            }
        }
    }



    private void GroundCheck()
    {
        if (Physics.Raycast(rayOriginPos.transform.position, Vector3.down, out hit) && hit.transform.tag == "Ground" || hit.transform != null && hit.transform.tag == "Planc")
        {
            //ON GROUND
        }
        else
        {
            //FALLING
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
            else
            {
                Jump();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            onGround = true;
        }
        if (collision.transform.tag == "Planc")
        {
            onPlanc = true;
        }

        if (collision.transform.tag == "Pick")
        {
            plancCount++;
            Destroy(collision.gameObject);
            PlancHolding();
            animator.SetBool("isPlanc", true);
        }
    }

    public void GravityAmplification()
    {
        if (enemy.velocity.y < 0)
        {
            Physics.gravity = new Vector3(0, -17, 0);
        }
    }

    private void SetPlanc()
    {
        currentPlancPos = Instantiate(plancPrefab, plancPos.transform.position, Quaternion.identity);
        plancCount--;
        destroyHandPlanc = true;
    }

    private void Jump()
    {
        enemy.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("Jump");
        GravityAmplification();
        onGround = false;
        onPlanc = false;
    }

    private void PlancHolding()
    {
        handPlancPos.transform.position = new Vector3(handPlancPos.transform.position.x, handPlancPos.transform.position.y + 0.05f, handPlancPos.transform.position.z);
        currentHandPlanc = Instantiate(plancPrefab, handPlancPos.transform.position, transform.rotation);
        currentHandPlanc.transform.parent = gameObject.transform;
    }

}