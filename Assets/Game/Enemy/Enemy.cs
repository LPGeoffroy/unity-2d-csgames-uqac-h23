using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 2f;
    public bool playerDetected = false;

    private GameObject ennemyManager;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        ennemyManager = GameObject.FindWithTag("EnemyManager");
        ennemyManager.GetComponent<EnemyManager>().AddEnemy(gameObject.GetInstanceID(), this);

        Player = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (playerDetected == false)
        {
            Transform wp = waypoints[_currentWaypointIndex];
            if (Vector3.Distance(transform.position, wp.position) < 0.01f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    wp.position,
                    _speed * Time.deltaTime);
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, _speed * Time.deltaTime);
           
            ennemyManager.GetComponent<EnemyManager>().UnFollowMode();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D otherObj)
    {
        if (otherObj.tag == "Player")
        {
            ennemyManager.GetComponent<EnemyManager>().FollowMode();
        }
    }
}
