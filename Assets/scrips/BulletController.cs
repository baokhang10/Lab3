using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    public PlayerData playerData;
    // Start is called before the first frame update


    public int scoreValue = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
           
            ScoreController.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn

        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {

            ScoreController.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn

        }
        if (collision.gameObject.tag.Equals("Trap"))
        {

            ScoreController.Instance.IncreaseScore(scoreValue);
            Destroy(collision.gameObject); // Đối tượng bị bắn
            Destroy(gameObject); // Viên đạn

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEdge") || collision.CompareTag("BoxEdge") )
        {
            Destroy(gameObject);
        }
            
    }
}
