using UnityEngine;

public class ProbeStealthMod : IModification
{
	private ProbeUpgrade _targetProbeUpgrade;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.ProbeStealth;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Probes have stealth";
		}
	}

	public string Description
	{
		get
		{
			return "adds a stealth modification to the probe";
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
			return -4;
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
		if (_targetProbeUpgrade.IsBroken || _targetProbeUpgrade.HasStealthMod)
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
		IModification modification = new ProbeStealthMod();
		modification.SetTarget(_targetProbeUpgrade);
		return modification;
	}
}
