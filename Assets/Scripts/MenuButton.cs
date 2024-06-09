using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButton : MonoBehaviour
{
    private int levelNumber=0;
    private TMP_Text buttonText;
    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();
        buttonText = 
            GetComponentInChildren<TMP_Text>();
        
    }

    public void SetLevelNumber(int levelNumber){
        this.levelNumber = levelNumber;
        buttonText.text = levelNumber.ToString();
        button.onClick.AddListener(GenerateLevel);
    }

    public void GenerateLevel(){
        LevelSeed.seed = levelNumber;
        SceneManager.LoadScene(1);
    }
}
