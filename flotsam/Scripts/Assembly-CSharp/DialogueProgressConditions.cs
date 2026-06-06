using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueProgressConditions : ICloneable
{
	[SerializeReference]
	[SubclassSelector]
	private List<IQuestObjective> _conditions;

	[SerializeField]
	[Tooltip("If true, the player can still manually progress the dialogue with inputs even if conditions are not met.\nIf true, the dialogue will also progress automatically when conditions are met.")]
	private bool _manualInputIgnoresConditions = true;

	[SerializeField]
	[ConditionalHide("_manualInputIgnoresConditions", true, true)]
	private bool _autoProgressOnConditionsMet = true;

	[SerializeField]
	[Tooltip("Skip the node if the conditions are already met when entering it")]
	private bool _skipNodeIfConditionsAlreadyMet;

	public Action OnConditionsMet;

	public IReadOnlyList<IQuestObjective> Conditions => _conditions;

	public bool ManualInputIgnoresConditions => _manualInputIgnoresConditions;

	public bool AutoProgressOnConditionsMet
	{
		get
		{
			if (!_manualInputIgnoresConditions)
			{
				return _autoProgressOnConditionsMet;
			}
			return true;
		}
	}

	public bool SkipNodeIfConditionsAlreadyMet => _skipNodeIfConditionsAlreadyMet;

	public void OnNodeEnter()
	{
		GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, OnConditionUpdated);
		foreach (IQuestObjective condition in _conditions)
		{
			condition.InitializeDialogueTriggers();
			condition.Initialize();
		}
	}

	public void OnNodeExit()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, OnConditionUpdated);
		foreach (IQuestObjective condition in _conditions)
		{
			condition.Uninitialize();
			condition.UninitializeDialogueTriggers();
		}
	}

	public bool AreConditionsMet()
	{
		foreach (IQuestObjective condition in _conditions)
		{
			if (!condition.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}

	private void OnConditionUpdated(GameEvent gameEvent)
	{
		if (gameEvent is QuestEvent { Objective: not null } questEvent && questEvent.Objective.IsCompleted() && _conditions.Contains(questEvent.Objective) && AreConditionsMet())
		{
			OnConditionsMet.SafeInvoke();
		}
	}

	public object Clone()
	{
		List<IQuestObjective> list = new List<IQuestObjective>(_conditions.Count);
		foreach (IQuestObjective condition in _conditions)
		{
			list.Add(condition.Clone() as IQuestObjective);
		}
		return new DialogueProgressConditions
		{
			_conditions = list,
			_manualInputIgnoresConditions = _manualInputIgnoresConditions,
			_autoProgressOnConditionsMet = _autoProgressOnConditionsMet,
			_skipNodeIfConditionsAlreadyMet = _skipNodeIfConditionsAlreadyMet
		};
	}
}
