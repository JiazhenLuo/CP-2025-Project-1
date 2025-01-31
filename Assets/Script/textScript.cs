using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textScript : MonoBehaviour
{
    public TMP_Text bad;
    public int badNum;

    public TMP_Text alright;
    public int alrNum;

    public TMP_Text good;
    public int goodNum;

    public static textScript Instnace { get; private set; }
    private void Awake()
    {
        Instnace = this;
    }

    private void Update()
    {
        bad.text = badNum.ToString();
        alright.text = alrNum.ToString();
        good.text = goodNum.ToString();
    }
}
