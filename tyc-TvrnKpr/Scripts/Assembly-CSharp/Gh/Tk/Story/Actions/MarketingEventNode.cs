using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class MarketingEventNode : ConnectedStoryNode
	{
		public float startInDayF;

		public float durationInDaysF;

		[Tooltip("can be null to affect the general business reputation, otherwise should match need types such as drink, food etc.")]
		public string category;

		public float reputationAdjustment;

		[StoryNodeTranslateFieldContent("Marketing Title", "Node")]
		public string title;

		[StoryNodeTranslateFieldContent("Marketing Description", "Node")]
		public string description;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
