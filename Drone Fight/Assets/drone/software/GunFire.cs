using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{

    private RaycastHit hit;
    public ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 10 * Time.deltaTime, 0);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.tag.ToString());
        if (collision.gameObject.tag =="Player")
        {
            Debug.Log("Drona Çarptı" + " - " + collision.gameObject.name);
           
        }
        if (collision.gameObject.tag == "terrain")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("Terraine Çarptı" + " - " + collision.gameObject.name);
            
            explosion.Play();

            Destroy(this.gameObject);
            explosion.Stop();
        }
        if (collision.gameObject.tag == "Respawn")
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("Terraine Çarptı" + " - " + collision.gameObject.name);

            explosion.Play();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            explosion.Stop();
        }
    }


}
