using System;
using System.Collections.Generic;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using TNRD;
using UnityEngine;

[Serializable]
public class MoveTownToLandmarkObjective : MoveTownObjective, ILocalizationParamsManager
{
	public enum Mode
	{
		LandmarkProvider = 0,
		LandmarkVariable = 1
	}

	public enum RadiusMode
	{
		SwimmingRaduis = 0,
		BoatRadius = 1,
		ClampedCustomRadius = 2
	}

	[Header("Move Town To Landmark")]
	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	private SerializableInterface<ILandmarkBehaviourProvider> _specificLandmark;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private int _landmarkVariable;

	[SerializeField]
	[ConditionalHide("_spawnLandmark", true)]
	private LandmarkPicker.Settings _landmarkPickerSettings;

	[SerializeField]
	private List<LandmarkAction> _landmarkActionsThatCompleteObjective = new List<LandmarkAction>();

	[SerializeField]
	private SpawnerObjectiveBearing _bearing;

	[SerializeField]
	private bool _logWarningIfLandmarkNotFound = true;

	[SerializeField]
	private RadiusMode _radiusMode;

	[SerializeField]
	[ConditionalEnumHide("_radiusMode", 2, false, HideInInspector = true)]
	[Tooltip("A custom radius that is campled between the swmming and boat radius")]
	private float _clampedCustomRadius;

	protected LandmarkSpawner _targetLandmark;

	public bool IsBearingAllowed { get; private set; }

	public MoveTownToLandmarkObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkRegionEntered);
	}

	public MoveTownToLandmarkObjective(MoveTownToLandmarkObjective other)
		: base(other)
	{
		_mode = other._mode;
		_specificLandmark = other._specificLandmark;
		_landmarkVariable = other._landmarkVariable;
		_landmarkPickerSettings = other._landmarkPickerSettings;
		_landmarkActionsThatCompleteObjective = new List<LandmarkAction>(other._landmarkActionsThatCompleteObjective);
		_bearing = new SpawnerObjectiveBearing(other._bearing);
		_logWarningIfLandmarkNotFound = other._logWarningIfLandmarkNotFound;
		_radiusMode = other._radiusMode;
		_clampedCustomRadius = other._clampedCustomRadius;
		_targetLandmark = other._targetLandmark;
	}

	public override void Initialize()
	{
		_targetLandmark = null;
		base.Initialize();
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active)
		{
			if (TryFindTargetLandmark(out var targetLandmark))
			{
				SetTargetLandmark(targetLandmark);
			}
			else
			{
				GameEventDispatcher.AddListener(GameEventType.MapActivated, OnMapActivated);
			}
		}
		else
		{
			_bearing.SetActive(active: false);
			GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		}
	}

	private bool TryFindTargetLandmark(out LandmarkSpawner targetLandmark)
	{
		if (_targetLandmark != null)
		{
			targetLandmark = _targetLandmark;
			return true;
		}
		if (_mode == Mode.LandmarkVariable)
		{
			targetLandmark = base.Quest.GetVariableValue<LandmarkSpawner>(this, _landmarkVariable);
			return targetLandmark != null;
		}
		return TryFindTargetLandmark(_specificLandmark.Value, out targetLandmark);
	}

	private bool TryFindTargetLandmark(ILandmarkBehaviourProvider landmarkBehaviourProvider, out LandmarkSpawner targetLandmark)
	{
		targetLandmark = GameManager.WorldManager.World.GetNearestLandmarkOfType(landmarkBehaviourProvider);
		if (targetLandmark != null || _landmarkPickerSettings.Spawn(out targetLandmark, landmarkBehaviourProvider))
		{
			return true;
		}
		if (_logWarningIfLandmarkNotFound)
		{
			Debug.LogWarning("No valid landmark \"" + ((landmarkBehaviourProvider != null) ? landmarkBehaviourProvider.Name : "NULL") + "\" found for objective MoveTownToLandmarkObjective! Will try again next time WorldMap is opened");
		}
		return false;
	}

	private void SetTargetLandmark(LandmarkSpawner targetLandmark)
	{
		if (_targetLandmark != targetLandmark)
		{
			if (_targetLandmark != null && (bool)_targetLandmark.LandmarkBehaviour)
			{
				_targetLandmark.LandmarkBehaviour.UpdatedEvent.RemoveListener(OnLandmarkActionUpdated);
			}
			_targetLandmark = targetLandmark;
			if ((bool)_targetLandmark.LandmarkBehaviour && !_landmarkActionsThatCompleteObjective.IsNullOrEmpty())
			{
				_targetLandmark.LandmarkBehaviour.UpdatedEvent.AddListener(OnLandmarkActionUpdated);
			}
			AddBlockingSpawner(targetLandmark);
			_bearing.Initialize(this, _targetLandmark);
			_bearing.SetActive(active: true);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		if (_targetLandmark != null && _targetLandmark.LandmarkBehaviour != null)
		{
			_targetLandmark.LandmarkBehaviour.UpdatedEvent.RemoveListener(OnLandmarkActionUpdated);
		}
		_bearing.Uninitialize();
		base.Uninitialize();
	}

	protected override bool IsArrived()
	{
		LandmarkSpawner landmarkSpawner = null;
		switch (_mode)
		{
		case Mode.LandmarkProvider:
			landmarkSpawner = ((_targetLandmark != null) ? _targetLandmark : GameManager.WorldManager.World.GetNearestLandmarkOfType(_specificLandmark.Value));
			break;
		case Mode.LandmarkVariable:
			landmarkSpawner = ((_targetLandmark != null) ? _targetLandmark : base.Quest.GetVariableValue<LandmarkSpawner>(this, _landmarkVariable));
			break;
		}
		if (landmarkSpawner == null)
		{
			return false;
		}
		Vector3 position = GameManager.WorldMapManager.WorldMap.Townheart.Position;
		return (landmarkSpawner.WorldPosition - position).sqrMagnitude <= GetSqrdRadius();
	}

	private void OnMapActivated(GameEvent gameEvent)
	{
		if (TryFindTargetLandmark(out var targetLandmark))
		{
			SetTargetLandmark(targetLandmark);
			GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		}
	}

	private void OnLandmarkActionUpdated(LandmarkBehaviour landmarkBehaviour, object action)
	{
		if (action is LandmarkAction landmarkAction && ShouldActionCompleteObjective(landmarkAction) && landmarkAction.IsCompleted)
		{
			SetCompleted(completed: true);
			Uninitialize();
		}
	}

	private bool ShouldActionCompleteObjective(LandmarkAction landmarkAction)
	{
		Type actionType = landmarkAction.GetType();
		return _landmarkActionsThatCompleteObjective.Find((LandmarkAction action) => action.GetType() == actionType) != null;
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Move To Landmark \"" + GetName() + "\"";
	}

	public override string GetParameterValue(string param)
	{
		if (param == "LANDMARK")
		{
			return GetName();
		}
		return base.GetParameterValue(param);
	}

	private string GetName()
	{
		if (_targetLandmark != null)
		{
			return _targetLandmark.Name;
		}
		if (_specificLandmark.Value != null)
		{
			return _specificLandmark.Value.Name;
		}
		return "Any";
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		if (dialogueTriggerType == DialogueTriggerType.OnLandmarkSelected || dialogueTriggerType == DialogueTriggerType.OnLandmarkRegionEntered)
		{
			return target is LandmarkBehaviour landmarkBehaviour && IsSpawnerInContext(landmarkBehaviour);
		}
		return false;
	}

	private bool IsSpawnerInContext(LandmarkBehaviour landmarkBehaviour)
	{
		if (_mode == Mode.LandmarkProvider)
		{
			return _specificLandmark.Value == null || _specificLandmark.Value.ReturnIsLandmarkBehaviour(landmarkBehaviour);
		}
		return _targetLandmark != null && landmarkBehaviour == _targetLandmark.LandmarkBehaviour;
	}

	public override object Clone()
	{
		return new MoveTownToLandmarkObjective(this);
	}

	private float GetSqrdRadius()
	{
		GameplaySettings gameplaySettings = GameSettings.Instance.GameplaySettings;
		float num = _radiusMode switch
		{
			RadiusMode.BoatRadius => gameplaySettings.InteractionRadius, 
			RadiusMode.ClampedCustomRadius => Mathf.Clamp(_clampedCustomRadius, gameplaySettings.SwimmingRadius, gameplaySettings.InteractionRadius), 
			_ => gameplaySettings.SwimmingRadius, 
		};
		return num * num;
	}
}
