using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyHunting_World : MonoBehaviour
{
    public GameObject[] _citizens;

    // Start is called before the first frame update
    void Start()
    {
        _citizens = GameObject.FindGameObjectsWithTag("Citizen");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Freeze()
    {
        foreach (GameObject citizen in _citizens)
        {
            //stops citizen
            citizen.GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }
}
