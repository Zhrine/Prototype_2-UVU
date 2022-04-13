using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public TextMeshProUGUI gameOverText;
    private int score;
    public TextMeshProUGUI scoreText;
    public List<GameObject> targets;

    private float spawnRate = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    } 
    IEnumerator SpawnTarget()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            
        }
    }
   public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
       
    }
   public void GameOver()
   {
       isGameActive = false;
       gameOverText.gameObject.SetActive(true);
   }
}
