using UnityEngine;

public class RepairShipSlotMod : IModification
{
	private SlotInfo _targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Repairs a ship upgrade slot";
		}
	}

	public string Description
	{
		get
		{
			return "repairs the WORST, still working slot back to full health";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetUpgrade).Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -10;
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	public void SetTarget(object itemToReceiveMod)
	{
		_targetUpgrade = null;
	}

	public bool CanApplyModToTarget()
	{
		SlotInfo slotInfo = null;
		float num = float.MinValue;
		if (GlobalSettings.GameState.ThePlayer.MyShip.slotList != null && GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count > 0)
		{
			int count = GlobalSettings.GameState.ThePlayer.MyShip.slotList.Count;
			for (int i = 0; i < count; i++)
			{
				SlotInfo slotInfo2 = GlobalSettings.GameState.ThePlayer.MyShip.slotList[i];
				if (slotInfo2.BrokenState != BrokenStateEnum.Broken && slotInfo2.BreakProbability >= 15f && slotInfo2.BreakProbability > num)
				{
					slotInfo = slotInfo2;
					num = slotInfo2.BreakProbability;
				}
			}
		}
		if (slotInfo != null)
		{
			_targetUpgrade = slotInfo;
			return true;
		}
		return false;
	}

	public void ApplyModToTarget()
	{
		if (_targetUpgrade == null)
		{
			Debug.LogError("target upgrade is null!!!");
		}
		else
		{
			_targetUpgrade.Fix();
		}
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairShipSlotMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
