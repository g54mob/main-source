using UnityEngine;

public class StealthRechargeMod : IModification
{
	private StealthUpgrade _targetStealthUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.StealthRecharge;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Lasts shorter but recharges very quick";
		}
	}

	public string Description
	{
		get
		{
			return "adds a flash-charge mod to the stealth upgrade at the expense of a lower stealth time";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetStealthUpgrade).Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -5;
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
		_targetStealthUpgrade = itemToReceiveMod as StealthUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetStealthUpgrade == null)
		{
			Debug.LogError("target stealth upgrade is null!!!");
			return false;
		}
		if (_targetStealthUpgrade.IsBroken || _targetStealthUpgrade.HasRechargeMod)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetStealthUpgrade == null)
		{
			Debug.LogError("target stealth upgrade is null!!!");
			return;
		}
		_targetStealthUpgrade.AppliedModifications |= ModificationStorageIdEnum.StealthRecharge;
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetStealthUpgrade, out parentKey);
		_targetStealthUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new StealthRechargeMod();
		modification.SetTarget(_targetStealthUpgrade);
		return modification;
	}
}
