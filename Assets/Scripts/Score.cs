using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    Text textCompoenent = null;
    // Start is called before the first frame update
    void Start()
    {
        textCompoenent = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textCompoenent.text = "Score: " + scoreValue;
    }
}
