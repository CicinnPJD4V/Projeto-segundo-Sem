using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemyDataSO enemyData;

    public PatrolRouteManager myPatrolRoute;
    
    private float _moveSpeed;

    private int _maxHealthPoints;

    private GameObject _enemyMesh;

    public float FollowDistance => _followDistance;
    public float _followDistance; //x = distancia minima pro inimigo seguir o jogador

    public float ReturnDistance => _returnDistance;
    public float _returnDistance; //z = distancia maxima pro inimigo seguir o jogador

    public float AttackDistance => _attackDistance;
    public float _attackDistance; //y = distancia minima pro inimigo atacar o jogador

    public float GiveUpDistance => _giveUpDistance;
    public float _giveUpDistance; //w = distancia maxima pro inimigo atacar o jogador

    private int _currentHealthPoints;

    private float _currentMoveSpeed;

    private Animator _enemyFSM;

    private NavMeshAgent _navMeshAgent;

    private SphereCollider _sphereCollider;

    private Transform _playerTransform;

    private Transform _currentPatrolPoint;

    private Transform _nextPatrolPoint;

    private int _currentPatrolIndex;

    private void Awake()
    {
        _moveSpeed = enemyData.moveSpeed;
        _maxHealthPoints = enemyData.maxHealthPoints;

        //_enemyMesh = Instantiate(enemyData.enemyMesh, transform);

        _followDistance = enemyData.followDistance;
        _returnDistance = enemyData.returnDistance;
        _attackDistance = enemyData.attackDistance;
        _giveUpDistance = enemyData.giveUpDistance;

        _currentHealthPoints = _maxHealthPoints;
        _currentMoveSpeed = _moveSpeed;

        _enemyFSM = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _sphereCollider = GetComponent<SphereCollider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _currentPatrolIndex = 0;
        _currentPatrolPoint = myPatrolRoute.patrolRoutePoints[_currentPatrolIndex];
    }

    public void Patrulhar()
    {

        List<Transform> pos = myPatrolRoute.patrolRoutePoints;
        Transform posAtual = pos[0];
        _navMeshAgent.SetDestination(posAtual.position);
        posAtual = pos[1];
        _navMeshAgent.SetDestination(posAtual.position);
        posAtual = pos[2];
        _navMeshAgent.SetDestination(posAtual.position);
        posAtual = pos[3];
        _navMeshAgent.SetDestination(posAtual.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyFSM.GetCurrentAnimatorStateInfo(0).IsName("Return"))
        {
            _enemyFSM.SetFloat("ReturnDistance",
                Vector3.Distance(transform.position, _currentPatrolPoint.position));
        }
    }

    public void SetSphereRadius(float value)
    {
        _sphereCollider.radius = value;
    }

    public void SetDestinationToPlayer()
    {
        //transform.position += (_playerTransform.position - transform.position).normalized * _moveSpeed * Time.deltaTime;
        _navMeshAgent.SetDestination(_playerTransform.position);
    }

    public void SetDestinationToPatrol()
    {
        _navMeshAgent.SetDestination(_currentPatrolPoint.position);
    }

    public void ResetPlayerTransform()
    {
        _playerTransform = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerTransform = other.transform;
            _enemyFSM.SetTrigger("OnPlayerEntered");
            Debug.Log("Jogador entrou na area");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _enemyFSM.SetTrigger("OnPlayerExited");
            Debug.Log("Jogador saiu da area");
        }
    }
}
