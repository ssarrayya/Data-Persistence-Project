using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TMP_InputField nameInput;

    public void StartNew()
    {
        DataManager.Instance.playerName = nameInput.text;

        SceneManager.LoadScene(0);
    }
}