using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestNotStartedCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private QuestProperties _questProperties;

		public bool IsMet()
		{
			return !StoryManager.IsQuestActiveOrCompleted(_questProperties);
		}
	}
}
