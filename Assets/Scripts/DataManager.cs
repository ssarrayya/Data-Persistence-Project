using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highScoreName;
    public int highScore;

    private void Awake()
    {
        // Singleton pattern
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadHighScore();
    }

    [System.Serializable]
    private class SaveData
    {
        public string highScoreName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();

        data.highScoreName = highScoreName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(
            Application.persistentDataPath + "/savefile.json",
            json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreName = data.highScoreName;
            highScore = data.highScore;
        }
    }
}