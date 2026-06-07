using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class AdjustTavernMoneyNode : ConnectedStoryNode
	{
		[Header("adjustment value")]
		public int adjustment;

		[Tooltip("If this is set and a value is found, the value will be used as the adjustment")]
		public string adjustmentValueStoryFlagId;

		public bool invertValueFromStoryFlag;

		[Header("player info")]
		[DropDownChoice(typeof(StoryHelper), "GetFinanceCategories")]
		public string category;

		[StoryNodeTranslateFieldContent("Finance adjustment reason", "Node")]
		public string reason;

		public override void OnTrigger(ActiveStory story)
		{
		}

		private int GetAdjustment(ActiveStory story)
		{
			return 0;
		}

		protected override void GenerateI18nEntriesInternal(string context)
		{
		}
	}
}
