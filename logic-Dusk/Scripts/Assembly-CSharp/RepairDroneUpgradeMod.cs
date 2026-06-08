using UnityEngine;

public class RepairDroneUpgradeMod : IModification
{
	private BaseDroneUpgrade _targetUpgrade;

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
				num = ((_targetUpgrade.BreakProbability > 30f) ? (-12) : ((_targetUpgrade.BreakProbability <= 6.8f) ? (-8) : ((_targetUpgrade.BreakProbability <= 12.6f) ? (-9) : ((_targetUpgrade.BreakProbability <= 18.4f) ? (-10) : ((!(_targetUpgrade.BreakProbability <= 24.2f)) ? (-12) : (-11))))));
				if (_targetUpgrade is GathererUpgrade || _targetUpgrade is GeneratorUpgrade)
				{
					num += 2;
				}
				return num;
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

	public RepairDroneUpgradeMod()
	{
		int num = 0;
		num++;
	}

	public void SetTarget(object itemToReceiveMod)
	{
		_targetUpgrade = itemToReceiveMod as BaseDroneUpgrade;
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
		_targetUpgrade.NonInGameFix();
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetUpgrade, out parentKey);
		_targetUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairDroneUpgradeMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
