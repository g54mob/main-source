using UnityEngine;

public class ArriveAtCafeState : FSMState
{
	[SerializeField]
	private FSMState goToCounterState;

	private bool checkCafeOpening = true;

	public override void AssignTarget()
	{
		if (checkCafeOpening)
		{
			moveTarget = CafeShopManager.GetEntrancePointOutside();
			return;
		}
		moveTarget = CafeShopManager.GetEntrancePointInside();
		CafeShopManager.TryOpenEntranceDoor();
		if (!CafeShopManager.IsCustomerInsideCafe(agent.GetComponent<CustomerCore>()))
		{
			CafeShopManager.NewCustomerArrived(agent.GetComponent<CustomerCore>());
		}
	}

	public override void OnArrive()
	{
		if (checkCafeOpening && CafeShopManager.IsCafeOpen())
		{
			checkCafeOpening = false;
			AssignTarget();
			ReEnterState();
		}
	}

	public override void OnUpdate()
	{
	}
}
