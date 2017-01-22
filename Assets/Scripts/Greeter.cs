using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Greeter : MonoBehaviour {
    // Use this for initialization
    public GameObject vibe;
    public GameObject gaze;
    public WalkerSpawner spawner;
    public GameObject effortPanel;
    public bool vibing;
    public int effort = 0;
    public int distance = 0;
    private float timer = 0f;
    private float timeBetweenVibes = 1f;
    void Start()
    {
        vibing = false;
    }
    public void StartGaugingEffort(Vector3 position)
    {
        float d = Vector3.Distance(transform.position, position);
        if(d > 10)
        {
            distance = 2;
        }
        else if(d > 3)
        {
            distance = 1;
        }
        else
        {
            distance = 0;
        }
        vibing = true;
        effortPanel.SetActive(true);
    }

    void Vibe()
    {
//        vibing = true;
        GameObject v = (GameObject)Instantiate(vibe, transform.position, transform.parent.rotation);
        v.transform.parent = transform;

    }
    // Update is called once per frame

    void Update () {

        if(Input.GetButtonDown("Fire1"))
        {
            if(!vibing)
            {
                Vibe();
            }
            else if (vibing && effortPanel.activeSelf)
            {
                Wave();
                effortPanel.SetActive(false);
                vibing = false;
            }

        }


    }
    public bool canMove()
    {
        return !effortPanel.activeSelf;
    }

    public void SetIdle()
    {
        vibing = true;
    }
    void Wave()
    {
        Animator ani = gameObject.GetComponent<Animator>();
        ani.SetInteger("effort", effort);
        ani.SetInteger("distance", distance);
        ani.SetTrigger("wave");
        spawner.Waved();
//        gameObject.GetComponent<Animator>().SetTrigger("normal");
    }

    void QuickWave()
    {
        spawner.Waved();
        gameObject.GetComponent<Animator>().SetTrigger("quick");


    }

    void SadWave()
    {
        spawner.Waved();
        gameObject.GetComponent<Animator>().SetTrigger("sad");
    }
}
