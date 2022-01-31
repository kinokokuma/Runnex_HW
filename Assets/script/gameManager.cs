using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private bool spawnNow = true;
    private float[] coolDownTime = { 1, 1.5f, 4 };
    public Image[] lifeIcon;
    public Text scoreText;
    private List<List<float[]>> spawnPoint =new List<List<float[]>>(){
        new List<float[]>() {
            new float[] { -17.5f, 41, 0 },
            new float[] { -12.5f, 41, 0 },
            new float[] { -7.5f, 41, 0 },
            new float[] { -2.5f, 41, 0 },
            new float[] { 2.5f, 41, 0 },
            new float[] { 7.5f, 41, 0 },
            new float[] { 12.5f, 41, 0 },
            new float[] { 17.5f, 41, 0 }},

        new List<float[]>() {
            new float[] { -17.5f, 41, 0 },
            new float[] { -12.5f, 41, 0 },
            new float[] { -7.5f, 41, 1 },
            new float[] { -2.5f, 41, 0 },
            new float[] { 2.5f, 41, 0 },
            new float[] { 7.5f, 41, 1 },
            new float[] { 12.5f, 41, 0 },
            new float[] { 17.5f, 41, 0 }},

        new List<float[]>() {
            new float[] { 5, 41, 0 },
            new float[] { -4, 41, 0 },
            new float[] { -3, 41, 0 },
            new float[] { -2, 41, 0 },
            new float[] { -1, 41, 0 },
            new float[] { 0, 41, 0 },
            new float[] { 1, 41, 0 },
            new float[] { 2, 41, 0 },
            new float[] { 3, 41, 0 },
            new float[] { 4, 41, 0 },
            new float[] { 5, 41, 0 },
            new float[] { -10, 41, 2 },
            new float[] { 10, 41, 2 }}

    };
    
    public int score=0,life=3;
    public GameObject[] enemy;

    

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score : " + score;
        if (spawnNow)
        {
            spawnEnemy();
            
        }

        if (life <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void spawnEnemy()
    {
        
        int numPatten=Random.Range(0, 3);
        for(int i=0;i< spawnPoint[numPatten].Count; i++)
        {
            Instantiate(enemy[(int)(Mathf.Floor(spawnPoint[numPatten][i][2]))],new Vector3(spawnPoint[numPatten][i][0], spawnPoint[numPatten][i][1],0), Quaternion.identity);
        }

        StartCoroutine(isCoolDownSpawn(coolDownTime[numPatten]));
        print(coolDownTime[numPatten]);
        print(numPatten);

    }

    IEnumerator isCoolDownSpawn(float time)
    {
        spawnNow = false;
        yield return new WaitForSeconds(time);
        spawnNow = true;
    }
}


