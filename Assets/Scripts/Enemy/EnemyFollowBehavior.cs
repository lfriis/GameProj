using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowBehavior : MonoBehaviour
{
    public float speed = 2.0f;
    public float aggroRange = 20.0f;
    public GameObject player;
    //private Vector3 startPos;

    // Use this for initialization
    void Start()
    {
        //startPos = transform.position;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //only move towards player if player enters a certain range
        var distToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distToPlayer <= aggroRange)
        {

            //move only along x axis
            Vector3 targetDirection = new Vector3(player.transform.position.x - transform.position.x, 0, 0);

            //move towards player position at a defined speed
            transform.position += targetDirection.normalized * speed * Time.deltaTime;

        }
    }
}
