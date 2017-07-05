﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBall : MonoBehaviour {

    GameObject hitEffect;
    public int attackPoint;
    public float speed;
    public bool IsAlive;


    private void Awake()
    {
        IsAlive = true;
        StartCoroutine(Move());
    }

    // Use this for initialization
    void Start () {
        hitEffect = gameObject.transform.FindChild("WaterBall_hit").gameObject;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    
    IEnumerator Move()
    {
        while (IsAlive)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            yield return null;
        }
    }

    //무언가와 부딪혔다.
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            hitEffect.SetActive(true);
            Destroy(hitEffect, 2f);
            gameObject.SetActive(false);
            Destroy(gameObject.transform.GetChild(0).gameObject);
            transform.DetachChildren();
            Destroy(gameObject);


            Player_damaged.Instance.Damaged(attackPoint);
        }
    }
}