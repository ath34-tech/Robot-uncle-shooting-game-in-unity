using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAutoSceneChange : MonoBehaviour
{
    public void LoadNewScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
    }
}
