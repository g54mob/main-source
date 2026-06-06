using System;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[Serializable]
public class DialogueEventUpdateBearings : IDialogueEvent
{
	public enum Mode
	{
		QuestLandmarkVariable = 0,
		QuestLandmarkVariableRegion = 1,
		QuestLandmarkVariableAndRegion = 2,
		CurrentRegion = 3
	}

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[QuestVariable(QuestVariableType.Landmark)]
	[ConditionalEnumHide("_mode", 3, true, Inverse = true)]
	[Tooltip("The quest landmark variables to updated the bering for.")]
	private QuestVariableReference[] _landmarkVariables;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true, Inverse = true)]
	private WorldMapScoutingId _scoutingIds;

	[SerializeField]
	private BearingFeatures _bearingFeatures;

	[SerializeField]
	[Tooltip("The bearing icon type to override the icon provided by the LandmarkBehaviour.")]
	private BearingIconType _bearingIcon;

	[SerializeField]
	[Tooltip("Should the bearing of a landmark be overriden when it already has an active bearing?")]
	private bool _overrideActiveBearing;

	[SerializeField]
	[Tooltip("The ScoutingState to set the landmark to. ScoutingState can only be increased, never decreased.")]
	private ScoutingState _scoutingState;

	[SerializeField]
	private bool _clearFogOfWar;

	public void TriggerEvent(Dialogue dialogue)
	{
		LandmarkSpawner value;
		switch (_mode)
		{
		case Mode.QuestLandmarkVariable:
		{
			QuestVariableReference[] landmarkVariables = _landmarkVariables;
			for (int i = 0; i < landmarkVariables.Length; i++)
			{
				if (landmarkVariables[i].TryGetValue<LandmarkSpawner>(out value))
				{
					UpdateBearing(value);
				}
			}
			break;
		}
		case Mode.QuestLandmarkVariableRegion:
		{
			QuestVariableReference[] landmarkVariables = _landmarkVariables;
			for (int i = 0; i < landmarkVariables.Length; i++)
			{
				if (landmarkVariables[i].TryGetValue<LandmarkSpawner>(out value))
				{
					ApplyBearingFeaturesToLandmarksInRegion(value.Region);
				}
			}
			break;
		}
		case Mode.QuestLandmarkVariableAndRegion:
		{
			QuestVariableReference[] landmarkVariables = _landmarkVariables;
			for (int i = 0; i < landmarkVariables.Length; i++)
			{
				if (landmarkVariables[i].TryGetValue<LandmarkSpawner>(out value))
				{
					UpdateBearing(value);
					ApplyBearingFeaturesToLandmarksInRegion(value.Region);
				}
			}
			break;
		}
		case Mode.CurrentRegion:
		{
			if (WorldManager.TryReturnCurrentRegion(out var region))
			{
				ApplyBearingFeaturesToLandmarksInRegion(region);
			}
			break;
		}
		}
	}

	private void ApplyBearingFeaturesToLandmarksInRegion(IWorldRegion region)
	{
		foreach (LandmarkSpawner landmark in region.Landmarks)
		{
			if ((landmark.ScoutingId & _scoutingIds) != WorldMapScoutingId.None)
			{
				UpdateBearing(landmark);
			}
		}
	}

	private void UpdateBearing(LandmarkSpawner landmarkSpawner)
	{
		if (landmarkSpawner.BearingFeatures == BearingFeatures.None || _overrideActiveBearing)
		{
			if (landmarkSpawner.ScoutingState < _scoutingState)
			{
				landmarkSpawner.SetScoutingState(_scoutingState);
			}
			if (_clearFogOfWar)
			{
				landmarkSpawner.ClearFogOfWar();
			}
			landmarkSpawner.SetBearingFeatures(_bearingFeatures, _bearingIcon);
		}
	}
}
