using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientalMusicScript : MonoBehaviour {

    public AudioSource ambiental;

    void Awake()
    {
        AudioManager.PlayAmbientalSound(ambiental);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
