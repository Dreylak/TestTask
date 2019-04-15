using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text circleSpeedText;

    private CircleController circle;

    void Start()
    {
        circle = FindObjectOfType<CircleController>();
    }

    void Update()
    {
        circleSpeedText.text = "Horizontal speed: " + circle.speed.ToString("0.0");  
    }
}
