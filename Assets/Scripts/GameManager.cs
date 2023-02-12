using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts {
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public int bestScore;
        public int score;

        [Header("UI")]
        public Text scoreTxt;
        public Text bestScoreTxt;

        private void Awake()
        {
            instance = this;
            bestScore = PlayerPrefs.GetInt("BestScore");
        }
        private void Start()
        {
            score = 0;
            UpdateScore(score);
        }

        public void UpdateScore(int value)
        {
            scoreTxt.text = value.ToString();
        }

        public void AddScore(int value)
        {
            score += value;
            UpdateScore(score);
        }

        public void UpdateBestScore(int value)
        {
            bestScoreTxt.text = "Best Score: " + value.ToString();
        }

        public void Death()
        {
            if (score > bestScore)
            {
                bestScore = score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            UpdateBestScore(bestScore);
            DeathUI.instance.gameObject.SetActive(true);
        }
    }

}