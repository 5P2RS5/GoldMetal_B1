using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerLogic : MonoBehaviour
{
    public int TotalItmeCount;
    public int stage;
    public Text stageCountText;
    public Text PlayerCountText;

    void Awake()
    {
        stageCountText.text = "/ " + TotalItmeCount.ToString();
    }

    public void getItem(int count)
    {
        PlayerCountText.text = count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(stage);
        }
    }
}
