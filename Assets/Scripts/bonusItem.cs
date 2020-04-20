﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bonusItem : MonoBehaviour
{   
    [SerializeField]
    private Vector2[] directions;
    private Collider2D itemCollider;
    private Rigidbody2D rb;
    private Transform player;
    [SerializeField]
    [Range(0, 1)]
    private float speed;
    private int randomSpawnRange;
    [SerializeField]
    private Vector2 _direction;

    private bool dirChange;

    public GameObject healEffect;

    // Start is called before the first frame update
    void Start()
    {
        dirChange = false;
        itemCollider = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Astronaut").transform;
        transform.position = RespawnPointsList.respawnMethod();
        randomSpawnRange = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        //   StartCoroutine(changeDirection());
        _direction = (directions[randomSpawnRange] - rb.position);
        rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Astronaut"))
        {
            Instantiate(healEffect, transform.position, Quaternion.identity);

            planet.healthAmount += 15;
            Destroy(gameObject);

        }else if(collision.tag.Equals("bullet Astronaut"))
        {

            Instantiate(healEffect, transform.position, Quaternion.identity);

            planet.healthAmount += 15;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

  //  IEnumerator changeDirection()
  //  {   
  //      if(dirChange == true) 
  //      { 
  //      _direction = player.position;
  //      rb.MovePosition(rb.position - _direction * speed * Time.fixedDeltaTime);
  //          yield return new WaitForSeconds(10f);
  //          dirChange = false;
  //      }
  //      else if(dirChange == false)
  //      {
  //          _direction = (directions[randomSpawnRange] - rb.position);
  //          rb.MovePosition(rb.position + _direction * speed * Time.fixedDeltaTime);
  //      }
  //  }

}
