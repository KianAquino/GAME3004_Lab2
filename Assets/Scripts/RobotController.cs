using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;

    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        _agent.SetDestination(_player.position);
    }
}
