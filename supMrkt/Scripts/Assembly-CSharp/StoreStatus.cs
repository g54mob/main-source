using System;

public class StoreStatus : NoktaSingletonPunCallbacks<StoreStatus>
{
	public Action<bool> onStoreStatusChanged;

	private bool m_IsOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public bool IsOpen
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Start()
	{
	}

	public void SetIsOpenField(bool value)
	{
	}

	private void NewDayStarted()
	{
	}

	private void DayCycleDisabled()
	{
	}
}
