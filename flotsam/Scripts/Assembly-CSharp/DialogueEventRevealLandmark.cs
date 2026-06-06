using System;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class DialogueEventRevealLandmark : IDialogueEvent
{
	public enum Mode
	{
		LandmarkVariable = 0,
		PointOfInterestVariable = 1,
		ILandmarkInteractable = 2
	}

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	private bool _openMapIfInactive = true;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private QuestVariableReference _landmarkVariable;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, true)]
	[QuestVariable(QuestVariableType.PointOfInterest)]
	private QuestVariableReference _pointOfInterestVariable;

	[SerializeField]
	private float _reCenterWaitTime = 2f;

	public void TriggerEvent(Dialogue dialogue)
	{
		if (TryGetSpawner(out var spawner, dialogue))
		{
			RevealSpawnerEvent.Dispatch(spawner, _reCenterWaitTime, _openMapIfInactive);
		}
	}

	private bool TryGetSpawner(out ISpawner spawner, Dialogue dialogue)
	{
		spawner = null;
		LandmarkSpawner landmarkSpawner;
		return _mode switch
		{
			Mode.LandmarkVariable => _landmarkVariable.TryGetValue<ISpawner>(out spawner), 
			Mode.PointOfInterestVariable => _pointOfInterestVariable.TryGetValue<ISpawner>(out spawner), 
			Mode.ILandmarkInteractable => dialogue != null && dialogue.Interactable != null && dialogue.Interactable.TryGetLandmark(out landmarkSpawner) && (spawner = landmarkSpawner) != null, 
			_ => false, 
		};
	}
}
