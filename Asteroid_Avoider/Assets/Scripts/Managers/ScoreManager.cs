using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float scoreMultipler;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    private float score;
    private bool shouldCount = true;

    private void Update()
    {
        IncrementScore();
    }

    private void IncrementScore()
    {
        if(!shouldCount)
        {
            return;
        }

        score += Time.deltaTime * scoreMultipler;
        scoreText.text = Mathf.FloorToInt(score).ToString();
        finalScoreText.text = $"Your Score Is: {Mathf.FloorToInt(score).ToString()}";
    }

    public void CountScore()
    {
        shouldCount = false;
    }

    public void StartTimer()
    {
        shouldCount = true;
    }
}
