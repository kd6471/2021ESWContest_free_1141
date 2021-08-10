using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnBack : MonoBehaviour
{
    

    public GameObject Enable1;
    public GameObject Enable2;
    public GameObject Disable1;
    public GameObject Disable2;
    public GameObject Disable3;
    public GameObject Disable4;
    public GameObject Disable5;
    public GameObject Disable6;
    public GameObject Disable7;
    public GameObject Disable8;
    public GameObject Disable9;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.B))
         {
            Enable1.SetActive(true);
            Enable2.SetActive(true);
            Disable1.SetActive(false);
            Disable2.SetActive(false);
            Disable3.SetActive(false);
            Disable4.SetActive(false);
            Disable5.SetActive(false);
            Disable6.SetActive(false);
            Disable7.SetActive(false);
            Disable8.SetActive(false);
            Disable9.SetActive(false);
           
            Invoke("Recall", 1f);
        } 
    }
    void OnTriggerEnter(Collider other)
    {
        Enable1.SetActive(true);
        Enable2.SetActive(true);
        Disable1.SetActive(false);
        Disable2.SetActive(false);
        Disable3.SetActive(false);
        Disable4.SetActive(false);
        Disable5.SetActive(false);
        Disable6.SetActive(false);
        Disable7.SetActive(false);
        Disable8.SetActive(false);
        Disable9.SetActive(false);

        Invoke("Recall", 1f);
    }

    void Recall()
    {
        Disable8.SetActive(true);
        Disable9.SetActive(true);
        GameObject.FindWithTag("GE").GetComponent<GameController>().MoleDestroy();
        GameObject.FindWithTag("GE").GetComponent<GameController>().Stop();
    }

}