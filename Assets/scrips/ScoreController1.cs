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
        // Khi bắt đầu, cập nhật điểm từ PlayerPrefs
        totalScore = PlayerPrefs.GetInt("TotalScore", 0);
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
        SaveScore(); // Lưu điểm sau mỗi lần tăng điểm
    }

    // Phương thức lưu điểm
    private void SaveScore()
    {
        PlayerPrefs.SetInt("TotalScore", totalScore);
        PlayerPrefs.Save();
        Debug.Log("Score saved: " + totalScore);
    }

    public void ResetScore()
    {
        totalScore = 0;
        PlayerPrefs.DeleteKey("TotalScore");
        UpdateScoreText();
        Debug.Log("Score reset");
    }
    private void OnApplicationQuit()
    {
        ResetScore();
    }
}
