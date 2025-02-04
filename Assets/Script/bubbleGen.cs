using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using System.Threading;

public class bubbleGen : MonoBehaviour
{
    //Num Gen
    public int value;

    //Total num of students to choose from
    private List<int> totalAmount = new List<int>();

    //Bubble Colors
    public GameObject[] bubble;

    int messageInt;

    
    Thread IOThread = new Thread(DataThread);
    private static SerialPort sp;
    private static string incomingMsg = "";

    private static void DataThread()
    {
        //Mac - /dev/cu.usbmodem1101
        //PC - COM
        sp = new SerialPort("/dev/cu.usbmodem11301", 9600);
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

    private void Start()
    {
        //StartCoroutine(myCounter());
        IOThread.Start();
    }
    void Update()
    {
        messageInt = int.Parse(incomingMsg);
        Debug.Log(incomingMsg + " " + messageInt);

        //Note: make true or false instead of zero for new numbers
        if (messageInt == 1)
        {
            bad();
            incomingMsg = "0";
        }
        else if (messageInt == 2)
        {
            alright();
            incomingMsg = "0";
        }
        else if (messageInt == 3)
        {
            good();
            incomingMsg = "0";
        }
    }

    /*
    private IEnumerator myCounter()
    {
        if(totalAmount.Count > 0)
        {
            value = Random.Range(0, totalAmount.Count);
            //Debug.Log("Location on list " + value);
            int genThis = totalAmount[value];
            //Debug.Log("It's value is " + genThis);
            Vector3 randompawnPosition = new Vector3(Random.Range(-2f, 2f), -3.75f, Random.Range(-2f, 2f));
            Instantiate(bubble[genThis], randompawnPosition, Quaternion.identity);
        }
        yield return new WaitForSeconds(.5f);
        StartCoroutine(myCounter());
    }
    */

    void bad()
    {
        totalAmount.Add(0);
        textScript.Instnace.badNum++;

        int genThis = 0;
        Vector3 randompawnPosition = new Vector3(Random.Range(-2f, 2f), -3.75f, Random.Range(-2f, 2f));
        Instantiate(bubble[genThis], randompawnPosition, Quaternion.identity);
    }
    void alright()
    {
        totalAmount.Add(1);
        textScript.Instnace.alrNum++;

        int genThis = 1;
        Vector3 randompawnPosition = new Vector3(Random.Range(-2f, 2f), -3.75f, Random.Range(-2f, 2f));
        Instantiate(bubble[genThis], randompawnPosition, Quaternion.identity);
    }
    void good()
    {
        totalAmount.Add(2);
        textScript.Instnace.goodNum++;

        int genThis = 2;
        Vector3 randompawnPosition = new Vector3(Random.Range(-2f, 2f), -3.75f, Random.Range(-2f, 2f));
        Instantiate(bubble[genThis], randompawnPosition, Quaternion.identity);
    }
}
