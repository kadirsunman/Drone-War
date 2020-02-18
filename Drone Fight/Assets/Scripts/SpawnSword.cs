using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnSword : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject swordMan;
    public GameObject boss;
    public GameObject drone;
    public GameObject missiles;
    GameObject createdDrone;
    GameObject createdMissiles;

    public float speed = -1;
    GameObject enemy;
    public int maxSword = 5;
    int swordRange = 0;
    bool timeResult = true;

    

    void Start()
    {
        createdDrone = Instantiate(drone, new Vector3(-6f, -0.05f, 0f), Quaternion.identity);
           
    }

    // Update is called once per frame
    void Update()
    {
        if (swordRange < maxSword && timeResult == true)
        {
            timeResult = false;
            StartCoroutine(example());
        }
        else if (swordRange == maxSword && timeResult == true)
        {
            timeResult = false;
            enemy = Instantiate(boss, new Vector3(-7.65f, -0.05f, 0f), Quaternion.identity);
        }
        else
        {

            StopCoroutine(example());
            
        }


        
    }

    IEnumerator example()
    {
        yield return new WaitForSeconds(2f);
        enemy =Instantiate(swordMan, new Vector3(11f, -2f, 0), Quaternion.identity);
        timeResult = true;
        swordRange++;
    }

}
