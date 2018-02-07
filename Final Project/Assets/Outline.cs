using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour {

    public GameObject plane;

	// Use this for initialization
	void Start () {
        plane.GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collider)  
    {
        plane.GetComponent<Renderer>().enabled = true;
    }

    void OnTriggerExit(Collider collider)
    {
        plane.GetComponent<Renderer>().enabled = false;
    }
}
