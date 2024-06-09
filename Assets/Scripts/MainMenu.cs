using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public const string OBTAINED_LEVEL_KEY = "Obtained_Level";
    [SerializeField] private GameObject buttonPrefab;
    void Start()
    {
        if(!PlayerPrefs.HasKey(OBTAINED_LEVEL_KEY)) PlayerPrefs.SetInt(OBTAINED_LEVEL_KEY, 1);

        for(int level=1; level<=PlayerPrefs.GetInt(OBTAINED_LEVEL_KEY)+1; level++){
            GameObject button = Instantiate(buttonPrefab, transform);
            button.GetComponent<MenuButton>().SetLevelNumber(level);
        }
        transform.GetChild(transform.childCount-1).GetComponent<Button>().interactable = false;
    }
}
