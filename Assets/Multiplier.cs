using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Multiplier : MonoBehaviour
{
    private Text multiplierText;

    void Awake()
    {
        multiplierText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        multiplierText.text = "MULTIPLIER (LIVES LEFT): " + GameMaster.RemainingLives.ToString();
    }
}