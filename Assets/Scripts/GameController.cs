using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject gameStartText_;
    [SerializeField] public GameObject gameInfoText_;
    public static GameController gameController;
    public bool isGameStarted=false;
    public bool isGameFailed=false;
    public CarStartingPos carStorageValue;
    public Vector3 carPos;
    public int activeScene;
    Car car;

    void Awake() {
        
        this.activeScene=SceneManager.GetActiveScene().buildIndex;

        car = FindObjectOfType<Car>();

        if(gameController==null){

            gameController=this;
            DontDestroyOnLoad(gameObject);

        }else{
           Destroy(gameObject);
        }
    }

    void Start() {

        Time.timeScale=0f;

    }
    void Update()
    {
        this.activeScene=SceneManager.GetActiveScene().buildIndex;
       
        if(Input.touchCount>0){

            isGameStarted=true;
            Time.timeScale=1f;
            gameStartText_.SetActive(false);
            gameInfoText_.SetActive(false);
        }

        if(car.gameOver){
            Destroy(this.gameObject);
        }

    }


    public void LoadNextScene(){

        SceneManager.LoadScene(this.activeScene+1);
        Time.timeScale=0f;
        gameStartText_.SetActive(true);
        gameInfoText_.SetActive(true);
    }

}
