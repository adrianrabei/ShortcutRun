using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutController : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemy1;
    [SerializeField] private EnemyMovement enemy2;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void CheckShortcut()
    {
        if(enemy1.plancCount > 5 && enemy2.plancCount > 5)
        {

        }
    }
}
