using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject player;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);

        StartCoroutine(SpawnObstacles());
        InvokeRepeating("ScoreUp", 2f, 1f);
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            yield return new WaitForSeconds(waitTime);

            Instantiate(Obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
