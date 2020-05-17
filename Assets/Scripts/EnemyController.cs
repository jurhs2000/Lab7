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
        animator.SetBool("isWalking", true);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > agent.stoppingDistance)
        {
            if (agent.speed < 2.5)
            {
                animator.SetBool("isWalking", true);
            }
        } else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isHunting", false);
            setNewRandomPoint();
        }
    }

    public void setNewAgentDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
        animator.SetBool("isHunting", true);
        agent.speed = 2.5f;
    }

    public void setNewRandomPoint()
    {
        agent.SetDestination(wpsList[Random.Range(0, wpsList.Count - 1)].transform.position);
        animator.SetBool("isHunting", false);
        agent.speed = 1.8f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            setNewRandomPoint();
        }
    }
}
