using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Unity.Notifications.Android;
using UnityEngine.UI;


public class MainMenuController : MonoBehaviour
{
    [SerializeField] TMP_Text highScore_Text;
    [SerializeField] TMP_Text energyText;
    [SerializeField] int maxEnergy;
    [SerializeField] int energyRechargeDuration;
    [SerializeField] private NotificationController notificationController;
    [SerializeField] private Button playButton;

    private int energy;
    private const string EnergyKey = "Energy";
    private const string EnergyReadKey = "EnergyReady";
    
    private void Start(){

        OnApplicationFocus(true);
    }
    
    private void OnApplicationFocus(bool focusStatus) {
        
        if(!focusStatus){return;}

        CancelInvoke();

        int highScore = PlayerPrefs.GetInt(Score.HighScoreKey, 0);

        highScore_Text.text= $"High Score : {highScore}";

        energy = PlayerPrefs.GetInt(EnergyKey, maxEnergy);

        if(energy == 0){
            
            string energyReadyString = PlayerPrefs.GetString(EnergyReadKey, string.Empty);

            if(energyReadyString == string.Empty) {return;}

            DateTime energyReady = DateTime.Parse(energyReadyString);

            if(DateTime.Now>energyReady){
                
                energy = maxEnergy;
                PlayerPrefs.SetInt(EnergyKey, energy);

            }else{

                playButton.interactable=false;
                Invoke(nameof(EnergyRecharged), (energyReady - DateTime.Now).Seconds);

            }

        }

        energyText.text = $"Play ({energy})";

    }

    void EnergyRecharged(){

        playButton.interactable=true;
        energy= maxEnergy;
        PlayerPrefs.SetInt(EnergyKey, energy);
        energyText.text= $"Play ({energy})";

    }


    public void Play(){

        if ( energy < 1){ return; }

        energy--;
        PlayerPrefs.SetInt(EnergyKey, energy);

        if(energy==0){

            DateTime energyReady = DateTime.Now.AddMinutes(energyRechargeDuration);
            PlayerPrefs.SetString(EnergyReadKey, energyReady.ToString());
#if UNITY_ANDROID                                               
            notificationController.ScheduleNotification(energyReady);
#endif

        }

        SceneManager.LoadScene(1);

    }
}
