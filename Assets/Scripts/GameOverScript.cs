using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Score;

    void Start()
    {
        Score.text = "Score: " + UIManager.score;
    }


}
