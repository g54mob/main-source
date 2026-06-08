using UnityEngine;

public class RepairShieldMod : IModification
{
	private const float HP_INCREASE_VALUE = 100f;

	private string _name;

	private ShieldUpgrade _targetShieldUpgrade;

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
			return _name;
		}
	}

	public string Description
	{
		get
		{
			return "partially repairs the shield's health";
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
			return -1;
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 2;
		}
	}

	public RepairShieldMod()
	{
		_name = string.Format("Repair HP by {0}", 100f);
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
		if (_targetShieldUpgrade.HasRechargeMod || _targetShieldUpgrade.IsBroken || _targetShieldUpgrade.CurrentHitPoints == _targetShieldUpgrade.TotalHitpoints)
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
		_targetShieldUpgrade.OverrideCurrentHitpoints(Mathf.Min(_targetShieldUpgrade.CurrentHitPoints + 100f, _targetShieldUpgrade.TotalHitpoints));
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetShieldUpgrade, out parentKey);
		_targetShieldUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairShieldMod();
		modification.SetTarget(_targetShieldUpgrade);
		return modification;
	}
}
