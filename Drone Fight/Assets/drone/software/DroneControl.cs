using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DroneControl : MonoBehaviour
{
    Joystick[] joystick;
    Joystick moveJoystick;

    private fireDynamicJoystick fireDynamicScript;

    public GameObject gunFire;
    public ParticleSystem fireParticle;

    public float speed = 5;
    public float h_State,v_State ,h_Fire,v_Fire;
    public float rotationSpeed = 2.0f;

    public GameObject missiles;
    public GameObject RotorLeft;
    public GameObject RotorRight;
    public GameObject drone;
    public Text xPosition,yPosition,digerBilgi;

    GameObject createdMissiles;
    float angle;
    int sarjor = 0, gecenSure;
    bool infoDown, infoFire;
    int reloadCoolDown = 0;
    bool reloadAmmoState = false;

    public GameObject droneMoveLeftLimit, droneMoveRightLimit, droneMoveUpLimit;


    //konuşma


    void Start()
    {
        joystick = GameObject.Find("Canvas").GetComponentsInChildren<Joystick>();
        moveJoystick = joystick[0];
        xPosition = GameObject.Find("Canvas").GetComponentsInChildren<Text>()[0];
        yPosition = GameObject.Find("Canvas").GetComponentsInChildren<Text>()[2];
        digerBilgi = GameObject.Find("Canvas").GetComponentsInChildren<Text>()[4];


    }

    // Update is called once per frame
    void Update()
    {
        fireDynamicScript = GameObject.FindWithTag("joystick").GetComponent<fireDynamicJoystick>();
        infoDown = fireDynamicScript.infoDown;
        infoFire = fireDynamicScript.infoFire;
        

    }   
    void FixedUpdate()
    {
        fire();
        
        if(reloadAmmoState == true)
        {
            reloadAmmo();
        }
        digerBilgi.text = (20-sarjor).ToString();
        droneControlFunction();
    }

    private void droneControlFunction()
    {
        //Rotor Rotation
        if (v_State == 0)
        {
            RotorLeft.transform.SetPositionAndRotation(RotorLeft.transform.position, new Quaternion(0f, 0f, 0f, 0f));
            RotorRight.transform.SetPositionAndRotation(RotorRight.transform.position, new Quaternion(0f, 0f, 0f, 0f));
            transform.Translate(0, -(speed / 1.5f) * Time.deltaTime, 0);
        }
        else
        {
            RotorLeft.transform.Rotate(0, 10000 * Time.deltaTime * speed, 0);
            RotorRight.transform.Rotate(0, 10000 * Time.deltaTime * speed, 0);
        }
        //Player Control  
        h_State = moveJoystick.Horizontal;
        v_State = moveJoystick.Vertical;
        xPosition.text = moveJoystick.Horizontal.ToString();
        yPosition.text = moveJoystick.Vertical.ToString();


        droneMoveLeftLimit = GameObject.FindGameObjectWithTag("gameAreaLeft");
        droneMoveRightLimit = GameObject.FindGameObjectWithTag("gameAreaRight");
        droneMoveUpLimit = GameObject.FindGameObjectWithTag("gameAreaUp");

        if ((droneMoveLeftLimit.transform.position.x < transform.position.x && h_State < 0) || (droneMoveRightLimit.transform.position.x > transform.position.x && h_State > 0))
        {
            transform.Translate(h_State * speed * Time.deltaTime, 0, 0);
        }
        if ((droneMoveUpLimit.transform.position.y > transform.position.y && v_State > 0) ||  v_State < 0)
        {
            transform.Translate(0, v_State * speed * Time.deltaTime, 0);
        }

        
    }


    public void fire()
    {

        GameObject fireJoystick = GameObject.FindWithTag("joystickHandle");
        

        Vector3 clickDirection =Camera.main.ScreenToWorldPoint(fireJoystick.transform.position);
        Vector2 direction = clickDirection - gunFire.transform.position;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        gunFire.transform.rotation = Quaternion.Slerp(gunFire.transform.rotation, rotation, speed * Time.deltaTime);
        if(infoDown == true)
        {
            if (sarjor < 20 && gecenSure % 10 == 0 && infoFire == true)
            {
                fireParticle.Play();
                createdMissiles = Instantiate(missiles,fireParticle.transform.position, Quaternion.Euler(0f, 0f, angle - 90f));
                sarjor++;

            }
            gecenSure++;
        }
        
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.tag == "reloadArea" && sarjor > 0 )
        {
            reloadAmmoState = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "reloadArea" && sarjor > 0)
        {
            reloadAmmoState = false;
        }
        Debug.Log(collision.gameObject.tag);
    }

    private void reloadAmmo()
    {
        if (reloadCoolDown % 10 == 0 && sarjor > -1)
        {
            sarjor = sarjor-1;
            reloadCoolDown = 0;
        }
        else if (sarjor ==0)
        {
            reloadAmmoState = false;
        }
        reloadCoolDown++;
    }


}
