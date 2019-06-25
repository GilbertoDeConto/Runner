using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScore(int score)
    {
        txt.text = "Score: " + score;
    }

}
