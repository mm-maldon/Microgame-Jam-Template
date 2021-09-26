using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyHunting_Crosshair : MonoBehaviour
{
    public float _speed = 1;
    public float _cooldown = 0.5f;
    public GameObject[] _citizens;
    private bool _shot = false;
    private bool _found = false;
    private float _timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        _citizens = GameObject.FindGameObjectsWithTag("Citizen");
        int target = (int) Random.Range(0f, 5f);
        _citizens[target].GetComponent<HappyHunting_Citizen>()._target = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_shot)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                _shot = false;
            }
        }

        //moves the crosshair
        if (!_shot && !_found)
        {
            Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            Vector3 finalPos = transform.position + direction;
            transform.position = Vector3.Lerp(transform.position, finalPos, Time.deltaTime * _speed);
        }

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

        //taking the shot
        if (Input.GetKeyDown("space") && !_shot && !_found)
        {
            CheckForTarget();
            _timer = _cooldown;
            _shot = true;
        }

    }

    //finding out if the target was correct
    void CheckForTarget()
    {
        foreach (GameObject citizen in _citizens)
        {
            if (citizen.GetComponent<HappyHunting_Citizen>()._target)
            {
                if(Mathf.Abs(citizen.transform.position.x - transform.position.x) < 1.15f && Mathf.Abs(citizen.transform.position.y - transform.position.y) < 1.15f)
                {
                    Freeze();
                    _found = true;
                }
            }
        }
    }

    //stopping all citizens
    void Freeze()
    {
        foreach (GameObject citizen in _citizens)
        {
            //stops citizen
            citizen.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        }
    }
}
