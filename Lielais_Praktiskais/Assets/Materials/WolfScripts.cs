using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfScripts : MonoBehaviour
{
    public Transform player;
    private Animator anim;
    public float speed;
    public float alertDistance;
    public float walkingDistance;
    public float attackingDistance;
    private Vector3 Direction;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //idle


        //walk


        //run


        //attack
        if (Vector3.Distance(player.position, transform.position) < alertDistance &&
        Vector3.Distance(player.position, transform.position) > attackingDistance)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isAlert", true);
            anim.SetBool("isCreep", false);
            anim.SetBool("isIdle", false);
        }
        else if (Vector3.Distance(player.position, transform.position) <= walkingDistance)
        {
            Direction = player.position - transform.position;
            Direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Direction), 0.9f * Time.deltaTime);

            transform.Translate(0, 0, speed);

            anim.SetBool("isWalk", true);   
            anim.SetBool("isCreep", false);
            anim.SetBool("isAlert", false);
            anim.SetBool("isIdle", false);

            if(Direction.magnitude <= attackingDistance)
            {
                anim.SetBool("isCreep", true);
                anim.SetBool("isWalk", false);
            }
        }
        else if (anim.GetBool("isIdle") == false)
        {
            anim.SetBool("isWalk", false);
            anim.SetBool("isCreep", false);
            anim.SetBool("isAlert", false);
            anim.SetBool("isIdle", true);
        }
    }
}