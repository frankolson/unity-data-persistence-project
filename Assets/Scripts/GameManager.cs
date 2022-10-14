using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string playerName;
    public string championName;
    public int topScore = 0;

    private string savefileName = "savefile.json";

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadTopScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string championName;
        public int topScore;
    }

    public void SaveNewTopScore(int newScore)
    {
        championName = playerName;
        topScore = newScore;
        
        SaveData data = new SaveData();
        data.championName = championName;
        data.topScore = topScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText($"{Application.persistentDataPath}/{savefileName}", json);
    }

    void LoadTopScore()
    {
        string path = $"{Application.persistentDataPath}/{savefileName}";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            championName = data.championName;
            topScore = data.topScore;
        }
    }
}
