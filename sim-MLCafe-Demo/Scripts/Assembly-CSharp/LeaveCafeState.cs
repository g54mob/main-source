using UnityEngine;

public class LeaveCafeState : FSMState
{
	private float destroyTimer = 8f;

	private bool assigned;

	private bool arrivedEarly;

	private bool arrivedCafeEntrance;

	public override void AssignTarget()
	{
		if (arrivedCafeEntrance)
		{
			agent.GetComponent<CustomerCore>().GetCustomerUIInfo().HideInfo();
			moveTarget = agent.GetComponent<CustomerCore>().GetSpawnPoint();
			if (CafeShopManager.IsCustomerInsideCafe(agent.GetComponent<CustomerCore>()))
			{
				CafeShopManager.CustomerLeft(agent.GetComponent<CustomerCore>());
			}
			assigned = true;
		}
		else
		{
			moveTarget = CafeShopManager.GetEntrancePointInside();
		}
	}

	public override void OnArrive()
	{
		if (arrivedCafeEntrance)
		{
			if (agent.GetComponent<CustomerCore>().GetCupSocket().IsHoldingItem())
			{
				CafeShopManager.OnCupWasTakenAway.Invoke();
			}
			routine.manager.Stop();
			CustomerManager.UnregisterCustomer(agent.GetComponent<CustomerCore>());
			arrivedEarly = true;
		}
		else
		{
			arrivedCafeEntrance = true;
			CafeShopManager.TryOpenEntranceDoor();
			AssignTarget();
			ReEnterState();
		}
	}

	public override void OnContinousUpdate()
	{
		base.OnContinousUpdate();
		if (!arrivedEarly && assigned)
		{
			if (destroyTimer > 0f)
			{
				destroyTimer -= Time.deltaTime;
				return;
			}
			routine.manager.Stop();
			CustomerManager.UnregisterCustomer(agent.GetComponent<CustomerCore>());
		}
	}

	public override void OnUpdate()
	{
	}
}
