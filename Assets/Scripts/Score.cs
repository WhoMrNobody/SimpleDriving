using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;

    public const string HighScoreKey = "HighScore";

    float score;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text="0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameController.gameController.isGameStarted){return;}
        score += Time.deltaTime * 2;

        scoreText.text = Mathf.FloorToInt(score).ToString();
    }

    private void OnDestroy() {

        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(score>currentHighScore){

            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(score));
        }

        
    }


}
