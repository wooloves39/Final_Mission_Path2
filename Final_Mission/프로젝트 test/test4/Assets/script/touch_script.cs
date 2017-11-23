using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_script : MonoBehaviour {

    public OVRInput.Controller controller;
	// Update is called once per frame
	void Update () {
        transform.localPosition = OVRInput.GetLocalControllerPosition(controller);
        transform.localRotation= OVRInput.GetLocalControllerRotation(controller);
       }
}
