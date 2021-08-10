using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.Linq;
using Leap;

public class quaternion : MonoBehaviour
{
    public GameObject DataReceiver;
    public string StickLR = null;

    private float x = 0f;
    private float y = 0f;
    private float z = 0f;
    private float w = 0f;

    Quaternion now;
    Quaternion past;

    float Start_Y = 0f;
    public float Dx = 0f;
    public float Dy = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartCal", 1f);
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        DataCopy();
        CalRotate(StickLR);
        Dx = transform.eulerAngles.x;
        Dy = transform.eulerAngles.y;
    }
    void DataCopy()
    {
        if (StickLR == "L") 
        {
            x = DataReceiver.GetComponent<LStickData>().x;
            y = DataReceiver.GetComponent<LStickData>().y;
            z = DataReceiver.GetComponent<LStickData>().z;
            w = DataReceiver.GetComponent<LStickData>().w;
        }
        if (StickLR == "R")
        {
            x = DataReceiver.GetComponent<RStickData>().x;
            y = DataReceiver.GetComponent<RStickData>().y;
            z = DataReceiver.GetComponent<RStickData>().z;
            w = DataReceiver.GetComponent<RStickData>().w;
        }
    }
    void StartCal()
    {
        Start_Y = transform.eulerAngles.y;
        if (Start_Y > 180)
            Start_Y = Start_Y - 180; //오일러 좌표 변환시 X축의 회전에 Y축의 값이 종속되는 문제 해결 
        //0<X<180 에서는 0<Y<180 이고 180<X<360 에서는 180<Y<360으로 표현됨
    }
    private void CalRotate(String StickLR)
    {
        now = new Quaternion(y, z, -x, -w);
        past = Quaternion.Euler(0, -Start_Y, 0);

        float ax = now[0] * past[0] - now[1] * past[1] - now[2] * past[2] - now[3] * past[3];
        float ay = now[0] * past[1] + now[1] * past[0] + now[2] * past[3] - now[3] * past[2];
        float az = now[0] * past[2] - now[1] * past[3] + now[2] * past[0] + now[3] * past[1];
        float aw = now[0] * past[3] + now[1] * past[2] - now[2] * past[1] + now[3] * past[0];
        transform.rotation = new Quaternion(ax, ay, az, aw);
        if (StickLR == "L")//왼쪽 스틱 수동 보정과 회전
        {
            Vector3 Pos_L = GameObject.FindWithTag("Hand_L").transform.position; //립모션의 손 좌표를 가져옴
            transform.position = Pos_L;
        }
        if (StickLR == "R")//오른쪽 스틱 수동 보정과 회전
        {
            Vector3 Pos_R = GameObject.FindWithTag("Hand_R").transform.position; //립모션의 손 좌표를 가져옴
            transform.position = Pos_R;
        }
    }

}

