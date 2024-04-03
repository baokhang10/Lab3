using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    private static ScoreController instance;
    public static ScoreController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreController>();
            }
            return instance;
        }
    }

    private int totalScore = 0; // Tổng điểm
    

    public Text scoreText; // Text hiển thị điểm

    private void Start()
    {
        UpdateScoreText(); // Cập nhật text điểm khi bắt đầu
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + totalScore.ToString();             
        
    }

    // Phương thức tăng điểm
    public void IncreaseScore(int amount)
    {
        totalScore += amount;
        UpdateScoreText();
    }
}