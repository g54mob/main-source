using UnityEngine;
using UnityEngine.AI;

public class ReturnBoxToRack : Baker.IState
{
	private Baker m_Baker;

	private NavMeshAgent m_Agent;

	private bool m_IsReached;

	private RackSlot m_TargetRackSlot;

	private int m_ProductID;

	public ReturnBoxToRack(Baker baker)
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

	private void PlaceBox()
	{
	}
}
