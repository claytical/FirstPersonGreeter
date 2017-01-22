using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffortMeter : MonoBehaviour {
    public Greeter greeter;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetEffort(int e)
    {
        greeter.effort = e;
    }
}
