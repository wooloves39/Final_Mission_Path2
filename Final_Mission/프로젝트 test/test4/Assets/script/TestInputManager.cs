using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInputManager : MonoBehaviour {

	// Use this for initialization
	// Update is called once per frame
	void Update () {

        //transform.Translate(InputManager_JHW.MainJoystick());

       // transform.Translate(Time.deltaTime * 1, 0, 0);
        if (!InputManager_JHW.AButton())
        {
            Debug.Log("dd");
        }
	}
}
