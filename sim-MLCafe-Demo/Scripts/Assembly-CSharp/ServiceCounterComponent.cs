using System.Linq;
using Lexone.UnityTwitchChat;
using UnityEngine;

public class ServiceCounterComponent : MonoBehaviour
{
	[SerializeField]
	private MoneySpawner moneySpawner;

	[SerializeField]
	private QuelinePoint[] quePoints;

	[SerializeField]
	private Animator animatorBell;

	[SerializeField]
	private string soundBellRing;

	public Item itemReference;

	private void OnDrawGizmos()
	{
		QuelinePoint[] array = quePoints;
		foreach (QuelinePoint quelinePoint in array)
		{
			Gizmos.color = Color.green;
			if (quelinePoint.IsTaken())
			{
				Gizmos.color = Color.red;
			}
			if (quelinePoint.GetPoint() != null)
			{
				Gizmos.DrawWireCube(quelinePoint.GetPoint().position, Vector3.one - Vector3.up);
			}
		}
	}

	private void Start()
	{
		if (base.transform.parent != null && base.transform.parent.GetComponent<RemovableInstance>() != null)
		{
			base.transform.parent.GetComponent<RemovableInstance>().onlyRemovableWhenCafeIsClosed = true;
		}
		CheckQueuePointsUnlockStates();
		ProgressionManager.OnLevelUpProgress.AddListener(delegate
		{
			CheckQueuePointsUnlockStates();
		});
		IRC.Instance.OnConnected.AddListener(CheckTwitchQueuePoints);
		IRC.Instance.OnTwitchSettingsChanged.AddListener(CheckTwitchQueuePoints);
		IRC.Instance.OnDisconnect.AddListener(CheckQueuePointsUnlockStates);
	}

	private void Update()
	{
		if (PreviewSystem.IsPreviewingWithGrid())
		{
			QuelinePoint[] array = quePoints;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ShowPreview();
			}
		}
		else if (quePoints.Any((QuelinePoint p) => p.IsVisible()))
		{
			QuelinePoint[] array = quePoints;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].HidePreview();
			}
		}
	}

	private void CheckTwitchQueuePoints()
	{
		if (!IRC.Instance.isConnected)
		{
			CheckQueuePointsUnlockStates();
			return;
		}
		if (TW_GlobalCommands.queuelineRestriction)
		{
			CheckQueuePointsUnlockStates();
			return;
		}
		QuelinePoint[] array = quePoints;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UnlockPoint();
		}
	}

	private void CheckQueuePointsUnlockStates()
	{
		int currentLevel = ProgressionManager.GetCurrentLevel();
		for (int i = 0; i < quePoints.Length; i++)
		{
			if (i <= currentLevel)
			{
				quePoints[i].UnlockPoint();
			}
			else
			{
				quePoints[i].LockPoint();
			}
		}
	}

	public int GetCustomerCountInQueue()
	{
		int num = 0;
		for (int i = 0; i < quePoints.Length; i++)
		{
			if (quePoints[i].IsTaken())
			{
				num++;
			}
		}
		return num;
	}

	public bool HasCoinsOnCounter()
	{
		return moneySpawner.GetCoins().Count > 0;
	}

	public void Pay(int totalAmount, int price, int tips)
	{
		moneySpawner.SpawnAmount(totalAmount);
		CafeShopManager.AddTips(tips);
		CafeShopManager.AddTurnOver(price);
	}

	public void GrabMoney()
	{
		moneySpawner.TakeAllSpawnedMoney();
	}

	public bool HasFreeQuelinePoint()
	{
		return quePoints.Any((QuelinePoint x) => !x.IsTaken() && !x.IsLocked());
	}

	public bool IsFirstPositionInQue(QuelinePoint point)
	{
		return point == quePoints[0];
	}

	public bool IsNextPositionFree(QuelinePoint point)
	{
		int num = quePoints.ToList().FindIndex((QuelinePoint x) => x.GetPoint() == point.GetPoint());
		if (num > 0)
		{
			if (!quePoints[num - 1].IsTaken())
			{
				return !quePoints[num - 1].IsLocked();
			}
			return false;
		}
		return false;
	}

	public int GetQuePosition(QuelinePoint point)
	{
		return quePoints.ToList().FindIndex((QuelinePoint x) => x.GetPoint() == point.GetPoint());
	}

	public QuelinePoint GetNextPosition(QuelinePoint point)
	{
		int num = quePoints.ToList().FindIndex((QuelinePoint x) => x.GetPoint() == point.GetPoint());
		if (num > 0)
		{
			return quePoints[num - 1];
		}
		return point;
	}

	public QuelinePoint GetNextPosition(int index)
	{
		if (index > 0)
		{
			return quePoints[index - 1];
		}
		return quePoints[index];
	}

	public QuelinePoint GetNextBestPoint(QuelinePoint point)
	{
		QuelinePoint result = null;
		for (int num = quePoints.Length - 1; num >= 0; num--)
		{
			if (!quePoints[num].IsTaken() && !quePoints[num].IsLocked())
			{
				result = quePoints[num];
			}
		}
		return result;
	}

	public QuelinePoint BookNextFreeQuelinePoint(Transform customer)
	{
		quePoints.ToList().Find((QuelinePoint x) => x.HasCustomer(customer))?.Free();
		QuelinePoint quelinePoint = quePoints.First((QuelinePoint x) => !x.IsTaken() && !x.IsLocked());
		quelinePoint.BookPoint(customer);
		return quelinePoint;
	}

	public QuelinePoint GetLastQuelinePoint(Transform customer)
	{
		return quePoints.Last((QuelinePoint x) => !x.IsLocked());
	}

	public void RingDismissBell()
	{
		SoundManager.PlaySoundOnce(soundBellRing);
		animatorBell.SetTrigger("Ring");
		if (!(quePoints[0].GetCustomer() == null) && !quePoints[0].GetCustomer().GetRating().gotServiced)
		{
			quePoints[0].GetCustomer().Dismiss();
			quePoints[0].Free();
		}
	}
}
