using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BtnCal : MonoBehaviour
{
    public GameObject Button;
    //public GameObject Board;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Button.SetActive(false);
           // Board.SetActive(true);
            Invoke("Act", 3f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Button.SetActive(false);
        //Board.SetActive(true);
        Invoke("Act", 3f);
    }
    void Act()
    {
        SceneManager.LoadSceneAsync("VR_Drum");
    }
}
