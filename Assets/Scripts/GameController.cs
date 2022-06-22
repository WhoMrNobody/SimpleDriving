using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] public GameObject gameStartText_;
    public static GameController gameController;
    public bool isGameStarted=false;
    public bool isGameFailed=false;
    public CarStartingPos carStorageValue;
    public Vector3 carPos;
    public AsyncOperation nextSceneAsync;
    ParticleSystem finishEffectLeft;
    ParticleSystem finishEffectRight;
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
    void Update()
    {
        this.activeScene=SceneManager.GetActiveScene().buildIndex;

       
        if(Input.touchCount>0){

            isGameStarted=true;
            gameStartText_.SetActive(false);
        }

    }

    IEnumerator GameFinished(){

        LoadNextScene();
        car.isGameFinished=false;
        yield return new WaitForSeconds(1f);
        carStorageValue.carStartingPos_=carPos;
        gameStartText_.SetActive(true);
        
        
    }

    public void LoadNextScene(){

        nextSceneAsync = SceneManager.LoadSceneAsync(activeScene+1, LoadSceneMode.Single);
        nextSceneAsync.allowSceneActivation=false;
        gameStartText_.SetActive(true);
    }

}
