using System;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using TNRD;
using UnityEngine;

[Serializable]
public class SelectLandmarkObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	public enum LandmarkMode
	{
		Tutorial = 0,
		LandmarkVariable = 1
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Select landmark";

	[SerializeField]
	private LandmarkMode _landmarkMode;

	[SerializeField]
	[ConditionalEnumHide("_landmarkMode", 0, true)]
	private SerializableInterface<ILandmarkBehaviourProvider> _specificLandmark;

	[SerializeField]
	[ConditionalEnumHide("_landmarkMode", 1, true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private int _landmarkVariable;

	[SerializeField]
	private LandmarkAction _requiredLandmarkAction;

	[SerializeField]
	private SpawnerObjectiveBearing _bearing;

	public SelectLandmarkObjective()
	{
	}

	public SelectLandmarkObjective(SelectLandmarkObjective other)
		: base(other)
	{
		_landmarkMode = other._landmarkMode;
		_specificLandmark = other._specificLandmark;
		_landmarkVariable = other._landmarkVariable;
		_requiredLandmarkAction = other._requiredLandmarkAction;
		_bearing = other._bearing;
	}

	public override bool IsCompleted()
	{
		if (base.IsCompleted())
		{
			return true;
		}
		if (Selector.SelectedType == ObjectType.Landmark && Selector.Selection.ObjectToSelect.TryGetComponent<Landmark>(out var component))
		{
			return IsLandmark(component);
		}
		return false;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
		}
	}

	public override void SetActive(bool active)
	{
		base.SetActive(active);
		if (!IsCompleted() && _landmarkMode == LandmarkMode.LandmarkVariable && base.Quest.TryGetVariableValue<LandmarkSpawner>(this, _landmarkVariable, out var value))
		{
			_bearing.Initialize(this, value);
			_bearing.SetActive(active);
		}
	}

	public override void Uninitialize()
	{
		_bearing.Uninitialize();
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkSelected, OnLandmarkSelected);
	}

	private void OnLandmarkSelected(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && (bool)landmarkNotificationEvent.LandmarkBehaviour && IsLandmark(landmarkNotificationEvent.LandmarkBehaviour.Landmark))
		{
			SetCompleted(completed: true);
		}
	}

	private bool IsLandmark(Landmark landmark)
	{
		switch (_landmarkMode)
		{
		case LandmarkMode.Tutorial:
			if (_specificLandmark.Value != null && !_specificLandmark.Value.ReturnIsLandmarkBehaviour(landmark.Behaviour))
			{
				return false;
			}
			break;
		case LandmarkMode.LandmarkVariable:
		{
			if (!base.Quest.TryGetVariableValue<LandmarkSpawner>(this, _landmarkVariable, out var value) || value.LandmarkBehaviour == null || value.LandmarkBehaviour.Landmark != landmark)
			{
				return false;
			}
			break;
		}
		}
		if (!(_requiredLandmarkAction == null))
		{
			if (landmark.Behaviour is ActionsBehaviour actionsBehaviour)
			{
				return actionsBehaviour.ReturnHasLandmarkAction(_requiredLandmarkAction);
			}
			return false;
		}
		return true;
	}

	protected override string GetNonLocalizedDescription()
	{
		return "Select Landmark: " + ((_specificLandmark.Value != null) ? _specificLandmark.Value.Name : "Any") + " with action: " + ((_requiredLandmarkAction != null) ? _requiredLandmarkAction.name : "Any");
	}

	public override string GetParameterValue(string param)
	{
		if (param == "LANDMARK")
		{
			return GetLandmarkName();
		}
		return base.GetParameterValue(param);
	}

	public override object Clone()
	{
		return new SelectLandmarkObjective(this);
	}

	private string GetLandmarkName()
	{
		switch (_landmarkMode)
		{
		case LandmarkMode.Tutorial:
			if (_specificLandmark.Value == null)
			{
				return "Any";
			}
			return _specificLandmark.Value.Name;
		case LandmarkMode.LandmarkVariable:
		{
			if (base.Quest == null || !base.Quest.TryGetVariableValue<LandmarkSpawner>(_landmarkVariable, out var value))
			{
				return "NULL";
			}
			return value.Name;
		}
		default:
			return "NOT IMPLEMENTED";
		}
	}
}
