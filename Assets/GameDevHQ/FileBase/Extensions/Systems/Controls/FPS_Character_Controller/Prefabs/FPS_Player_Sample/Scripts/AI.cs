using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AI : MonoBehaviour
{
    private enum AIState
    {
        Walking,
        Jumping,
        Shooting,
        Death
    }


    [SerializeField] private Transform[] _wayPoints;
    private NavMeshAgent _agent;
    private int _currentPoint = 0;
    private bool _reverse;
    private bool _attacking;
    [SerializeField]private AIState _currentState;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _wayPoints[_currentPoint].transform.position;
    }
    private void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            _currentState = AIState.Jumping;
            _agent.isStopped = true;
        }

        switch (_currentState)
        {
            case AIState.Walking:
                _agent.isStopped = false;
             CalculateMovement();                    
                break;
            case AIState.Jumping:             
                break;
            case AIState.Shooting:
                StartCoroutine("AttackWait");
                break;
            case AIState.Death:
                break;
        }

    }

    private void CalculateMovement()
    {
        if (_agent.remainingDistance < 0.5f)
        {
            if (_reverse == true)
            {
                Reverse();
            }
            else
            {
                Forward();
            }
            _agent.SetDestination(_wayPoints[_currentPoint].position);

           
            _currentState = AIState.Shooting;        
        }
    }

   private  IEnumerator AttackWait()
    {
        if (_attacking==true)
        {
            yield break;
        }

        else if (_attacking==false)
        {
            _attacking = true;
            _agent.isStopped = true;
            yield return new WaitForSeconds(3);
            _attacking = false;
            _currentState = AIState.Walking;
        }
     
    }

    private void Reverse()
    {
          if (_currentPoint == 0)
        {
            _reverse = false;
            _currentPoint++;
        }

          else
        {
            _currentPoint--;
        }
    }

    private void Forward()
    {
        if (_currentPoint == _wayPoints.Length - 1)
        {
            _reverse = true;
            _currentPoint--;
        }
        else
        {
            _currentPoint++;
        }
    }

}
