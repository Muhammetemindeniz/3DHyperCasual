using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class UIMenager : MonoBehaviour
{
   
    public AudioMenager audioMenager;
    public Image FillRate;
    public GameObject Player;
    public GameObject FinishLine;
    public TextMeshProUGUI CoinText;
    public GameObject RestartButton;
    public GameObject fScreen;
    public GameObject fCompleted;
    public GameObject fBackground;
    public GameObject fRadialShine;
    public GameObject fNextLevel;
    bool radialShine=false;
    public GameObject fCoin;
    void Start()
    {
        CoinUpdate();
    
    }
    private void Update()
    {
        FillRate.fillAmount = Player.transform.position.z / FinishLine.transform.position.z;
        if (radialShine)
        {
            fRadialShine.GetComponent<RectTransform>().Rotate(new Vector3(0,0,10 * Time.deltaTime));
        }
       
    }
    public void RestartSceneActive()
    {
        RestartButton.SetActive(true);
    }
    public void RestartScene()
    {
        Variables.firstTouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
   
       SceneManager.LoadSceneAsync(0);
    }
    public void CoinUpdate()
    {
        CoinText.text = PlayerPrefs.GetInt("money").ToString();
    }
    public void FinishScreen()
    {
        StartCoroutine(FinishLaunch());
    }
    public IEnumerator FinishLaunch()
    {
        Time.timeScale = .5f;
        audioMenager.CompletedSound();
        radialShine = true;
        fScreen.SetActive(true);
        fBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(.4f);
        audioMenager.CompletedSound();
        fCompleted.SetActive(true);
        yield return new WaitForSecondsRealtime(.4f);
        audioMenager.CompletedSound();
        fRadialShine.SetActive(true);
        fCoin.SetActive(true);
        yield return new WaitForSecondsRealtime(.4f);
        fNextLevel.SetActive(true);
        audioMenager.CashSound();
    }
}
