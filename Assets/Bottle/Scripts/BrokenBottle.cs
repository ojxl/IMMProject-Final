using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBottle : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;
    [SerializeField] float velMultiplier = 1.5f;
    [SerializeField] float timeBeforeDestroying = 60f;

    void Start()
    {
        Destroy(this.gameObject, timeBeforeDestroying);
    }
    
    public void RandomVelocities()
    {
        for(int i = 0; i <= pieces.Length - 1; i++)
        {
            float xVel = Random.Range(0.2f, 1f);
            float yVel = Random.Range(0.2f, 1f);
            float zVel = Random.Range(0.2f, 1f);
            Vector3 vel = new Vector3(velMultiplier * xVel, velMultiplier * yVel, velMultiplier * zVel);
            pieces[i].GetComponent<Rigidbody>().velocity = vel;
        }
    }
}