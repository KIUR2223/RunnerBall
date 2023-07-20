using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    //zoos ergelt
    void Update()
    {
        transform.Rotate(30 * Time.deltaTime, 0, 0);
    }

    //zoos dairah bolgond 1eer nemeh
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 1;
            
            Destroy(gameObject); 
        }
    }
}
