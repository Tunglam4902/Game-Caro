using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text winner;

    public Button restartButton;

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void Awake(){
        restartButton.onClick.AddListener(OnClick);
    }

    public void SetName(string s){
        winner.text = "Winner: " + s;
    }

    public void OnClick(){
        SceneManager.LoadScene("SampleScene");
    }
}
