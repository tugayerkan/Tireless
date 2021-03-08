using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public PlayerMovement player;


    public void SetMaxVelocity(float velocity)
    {

        slider.maxValue = player.maxVelocity;
        slider.value = velocity;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetVelocity(int velocity)
    {

        slider.value = velocity;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }


}


