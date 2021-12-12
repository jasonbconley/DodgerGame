using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform goal;
    public Transform home;
    NavMeshAgent agent;
    public static bool disable = false;

    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!VolleyBallController.grounded)
        {
            agent.SetDestination(goal.position);
            GetComponent<Animator>().SetBool("idle", false);
            GetComponent<Animator>().SetBool("running", true);
        }
        else
        {
            agent.SetDestination(home.position);
            GetComponent<Animator>().SetBool("running", false);
        }

        if (this.gameObject.transform.position == home.position)
        {
            GetComponent<Animator>().SetBool("idle", true);
        }

        if (disable)
        {
            this.gameObject.GetComponent<EnemyAI>().enabled = false;
        }
    }
}
