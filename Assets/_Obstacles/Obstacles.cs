﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private int Hitpoints = 3;
    [SerializeField] private bool RandomRotation = false;
    public GameManager gamemanager;
    

    private void Start()
    {
        if(RandomRotation)
            transform.eulerAngles = new Vector3(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
        gamemanager = GetComponent<GameManager>();
      
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - ( 8 * 2 * Time.deltaTime));

        if(transform.position.z <= -8)
        {
           Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            
            GameManager.Lives -= 1;
            //Destroy(this.gameObject);
        }
        if(GameManager.Lives <= 0)
        {
            SceneManager.LoadScene("Gameover");
        }

        if(other.gameObject.tag == "addscore")
        {
            
            GameManager.Score += 1;
            print("add");
        }
    }
}
