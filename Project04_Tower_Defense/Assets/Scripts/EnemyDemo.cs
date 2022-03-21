using System.Collections.Generic;
using UnityEngine;

public class EnemyDemo : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth

    public int health = 3;
    public float speed = 3f;
    public int coins = 3;

    //   waypoints

    public List<Transform> waypoints;
    //   delegate event for outside code to subscribe and be notified of enemy death

    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        //   Place our enemy at the starting waypoint
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        // todo #3 Move towards the next waypoint
        // todo #4 Check if destination reaches or passed and change target
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }
}
