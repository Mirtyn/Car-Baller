using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public Player Player;
    public Player Player1;
    public Player Player2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name != "Ball")
        {
            return;
        }

        Player.Score++;

        collision.gameObject.transform.position = new Vector3(0, (float)Random.Range(-5, 5), 0);

        var player1 = GameObject.Find("Player1");
        player1.transform.position = new Vector3(-9, 0, 0);
        player1.transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

        var player2 = GameObject.Find("Player2");
        player2.transform.position = new Vector3(9, 0, 0);
        player2.transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

        Debug.Log("GOAL!!! " + Player1.Score + " - " + Player2.Score);
    }
}
