using System;

[Serializable]
public class LandmarkActionsBehaviourPersistentData
{
	private LandmarkActionPersistentData[] _actions;

	public LandmarkActionsBehaviourPersistentData(ActionsBehaviour behaviour)
	{
		_actions = new LandmarkActionPersistentData[behaviour.Actions.Count];
		for (int i = 0; i < _actions.Length; i++)
		{
			_actions[i] = behaviour.Actions[i].ReturnLandmarkActionPersistentData();
		}
	}

	public void PopulateReferences()
	{
		for (int i = 0; i < _actions.Length; i++)
		{
			_actions[i].PopulateReferences();
		}
	}

	public void Restore(ActionsBehaviour behaviour)
	{
		if (behaviour == null)
		{
			return;
		}
		foreach (LandmarkAction action in behaviour.Actions)
		{
			if (!RestoreLandmarkAction(action, behaviour))
			{
				action.OnLandmarkSpawned();
			}
		}
	}

	private bool RestoreLandmarkAction(LandmarkAction action, ActionsBehaviour behaviour)
	{
		LandmarkActionPersistentData[] actions = _actions;
		for (int i = 0; i < actions.Length; i++)
		{
			if (actions[i].Restore(action, behaviour))
			{
				return true;
			}
		}
		return false;
	}

	public void RestoreReferences()
	{
		LandmarkActionPersistentData[] actions = _actions;
		for (int i = 0; i < actions.Length; i++)
		{
			actions[i].RestoreReferences();
		}
	}

	public bool TryGetActionPersistentData<T>(out T data) where T : LandmarkActionPersistentData
	{
		LandmarkActionPersistentData[] actions = _actions;
		for (int i = 0; i < actions.Length; i++)
		{
			if (actions[i] is T val)
			{
				data = val;
				return true;
			}
		}
		data = null;
		return false;
	}
}
