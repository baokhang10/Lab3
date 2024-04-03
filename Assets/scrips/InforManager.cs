using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text info;
    string name = "DavidBeckBin";
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        info.text = "Name:  " + name;
    }
}