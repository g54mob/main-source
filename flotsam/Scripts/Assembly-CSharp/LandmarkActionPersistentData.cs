using System;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable]
public class LandmarkActionPersistentData
{
	public enum LandmarkActionId
	{
		None = 0,
		Salvage = 1,
		RevealMap = 2,
		Rescue = 3,
		AnimalRescue = 4
	}

	public LandmarkActionId Id;

	public ILandmarkActionStates State;

	public PersistentReference<Project>.Reference Project;

	[OptionalField(VersionAdded = 3)]
	public bool UseBoat;

	[OptionalField(VersionAdded = 2)]
	public int Version;

	[NonSerialized]
	protected LandmarkAction _action;

	public LandmarkActionPersistentData(LandmarkAction action)
	{
		_action = action;
		Id = ReturnId(action);
		State = _action.State;
		UseBoat = action.UseBoat;
		Version = 1;
	}

	public virtual void PopulateReferences()
	{
		if ((bool)_action)
		{
			Project = _action.Project;
		}
		else
		{
			Debug.LogWarning("Unable to PopulateReferences, reference to LandmarkAction is NULL!");
		}
	}

	public bool Restore(LandmarkAction action, LandmarkBehaviour landmarkBehaviour)
	{
		if (Version == 0)
		{
			return RestoreVersion0(action, landmarkBehaviour);
		}
		if (Id == LandmarkActionId.AnimalRescue)
		{
			Id = LandmarkActionId.Rescue;
		}
		if (ReturnId(action) == Id)
		{
			_action = action;
			_action.Restore(this, landmarkBehaviour);
			return true;
		}
		return false;
	}

	public void RestoreReferences()
	{
		_action?.RestoreReferences(this);
	}

	protected LandmarkActionId ReturnId(LandmarkAction action)
	{
		if (action is LandmarkActionSalvage)
		{
			return LandmarkActionId.Salvage;
		}
		if (action is LandmarkActionRescue)
		{
			return LandmarkActionId.Rescue;
		}
		if (action is LandmarkActionAnimalRescue)
		{
			return LandmarkActionId.AnimalRescue;
		}
		if (action is LandmarkActionRevealMap)
		{
			return LandmarkActionId.RevealMap;
		}
		Debug.LogErrorFormat("No LandmarkActionId defined for '{0}'.", action.GetType().Name);
		return LandmarkActionId.None;
	}

	private bool RestoreVersion0(LandmarkAction action, LandmarkBehaviour landmarkBehaviour)
	{
		if (ReturnIdVersion0(action) == Id)
		{
			_action = action;
			_action.Restore(this, landmarkBehaviour);
			return true;
		}
		return false;
	}

	protected LandmarkActionId ReturnIdVersion0(LandmarkAction action)
	{
		if (action is LandmarkActionSalvage)
		{
			return LandmarkActionId.Salvage;
		}
		if (action is LandmarkActionRescue)
		{
			return LandmarkActionId.Rescue;
		}
		return LandmarkActionId.None;
	}
}
