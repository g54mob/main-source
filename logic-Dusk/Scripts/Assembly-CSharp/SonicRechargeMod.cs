using UnityEngine;

public class SonicRechargeMod : IModification
{
	private SonicUpgrade _targetSonicUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.SonicRecharge;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Recharge to full";
		}
	}

	public string Description
	{
		get
		{
			return "one-time recharge of sonic";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetSonicUpgrade).Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -2;
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
		_targetSonicUpgrade = itemToReceiveMod as SonicUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetSonicUpgrade == null)
		{
			Debug.LogError("target sonic upgrade is null!!!");
			return false;
		}
		if (_targetSonicUpgrade.IsBroken || (_targetSonicUpgrade.AppliedModifications & ModificationStorageIdEnum.SonicRecharge) == ModificationStorageIdEnum.SonicRecharge || _targetSonicUpgrade.CurrentPower >= _targetSonicUpgrade.TotalPower)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetSonicUpgrade == null)
		{
			Debug.LogError("target sonic upgrade is null!!!");
			return;
		}
		_targetSonicUpgrade.OverridePower(_targetSonicUpgrade.TotalPower);
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetSonicUpgrade, out parentKey);
		_targetSonicUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new SonicRechargeMod();
		modification.SetTarget(_targetSonicUpgrade);
		return modification;
	}
}
