using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
    using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public GameObject nameInput;

    public void StartNew()
    {
        GameManager.Instance.playerName = nameInput.GetComponent<TMP_InputField>().text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
