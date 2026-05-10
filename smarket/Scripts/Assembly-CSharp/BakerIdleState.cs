using UnityEngine;
using UnityEngine.AI;

public class BakerIdleState : Baker.IState
{
	private float m_IdleTimer;

	private const float m_IdleTimeout = 4f;

	private Baker m_Baker;

	private NavMeshAgent m_Agent;

	private bool m_IsReached;

	private Vector3 m_WaitingPos;

	private Quaternion m_WaitingRot;

	public BakerIdleState(Baker baker)
	{
	}

	public void Enter()
	{
	}

	public void Update()
	{
	}

	public void Exit()
	{
	}

	private void MoveTo(Vector3 target)
	{
	}

	private void LookAt(Vector3 target)
	{
	}
}
