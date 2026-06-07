using System;
using System.Collections.Generic;
using Assets.Code.Story.Objectives;
using I2.Loc;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

[Serializable]
public class RescueObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	public enum RescueType
	{
		QuestGiver = 0,
		ReferenceProfile = 1,
		Any = 2,
		LandmarkVariable = 3
	}

	[SerializeField]
	[HideInInspector]
	private string _name = "Rescue";

	[SerializeField]
	private RescueType _rescueType;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 2, true)]
	private ActorType _actorType;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 1, true)]
	private AgentProfile _specificActorToRescue;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 2, true)]
	private int _requiredCount = 1;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 2, true)]
	private ComparisonType _comparisonType = ComparisonType.EqualOrGreaterThan;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 3, true)]
	[QuestVariable(QuestVariableType.Landmark)]
	private int _rescueLandmarkVariable;

	[SerializeField]
	[ConditionalEnumHide("_rescueType", 3, true)]
	private SpawnerObjectiveBearing _bearing;

	private LandmarkSpawner _rescueLandmark;

	private AgentDescriptor _rescuableDescriptor;

	private readonly List<ActorDescriptor> _rescuedActors = new List<ActorDescriptor>();

	public RescueObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkRegionEntered);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnAgentSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnAgentFromPlayerCommunitySelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnOutsiderAgentSelected);
	}

	public RescueObjective(RescueObjective other)
		: base(other)
	{
		_rescueType = other._rescueType;
		_actorType = other._actorType;
		_specificActorToRescue = other._specificActorToRescue;
		_requiredCount = other._requiredCount;
		_comparisonType = other._comparisonType;
		_rescueLandmarkVariable = other._rescueLandmarkVariable;
		_bearing = new SpawnerObjectiveBearing(other._bearing);
		_rescuedActors = new List<ActorDescriptor>(other._rescuedActors);
	}

	public override bool IsCompleted()
	{
		bool flag = base.IsCompleted();
		if (!flag)
		{
			flag = _rescueType switch
			{
				RescueType.QuestGiver => _rescuedActors.Contains(base.Quest.QuestGiver) || Community.PlayerCommunity.HasActor(base.Quest.QuestGiver), 
				RescueType.ReferenceProfile => _rescuedActors.Contains(_specificActorToRescue.GetDescriptor()) || Community.PlayerCommunity.HasActor(_specificActorToRescue.GetDescriptor()), 
				RescueType.LandmarkVariable => IsRescueActionCompleted(), 
				RescueType.Any => _rescuedActors.Count.Compare(_comparisonType, _requiredCount), 
				_ => false, 
			};
		}
		return flag;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.ActorRescue, OnActorRescued);
		}
	}

	public override void SetActive(bool active)
	{
		if (_rescueType == RescueType.LandmarkVariable)
		{
			if (base.Quest.TryGetVariableValue<LandmarkSpawner>(this, _rescueLandmarkVariable, out _rescueLandmark))
			{
				base.Quest.TryGetVariableValue<AgentDescriptor>(this, _rescueLandmarkVariable, out _rescuableDescriptor);
				_bearing.Initialize(this, _rescueLandmark);
				_bearing.SetActive(active);
				base.SetActive(active);
				AddBlockingSpawner(_rescueLandmark);
			}
			else if (IsOptional)
			{
				QuestProperties arg = ((base.Quest == null) ? null : base.Quest.Properties);
				Debug.LogException(new Exception($"Unable to initialize optional RescueObjective with RescueType.LandmarkVariable for quest '{arg}'."));
				SetCompleted(completed: false);
			}
			else
			{
				QuestProperties arg2 = ((base.Quest == null) ? null : base.Quest.Properties);
				Debug.LogException(new Exception($"Unable to initialize RescueObjective with RescueType.LandmarkVariable for quest '{arg2}'. The quest failed!"));
				base.Quest.SetFailed();
			}
		}
		else
		{
			base.SetActive(active);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ActorRescue, OnActorRescued);
		_bearing.Uninitialize();
	}

	private void OnActorRescued(GameEvent gameEvent)
	{
		if (gameEvent is ActorEvent { ActorDescriptor: not null } actorEvent && DoesActorCount(actorEvent.ActorDescriptor))
		{
			_rescuedActors.Add(actorEvent.ActorDescriptor);
			if (IsCompleted())
			{
				SetCompleted(completed: true);
			}
		}
	}

	private bool DoesActorCount(ActorDescriptor actorDescriptor)
	{
		AgentDescriptor agentDescriptor = actorDescriptor as AgentDescriptor;
		return _rescueType switch
		{
			RescueType.QuestGiver => agentDescriptor == base.Quest.QuestGiver, 
			RescueType.ReferenceProfile => agentDescriptor == _specificActorToRescue.GetDescriptor(), 
			RescueType.LandmarkVariable => _rescuableDescriptor == null || agentDescriptor == _rescuableDescriptor, 
			RescueType.Any => actorDescriptor.ActorType == _actorType, 
			_ => true, 
		};
	}

	private bool IsRescueActionCompleted()
	{
		if (_rescuableDescriptor != null)
		{
			if (!_rescuedActors.Contains(_rescuableDescriptor))
			{
				return Community.PlayerCommunity.HasActor(_rescuableDescriptor);
			}
			return true;
		}
		if (_rescueLandmark != null && _rescueLandmark.LandmarkBehaviour is ActionsBehaviour actionsBehaviour && actionsBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
		{
			return action.IsCompleted;
		}
		return false;
	}

	protected override string GetNonLocalizedDescription()
	{
		RescueType rescueType = _rescueType;
		if ((uint)rescueType <= 1u)
		{
			return "Rescue " + GetTargetAgentName();
		}
		return $"Rescue drifters ({_comparisonType} {_requiredCount})";
	}

	public override string GetParameterValue(string param)
	{
		switch (param)
		{
		case "AGENT":
		case "DRIFTER":
			return GetTargetAgentName();
		case "LANDMARK":
			return (_rescueLandmark != null) ? _rescueLandmark.Name : "NULL";
		default:
			return base.GetParameterValue(param);
		}
	}

	private string GetTargetAgentName()
	{
		return _rescueType switch
		{
			RescueType.QuestGiver => (base.Quest != null && base.Quest.QuestGiver != null) ? base.Quest.QuestGiver.Name : "NULL", 
			RescueType.ReferenceProfile => (_specificActorToRescue != null) ? _specificActorToRescue.Name : "NULL", 
			RescueType.LandmarkVariable => (_rescuableDescriptor != null) ? _rescuableDescriptor.Name : "NULL", 
			_ => "Any", 
		};
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		switch (dialogueTriggerType)
		{
		case DialogueTriggerType.OnLandmarkSelected:
		case DialogueTriggerType.OnLandmarkRegionEntered:
			return target is ActionsBehaviour landmarkBehaviour && IsLandmarkBehaviourInContext(landmarkBehaviour);
		case DialogueTriggerType.OnAgentSelected:
		case DialogueTriggerType.OnAgentFromPlayerCommunitySelected:
		case DialogueTriggerType.OnOutsiderAgentSelected:
			return target is Agent agent && IsAgentInContext(agent, dialogueTriggerType);
		default:
			return false;
		}
	}

	private bool IsLandmarkBehaviourInContext(ActionsBehaviour landmarkBehaviour)
	{
		if (landmarkBehaviour.TryReturnAction<LandmarkActionRescue>(out var action, false))
		{
			return action.Rescueables.Find(IsAgentInContextForLandmarkSelected) != null;
		}
		return false;
	}

	private bool IsAgentInContextForLandmarkSelected(LandmarkActionRescue.Rescueable rescueable)
	{
		if (rescueable != null && rescueable.Agent != null)
		{
			return DoesActorCount(rescueable.Agent.Descriptor);
		}
		return false;
	}

	private bool IsAgentInContext(Agent agent, DialogueTriggerType dialogueTriggerType)
	{
		bool flag = agent != null;
		if (flag)
		{
			flag = _rescueType switch
			{
				RescueType.QuestGiver => agent.Descriptor == base.Quest.QuestGiver, 
				RescueType.ReferenceProfile => agent.Descriptor == _specificActorToRescue.GetDescriptor(), 
				RescueType.LandmarkVariable => agent.Descriptor == _rescuableDescriptor, 
				RescueType.Any => dialogueTriggerType switch
				{
					DialogueTriggerType.OnAgentSelected => !agent.InPlayerCommunity() || (_rescuedActors != null && _rescuedActors.Contains(agent.Descriptor)), 
					DialogueTriggerType.OnAgentFromPlayerCommunitySelected => _rescuedActors != null && _rescuedActors.Contains(agent.Descriptor), 
					DialogueTriggerType.OnOutsiderAgentSelected => !agent.InPlayerCommunity(), 
					_ => false, 
				}, 
				_ => false, 
			};
		}
		return flag;
	}

	public override object Clone()
	{
		return new RescueObjective(this);
	}
}
