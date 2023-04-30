using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenager : MonoBehaviour
{
    public UIMenager uIMenager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("Finish"))
        {
            CoinsCal(100);

            uIMenager.CoinUpdate();
            uIMenager.FinishScreen();
            PlayerPrefs.SetInt("LevelIndex", PlayerPrefs.GetInt("LevelIndex") + 1);
        }
    }
   
    private void Start()
    {
        CoinsCal(0);
    }
    public void CoinsCal(int money)
    {
        if (PlayerPrefs.HasKey("money"))
        {
            int ageScore = PlayerPrefs.GetInt("money");
            PlayerPrefs.SetInt("money", ageScore + money);
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
        }
    }
}













