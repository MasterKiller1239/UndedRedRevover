﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public Timer timer;
    void FixedUpdate()
    {
        if(timer.timeToEnd - timer._currentTime < 0){
            foreach(SpriteRenderer sp in this.GetComponentsInChildren<SpriteRenderer>()){
                sp.color = new Color(1.0f, 0, 0, 1.0f);
            }
        }
    }
}
