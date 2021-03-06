using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth

    private int health = 3;
    public float speed = 3f;
    public int coins = 3;

    //   waypoints

    public List<Transform> waypoints;
    public int targetWPIndex = 0;

    public int Health { get => health; set => health = value; }

    //   delegate event for outside code to subscribe and be notified of enemy death
    public delegate void EnemyDied(EnemyDemo deadEnemy);

    public event EnemyDied OnEnemyDied;

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint

        transform.position = waypoints[0].position;
        targetWPIndex++;
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        //this will be our movement section
        Vector3 targetPos = waypoints[targetWPIndex].position;

        // in order to get a vector with in 1
        Vector3 movementDir = (targetPos -transform.position).normalized;

        //next we need to change the direction for the enenmie object
        Vector3 newPosition = transform.position;
        newPosition += movementDir * speed * Time.deltaTime;

        transform.position = newPosition;


        // todo #4 Check if destination reaches or passed and change target
        // we will checkt to see if the targetPos is in the same spot as transform.position

       
        Vector3 forward = transform.TransformDirection(Vector3.forward);


        //if (Vector3.Dot(forward, movementDir) < 0)
        //{
        //    TargetNextWaypoint();
        //}
        float check = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetWPIndex].position, check);
        if ((transform.position - waypoints[targetWPIndex].position) == new Vector3(0,0,0))
        {
            TargetNextWaypoint();
        }



        bool enemyD = false;
        if (enemyD)
        {
            OnEnemyDied?.Invoke(this);
        }

        //Increment to the end of the list 
        //targetWPIndex++;
        
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
        targetWPIndex++;
    }



    
}
