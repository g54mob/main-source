using System;
using PajamaLlama.Utilities;
using UnityEngine;

[Serializable]
public class ObjectiveTrigger : ICloneable
{
	[SerializeReference]
	[SubclassSelector]
	private IQuestObjective _triggerCondition;

	public Action OnConditionMet;

	public IQuestObjective TriggerCondition => _triggerCondition;

	public void Initialize()
	{
		_triggerCondition.Initialize();
		FinalUpdate.RegisterEndOfFrameOneShot(RegisterObjectivesUpdated);
	}

	public void Uninitialize()
	{
		GameEventDispatcher.RemoveListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		_triggerCondition.Uninitialize();
	}

	private void RegisterObjectivesUpdated()
	{
		GameEventDispatcher.AddListener(GameEventType.QuestObjectiveUpdated, CheckObjectivesCompletion);
		CheckObjectivesCompletion();
	}

	private void CheckObjectivesCompletion(GameEvent gameEvent = null)
	{
		if (_triggerCondition != null && _triggerCondition.IsCompleted())
		{
			OnConditionMet.SafeInvoke();
			Uninitialize();
		}
	}

	public object Clone()
	{
		return new ObjectiveTrigger
		{
			_triggerCondition = (_triggerCondition.Clone() as IQuestObjective)
		};
	}
}
