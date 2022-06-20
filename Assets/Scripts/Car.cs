using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{

    [SerializeField] float carSpeed=5f;
    [SerializeField] float speedGainPerSecond = 0.3f;
    [SerializeField] float turnSpeed = 100f;

    public float maxMotorTorque; 
    public float maxSteeringAngle; 

    private int steerValue;

    void Start()
    {
        
    }
    
    void Update()
    {

        carSpeed += speedGainPerSecond * Time.deltaTime;

        transform.Rotate(0f, steerValue * turnSpeed * Time.deltaTime, 0f);
        transform.Translate(Vector3.forward * carSpeed * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider coll) {

        if(coll.CompareTag("obstacle")){

            SceneManager.LoadScene(0);

        }
        
    }

    public void Steer(int value){

        steerValue = value;
        
        
    }
    
}
