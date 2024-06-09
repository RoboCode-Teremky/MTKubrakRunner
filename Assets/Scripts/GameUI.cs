using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TMP_Text bonusText, levelText, percentText;
    [SerializeField] private Button pauseButton, nextLevelButton;
    [SerializeField] private GameObject pauseMenuPanel, finishMenuPanel;
    [Range(0.0f, 100.0f)][SerializeField] private float threshold = 75.0f;
    private bool isPause = false;

    private void OnEnable()
    {
        Bonus.takeBonus.AddListener(ChangeScore);
        Finish.finishReached.AddListener(FinaleScore);
    }

    private void OnDisable()
    {
        Bonus.takeBonus.RemoveListener(ChangeScore);
        Finish.finishReached.RemoveListener(FinaleScore);
    }

    void Start()
    {
        Time.timeScale=1.0f;
        pauseButton.onClick.AddListener(Pause);
        nextLevelButton.onClick.AddListener(NextLevel);
        pauseMenuPanel.SetActive(false);
        finishMenuPanel.SetActive(false);
        ScoreCounter.currentScore=0;
        ChangeScore(); // ?
        levelText.text = "Level " + LevelSeed.seed.ToString("D2");
    }

    private void ChangeScore()
    {
        bonusText.text = "Icecream: " + ScoreCounter.currentScore.ToString("D3");
    }

    public void Pause()
    {
        isPause = !isPause;
        pauseMenuPanel.SetActive(isPause);
        if (isPause) { Time.timeScale = 0.0f; }
        else { Time.timeScale = 1.0f; }
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void FinaleScore(){
        Time.timeScale = 0.0f;
        finishMenuPanel.SetActive(true);
        float bonusPercent = (float)ScoreCounter.currentScore/(float)ScoreCounter.allBonuses*100.0f;
        percentText.text = "Your collect "+bonusPercent.ToString("F2") + "% of all bonuses";
        if(bonusPercent>threshold) {
            nextLevelButton.interactable = true;
            LevelSeed.seed++;
            if(PlayerPrefs.GetInt(MainMenu.OBTAINED_LEVEL_KEY)<LevelSeed.seed)
                PlayerPrefs.SetInt(MainMenu.OBTAINED_LEVEL_KEY, LevelSeed.seed);
        }
        else nextLevelButton.interactable = false;
    }

    public void NextLevel(){
        SceneManager.LoadScene(1);
    }
}
