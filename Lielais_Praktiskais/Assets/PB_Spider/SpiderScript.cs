using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderScript : MonoBehaviour
{

    public Transform player;
    public List<GameObject> DestinationPoints;
    private Animator anim;
    public float speed;
    public float alertDistance;
    public float walkingDistance;
    public float attackingDistance;
    public int mintime;
    public int maxtime;
    public float remainingDistance;
  


    private Vector3 Direction;
    private NavMeshAgent agent;
    private int selectedDestination;
    
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.enabled == true && agent.remainingDistance < remainingDistance)
        {
            agent.enabled = false;
            anim.SetBool("isWalking", false);
            anim.SetBool("isIdle", true);
            StartCoroutine(RandomMovement());
        }
        //idle


        //walk


        //run


        //attack
        if (Vector3.Distance(player.position, transform.position) < alertDistance &&
        Vector3.Distance(player.position, transform.position) > walkingDistance)
        {
            agent.enabled = false;
            anim.SetBool("isAlert", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isIdle", false);
        }
        else if (Vector3.Distance(player.position, transform.position) <= walkingDistance)
        {
           
             Direction = player.position - transform.position;
             Direction.y = 0;

             transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), 0.9f * Time.deltaTime);

             transform.Translate(0, 0, speed);  

         

            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isAlert", false);
            anim.SetBool("isIdle", false);

            if (Direction.magnitude <= attackingDistance)
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
        }
        else if (anim.GetBool("isIdle") == false && agent.enabled == false)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isAlert", false);
            anim.SetBool("isIdle", true);
            StartCoroutine(RandomMovement());
        }
    }


    public IEnumerator RandomMovement()
    {
        int index = Random.Range(mintime, maxtime);

        Debug.Log("randomtime" + index);
        yield return new WaitForSeconds(index);


        int index2 = Random.Range(1, 3);
        switch (index2)
        {
            case 1:
                Debug.Log("Keep idle");
                StartCoroutine(RandomMovement());
                break;
            case 2:
                Debug.Log("Move");
                agent.enabled = true;
                int lastDestination = selectedDestination;

                selectedDestination = Random.Range(0, DestinationPoints.Count);

                while (selectedDestination == lastDestination )
                {
                    selectedDestination = Random.Range(0, DestinationPoints.Count);
                }
             
                agent.SetDestination(DestinationPoints[selectedDestination].transform.position);
            
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isAlert", false);
                anim.SetBool("isIdle", false);
                break;
        }

    }

    
}