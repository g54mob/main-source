using UnityEngine;

public class ShieldRechargeMod : IModification
{
	private ShieldUpgrade _targetShieldUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.ShieldRecharge;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Shield recharges but has lower health";
		}
	}

	public string Description
	{
		get
		{
			return "adds an auto-charge mod to the shield at the expense of a lower maximum health";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetShieldUpgrade).Name;
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
		_targetShieldUpgrade = itemToReceiveMod as ShieldUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetShieldUpgrade == null)
		{
			Debug.LogError("target shield upgrade is null!!!");
			return false;
		}
		if (_targetShieldUpgrade.IsBroken || _targetShieldUpgrade.HasRechargeMod)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetShieldUpgrade == null)
		{
			Debug.LogError("target shield upgrade is null!!!");
			return;
		}
		_targetShieldUpgrade.AppliedModifications |= ModificationStorageIdEnum.ShieldRecharge;
		_targetShieldUpgrade.OverrideCurrentHitpoints(_targetShieldUpgrade.TotalHitpoints);
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetShieldUpgrade, out parentKey);
		_targetShieldUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new ShieldRechargeMod();
		modification.SetTarget(_targetShieldUpgrade);
		return modification;
	}
}
