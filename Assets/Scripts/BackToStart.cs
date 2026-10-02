using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToStart : MonoBehaviour
{
    public TextMeshProUGUI scoreUI ;
    public TextMeshProUGUI highScoreUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        scoreUI.text = "Your Score: " + PlayerPrefs.GetInt("lastScore");
        highScoreUI.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    public void toStart()
    {
        SceneManager.LoadScene(0);
    }

}

