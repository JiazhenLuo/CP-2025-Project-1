using System.IO.Ports;
using UnityEngine;
using System.Threading;

public class testUno : MonoBehaviour
{
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";
    //private static string outgoingMsg = "";

    public static testUno Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private static void DataThread()
    {
        //Mac - /dev/cu.usbmodem1101
        //PC - COM
        sp = new SerialPort("/dev/cu.usbmodem1101", 9600);
        sp.Open();

        while (true)
        {
            incomingMsg = sp.ReadExisting();
            Thread.Sleep(200);
        }
    }

    private void OnDestory()
    {
        IOThread.Abort();
        sp.Close();
    }

    void Start()
    {
        IOThread.Start();
    }

    void Update()
    {
        Debug.Log(incomingMsg);
    }
}
