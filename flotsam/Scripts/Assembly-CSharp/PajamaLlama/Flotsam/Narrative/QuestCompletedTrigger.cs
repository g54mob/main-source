using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestCompletedTrigger : IScenarioTrigger
	{
		[SerializeField]
		private QuestProperties _questProperties;

		[SerializeReference]
		[SubclassSelector]
		private ScenarioTriggerableBase _triggerable;

		[SerializeField]
		private bool _tryTriggerOnInitialize = true;

		public void Initialize()
		{
			if (!_triggerable.WasTriggered && (!_tryTriggerOnInitialize || !StoryManager.IsQuestCompleted(_questProperties) || !_triggerable.TryTrigger()))
			{
				GameEventDispatcher.AddListener(GameEventType.QuestCompleted, OnQuestCompleted);
			}
		}

		public void Uninitialize()
		{
			GameEventDispatcher.RemoveListener(GameEventType.QuestCompleted, OnQuestCompleted);
		}

		private void OnQuestCompleted(GameEvent gameEvent)
		{
			if (gameEvent is QuestEvent questEvent && questEvent.Quest.Properties == _questProperties)
			{
				if (_triggerable.TryTrigger(questEvent.Quest.QuestGiver))
				{
					Uninitialize();
				}
				else
				{
					Debug.LogException(new Exception($"QuestCompletedTrigger '{_questProperties}' its triggerable did not trigger. This is a bug."));
				}
			}
		}
	}
}
