using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum UnitState
{
    Idle,
    WalkToEnemy,
    Attack,
    Die
}

public class Knight : Unit
{
    [SerializeField] private Enemy TargetEnemy;
    [SerializeField] private float _distanceToAttack;
    [SerializeField] private float _attackPeriod;
    [SerializeField] private Animator _animator;
    private float _timer = 0f;
    public UnitState CurrentUnitState;
    public NavMeshAgent navMeshAgent;

   public override void Start()
    {
        base.Start();
        SetState(UnitState.WalkToEnemy);
    }

    void Update()
    {
        if (CurrentUnitState == UnitState.Idle)
        {
            FindClosestEnemy();
        }
        else if (CurrentUnitState == UnitState.WalkToEnemy)
        {
            if (TargetEnemy)
            {
                _animator.SetBool("Run", true);
                FindClosestEnemy();
                navMeshAgent.SetDestination(TargetEnemy.transform.position);
                float distance = Vector3.Distance(transform.position, TargetEnemy.transform.position);
                if (distance < _distanceToAttack)
                {
                    SetState(UnitState.Attack);
                }
            }
        }
        else if (CurrentUnitState == UnitState.Attack)
        {
            if (TargetEnemy)
            {
                navMeshAgent.SetDestination(TargetEnemy.transform.position);
                float distance = Vector3.Distance(transform.position, TargetEnemy.transform.position);
                if (distance > _distanceToAttack)
                {
                    SetState(UnitState.WalkToEnemy);
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
                SetState(UnitState.Idle);
            }

        }
        else if (CurrentUnitState == UnitState.Die)
        {

        }
    }

    public void SetState(UnitState unitState)
    {

        CurrentUnitState = unitState;
        if (CurrentUnitState == UnitState.Idle)
        {

        }
        else if (CurrentUnitState == UnitState.WalkToEnemy)
        {
            FindClosestEnemy();
            navMeshAgent.SetDestination(TargetEnemy.transform.position);

        }
        else if (CurrentUnitState == UnitState.Attack)
        {


        }
        else if (CurrentUnitState == UnitState.Die)
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
