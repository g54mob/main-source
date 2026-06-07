using System;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class MoveTownToPOIObjective : MoveTownObjective, ILocalizationParamsManager
{
	public enum Mode
	{
		POIProperties = 0,
		POIVariable = 1
	}

	[Header("Move Town To POI")]
	[SerializeField]
	private Mode _mode;

	[SerializeField]
	[ConditionalEnumHide("_mode", 0, true)]
	private PointOfInterestProperties _poiProperties;

	[SerializeField]
	[ConditionalEnumHide("_mode", 1, true)]
	[QuestVariable(QuestVariableType.PointOfInterest)]
	private int _poiVariable;

	[SerializeField]
	private SpawnerObjectiveBearing _bearing;

	[SerializeField]
	private bool _logWarningIfPOINotFound = true;

	protected PointOfInterestSpawner _targetPOI;

	public bool IsBearingAllowed { get; private set; }

	public MoveTownToPOIObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnFlotsamItemSalvaged);
	}

	public MoveTownToPOIObjective(MoveTownToPOIObjective other)
		: base(other)
	{
		_mode = other._mode;
		_poiProperties = other._poiProperties;
		_poiVariable = other._poiVariable;
		_bearing = new SpawnerObjectiveBearing(other._bearing);
		_logWarningIfPOINotFound = other._logWarningIfPOINotFound;
		_targetPOI = other._targetPOI;
	}

	public override void Initialize()
	{
		_targetPOI = null;
		base.Initialize();
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (active)
		{
			if (TryFindTargetPOI(out var targetPOI))
			{
				SetTargetPOI(targetPOI);
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

	private bool TryFindTargetPOI(out PointOfInterestSpawner targetPOI)
	{
		if (_targetPOI != null)
		{
			targetPOI = _targetPOI;
			return true;
		}
		if (_mode == Mode.POIVariable)
		{
			targetPOI = base.Quest.GetVariableValue<PointOfInterestSpawner>(this, _poiVariable);
			return targetPOI != null;
		}
		return TryFindTargetPOIWithProperties(out targetPOI);
	}

	private bool TryFindTargetPOIWithProperties(out PointOfInterestSpawner targetPOI)
	{
		targetPOI = GameManager.WorldManager.World.GetNearestPOIOfType(_poiProperties);
		if (targetPOI != null)
		{
			return true;
		}
		if (_logWarningIfPOINotFound)
		{
			Debug.LogWarning("No valid poi \"" + _poiProperties.name + "\" found for objective MoveTownToPOIObjective! Will try again next time WorldMap is opened");
		}
		return false;
	}

	private void SetTargetPOI(PointOfInterestSpawner targetPOI)
	{
		if (_targetPOI != targetPOI)
		{
			_targetPOI = targetPOI;
			_bearing.Initialize(this, _targetPOI);
			_bearing.SetActive(active: true);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		_targetPOI = null;
		_bearing.Uninitialize();
		base.Uninitialize();
	}

	protected override bool IsArrived()
	{
		PointOfInterestSpawner pointOfInterestSpawner = null;
		switch (_mode)
		{
		case Mode.POIProperties:
			pointOfInterestSpawner = ((_targetPOI != null) ? _targetPOI : GameManager.WorldManager.World.GetNearestPOIOfType(_poiProperties));
			break;
		case Mode.POIVariable:
			pointOfInterestSpawner = ((_targetPOI != null) ? _targetPOI : base.Quest.GetVariableValue<PointOfInterestSpawner>(this, _poiVariable));
			break;
		}
		if (pointOfInterestSpawner == null)
		{
			return false;
		}
		float num = GameManager.Settings.GameplaySettings.SwimmingRadius;
		num *= num;
		Vector3 position = GameManager.WorldMapManager.WorldMap.Townheart.Position;
		return (pointOfInterestSpawner.WorldPosition - position).sqrMagnitude <= num;
	}

	private void OnMapActivated(GameEvent gameEvent)
	{
		if (TryFindTargetPOI(out var targetPOI))
		{
			SetTargetPOI(targetPOI);
			GameEventDispatcher.RemoveListener(GameEventType.MapActivated, OnMapActivated);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Move To Landmark \"" + GetName() + "\"";
	}

	public override string GetParameterValue(string param)
	{
		if (param == "POI")
		{
			return GetName();
		}
		return base.GetParameterValue(param);
	}

	private string GetName()
	{
		if (_targetPOI != null)
		{
			return _targetPOI.Name;
		}
		if (_poiProperties != null)
		{
			return _poiProperties.Title;
		}
		return "Any";
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		if (dialogueTriggerType == DialogueTriggerType.OnFlotsamItemSalvaged)
		{
			return target is ItemProperties itemProperties && IsItemInContext(itemProperties);
		}
		return false;
	}

	private bool IsItemInContext(ItemProperties itemProperties)
	{
		if (_mode == Mode.POIProperties)
		{
			return _poiProperties != null && _poiProperties.ReturnItems().Contains(itemProperties);
		}
		return _targetPOI != null && _targetPOI.GetAllFlotsamProperties().Contains(itemProperties.FlotsamProperties);
	}

	public override object Clone()
	{
		return new MoveTownToPOIObjective(this);
	}
}
