using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yukidamage_movesnoball : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        float y = Input.GetAxis("Vertical");

        Vector2 dir = new Vector2(x, y);

        rb.velocity = dir * speed;
    }
}
