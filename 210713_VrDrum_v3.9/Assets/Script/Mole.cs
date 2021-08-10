using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
//using System.Security.Cryptography;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //Variables
    public float visibleY = 2.0f;
    public float hiddenY= -1.5f;
    public float visibleX= 2.0f;
    public float hiddenX = -1.5f;

    public float VisibleScale = 0.08f;

    private Vector3 myNewXYZPosition;
    private Vector3 myNewXYZScale;

    public float Molespeed = 10f;
    
    //Mole Created
    void Awake()
    {
        HideMole();

        transform.localPosition= myNewXYZPosition;
        transform.localScale = myNewXYZScale;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Move mole to new XYZ
        MoveMole();
    }
    
    public bool OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HideMole();
            PlaySound();
            return true;
        }
        return false;
    }
    void OnTriggerEnter(Collider other)
    {
        HideMole();
        //GetComponent<AudioSource>().Play();
        GetComponent<ParticleSystem>().Play();
        //GameObject.FindWithTag("GE").GetComponent<IMU_Control>().vibrate();      
    }
    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void MoveMole()
    {
        //Move mole to new XYZ
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            myNewXYZPosition,
            Time.deltaTime * Molespeed);

        transform.localScale = Vector3.Lerp(
            transform.localScale,
            myNewXYZScale,
            Time.deltaTime * Molespeed);
    }

    public void HideMole()
    {
        myNewXYZPosition = new Vector3(
                hiddenX,
                hiddenY,
                transform.localPosition.z
            );
        myNewXYZScale= new Vector3(0,0,0);
    }

    public void ShowMole()
    {
        myNewXYZPosition = new Vector3(
                hiddenX,
                visibleY,
                transform.localPosition.z
                );
        myNewXYZScale = new Vector3(VisibleScale, VisibleScale, VisibleScale);
    }
}
