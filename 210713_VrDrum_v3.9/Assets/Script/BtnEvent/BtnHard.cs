﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnHard : MonoBehaviour
{
    public GameObject Button;
    public GameObject DrumNotice;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Button.SetActive(false);
            DrumNotice.SetActive(true);
            GameObject.FindWithTag("CountDown").GetComponent<GameCountDown>().countDown();
            GameObject.FindWithTag("GE").GetComponent<GameController>().OnClickHardBtn();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Button.SetActive(false);
        DrumNotice.SetActive(true);
        GameObject.FindWithTag("CountDown").GetComponent<GameCountDown>().countDown();
        GameObject.FindWithTag("GE").GetComponent<GameController>().OnClickHardBtn();
    }

}