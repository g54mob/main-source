using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
	private NavMeshAgent m_Agent;

	private RaycastHit m_HitInfo;

	private void Start()
	{
	}

	private void Update()
	{
	}
}
