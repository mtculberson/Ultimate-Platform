using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class HighscoreScript : MonoBehaviour
{
    private Text highscoreText;

    void Awake()
    {
        highscoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = "HIGH SCORE: " + GameMaster.HighScore.ToString();
    }
}
