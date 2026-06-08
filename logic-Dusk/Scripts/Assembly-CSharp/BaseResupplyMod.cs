using UnityEngine;

public abstract class BaseResupplyMod : IModification
{
	protected string _name;

	protected BaseDroneUpgrade _targetUpgrade;

	public virtual ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public virtual string DisplayName
	{
		get
		{
			return _name;
		}
	}

	public abstract string Description { get; }

	public virtual string TargetName
	{
		get
		{
			return (_targetUpgrade == null) ? "n/a" : _targetUpgrade.Name;
		}
	}

	public virtual int ScrapCost
	{
		get
		{
			return -2;
		}
	}

	public abstract int MaxAllowed { get; }

	protected abstract int ResourceIncreaseValue { get; }

	public void SetTarget(object itemToReceiveMod)
	{
		if (itemToReceiveMod is BaseDroneUpgrade && itemToReceiveMod is IStorageUpgrade)
		{
			_targetUpgrade = (BaseDroneUpgrade)itemToReceiveMod;
		}
	}

	public bool CanApplyModToTarget()
	{
		if (_targetUpgrade == null)
		{
			Debug.LogError("target upgrade is null!!!");
			return false;
		}
		if (_targetUpgrade.IsBroken || ((IStorageUpgrade)_targetUpgrade).Quantity == ((IStorageUpgrade)_targetUpgrade).Capacity)
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
		((IStorageUpgrade)_targetUpgrade).OverrideQuantity(Mathf.Min(((IStorageUpgrade)_targetUpgrade).Quantity + ResourceIncreaseValue, ((IStorageUpgrade)_targetUpgrade).Capacity));
		string parentKey;
		int droneUpgradeSlot = GalaxyMapManager.GetDroneUpgradeSlot(_targetUpgrade, out parentKey);
		_targetUpgrade.SaveData(parentKey, droneUpgradeSlot);
	}

	public abstract IModification CopyModification();
}
