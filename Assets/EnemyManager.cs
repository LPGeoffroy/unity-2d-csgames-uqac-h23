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

    void Update()
    {
        if (!OneFollower())
        {
            UnFollowMode();
        }
    }

    public void AddEnemy(int id, Enemy enemy)
    {
        enemies.Add(id, enemy);
    }

    public void FollowMode()
    {
        foreach (KeyValuePair<int, Enemy> enemy in enemies)
        {
            enemy.Value.playerDetected = true;
        }
    }

    public bool OneFollower()
    {
        foreach (KeyValuePair<int, Enemy> enemy in enemies)
        {
            if(enemy.Value.onTrack == true)
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
            enemy.Value.playerDetected = false;
        }
    }
}
