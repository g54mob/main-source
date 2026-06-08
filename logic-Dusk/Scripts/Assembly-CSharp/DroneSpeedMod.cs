using UnityEngine;

public class DroneSpeedMod : IModification
{
	private const float SPEED_INCREASE_FACTOR = 1.35f;

	private NonVisualDrone _targetDrone;

	public ModificationStorageIdEnum ModificationStorageId
	{
		get
		{
			return ModificationStorageIdEnum.DroneSpeed;
		}
	}

	public string DisplayName
	{
		get
		{
			return "Increase speed by 35%";
		}
	}

	public string Description
	{
		get
		{
			return "increases drone's speed";
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
			return 1;
		}
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
		if ((_targetDrone.IsDead && !_targetDrone.CanBeFullyRepaired) || (_targetDrone.AppliedModifications & ModificationStorageIdEnum.DroneSpeed) != ModificationStorageIdEnum.None)
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
		_targetDrone.OriginalSpeed *= 1.35f;
		_targetDrone.AppliedModifications |= ModificationStorageId;
	}

	public IModification CopyModification()
	{
		IModification modification = new DroneSpeedMod();
		modification.SetTarget(_targetDrone);
		return modification;
	}
}
