using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public AudioClip collectSound;
    float rotationsPerMinute = 10;



    void Start()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
        
    }
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);

    }
    void OnTriggerEnter(Collider collider)
    {


        if (collider.gameObject.name == "FPSController")
        {
           
                CoinCount.coinCount++;
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
                DestroyObject(this.gameObject);






            
        }
    }

    
}