using UnityEngine;
using UnityEngine.AI;

public class DropBoxState : Baker.IState
{
	private Baker m_Baker;

	private NavMeshAgent m_Agent;

	private bool m_IsReached;

	public DropBoxState(Baker baker)
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
}
