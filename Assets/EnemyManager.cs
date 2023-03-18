using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Dictionary<int, Enemy> enemies;
    private GameObject Player;

    void Awake()
    {
        enemies = new Dictionary<int, Enemy>();
        Player = GameObject.FindWithTag("Player");
    }

    public void AddEnemy(int id, Enemy enemy)
    {
        enemies.Add(id, enemy);
        Debug.Log(enemies.Count);
    }

    public void FollowMode()
    {
        Debug.Log("AYOOOO");

        foreach (KeyValuePair<int, Enemy> enemy in enemies)
        {
            enemy.Value.playerDetected = true;
        }
    }

    public bool OneFollower()
    {
        foreach (KeyValuePair<int, Enemy> enemy in enemies)
        {
            if(enemy.Value.playerDetected == true)
            {
                return true;
            }
        }
        return false;
    }

    public void UnFollowMode()
    {
        foreach (KeyValuePair<int, Enemy> enemy in enemies)
        {
            Vector2 positionA = Player.transform.position;
            Vector2 positionB = this.transform.position;

            if (Vector2.Distance(positionA, positionB) > 10)
            {

                float distance = Vector2.Distance(Player.transform.position, enemy.Value.transform.position);
                enemy.Value.playerDetected = false;
            }
        }
    }
}
