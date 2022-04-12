using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float coinC = 0f;

    public int coinsInPurse = 10;

    public GameObject enemy;

    public MobaEnemy enemyManager;

    public PlaceT towerPlacement;

    public GameObject UI_Root;


    // Start is called before the first frame update
    void Start()
    {
        towerPlacement = GetComponent<PlaceT>();
        Debug.Log("Begining coins " + coinsInPurse);
    }

    // Update is called once per frame
    void Update()
    {

        //updatePlace();

        // this will use the mouse to test 'clicking' on enemies to reduce health
        // in order to kill an enemy you will have to decrease the health down to zero with clickes making 15 damgage per click

        if (Input.GetMouseButtonDown(0))
        {

            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //BoxCollider bc = hit.collider as BoxCollider;

                if (hit.transform.tag == "Enemy_Nav_Mesh")
                {
                    hit.transform.GetComponent<MobaEnemy>().DamageHealthCal();

                    if (hit.transform.GetComponent<MobaEnemy>().Health <= 0)
                    {
                        coinCounter();
                        //current purse allawoence
                       Debug.Log("Pusre Contains: " + coinsInPurse);
                    }
                    /*
                    Debug.Log("Enemies Current health: " +enemyManager.Health); 
                    //reduces the health by one tick
                    enemyManager.Health -= 25;
                    //enemyManager.DamageHealthCal();

                    if (enemyManager.Health < 0 )
                    {
                        Destroy(bc.gameObject);
                        coinCounter();
                    }
                    */

                }
                
            }
            

        }

        if(Input.GetKeyDown(KeyCode.Q)){
            LoadScene("End_Game");
        }

        

    }

    void coinCounter()
    {
        // if this method gets called then we know a coin will be added b/c a enemy has been killed.
        coinC += 10;
        coinsInPurse += 10;
        
        
    }

    void updatePlace()
    {

        if (coinsInPurse > 0)
        {
            // then we cant place a tower down... there for we have to make a variable switch
            towerPlacement.setPlace(true);

        }
        else
        {
            towerPlacement.setPlace(false);
        }

    }

    public void LoadScene(string sceneName)
    {
        UI_Root.SetActive(false);
        SceneManager.LoadScene(sceneName);
    }
}
