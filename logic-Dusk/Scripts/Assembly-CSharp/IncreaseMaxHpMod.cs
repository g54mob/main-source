using UnityEngine;

public class IncreaseMaxHpMod : IModification
{
	private const float HP_INCREASE_VALUE = 10f;

	private string _name;

	private NonVisualDrone _targetDrone;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.IncreaseDroneHealth;
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
			return "increases drone's maximum health";
		}
	}

	public string TargetName
	{
		get
		{
			return ((IInventoryItem)_targetDrone).Name;
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
			return 10;
		}
	}

	public IncreaseMaxHpMod()
	{
		_name = string.Format("Increase max HP by {0}", 10f);
	}

	public void SetTarget(object itemToReceiveMod)
	{
		_targetDrone = itemToReceiveMod as NonVisualDrone;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetDrone == null)
		{
			Debug.LogError("target drone is null!!!");
			return false;
		}
		if ((_targetDrone.IsDead && !_targetDrone.CanBeFullyRepaired) || _targetDrone.TotalHitpoints == 500f)
		{
			return false;
		}
		return true;
	}

	public void ApplyModToTarget()
	{
		if (_targetDrone == null)
		{
			Debug.LogError("target drone is null!!!");
			return;
		}
		_targetDrone.OverrideTotalHitpoints(Mathf.Min(_targetDrone.TotalHitpoints + 10f, 500f));
		_targetDrone.OverrideCurrentHitpoints(Mathf.Min(_targetDrone.CurrentHitPoints + 10f, _targetDrone.TotalHitpoints));
		_targetDrone.AppliedModifications |= ModificationStorageId;
	}

	public IModification CopyModification()
	{
		IModification modification = new IncreaseMaxHpMod();
		modification.SetTarget(_targetDrone);
		return modification;
	}
}
