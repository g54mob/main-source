using System;
using TNRD;
using UnityEngine;

[Serializable]
public class DialogueEventToggleLandmarkAction : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Toggle Landmark Action";

	[SerializeField]
	private SerializableInterface<ILandmarkBehaviourProvider> _landmark;

	[SerializeField]
	private GameEventType _actionToToggle;

	[SerializeField]
	private bool _actionStateToSet = true;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (Selector.SelectedType != ObjectType.Landmark || !Selector.Selection.ObjectToSelect.TryGetComponent<Landmark>(out var component) || !TrySetActionActive(component.Behaviour))
		{
			LandmarkSpawner nearestLandmarkOfType = GameManager.WorldManager.World.GetNearestLandmarkOfType(_landmark.Value, _actionToToggle);
			if (nearestLandmarkOfType == null || !TrySetActionActive(nearestLandmarkOfType.LandmarkBehaviour))
			{
				Debug.LogError(string.Format("Could not find an appropriate landmark of type \"{0}\" with action \"{1}\" to toggle!", (_landmark.Value != null) ? _landmark.Value.EditorName : "Any", _actionToToggle));
			}
		}
	}

	private bool TrySetActionActive(LandmarkBehaviour landmarkBehaviour)
	{
		if (landmarkBehaviour != null && landmarkBehaviour.Landmark != null && landmarkBehaviour.Landmark.IsInSwimmingRadius() && landmarkBehaviour is ActionsBehaviour actionsBehaviour)
		{
			return actionsBehaviour.TrySetActionActive(_actionToToggle, _actionStateToSet);
		}
		return false;
	}
}
