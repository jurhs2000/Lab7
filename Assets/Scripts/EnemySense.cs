using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySense : MonoBehaviour
{
    public EnemyController enemyController;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //enemyController.setNewAgentDestination(other.gameObject.transform.position);
        }
    }
}
