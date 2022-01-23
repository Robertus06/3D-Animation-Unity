using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCameras : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera cam;
    public Camera camF;

    void Start()
    {
        cam.enabled = true;
        camF.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (cam.enabled == true)
            {
                cam.enabled = false;
                camF.enabled = true;
            }
            else
            {
                cam.enabled = true;
                camF.enabled = false;
            }
        }
    }
}
