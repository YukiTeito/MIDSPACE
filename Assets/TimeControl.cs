﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{

    public static int minute;
    public static double seconds;

    // Start is called before the first frame update
    void Start()
    {
        minute = 4;
        seconds = 60;
        this.GetComponent<Text>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        seconds -= Time.deltaTime;
        if (seconds <= 0f)
        {
            minute--;
            seconds += 60;
        }
        
        if(minute <= 0 && seconds <= 0) SceneManager.LoadScene("EndCard");
        this.GetComponent<Text>().text = "LimitTime => "+minute+":"+((int)seconds).ToString("00");
    }
}
