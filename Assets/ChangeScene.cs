using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ChangeScene : MonoBehaviour {


    public int SceneNum = 1;
	// Use this for initialization
	void Start () {
       XRSettings.enabled = false;
	}
	
    public void ChangeSceneTo()
    {
        SceneManager.LoadScene(SceneNum);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
