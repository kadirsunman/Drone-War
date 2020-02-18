using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tire;
    void Start()
    {
        
    }
    public float speed = -1;
    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime, 0, 0);
        tire.transform.Rotate(0, 0 , -300 * Time.deltaTime * speed);
    }
}
