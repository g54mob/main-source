using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FrozenSearchingState : Baker.IState
{
	private NavMeshAgent m_Agent;

	private Baker m_Baker;

	private Box m_TargetBox;

	private RackSlot m_TargetRackSlot;

	private const float m_RotationSmoothness = 5f;

	public FrozenSearchingState(Baker _baker)
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

	private void LookAt(Vector3 target)
	{
	}

	private Dictionary<int, List<DisplaySlot>> GetRequiredProducts()
	{
		return null;
	}

	private void MoveTo(Vector3 target)
	{
	}

	private Box SearchAvailableBoxFromStreet(int requiredProductID)
	{
		return null;
	}

	private RackSlot SearchAvailableBoxFromRacks(int requiredProductID)
	{
		return null;
	}
}
