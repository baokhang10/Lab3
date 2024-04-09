using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public int playerLevel;
   

    public void ResetPlayerData()
    {
        // Thiết lập cấp độ và điểm số của người chơi về 0
        playerLevel = 0;
       

        // Lưu trữ dữ liệu mới vào PlayerPrefs để giữ lại giá trị 0
        PlayerPrefs.SetInt("PlayerLevel", playerLevel);
       

        Debug.Log("Player data reset."); // (Tùy chọn) In ra thông báo để xác nhận rằng dữ liệu đã được reset
    }
}
