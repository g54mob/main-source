using System;

namespace Gh.Tk.Story.Actions
{
	public class ScheduleStockDeliveryActionNode : ConnectedStoryNode
	{
		[Serializable]
		public struct StockDeliveryItemConfig
		{
			[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
			public string itemKey;

			public int amount;
		}

		[StoryNodeTranslateFieldContent("orderFromDisplayName", "Node")]
		public string orderFromDisplayName;

		public StockDeliveryItemConfig[] stockToDeliver;

		public float daysUntilDelivery;

		public bool isFastDelivery;

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
