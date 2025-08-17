using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Master : MonoBehaviour
{
    public GameObject[] enemy;
    public int id;

    public int score;

    public GameObject tip;
    void Start()
    {
        Show_enemy();
        Invoke("Show_enemy", 7f);
        Invoke("Show_enemy", 15f);
        Invoke("Show_enemy", 24f);
        Invoke("Show_enemy", 24.1f);
    }

    void Show_enemy()
    {
        enemy[id].SetActive(true);
        id++;
    }
    public Transform enemyF;
    public bool shengli = true;
    public GameObject victory;
    public GameObject wenzi;
    private void Update()
    {
        if(shengli && score == 5)
        {
            shengli = false;
            victory.SetActive(true);
            wenzi.SetActive(true);
            if(tip != null)
            tip.SetActive(false);

            SceneFade.Instance.FadeIn(() =>
            {
                SceneManager.LoadScene(4);
            });

        }
    }

    public void Game_on()
    {
        Debug.Log("=================");
        SceneManager.LoadScene(2);
    }
}
