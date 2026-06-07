using System;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class NoActiveQuestCondition : IScenarioTriggerableCondition
	{
		public bool IsMet()
		{
			return !StoryManager.HasAnyActiveQuest();
		}
	}
}
