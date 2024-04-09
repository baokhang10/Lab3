using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerData playerData;

    void Start()
    {
        if (playerData == null)
        {
            playerData = ScriptableObject.CreateInstance<PlayerData>();
            playerData.playerLevel = 0;
            
        }
        else
        {
            LoadPlayerData();
        }
    }

    void LoadPlayerData()
    {
        if (PlayerPrefs.HasKey("PlayerLevel"))
        {
            playerData.playerLevel = PlayerPrefs.GetInt("PlayerLevel");
           
            Debug.Log("PlayerLevel: " + playerData.playerLevel);
           
        }
        else
        {
            playerData.playerLevel = 0;
           
        }
    }

    void OnApplicationQuit()
    {
        // Gọi phương thức ResetPlayerData từ PlayerData để reset dữ liệu khi trò chơi kết thúc
        playerData.ResetPlayerData();
    }
}

