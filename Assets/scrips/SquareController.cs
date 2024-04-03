using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    public float timeRemaining = 60;
    public Text countdownText;
    
    private int score = 0;
    public float moveSpeed = 3f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private Vector2 shootDirection;

   


    void Start()
    {
        StartCoroutine(Countdown());
        UpdateScoreText();
    }
    IEnumerator Countdown()
    {
        while (timeRemaining > 0)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        countdownText.text = "Time's up!";
        SceneManager.LoadScene("GameoverScene");
    }
    void UpdateScoreText()
    {
        
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            shootDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            shootDirection = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            shootDirection = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            shootDirection = Vector2.down;
        }

        // Bắn đạn khi người chơi nhấn Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, moveDirection, out hit, 1.0f))
        {
            Renderer renderer = hit.collider.GetComponent<Renderer>();

            if (renderer != null && renderer.material.color == Color.black)
            {
                // Nếu nhân vật chạm vào vùng màu đen, ngăn nhân vật di chuyển
                transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);
            }
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
        transform.Translate(movement * 5f *Time.deltaTime);
        
            }
    public void LoadNextScene()
    {
        int currenSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currenSceneIndex + 1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxxx");
            Vector2 firstPosition = new Vector2(-6, 3.7f);
            transform.position = firstPosition;
            
        }
        else if (collision.gameObject.tag.Equals("Star"))
        {
            ScoreController.Instance.IncreaseScore(10); // Tăng điểm chung
            Destroy(collision.gameObject); // Hủy đối tượng "Star" 
        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
        {
            Debug.Log("xxxx");
            Vector2 firstPosition = new Vector2(-6, 3.7f);
            transform.position = firstPosition;

        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("win");
            LoadNextScene();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MapEdge")) // Kiểm tra xem collider khác có phải là viền bản đồ không
        {
            Debug.Log("xxxxxx");
            // Dừng di chuyển của GameObject khi va chạm vào viền bản đồ
            Vector2 fistPosition = new Vector2(-6, 3.7f);
            transform.position = fistPosition;
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * bulletSpeed;  // Bắn theo hướng "up" của GameObject
        }
    }
}
