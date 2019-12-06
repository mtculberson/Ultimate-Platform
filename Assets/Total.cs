using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Total : MonoBehaviour
{
    private Text totalText;

    void Awake()
    {
        totalText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        totalText.text = "TOTAL: " + (GameMaster.RemainingLives * GameMaster.HighScore).ToString();
    }
}