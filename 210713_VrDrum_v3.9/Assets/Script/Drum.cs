using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Drum : MonoBehaviour
{
    public GameObject DataReceiver;
    public GameObject Collider;
    private MeshCollider[] trigger;
    public int ColNum;
    float waitSec = 0.5f;

    public void Start()
    {
        trigger = Collider.GetComponentsInChildren<MeshCollider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Stick_L")
        {
            GetComponent<AudioSource>().Play(); // 오디오 재생
            GetComponent<ParticleSystem>().Play();
            DataReceiver.GetComponent<LStickData>().vibrate(ColNum);
        }

        if (other.gameObject.tag == "Stick_R" )
        {
            GetComponent<AudioSource>().Play(); // 오디오 재생
            GetComponent<ParticleSystem>().Play();
            DataReceiver.GetComponent<RStickData>().vibrate(ColNum);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(waitSec);
        for (int i = 0; i < 8; i++)
        {
            trigger[i].isTrigger = true;
        }
    }
}