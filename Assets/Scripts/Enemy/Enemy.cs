using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Player  target; //si quiero que el target pueda ser otra cosa aparte del palyer cambiar player a gameobject
    public float lookRadius;
    public float attackRate;
    public float damage;
    public float distance;
    NavMeshAgent agent;

    public float totalHP;
    public float currentHP;

    public float maxSpeed;
    public float slowedDownSpeed;
    public float currentSlowDownTime;
    public float slowDownTime;
    public float slowDownVariable;
    public GameObject slowDownParticles;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        target = FindObjectOfType<Player>();
        maxSpeed = agent.speed;
        slowedDownSpeed = maxSpeed / slowDownVariable;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(target.transform.position, transform.position);

        if(currentHP <=0)
        {
            Die();
        }

        if (distance <= lookRadius && currentHP>0)
        {
            MoveTowardsTarget();
        }
        if (distance <= agent.stoppingDistance && currentHP > 0)
        {
            Attack();
        }

        currentSlowDownTime += Time.deltaTime;

        if(currentSlowDownTime>slowDownTime)
        {
            ResumeSpeed();
        }
    }

    private void MoveTowardsTarget()
    {
        agent.SetDestination(target.transform.position);
    }
    private void Attack()
    {
        Player player = target.GetComponent<Player>(); //si quiero poner un segundo target esto deberia cambiar y deberia separar la vida del player a otro scrip
        player.currentHP -= damage;
        
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void SlowDown()
    {
        agent.speed = slowedDownSpeed;
        currentSlowDownTime = 0;
        slowDownParticles.SetActive(true);
    }
     private void ResumeSpeed()
    {
        agent.speed = maxSpeed;
        slowDownParticles.SetActive(false);
    }
}
