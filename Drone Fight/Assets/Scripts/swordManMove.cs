using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordManMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = -1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
