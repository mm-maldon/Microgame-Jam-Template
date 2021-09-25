using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyHunting_Crosshair : MonoBehaviour
{
    public float _speed = 1;
    public GameObject _world;

    // Start is called before the first frame update
    void Start()
    {
        _world = GameObject.Find("HappyHunting_World");
        
    }

    // Update is called once per frame
    void Update()
    {
        //moves the crosshair
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 finalPos = transform.position + direction;
        transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * _speed);

        //keeps in the boundary
        if (transform.position.x < -9f)
        {
            transform.position = new Vector3(-9f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9f)
        {
            transform.position = new Vector3(9f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, transform.position.z);
        }
        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HappyHunting_Citizen citizen = collision.gameObject.GetComponent<HappyHunting_Citizen>();
        if (citizen._target)
        {

        }
    }
}
