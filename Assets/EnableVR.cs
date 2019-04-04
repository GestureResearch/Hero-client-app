using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnableVR : MonoBehaviour {

	// Use this for initialization
	void Start () {

        StartCoroutine(LoadDevice("cardboard"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator LoadDevice(string newDevice)
    {
        XRSettings.LoadDeviceByName(newDevice);
        yield return null;

        XRSettings.enabled = true;
    }
}
