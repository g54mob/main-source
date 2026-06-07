using System;
using I2.Loc;
using UnityEngine;

[Serializable]
public class InitiateLandmarkActionObjective : QuestObjectiveBase, ILocalizationParamsManager
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Initiate landmark action";

	[SerializeField]
	private LandmarkAction _action;

	public InitiateLandmarkActionObjective()
	{
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkSelected);
		_supportedDialogueTriggers.Add(DialogueTriggerType.OnLandmarkRegionEntered);
	}

	public InitiateLandmarkActionObjective(InitiateLandmarkActionObjective other)
		: base(other)
	{
		_action = other._action;
	}

	public override bool IsCompleted()
	{
		if (!base.IsCompleted())
		{
			return GameManager.GameStatsManager.GetLandmarkActionsInProgressCount(_action) > 0;
		}
		return true;
	}

	public override void Initialize()
	{
		if (!InitializeIsCompleted())
		{
			GameEventDispatcher.AddListener(GameEventType.LandmarkNotificationWorking, OnLandmarkActionStarted);
		}
	}

	public override void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.LandmarkNotificationWorking, OnLandmarkActionStarted);
	}

	private void OnLandmarkActionStarted(GameEvent gameEvent)
	{
		if (gameEvent is LandmarkNotificationEvent landmarkNotificationEvent && landmarkNotificationEvent.LandmarkAction != null && landmarkNotificationEvent.LandmarkAction.GetType() == _action.GetType())
		{
			SetCompleted(completed: true);
		}
	}

	protected override string GetNonLocalizedDescription()
	{
		return string.Format("Initiate Landmark Action: {0}", (_action != null) ? ((object)_action.Title) : "Any");
	}

	public override string GetParameterValue(string param)
	{
		if (param == "LANDMARKACTION")
		{
			return (_action != null) ? ((string)_action.Title) : "Any";
		}
		return base.GetParameterValue(param);
	}

	public override bool IsObjectInContext(object target, DialogueTriggerType dialogueTriggerType)
	{
		if (dialogueTriggerType == DialogueTriggerType.OnLandmarkSelected || dialogueTriggerType == DialogueTriggerType.OnLandmarkRegionEntered)
		{
			return target is ActionsBehaviour actionsBehaviour && actionsBehaviour.ReturnHasLandmarkAction(_action);
		}
		return false;
	}

	public override object Clone()
	{
		return new InitiateLandmarkActionObjective(this);
	}
}
