using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        bestScoreText.text = $"Best Score : {GameManager.Instance.championName} : {GameManager.Instance.topScore}";
    }

    public void OnNameInputFieldChange(string name)
    {
        GameManager.Instance.playerName = name;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
