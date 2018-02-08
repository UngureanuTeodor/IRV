using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollect : MonoBehaviour {

    public AudioSource collect;

	// Use this for initialization
	void Start () {
        collect = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Collider[] hitColliders = Physics.OverlapSphere(this.transform.position, 1);
            for (int i = 0; i < hitColliders.Length; i++)
            {
                Debug.Log(hitColliders[i].gameObject.tag);
                if (hitColliders[i].gameObject.tag == "Player")
                {
                    collect.Play();
                    hitColliders[i].GetComponent<PlayerHealth>().collectStick();
                    StartCoroutine(DestroyStick());
                }
            }
        }
	}

    IEnumerator DestroyStick()
    {
        while (collect.isPlaying)
        {
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
