using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TiringBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider tiringBar;
    public Gradient gradient;
    public Image fill;
    public PlayerSleepingController playerSleepingController;
    
    void Update()
    {
        tiringBar.maxValue = playerSleepingController.MaxTiringPoint;
        tiringBar.value = playerSleepingController.TiringPoint;
        fill.color = gradient.Evaluate(tiringBar.normalizedValue);
    }
}
