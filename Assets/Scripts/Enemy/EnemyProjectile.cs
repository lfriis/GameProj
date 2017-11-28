using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float thrust = 2.0f;
    public float despawnRange = 200.0f;
    public GameObject player;


    private Rigidbody rb;
    private Vector3 heading;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        //get direction of travel to the player at instantiation
        heading = player.transform.position - transform.position;
        rb = GetComponent<Rigidbody>();
        rb.velocity = heading.normalized * thrust; //set constant velocity
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //despawn object if it exceeds a certain range from the player
        if (despawnRange < Vector3.Distance(player.transform.position, transform.position))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        //destroy projectile if it vollides with any object without an "Enemy..." tag
        //NOTE: Could probably be written better
        if (col.tag.Substring(0, 5) != "Enemy") Destroy(gameObject);
    }
}
