using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float coinC = 0f;

    public GameObject enemy;

    public EnemyDemo enemyManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // this will use the mouse to test 'clicking' on enemies to reduce health
        // in order to kill an enemy you will have to decrease the health down to zero with clickes making 15 damgage per click

        if (Input.GetMouseButtonDown(0))
        {

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out  RaycastHit hit))
            {
                BoxCollider bc = hit.collider as BoxCollider;

                if (bc.name == "Enemy")
                {
                   
                    Debug.Log("Enemies Current health: " +enemyManager.Health); 
                    //reduces the health by one tick
                    enemyManager.Health -= 1;

                    if (enemyManager.Health < 0 )
                    {
                        Destroy(bc.gameObject);
                        coinCounter();
                    }
                    
                }
            }

        }

    }

    void coinCounter()
    {
        // if this method gets called then we know a coin will be added b/c a enemy has been killed.
        coinC++;
        Debug.Log("Coin: " + coinC);
        
    }
}
