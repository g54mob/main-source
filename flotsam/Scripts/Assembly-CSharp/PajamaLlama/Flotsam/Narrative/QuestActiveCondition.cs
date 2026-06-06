using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class QuestActiveCondition : IScenarioTriggerableCondition
	{
		[SerializeField]
		private QuestProperties _questProperties;

		public bool IsMet()
		{
			return StoryManager.IsQuestActive(_questProperties);
		}
	}
}
