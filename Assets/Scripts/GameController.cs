using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameStartText;

    public static GameController gameController;

    public bool isGameStarted=false;

    void Awake() {
        gameController=this;
        
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        if(Input.touchCount>0){
            isGameStarted=true;
            gameStartText.SetActive(false);
        }
        
    }
}
