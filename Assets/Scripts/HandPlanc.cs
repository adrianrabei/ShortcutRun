using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPlanc : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private EnemyMovement enemy1;
    [SerializeField] private EnemyMovement enemy2;
    [SerializeField] private EnemyMovement enemy3;
    [SerializeField] private EnemyMovement enemy4;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        enemy1 = FindObjectOfType<EnemyMovement>();
        enemy2 = FindObjectOfType<EnemyMovement>();
        enemy3 = FindObjectOfType<EnemyMovement>();
        enemy4 = FindObjectOfType<EnemyMovement>();
    }
    
    void FixedUpdate()
    {
        if(player.destroyHandPlanc)
        {
            if(Vector3.Distance(gameObject.transform.position, player.handPlancPos.transform.position) < 0.03f)
            {
                DestroyPlanc();
                player.destroyHandPlanc = false;
                player.handPlancPos.transform.position = new Vector3(player.handPlancPos.transform.position.x, player.handPlancPos.transform.position.y - 0.05f, player.handPlancPos.transform.position.z);
            }
        }

        if (enemy1.destroyHandPlanc)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy1.handPlancPos.transform.position) < 0.03f)
            {
                DestroyPlanc();
                enemy1.destroyHandPlanc = false;
                enemy1.handPlancPos.transform.position = new Vector3(enemy1.handPlancPos.transform.position.x, enemy1.handPlancPos.transform.position.y - 0.05f, enemy1.handPlancPos.transform.position.z);
            }
        }

        if (enemy2.destroyHandPlanc)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy2.handPlancPos.transform.position) < 0.03f)
            {
                DestroyPlanc();
                enemy2.destroyHandPlanc = false;
                enemy2.handPlancPos.transform.position = new Vector3(enemy2.handPlancPos.transform.position.x, enemy2.handPlancPos.transform.position.y - 0.05f, enemy2.handPlancPos.transform.position.z);
            }
        }

        if (enemy3.destroyHandPlanc)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy3.handPlancPos.transform.position) < 0.03f)
            {
                DestroyPlanc();
                enemy3.destroyHandPlanc = false;
                enemy3.handPlancPos.transform.position = new Vector3(enemy3.handPlancPos.transform.position.x, enemy3.handPlancPos.transform.position.y - 0.05f, enemy3.handPlancPos.transform.position.z);
            }
        }

        if (enemy4.destroyHandPlanc)
        {
            if (Vector3.Distance(gameObject.transform.position, enemy4.handPlancPos.transform.position) < 0.03f)
            {
                DestroyPlanc();
                enemy4.destroyHandPlanc = false;
                enemy4.handPlancPos.transform.position = new Vector3(enemy4.handPlancPos.transform.position.x, enemy4.handPlancPos.transform.position.y - 0.05f, enemy4.handPlancPos.transform.position.z);
            }
        }
    }

    private void DestroyPlanc()
    {
        Destroy(gameObject);
    }
}
