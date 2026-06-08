using UnityEngine;

public class TeleportMod : IModification
{
	private BaseDroneUpgrade _targetUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.TeleportMod;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Teleport Droppable Items";
		}
	}

	public string Description
	{
		get
		{
			return "teleport sensors and traps dropped in room to any other room in the ship";
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
		if (_targetUpgrade.IsBroken || (_targetUpgrade.AppliedModifications & ModificationStorageIdEnum.TeleportMod) == ModificationStorageIdEnum.TeleportMod)
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
		IModification modification = new TeleportMod();
		modification.SetTarget(_targetUpgrade);
		return modification;
	}
}
