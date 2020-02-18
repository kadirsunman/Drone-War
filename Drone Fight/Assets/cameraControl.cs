using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        Camera.main.projectionMatrix = Matrix4x4.Ortho(-5.5f * 1.6f, 5.5f * 1.6f, -4.0f, 5f, 0.3f, 1000f);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
