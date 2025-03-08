using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIManager : MonoBehaviour
{
    public InputField nameInput;
    public Text scoreText;

    void Start()
    {
        SaveManager.Instance.LoadScore();
        Debug.Log(SaveManager.recordName);
        Debug.Log(SaveManager.highScore);
        scoreText.text = "Best Score : " + SaveManager.recordName + " : " + SaveManager.highScore;
    }
    public void UpdateName()
    {
        SaveManager.Instance.playerName = nameInput.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        SaveManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
