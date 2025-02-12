using UnityEngine;
using UnityEngine.AI;

public class RobotController : MonoBehaviour
{
    [SerializeField] NavMeshAgent _agent;

    private Transform _player;

    private void Update()
    {
        _player = GameObject.FindWithTag("Player").transform;

        if (_player == null)
            return;

        _agent.SetDestination(_player.position);
    }
}
