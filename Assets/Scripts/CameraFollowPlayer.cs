using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float cameraDistance = 20;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var max = Mathf.Max(player.transform.position.x, transform.position.x);
        transform.position = new Vector3(max, player.transform.position.y, player.transform.position.z - cameraDistance);
    }
}
