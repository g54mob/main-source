using UnityEngine;

public class RepairShipUpgradeMod : IModification
{
	private BaseShipUpgrade _targetUpgrade;

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
			return "Repairs the upgrade";
		}
	}

	public string Description
	{
		get
		{
			return "repairs the upgrade back to full working order";
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
			if (_targetUpgrade.BreakProbability >= 1f)
			{
				int num = 0;
				if (_targetUpgrade.BreakProbability > 30f)
				{
					return -12;
				}
				if (_targetUpgrade.BreakProbability <= 6.8f)
				{
					return -8;
				}
				if (_targetUpgrade.BreakProbability <= 12.6f)
				{
					return -9;
				}
				if (_targetUpgrade.BreakProbability <= 18.4f)
				{
					return -10;
				}
				if (_targetUpgrade.BreakProbability <= 24.2f)
				{
					return -11;
				}
				return -12;
			}
			return 0;
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
		_targetUpgrade = itemToReceiveMod as BaseShipUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetUpgrade == null)
		{
			Debug.LogError("target upgrade is null!!!");
			return false;
		}
		if (_targetUpgrade.BreakProbability < 1f || _targetUpgrade.BrokenState == BrokenStateEnum.Broken)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetUpgrade == null)
		{
			Debug.LogError("target upgrade is null!!!");
			return;
		}
		string fixMessage = string.Empty;
		_targetUpgrade.Fix(out fixMessage);
		string parentKey = UniverseSaveFile.Get(_targetUpgrade.GroupKey, "P", string.Empty);
		string parentKey2;
		int shipUpgradeSlot = GalaxyMapManager.GetShipUpgradeSlot(_targetUpgrade, out parentKey2);
		_targetUpgrade.SaveData(parentKey, shipUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairShipUpgradeMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
