using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderboardUIHandler : MonoBehaviour {
    public GameObject playerList;
    public GameObject scoreList;

    // Start is called before the first frame update
    void Start() 
    {
        playerList.GetComponent<TMP_Text>().text = "";
        scoreList.GetComponent<TMP_Text>().text = "";

        GameManager.LeaderboardData leaderboard = GameManager.Instance.LoadLeaderboard();

        if (leaderboard == null) return;

        for (int i = 0; i < leaderboard.Leaderboard.Count; i++)
        {
            playerList.GetComponent<TMP_Text>().text += leaderboard.Leaderboard[i].LeaderName + "\n";
            scoreList.GetComponent<TMP_Text>().text += leaderboard.Leaderboard[i].LeaderScore + "\n";
        }
    }
}
