﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yukidango.BarrageShooting.Boss;

public class BossHpSliderControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    this.GetComponent<Slider>().value = BossController.HitPoint.hitPoint;
	}

}
