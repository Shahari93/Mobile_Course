using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener // must have in order to use the ads
{
    public static AdManager adManagerInstance;
    private GameOverClass gameOverClass;
#if UNITY_ANDROID
    private string gameId = "4274647";
#elif UNITY_IOS
 private string gameId = "4274646";
#endif
    [SerializeField] private bool isTestAds = true;

    private void Awake()
    {
        if (adManagerInstance != null && adManagerInstance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            adManagerInstance = this;
            DontDestroyOnLoad(gameObject);
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, isTestAds);
        }
    }

    public void ShowAd(GameOverClass gameOverClass)
    {
        // this. refers to the private gameOverClass at the top of the class
        this.gameOverClass = gameOverClass;
        Advertisement.Show("rewardedVideo"); // the id is from the Unity dashboard
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                gameOverClass.ContinueGame();
                break;
            case ShowResult.Failed:
                Debug.LogError("Ad Failed");
                break;
            case ShowResult.Skipped:
                Debug.LogError("Ad Was Skipped");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }
}