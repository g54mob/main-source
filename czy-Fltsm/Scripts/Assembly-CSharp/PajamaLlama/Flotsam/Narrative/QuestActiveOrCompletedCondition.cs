using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestActiveOrCompletedCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private QuestProperties _questProperties;

		public bool IsMet()
		{
			return StoryManager.IsQuestActiveOrCompleted(_questProperties);
		}
	}
}
