using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag=="Enemy")
        {
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.currentHP -= 1*Time.deltaTime;
            Debug.Log("Hacer da�o");
            //enemy.Die();
        }
    }
}
