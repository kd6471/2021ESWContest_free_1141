using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCountDown : MonoBehaviour
{
    public GameObject Img1;
    public GameObject Img2;
    public GameObject Img3;
    public GameObject start;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void act1()
    {
        Img3.SetActive(true);
    }
    public void act2()
    {
        Img3.SetActive(false);
        Img2.SetActive(true);
    }
    public void act3()
    {
        Img2.SetActive(false);
        Img1.SetActive(true);
    }
    public void act4()
    {
        Img1.SetActive(false);
        start.SetActive(true);
    }
    public void act5()
    {
        start.SetActive(false);
    }
    public void countDown()
    {
        act1();
        Invoke("act2", 1f);
        Invoke("act3", 2f);
        Invoke("act4", 3f);
        Invoke("act5", 3.5f);
    }

}
