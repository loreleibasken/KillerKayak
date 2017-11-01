using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{

    [System.Serializable]
    public struct Range
    {
        public float min;
        public float max;
    }

    public float xPosition = 15f;
    public Range yPosition;
    public Range waitTime;
    public List<GameObject> prefabs = new List<GameObject>();

    void Start()
    {
        StartCoroutine("CreateObstacles");
    }

    IEnumerator CreateObstacles()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waitTime.min, waitTime.max));
            CreateObstacle();
        }
    }

    void CreateObstacle()
    {
        if (prefabs.Count > 0 && GameObject.FindGameObjectWithTag("Player") != null)
        {
            int obstacleIndex = Random.Range(0, prefabs.Count);
            GameObject gameObject = (GameObject)Instantiate(prefabs[obstacleIndex]);
            Vector2 position = new Vector2(xPosition, Random.Range(yPosition.min, yPosition.max));
            gameObject.transform.position = position;
        }
    }

}
