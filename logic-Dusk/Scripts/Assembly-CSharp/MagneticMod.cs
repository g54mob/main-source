using UnityEngine;

public class MagneticMod : IModification
{
	private BaseDroneUpgrade _targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.MagneticMod;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Magnetic clamp";
		}
	}

	public string Description
	{
		get
		{
			return "magnetically clamps item in room to prevent being pulled outside of ship";
		}
	}

	public string TargetName
	{
		get
		{
			return _targetUpgrade.Name;
		}
	}

	public int ScrapCost
	{
		get
		{
			return -3;
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
		_targetUpgrade = itemToReceiveMod as BaseDroneUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetUpgrade == null)
		{
			Debug.LogError("target upgrade is null!!!");
			return false;
		}
		if (_targetUpgrade.IsBroken || (_targetUpgrade.AppliedModifications & ModificationStorageIdEnum.MagneticMod) == ModificationStorageIdEnum.MagneticMod)
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
		_targetUpgrade.AppliedModifications |= ModificationStorageId;
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetUpgrade, out parentKey);
		_targetUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new MagneticMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
