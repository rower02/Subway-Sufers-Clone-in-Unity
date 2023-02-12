using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Levels
{
    public class LevelGenerator : MonoBehaviour
    {
        public int index = 0;
        public List<GameObject> terrainParts = new List<GameObject>();
        public List<GameObject> existsParts = new List<GameObject>();
        public int startNumberOfParts;
        public int placesBefore;

        public GameObject coin;

        private void Start()
        {
            GenerateFirstTerrainPart();
            for (int i = 0; i < startNumberOfParts; i++)
            {
                GenerateTerrainPart();
            }
        }

        public void GenerateFirstTerrainPart()
        {
            GameObject part = Instantiate(terrainParts[0], new Vector3(index, -1, 0), Quaternion.identity);
            existsParts.Add(part);
            index += 10;
        }

        public void GenerateTerrainPart()
        {
            GameObject part = Instantiate(terrainParts[Random.Range(0, terrainParts.Count)], new Vector3(index, -1, 0), Quaternion.identity);
            existsParts.Add(part);
            index += 10;
            if (Random.Range(1, 6) == 1)
            {
                GameObject _Coin = Instantiate(coin, new Vector3(index, 1, 2), Quaternion.identity, part.transform);
            }
            if (Random.Range(1, 6) == 2)
            {
                GameObject _Coin = Instantiate(coin, new Vector3(index, 1, -2), Quaternion.identity, part.transform);
            }
            if (Random.Range(1, 6) == 3)
            {
                GameObject _Coin = Instantiate(coin, new Vector3(index, 1, 0), Quaternion.identity, part.transform);
            }
        }

        private void Update()
        {
            if (Player.Player.instance.transform.position.x > index - placesBefore)
            {
                GenerateTerrainPart();
                Destroy(existsParts[0]);
                existsParts.RemoveAt(0);
            }
        }
    }
}
