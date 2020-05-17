using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySense : MonoBehaviour
{
    public EnemyController enemyController;
    public Restart restart;

    private void Start()
    {
        restart = FindObjectOfType(typeof(Restart)) as Restart;
    }

    private void Update()
    {
        transform.position = enemyController.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        if (restart.playerRestarting)
        {
            enemyController.setNewRandomPoint();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyController.setNewAgentDestination(other.gameObject.transform.position);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enemyController.setNewRandomPoint();
        }
    }
}
