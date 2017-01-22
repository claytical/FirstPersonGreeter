using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibe : MonoBehaviour
{
    private float speed;

    // Use this for initialization
    void Start()
    {
        //        GetComponent<Rigidbody>().velocity = Vector3.forward;	
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.parent.GetComponent<Greeter>().gaze.transform.forward;

        if (transform.position.z > 100)
        {
            Destroy(gameObject);
        }
    }
}