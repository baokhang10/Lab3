using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderController : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    private void Start()
    {
        slider.value = 10f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trap");
            slider.value--;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
       
    }
}
