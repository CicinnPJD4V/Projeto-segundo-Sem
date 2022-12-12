using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnamyDataSO enemyData;

    public PatrolRouteManeger myPatrolRoute;
    
    private float _moveSpeed;

    private int _maxHealthPoints;

    private GameObject _enemyMesh;


    public float FollowDistance => _followDistance;
    public float _followDistance; //x
    
    public float ReturnDistance => _returnDistance;
    public float _returnDistance; //z
    
    public float AttackDistance => _attackDistance;
    public float _attackDistance; //y

    public float GeviUpDistance => _geviUpDistance;
    public float _geviUpDistance; //w


    private int _currentHealthPoints;

    private float _currentMoveSpeed;

    private Animator _enemyFSM;
    private NavMeshAgent _navMeshAgent;

    private SphereCollider _sphereCollider;

    private void Awake()
    {
        _moveSpeed = enemyData.moveSpeed;
        _maxHealthPoints = enemyData.maxHealthPoints;

       // _enemyMesh = Instantiate(enemyData.enemyMesh, transform);

        _followDistance = enemyData.followDistance;
        _returnDistance = enemyData.returnDistance;
        _attackDistance = enemyData.attackDistance;
        _geviUpDistance = enemyData.geviUpDistance;

        _currentHealthPoints = _maxHealthPoints;
        _currentMoveSpeed = _moveSpeed;

        _enemyFSM = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _sphereCollider = GetComponent<SphereCollider>();

    }
    

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void SetSphereRadius(float value)
    {
        _sphereCollider.radius = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Jogador entrou na area");
        }
    }
}




