using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    public Transform prefab;
    public Vector3 position = new Vector3 (22f, 4f, 0f);
    public int platformsCreated = 15;
    public float xAxisMax = 6f;
    public float xAxisMin = 14f;
    public float yAxisMax = 2f;
    public float yAxisMin = 6f;

    void Start ()
    {

        RandomizeAxis();

        position = new Vector3(Random.Range(xAxisMin, xAxisMax), Random.Range(yAxisMin, yAxisMax), 0);

        Instantiate(prefab, position, Quaternion.identity);
        platformsCreated--;

        if (transform.IsChildOf(prefab))
        {
            Debug.Log("YES YES");
        }
    }

    void Update ()
    {


    }

    void RandomizeAxis()
    {
        xAxisMax += Random.Range(1f, 5f);
        xAxisMin += Random.Range(1f, 5f);
        yAxisMax += Random.Range(-5f, 5f);
        yAxisMin += Random.Range(-5f, 5f);
    }

    /*void createPlatform()
    {
        position = new Vector3(Random.Range(xAxisMin, xAxisMax), Random.Range(yAxisMin, yAxisMax), 0);

        Instantiate(prefab, prefab.position, Quaternion.identity);

        
    }*/
    
}
