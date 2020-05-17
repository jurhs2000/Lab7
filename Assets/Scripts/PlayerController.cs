using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    public Restart restart;
    private Vector3 startPos;
    public Text text;

    private void Start()
    {
        startPos = transform.position;
        restart = FindObjectOfType(typeof(Restart)) as Restart;
        text = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            /*NavMeshHit navMeshHit;
            if (Physics.Raycast(ray, out hit) && NavMesh.SamplePosition(hit.point, out navMeshHit, 0.3f, NavMesh.AllAreas)) {
                agent.SetDestination(navMeshHit.position);
            }*/
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    agent.SetDestination(hit.point);
                    restart.setRestart(false);
                    text.text = "Intenta llegar a la zona azul";
                }
            }
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            restart.restoreNewInstance(startPos);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            restart.restoreNewInstance(startPos);
            Destroy(this.gameObject);
            text.text = "¡GANASTE!";
        }
    }
}
