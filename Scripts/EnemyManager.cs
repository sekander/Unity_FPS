using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;
    public Animator enemyAnimator;
    public float damage = 20.0f;
    public float health = 100;
    private bool attacking;
    public bool gotHit = false;

    Rigidbody rigidbody;
    public GameManager gameManager;

    // Start is called before the first frame update
    public void Hit(float damage)
    {
        health -= damage;

        enemyAnimator.SetTrigger("isHit");



        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            Destroy(gameObject);
        }
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Distance Between Player: " + Vector3.Distance(transform.position, player.transform.position));

        if(!attacking ||
            Vector3.Distance(transform.position, player.transform.position) > 5.0f
        )
            GetComponent<NavMeshAgent>().destination = player.transform.position;        

        if(GetComponent<NavMeshAgent>().velocity.magnitude > 0)
            enemyAnimator.SetBool("isRunning", true);
        else
            enemyAnimator.SetBool("isRunning", false);


        //Check enemy distance with player to activate attack
        if(Vector3.Distance(transform.position, player.transform.position) < 2.0f)
        {
            attacking = true;
            rigidbody.velocity = Vector3.zero;
            enemyAnimator.SetBool("isAttacking", true);
        }
        else if(Vector3.Distance(transform.position, player.transform.position) > 2.0f)
        {
            attacking = false;
            enemyAnimator.SetBool("isAttacking", false);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            Debug.Log("Player got hit");
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
