using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour 
{
    public static GameManager Instance;

    public string PlayerName;
    public string HighScoreName;
    public int HighScore;

    private void Awake() 
    {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int HighScore;
    }

    public void CheckHighscore(int score)
    {
        if (score > HighScore)
        {
            HighScoreName = PlayerName;
            HighScore = score;
            SaveHighscore();
        }
    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.PlayerName = PlayerName;
        data.HighScore = HighScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighscore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.PlayerName;
            HighScore = data.HighScore;
        }
    }
}
