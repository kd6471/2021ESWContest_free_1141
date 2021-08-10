using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonAct : MonoBehaviour
{
    public string Act;
 
    public GameObject Button;
    public GameObject Button1;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Button4;

    // Start is called before the first frame update
    void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        if (Act == "Play")
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                Button.SetActive(false);
                Button1.SetActive(true);
                Button2.SetActive(true);
                Button3.SetActive(true);
                Button4.SetActive(true);
            }
        }

        if (Act == "Option")
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Button.SetActive(false);
                Button1.SetActive(true);
                Button2.SetActive(true);
                Button3.SetActive(true);
                Button4.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Button.SetActive(false);
        Button1.SetActive(true);
        Button2.SetActive(true);
        Button3.SetActive(true);
        Button4.SetActive(true);
    }
    

}
