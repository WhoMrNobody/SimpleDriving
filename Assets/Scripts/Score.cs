using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreText;

    public const string HighScoreKey = "HighScore";

    Car car;

    public float scorePoints;

    private void Awake() {

        car = FindObjectOfType<Car>();
    }
    void Start()
    {   
        scoreText.text="0";
    }

    
    void Update()
    {
        if(!GameController.gameController.isGameStarted){ return; }

            scorePoints += Time.deltaTime * 2;

            scoreText.text = Mathf.FloorToInt(scorePoints).ToString();
    }

    private void OnDestroy() {

        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);

        if(scorePoints>currentHighScore){

            PlayerPrefs.SetInt(HighScoreKey, Mathf.FloorToInt(scorePoints));
        }

        
    }


}
