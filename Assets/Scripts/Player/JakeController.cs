using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Player {
    public class JakeController : MonoBehaviour
    {
        public void OnLanding()
        {
            Player.instance.GetComponent<Movement>().OnLanding();
        }
    }
}
