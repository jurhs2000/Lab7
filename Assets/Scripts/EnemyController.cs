using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject wps;
    private List<GameObject> wpsList;
    public NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        wpsList = new List<GameObject>();
        foreach(Transform child in wps.transform)
        {
            wpsList.Add(child.gameObject);
        }
        agent.SetDestination(wpsList[Random.Range(0, wpsList.Count - 1)].transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
            agent.SetDestination(wpsList[Random.Range(0, wpsList.Count - 1)].transform.position);
        }
    }

    public void setNewAgentDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        animator.SetBool("isHunting", true);
    }
}
