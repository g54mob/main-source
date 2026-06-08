using UnityEngine;

public class RepairFullHpMod : IModification
{
	private const int SCRAP_COST_PER_INCREMENT = 1;

	private const float HP_INCREASE_INCREMENT = 10f;

	private IDrone _targetDrone;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.None;
		}
	}

	public string Description
	{
		get
		{
			return "repairs the drone back to full health";
		}
	}

	public string DisplayName
	{
		get
		{
			if (_targetDrone == null)
			{
				return "null target drone!!";
			}
			return string.Format("Repair full HP {0}", HpToIncrease);
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
			return -(GetNumberOfHpIncrements() * 1);
		}
	}

	public int MaxAllowed
	{
		get
		{
			return 1;
		}
	}

	private float HpToIncrease
	{
		get
		{
			return (float)GetNumberOfHpIncrements() * 10f;
		}
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
			return;
		}
		_targetDrone.OverrideCurrentHitpoints(Mathf.Min(_targetDrone.CurrentHitPoints + HpToIncrease, _targetDrone.TotalHitpoints));
		_targetDrone.TraitVeer = _targetDrone.TraitPermVeer;
	}

	private int GetNumberOfHpIncrements()
	{
		if (_targetDrone == null)
		{
			Debug.LogError("null target drone");
			return 50000;
		}
		int num = (int)(_targetDrone.TotalHitpoints - _targetDrone.CurrentHitPoints) / 10;
		if ((int)(_targetDrone.TotalHitpoints - _targetDrone.CurrentHitPoints) % 10 > 0)
		{
			num++;
		}
		return num;
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairFullHpMod();
		modification.SetTarget(_targetDrone);
		return modification;
	}
}
