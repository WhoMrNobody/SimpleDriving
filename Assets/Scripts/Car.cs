using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Car : MonoBehaviour
{

    [SerializeField] float carSpeed=5f;
    [SerializeField] float speedGainPerSecond = 0.3f;
    [SerializeField] float turnSpeed = 100f;
    [SerializeField] GameObject gameStartText;

    public float maxMotorTorque; 
    public float maxSteeringAngle; 

    private int steerValue;

    int activeScene;

    void Start()
    {
        
    }
    
    void Update()
    {
        if(!GameController.gameController.isGameStarted){ return; }

            carSpeed += speedGainPerSecond * Time.deltaTime;

            transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
            transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);

        activeScene=SceneManager.GetActiveScene().buildIndex;
    }


    private void OnTriggerEnter(Collider coll) {

        if(coll.CompareTag("obstacle")){

            SceneManager.LoadScene(activeScene);
        }

        if(coll.CompareTag("Finish")){
            SceneManager.LoadScene(activeScene++);
        }
        
    }

    public void Steer(int value){

        steerValue = value;
        
        
    }

    
}
