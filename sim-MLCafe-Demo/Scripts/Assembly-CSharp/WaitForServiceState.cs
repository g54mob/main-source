using UnityEngine;

public class WaitForServiceState : FSMState
{
	public ServiceCounterComponent assignedCounter;

	public QuelinePoint assignedPoint;

	private CustomerUIInfo info;

	[SerializeField]
	private int quePosition;

	[SerializeField]
	private int waitingCount = 200;

	[SerializeField]
	private int maxWaitingCount = 200;

	private int waitCounter;

	private bool wait;

	public int GetCurrentWaitingCount()
	{
		return waitCounter;
	}

	public int GetMaxWaitCount()
	{
		return maxWaitingCount;
	}

	public override void OnInit()
	{
		wait = GameModeManager.GetGameModeValue<bool>("gm_customer_waitqueue_use");
		maxWaitingCount = GameModeManager.GetGameModeValue<int>("gm_customer_waitqueue_amount");
		maxWaitingCount = Mathf.RoundToInt((float)maxWaitingCount * AnomalyManager.GetAnomalyProperties().customer_waitcount_multiplier);
	}

	public override void AssignTarget()
	{
		moveTarget = assignedPoint.GetPoint();
		if (wait && CafeShopManager.IsCafeOpen())
		{
			waitCounter = 0;
		}
	}

	public override void OnArrive()
	{
	}

	public override void OnContinousUpdate()
	{
		base.OnContinousUpdate();
		if (!wait)
		{
			return;
		}
		int num = maxWaitingCount / 2;
		if (waitCounter >= num)
		{
			if (!CafeShopManager.IsCafeOpen())
			{
				PopClosingUI(num);
			}
			else if (waitCounter <= maxWaitingCount)
			{
				PopWaitingUI(num);
			}
		}
	}

	public override void OnUpdate()
	{
		CustomerCore component = agent.GetComponent<CustomerCore>();
		component.TrySpawnDirt();
		info = component.GetCustomerUIInfo();
		if (waitCounter > maxWaitingCount && wait)
		{
			Dismiss();
			component.WaitedTooLongForService();
			return;
		}
		if (assignedCounter == null || assignedPoint == null)
		{
			routine.ChangeState(routine.GetPreviousState());
		}
		quePosition = assignedCounter.GetQuePosition(assignedPoint);
		if (assignedCounter.IsNextPositionFree(assignedPoint))
		{
			assignedPoint.Free();
			assignedPoint = assignedCounter.GetNextPosition(quePosition);
			assignedPoint.BookPoint(agent.transform);
			navAgent.ResetPath();
			moveTarget = assignedPoint.GetPoint();
			if (info != null)
			{
				info.HideInfo();
			}
			ReEnterState();
		}
		else if (wait)
		{
			waitCounter += (CafeShopManager.IsCafeOpen() ? 1 : 4);
		}
	}

	private void Dismiss()
	{
		if (assignedPoint != null)
		{
			assignedPoint.Free();
		}
		routine.ChangeRoutineTo(routine.manager.dismissRoutine);
		if (info != null)
		{
			info.HideInfo();
		}
	}

	private void PopWaitingUI(int minimum)
	{
		if (info == null)
		{
			info = agent.GetComponent<CustomerCore>().GetCustomerUIInfo();
		}
		if (!info.IsVisible())
		{
			info.PopWaitingDuration(waitCounter, minimum, maxWaitingCount);
		}
		info.UpdateFillAndColor(waitCounter, minimum, maxWaitingCount);
	}

	private void PopClosingUI(int minimum)
	{
		if (info == null)
		{
			info = agent.GetComponent<CustomerCore>().GetCustomerUIInfo();
		}
		if (!info.IsVisible())
		{
			info.PopClosingDuration(waitCounter, minimum, maxWaitingCount);
		}
		else
		{
			info.SetIconClosing();
		}
		info.UpdateFillAndColor(waitCounter, minimum, maxWaitingCount);
	}
}
