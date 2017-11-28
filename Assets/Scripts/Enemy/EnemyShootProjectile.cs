using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootProjectile : MonoBehaviour
{
    public float aggroRange = 20.0f;
    public float startFire = 1.0f;
    public float rateOfFire = 3.0f;
    public GameObject projectile;
    public GameObject player;
    private bool shooting;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        shooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        var distToPlayer = Vector3.Distance(player.transform.position, transform.position);
        //if player is within aggro range and enemy NOT currently shooting
        if (distToPlayer <= aggroRange)
        {
            if (!shooting)
            {
                //start shooting
                InvokeRepeating("Shoot", startFire, rateOfFire);
                shooting = true;
            }
        }
        //if player is outside range and enemy is shooting
        else if (shooting)
        {
            //stop shooting
            CancelInvoke("Shoot");
            shooting = false;
        }
    }

    void Shoot()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
