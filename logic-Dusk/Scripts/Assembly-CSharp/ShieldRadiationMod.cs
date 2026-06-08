using UnityEngine;

public class ShieldRadiationMod : IModification
{
	private ShieldUpgrade _targetShieldUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.ShieldRadiation;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Radiation-proof shield";
		}
	}

	public string Description
	{
		get
		{
			return "protects shield from radiation (no damage)";
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
			return -6;
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
		if (_targetShieldUpgrade.IsBroken || _targetShieldUpgrade.HasRadiationMod)
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
		_targetShieldUpgrade.AppliedModifications |= ModificationStorageIdEnum.ShieldRadiation;
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetShieldUpgrade, out parentKey);
		_targetShieldUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new ShieldRadiationMod();
		modification.SetTarget(_targetShieldUpgrade);
		return modification;
	}
}
