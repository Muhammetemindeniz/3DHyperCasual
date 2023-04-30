using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class LevelMenager : MonoBehaviour
{
    public TextMeshProUGUI loadingtxt;
    void Start()
    {
        if (!PlayerPrefs.HasKey("LevelIndex"))
        {
            PlayerPrefs.SetInt("LevelIndex", 1);
        }
        StartCoroutine(LoadingBar());
        LevelControl();
    }
    public void LevelControl()
    {
        int level = PlayerPrefs.GetInt("LevelIndex");
        SceneManager.LoadSceneAsync(level);
    }
    public IEnumerator LoadingBar()
    {
        while (true)
        {
            loadingtxt.text = "LOADING".ToString();
            yield return new WaitForSecondsRealtime(.2f);
            loadingtxt.text = "LOADING.".ToString();
            yield return new WaitForSecondsRealtime(.4f);
            loadingtxt.text = "LOADING..".ToString();
            yield return new WaitForSecondsRealtime(.6f);
            loadingtxt.text = "LOADING...".ToString();

        }
    }

}
