using UnityEngine;

public class RepairDroneVideoMod : IModification
{
	private NonVisualDrone _targetDrone;

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
			return "Repairs drone's video signal";
		}
	}

	public string Description
	{
		get
		{
			return "repairs the drone's failing video signal";
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
			return -7;
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
		if (_targetDrone.IsDead && !_targetDrone.CanBeFullyRepaired)
		{
			return false;
		}
		return UniverseSaveFile.Get(string.Format("DRONE_{0}", _targetDrone.InternalID), "HASFAILED", false);
	}

	public void ApplyModToTarget()
	{
		if (_targetDrone == null)
		{
			Debug.LogError("target drone is null!!!");
			return;
		}
		_targetDrone.ResetVideoFailureCompletely();
		UniverseSaveFile.Save(string.Format("DRONE_{0}", _targetDrone.InternalID), "HASFAILED", false);
	}

	public IModification CopyModification()
	{
		IModification modification = new RepairDroneVideoMod();
		modification.SetTarget(_targetDrone);
		return modification;
	}
}
