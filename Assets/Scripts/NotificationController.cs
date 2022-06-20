using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class NotificationController : MonoBehaviour
{

#if UNITY_ANROİD
    const string ChannelId = "notification_channel";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ScheduleNotification(DateTime dateTime){

        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel{

            Id = ChannelId,
            Name = "Notification Channel",
            Description = "Some random description",
            Importance = Importance.Default

        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);

        AndroidNotification notification = new AndroidNotification{

            Title="Energy Recharged!",
            Text = "Your energy has recharged, come back to play again!",
            SmallIcon="default",
            LargeIcon="default",
            FireTime=dateTime

        };

        AndroidNotificationCenter.SendNotification(notification, ChannelId);

    }
#endif
}
