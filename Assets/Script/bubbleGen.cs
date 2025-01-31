using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGen : MonoBehaviour
{
    //Num Gen
    public int value;

    //Total num of students to choose from
    private List<int> totalAmount = new List<int>();

    //Bubble Colors
    public GameObject[] bubble;

    private void Start()
    {
        StartCoroutine(myCounter());
    }
    void Update()
    {
        if (Input.GetKeyUp("1")) //Input for "Bad"
        {
            totalAmount.Add(0);
            textScript.Instnace.badNum++;
        }
        else if (Input.GetKeyUp("2")) //Input for "Alright"
        {
            totalAmount.Add(1);
            textScript.Instnace.alrNum++;
        }
        else if (Input.GetKeyUp("3")) //Input for "Good"
        {
            totalAmount.Add(2);
            textScript.Instnace.goodNum++;
        }
    }
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
}
