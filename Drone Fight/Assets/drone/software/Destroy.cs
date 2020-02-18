using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float timeLeft;

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,1.5f);
    }
}
