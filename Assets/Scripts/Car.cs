using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] float carSpeed=5f;
    [SerializeField] float speedGainPerSecond = 0.3f;
    [SerializeField] float turnSpeed = 100f;
    Score score;
    public float maxMotorTorque; 
    public float maxSteeringAngle; 
    private int steerValue;
    public bool isGameFinished=false;

    public bool gameOver=false;
    Quaternion startRotation;
    
    void Awake() {

        startRotation=transform.rotation;
        score=FindObjectOfType<Score>();
    }
    void Update()
    {

        if(!GameController.gameController.isGameStarted){ return; }

            AccelerationCar();
    }


    private void OnTriggerEnter(Collider coll) {

        if(coll.CompareTag("obstacle")){

            RestartGame();
            
        }

        if(coll.CompareTag("Finish")){

            isGameFinished=true;
            GameController.gameController.isGameStarted=false;
            GameController.gameController.LoadNextScene();
            transform.position=GameController.gameController.carStorageValue.carStartingPos_;

        }

        if(coll.CompareTag("LastFinish")){

            isGameFinished=true;
            gameOver=true;
            GameController.gameController.isGameStarted=false;
            SceneManager.LoadScene(0);
            score.OnDestroy();

        }
        
    }

    public void Steer(int value){

        steerValue = value;
        
    }

    void RestartGame(){

        Time.timeScale=0f;
        transform.rotation=startRotation;
        transform.position=GameController.gameController.carStorageValue.carStartingPos_;
        score.scoreText.text="0";
        score.scorePoints=0f;
        GameController.gameController.isGameStarted=false;
        GameController.gameController.gameStartText_.SetActive(true);
        SceneManager.LoadScene(GameController.gameController.activeScene);

    }

    public void AccelerationCar(){

        carSpeed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }
    
}
