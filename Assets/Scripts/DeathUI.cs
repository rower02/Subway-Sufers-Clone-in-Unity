using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Scripts
{
    public class DeathUI : MonoBehaviour
    {
        public static DeathUI instance;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            gameObject.SetActive(false);
        }


        public void Respawn()
        {
            SceneManager.LoadScene("Game");
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
