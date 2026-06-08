using UnityEngine;

public class RepairHpMod : IModification
{
	private const float HP_INCREASE_VALUE = 10f;

	private string _name;

	private IDrone _targetDrone;

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
			return "partially repairs the drone's health";
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
			return -1;
		}
	}

	public int MaxAllowed
	{
		get
		{
			if (_targetDrone == null)
			{
				return 1;
			}
			return (int)((_targetDrone.TotalHitpoints - _targetDrone.CurrentHitPoints) / 10f);
		}
	}

	public RepairHpMod()
	{
		_name = string.Format("Repair HP by {0}", 10f);
	}

	public void SetTarget(object itemToReceiveMod)
	{
		_targetDrone = itemToReceiveMod as IDrone;
	}

	public bool CanApplyModToTarget()
	{
		if (_targetDrone == null)
		{
			Debug.LogError("target drone is null!!!");
			return false;
		}
		if ((_targetDrone.IsDead && !_targetDrone.CanBeFullyRepaired) || _targetDrone.CurrentHitPoints == _targetDrone.TotalHitpoints)
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
		}
		else
		{
			_targetDrone.OverrideCurrentHitpoints(Mathf.Min(_targetDrone.CurrentHitPoints + 10f, _targetDrone.TotalHitpoints));
		}
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairHpMod();
		modification.SetTarget(_targetDrone);
		return modification;
	}
}
