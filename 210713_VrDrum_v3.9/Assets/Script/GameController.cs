using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using System.IO;

public class GameController : MonoBehaviour
{
    public GameObject moleContainer;
    public GameObject DrumGuideContainer;
    public Mole[] moles;
    public DrumGuide[] drumRender;

    AudioClip Music1;
    TextAsset Text1;

    AudioClip Music2;
    TextAsset Text2;

    AudioClip Music3;
    TextAsset Text3;

    // Start is called before the first frame update
    void Start()
    {
        Music1 = Resources.Load("MUSIC/Music1") as AudioClip;
        Music2 = Resources.Load("MUSIC/Music2") as AudioClip;
        Music3 = Resources.Load("MUSIC/Music3") as AudioClip;

        Text1 = Resources.Load("TEXT/Text1") as TextAsset;
        Text2 = Resources.Load("TEXT/Text2") as TextAsset;
        Text3 = Resources.Load("TEXT/Text3") as TextAsset;    
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void MakeMole(int DrumNum, float DrumDelay, float MoleSpeed, float MoleDelay)
    {
        //드럼의 각 위치에 두더지들 생성
        //moles = moleContainer.GetComponentsInChildren<Mole>();
        //drumRender = DrumGuideContainer.GetComponentsInChildren<Renderer>();
        //MoleTest();
        /*###DrumNum###
         * 0=Ride
         * 1=Bass
         * 2=Hihat              ************************
         * 3=Snare              *  4               0   *
         * 4=Crash              *         6   7        *
         * 5=FloorTom           *           1          *
         * 6=MidTom             *    2  3       5      *
         * 7=SmallTom           ************************
         */
        //MakeMole( 드럼 번호,두더지가 올라오기 시작하는 시간, 두더지가 올라오는 속도, 두더지가 올라온 후 멈춰있는 시간)
        moles[DrumNum].Molespeed = MoleSpeed;
        drumRender[DrumNum].Invoke("FlashAct", DrumDelay);
        moles[DrumNum].Invoke("ShowMole", DrumDelay);
        moles[DrumNum].Invoke("HideMole", DrumDelay + MoleDelay);
        
    }
    public void MoleDestroy()
    {
        for (int i = 0; i < 8; i++)
        {
            moles[i].HideMole();
            moles[i].CancelInvoke();
            drumRender[i].CancelInvoke();
        }
    }
    public void BeClickEasyBtn()
    {
        Invoke("OnClickEasyBtn", 3.5f);
    }
    public void BeClickNormalBtn()
    {
        Invoke("OnClickNormalBtn", 3.5f);
    }
    public void BeClickHardBtn()
    {
        Invoke("OnClickHardBtn", 3.5f);
    }
    public void OnClickEasyBtn()
    {
        /*float Beat = 5.4544f;
        //0.34s per beat
        GetComponent<AudioSource>().Play();
        MakeMole(0, 4f, 1f, 4f);
        MakeMole(2, 4f+Beat, 1f, 4f);
        MakeMole(2, 4f + 2 * Beat, 1f, 4f);
        MakeMole(2, 4f + 3 * Beat, 1f, 4f);
        MakeMole(0, 4f + 4 * Beat, 1f, 4f);
        MakeMole(2, 4f + 5 * Beat, 1f, 4f);
        MakeMole(2, 4f + 6 * Beat, 1f, 4f);*/
        GetComponent<AudioSource>().PlayOneShot(Music1);
        TextLoad(1);
    }
    public void OnClickNormalBtn()
    {
        GetComponent<AudioSource>().PlayOneShot(Music2);
        TextLoad(2);
    }
    public void OnClickHardBtn()
    {
        GetComponent<AudioSource>().PlayOneShot(Music3);
        TextLoad(3);
    }
    public void Stop()
    {
        GetComponent<AudioSource>().Stop();
    }
    public void TextLoad(int mode)
    {
        int a; //DrumNum
        float b, c, d; //두더지가 나타나는 시간, 두더지의 속도, 두더지가 올라와 있는 시간
        StringReader reader=new StringReader(Text2.text);
        switch (mode)
        {
            case 1:
                reader = new StringReader(Text1.text);
                break;
            case 2 :
                reader = new StringReader(Text2.text);
                break;
            case 3:
                reader = new StringReader(Text3.text);
                break;
        }

        while(true)
        {
            string line = reader.ReadLine(); //한줄씩 읽어와서 파싱 
            if (line == null)
                break;
            string[] arr = line.Split(' ');
            a = int.Parse(arr[0]);
            b = float.Parse(arr[1]);
            c = float.Parse(arr[2]);
            d = float.Parse(arr[3]);
            MakeMole(a, b, c, d); //파싱 후 MakeMole 함수 동작
        }
    }
}
