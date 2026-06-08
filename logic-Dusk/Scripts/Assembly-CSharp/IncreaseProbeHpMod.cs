using UnityEngine;

public class IncreaseProbeHpMod : IModification
{
	private ProbeUpgrade _targetProbeUpgrade;

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
			return "Greatly increase probe HP";
		}
	}

	public string Description
	{
		get
		{
			return "adds armor to the probe";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetProbeUpgrade).Name;
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
		_targetProbeUpgrade = itemToReceiveMod as ProbeUpgrade;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetProbeUpgrade == null)
		{
			Debug.LogError("target probe upgrade is null!!!");
			return false;
		}
		if (_targetProbeUpgrade.IsBroken || _targetProbeUpgrade.HasIncreasedHealthMod)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetProbeUpgrade == null)
		{
			Debug.LogError("target probe upgrade is null!!!");
			return;
		}
		_targetProbeUpgrade.AppliedModifications |= ModificationStorageId;
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetProbeUpgrade, out parentKey);
		_targetProbeUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new IncreaseProbeHpMod();
		modification.SetTarget(_targetProbeUpgrade);
		return modification;
	}
}
