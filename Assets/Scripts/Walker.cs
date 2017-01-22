using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour {

    public Transform target;
    public float speed = 1.0f;
    public GameObject marker;
   
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if(speed < 1)
        {
            speed += .0001f;
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

    public void Satisified()
    {
        GetComponent<CapsuleCollider>().enabled = false;
        speed = .0f;
        marker.SetActive(false);
    }
    public void Disengage()
    {
        marker.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player"))
        {
            Destroy(other.gameObject);
            GetComponentInParent<WalkerSpawner>().ClearCubes();
            GetComponentInParent<WalkerSpawner>().SetTargetedWalker(gameObject);
            marker.SetActive(true);
           
        }
    }

}
