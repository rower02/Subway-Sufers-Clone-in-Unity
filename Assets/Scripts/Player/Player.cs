using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.Player
{
    public class Player : MonoBehaviour
    {
        public static Player instance;
        public GameObject model;
        public GameObject deathUI;
        public Collider rollCollider;
        public Collider normalCollider;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            //bestScore = PlayerPrefs.GetInt("BestScore");
            //deathUI.GetComponent<DeathUI>().bestScoreTxt.text = "Best Score: " + bestScore.ToString();
        }

      

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Object")
            {
                GameManager.instance.Death();
                gameObject.SetActive(false);
            }
            if (other.tag == "Coin")
            {
                GameManager.instance.AddScore(1);
                Destroy(other.gameObject);
            }
        }

    }
}