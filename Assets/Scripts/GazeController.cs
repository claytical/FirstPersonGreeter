using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour {
    public Greeter greeter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (greeter.canMove())
        {
            transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal"), 0f));
        }
       }
}
