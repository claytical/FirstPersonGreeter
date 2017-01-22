using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalkerSpawner : MonoBehaviour {
    public Transform[] startLocations;
    public Transform[] endLocations;
    private GameObject targetedWalker;
    public GameObject walkerPrefab;
    public Greeter greeter;
    public float timeBetweenSpawns;
    private float timer = 0f;
	// Use this for initialization
	void Start () {
    }
	
    public void Waved()
    {
        if(targetedWalker)
        {
            targetedWalker.GetComponentInChildren<Animator>().SetInteger("effort", greeter.effort);
            targetedWalker.GetComponentInChildren<Animator>().SetInteger("distance", greeter.distance);
            targetedWalker.GetComponentInChildren<Animator>().SetTrigger("wave");
            targetedWalker.GetComponent<Walker>().Satisified();

            greeter.SetIdle();
        }

    }
    public void SetTargetedWalker(GameObject obj)
    {
        targetedWalker = obj;
        greeter.StartGaugingEffort(obj.transform.position);
    }
    public void ClearCubes()
    {
        foreach (Transform child in transform)
        {
            Walker w = child.GetComponent<Walker>();
            w.Disengage();
        }
    }
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > timeBetweenSpawns)
        {
            timer = 0f;
            Spawn();    
        }
    }

    void Spawn()
    {
        int sl = Random.Range(0, startLocations.Length);
        int el = Random.Range(0, endLocations.Length);
        Vector3 pos = startLocations[sl].position;
        GameObject walker = (GameObject)Instantiate(walkerPrefab, pos, walkerPrefab.transform.rotation);
        walker.GetComponent<Walker>().target = endLocations[el];
        walker.transform.parent = transform;
    }
}
