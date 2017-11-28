using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpike : MonoBehaviour {

    public bool dirPos = true;
    public float speed = 3.0f;
    public float range = 6.0f;
    private Vector3 startPos;

    // Use this for initialization
    void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dirPos)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        else
            transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (startPos.x - transform.position.x <= -range)
            dirPos = false;

        if (startPos.x - transform.position.x >= range)
            dirPos = true;
    }

}
