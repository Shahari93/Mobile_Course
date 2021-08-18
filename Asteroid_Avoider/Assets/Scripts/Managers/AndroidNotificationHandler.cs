#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif
using UnityEngine;
using System;

#if UNITY_ANDROID
public class AndroidNotificationHandler : MonoBehaviour
{

    private const string channelID = "notification_Channel_ID";

    public void SceducleNotification()
    {
        AndroidNotificationChannel androidNotificationChannel = new AndroidNotificationChannel()
        {
            Id = channelID,
            Name = "Notification",
            Description = "Notification Description",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(androidNotificationChannel);

        AndroidNotification androidNotification = new AndroidNotification()
        {
            Text = "Test Notification",
            Title = "This is a test",
            LargeIcon = "default",
            SmallIcon = "default",
            FireTime = DateTime.Now.AddMinutes(1)
        };

        AndroidNotificationCenter.SendNotification(androidNotification, channelID);
    }



    //private void OnDestroy()
    //{
    //    SceducleNotification();
    //}
}
#endif