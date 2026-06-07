using System;
using Assets.Code.Story.Objectives;
using PajamaLlama.Flotsam.Narrative;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[Serializable]
public class ScoutRegionObjective : QuestObjectiveBase
{
	public enum Mode
	{
		LandmarkVariable = 0,
		AnyRegion = 1
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Scout region";

	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private int _landmarkVariable;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	private SpawnerObjectiveBearing _bearing;

	[SerializeField]
	private bool _reinitializeOnMapActivated = true;

	private LandmarkSpawner _targetLandmark;

	public ScoutRegionObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkRegionEntered);
	}

	public ScoutRegionObjective(ScoutRegionObjective other)
		: base(other)
	{
		_mode = other._mode;
		_landmarkVariable = other._landmarkVariable;
		_bearing = new SpawnerObjectiveBearing(other._bearing);
		_reinitializeOnMapActivated = other._reinitializeOnMapActivated;
		_targetLandmark = other._targetLandmark;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted() || (_mode == Mode.AnyRegion && GameManager.GameStatsManager.RegionsScoutedCount > 0))
		{
			return true;
		}
		if (_mode == Mode.LandmarkVariable && base.Quest != null)
		{
			LandmarkSpawner landmarkSpawner = ((_targetLandmark != null) ? _targetLandmark : base.Quest.GetVariableValue<LandmarkSpawner>(this, _landmarkVariable));
			if (landmarkSpawner != null && landmarkSpawner.ScoutingState == ScoutingState.Scouted)
			{
				return true;
			}
		}
		return false;
	}

	public override void Initialize()
	{
		if (InitializeIsCompleted())
		{
			return;
		}
		if (InitializeTargetLandmark())
		{
			GameEventDispatcher.AddListener(GameEventType.RegionScouted, OnScouted);
			if (_reinitializeOnMapActivated)
			{
				GameEventDispatcher.AddListener(GameEventType.MapActivated, OnMapActivated);
			}
		}
		else
		{
			Debug.LogException(new Exception($"Unable to find target landmark for ScoutRegionObjective in '{_mode}' mode."));
			SetCompleted(completed: true, sendEvent: false);
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		GameEventDispatcher.RemoveListener(GameEventType.RegionScouted, OnScouted);
		_bearing.Uninitialize();
	}

	private bool InitializeTargetLandmark()
	{
		_targetLandmark = null;
		switch (_mode)
		{
		case Mode.LandmarkVariable:
			_targetLandmark = base.Quest.GetVariableValue<LandmarkSpawner>(this, _landmarkVariable);
			break;
		case Mode.AnyRegion:
			return true;
		}
		if (_targetLandmark == null)
		{
			_bearing.SetActive(active: false);
			return false;
		}
		_bearing.Initialize(this, _targetLandmark);
		_bearing.SetActive(active: true);
		return true;
	}

	private void OnScouted(GameEvent gameEvent)
	{
		if (_mode == Mode.AnyRegion || _targetLandmark == null || (gameEvent is ScoutingEvent scoutingEvent && scoutingEvent.Region == _targetLandmark.Region))
		{
			SetCompleted(completed: true);
			Uninitialize();
		}
	}

	private void OnMapActivated(GameEvent gameEvent = null)
	{
		InitializeTargetLandmark();
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Scout a Region";
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		return dialogueTriggerType switch
		{
			DialogueTriggerType.OnLandmarkSelected => target == _targetLandmark, 
			DialogueTriggerType.OnLandmarkRegionEntered => target is IWorldRegion worldRegion && _targetLandmark != null && worldRegion == _targetLandmark.Region, 
			_ => false, 
		};
	}

	public override object Clone()
	{
		return new ScoutRegionObjective(this);
	}
}
