using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Prey : Animal
{

    public GameObject robot;
    public bool happiness = false;
    public bool hunger = false;
    public bool energy = false;

    [Header("Prey Variables")]
    [SerializeField] private float detectionRange = 10f;
    [SerializeField] private float escapeMaxDistance = 80f;

    private Predator currentPredator = null;

    public void AlertPrey(Predator predator)
    {
        SetState(AnimalState.Chase);
        currentPredator = predator;
        StartCoroutine(RunFromPredator());
    }

    private IEnumerator RunFromPredator()
    {
        // Wait until the predator is within detection range.
        while (currentPredator == null || Vector3.Distance(transform.position, currentPredator.transform.position) > detectionRange)
        {
            yield return null;
        }

        // Predator detected, so we should run away.
        while (currentPredator != null && Vector3.Distance(transform.position, currentPredator.transform.position) <= detectionRange)
        {
            RunAwayFromPredator();

            yield return null;
        }

        // Predator out of range, run to our final location and go back to idle.
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            yield return null;
        }

        SetState(AnimalState.Idle);
    }

    private void RunAwayFromPredator()
    {
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                Vector3 runDirection = transform.position - currentPredator.transform.position;
                Vector3 escapeDestination = transform.position + runDirection.normalized * (escapeMaxDistance * 2);
                navMeshAgent.SetDestination(GetRandomNavMeshPosition(escapeDestination, escapeMaxDistance));
            }
        }
    }

    protected override void Die()
    {
        if (happiness == true)
        {
            robot.GetComponent<Robot>().updateHappiness(2);
            Debug.Log("happiness");
        }
        if (hunger == true)
        {
            robot.GetComponent<Robot>().updateHunger(2);
            Debug.Log("hunger");
        }
        if (energy == true)
        {
            robot.GetComponent<Robot>().updateEnergy(2);
            Debug.Log("energy");
        }
        StopAllCoroutines();
        base.Die();
        
    }

    private void OnDrawGizmos()
    {

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
