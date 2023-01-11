using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ShooterState
{
    Idle,
    WalkToEnemy,
    Attack,
    Die
}

public class Shooter : Unit
{
    [SerializeField] private Enemy TargetEnemy;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private float _attackPeriod;
    [SerializeField] private Animator _animator;
    private float _timer = 0f;
    public ShooterState CurrentUnitState;
    public NavMeshAgent navMeshAgent;

    public override void Start()
    {
        base.Start();
        SetState(ShooterState.WalkToEnemy);
    }

    void Update()
    {
        if (CurrentUnitState == ShooterState.Idle)
        {
            FindClosestEnemy();
            _animator.SetBool("Idle", true);
        }
        else if (CurrentUnitState == ShooterState.Attack)
        {
            if (TargetEnemy)
            {
                navMeshAgent.SetDestination(TargetEnemy.transform.position);
                float distance = Vector3.Distance(transform.position, TargetEnemy.transform.position);
                if (distance > _distanceToAttack)
                {
                    SetState(ShooterState.WalkToEnemy);
                }
                _timer += Time.deltaTime;
                if (_timer > _attackPeriod)
                {
                    _timer = 0;
                    TargetEnemy.TakeDamage(1);
                    _animator.SetTrigger("Attack");
                }
            }
            else
            {
                SetState(ShooterState.Idle);
            }

        }
        else if (CurrentUnitState == ShooterState.Die)
        {

        }
    }

    public void SetState(ShooterState unitState)
    {

        CurrentUnitState = unitState;
        if (CurrentUnitState == ShooterState.Idle)
        {

        }
        else if (CurrentUnitState == ShooterState.WalkToEnemy)
        {
            FindClosestEnemy();
            navMeshAgent.SetDestination(TargetEnemy.transform.position);

        }
        else if (CurrentUnitState == ShooterState.Attack)
        {


        }
        else if (CurrentUnitState == ShooterState.Die)
        {

        }
    }

    public void FindClosestEnemy()
    {
        Enemy[] allEnemys = FindObjectsOfType<Enemy>();

        float minDistance = Mathf.Infinity;
        Enemy closestEnemy = null;

        for (int i = 0; i < allEnemys.Length; i++)
        {
            float distance = Vector3.Distance(transform.position, allEnemys[i].transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestEnemy = allEnemys[i];
            }
        }
        TargetEnemy = closestEnemy;
    }
}
