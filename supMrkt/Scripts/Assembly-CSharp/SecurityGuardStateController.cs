using MyBox;
using UnityEngine;

public class SecurityGuardStateController : MonoBehaviour
{
	public enum Status
	{
		Fired = 0,
		Idle = 1,
		Patroling = 2,
		Chasing = 3,
		Collecting = 4,
		Restocking = 5
	}

	public Status CurrentStatus;

	[HideInInspector]
	public SecurityGuard SecurityGuard;

	private SecurityGuardState m_CurrentState;

	private readonly FiredState m_FiredState;

	private readonly IdleState m_IdleState;

	private readonly PatrolingState m_PatrolingState;

	private readonly ChaseState m_ChaseState;

	private readonly CollectingState m_CollectingState;

	private readonly RestockingState m_RestockingState;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void SetState(SecurityGuardState newState)
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Chase()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Idle()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Collecting()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Restocking()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Fired()
	{
	}

	[ButtonMethod(ButtonMethodDrawOrder.AfterInspector)]
	public void Patroling()
	{
	}

	public void OnShoplifterDetected(Shoplifter shoplifter, bool onAlert)
	{
	}
}
