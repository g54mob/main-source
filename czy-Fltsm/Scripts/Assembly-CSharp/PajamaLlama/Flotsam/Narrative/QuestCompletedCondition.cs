using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestCompletedCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private QuestProperties _questProperties;

		public bool IsMet()
		{
			return StoryManager.IsQuestCompleted(_questProperties);
		}
	}
}
