using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System;
using System.Globalization;
using System.Linq;


public class LStickData : MonoBehaviour
{
    SerialPort stream;
    Thread myThread;
    public string nPort;

    public float x = 0f;
    public float y = 0f;
    public float z = 0f;
    public float w = 0f;

    void Start()
    {
        stream = new SerialPort(nPort, 115200, Parity.None, 8, StopBits.One);
        stream.Open();
        myThread = new Thread(new ThreadStart(GetData));
        myThread.Start();
        vibrate();
    }


    private void GetData()
    {
        try
        {
            while (myThread.IsAlive)
            {
                string value = stream.ReadLine();
                separateData(value);
                printVector();
            }
        }
        catch (Exception e)
        {

        }
    }
    private void separateData(string data)
    {
        char[] sep = { '*', ',' };
        string[] tmp = data.Split(sep, StringSplitOptions.RemoveEmptyEntries);

        z = float.Parse(tmp[0]);
        y = float.Parse(tmp[1]);
        x = float.Parse(tmp[2]);
        w = float.Parse(tmp[3]);

        // Quaternion => "*,z,y,x,w"
    }
    private void printVector()
    {
        Debug.Log("(x, y, z, w) = (" + string.Format("{0:0.##}", x) + ", "
                                           + string.Format("{0:0.##}", y) + ", "
                                           + string.Format("{0:0.##}", z) + ", "
                                           + string.Format("{0:0.##}", w) + ")");
    }
    public void SendHexLine(string line)
    {
        string str = line;
        byte[] bytes;

        bytes = str.Split(' ').Select(h => byte.Parse(h, NumberStyles.AllowHexSpecifier)).ToArray();
        stream.Write(bytes, 0, bytes.Length);
    }
    public void vibrate()
    {
        SendHexLine("55 51 00 00 00 00 00 54");
    }
    public void vibrate(int num)
    {
        if (num == 0) //Ride
            SendHexLine("55 51 82 32 03 00 00 54");
        if (num == 1) //Bass
            SendHexLine("55 51 42 00 00 32 02 54");
        if (num == 2) //Hihat
            SendHexLine("55 51 82 32 03 00 00 54");
        if (num == 3) //Snare
            SendHexLine("55 51 42 00 00 32 02 54");
        if (num == 4) //Crash
            SendHexLine("55 51 82 32 03 00 00 54");
        if (num == 5) //FloorTom
            SendHexLine("55 51 42 00 00 32 02 54");
        if (num == 6) //MidTom
            SendHexLine("55 51 42 00 00 32 02 54");
        if (num == 7) //SmallTom
            SendHexLine("55 51 42 00 00 32 02 54");
    }
    void OnApplicationQuit()
    {
        SendHexLine("55 52 00 00 00 00 00 54");//종료시 블루투스 연결을 중단시킵니다.
        stream.Close();
    }

}
