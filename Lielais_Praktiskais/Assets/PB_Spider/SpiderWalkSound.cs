using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalkSound : MonoBehaviour {
    public AudioClip footStep;
    public AudioSource audioS;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void FootStep()
    {
        audioS.PlayOneShot(footStep);
    }

    void Stop()
    {
        audioS.Stop();
    }
}
