using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCreator : MonoBehaviour
{

    [System.Serializable]
    public struct Range
    {
        public float min;
        public float max;
    }

    public float xPosition = 15f;
    public Range yPosition;
    public Range obstacleTime;
    public List<GameObject> obstacles = new List<GameObject>();

    void Start()
    {
        StartCoroutine("CreateObstacles");
	}

    IEnumerator CreateObstacles()
    {
        while (true)
        {
            CreateObstacle();
            yield return new WaitForSeconds(Random.Range(obstacleTime.min, obstacleTime.max));
        }
    }

    void CreateObstacle()
    {
        if (obstacles.Count > 0)
        {
            int obstacleIndex = Random.Range(0, obstacles.Count);
            GameObject obstacle = (GameObject)Instantiate(obstacles[obstacleIndex]);
            Vector2 position = new Vector2(xPosition, Random.Range(yPosition.min, yPosition.max));
            obstacle.transform.position = position;
        }
    }

}
