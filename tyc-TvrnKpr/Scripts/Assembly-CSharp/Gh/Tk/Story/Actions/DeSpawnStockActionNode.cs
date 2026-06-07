using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk.Story.Actions
{
	public class DeSpawnStockActionNode : ConnectedStoryNode
	{
		public StockSearchType searchType;

		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string itemKey;

		[DropDownChoice(typeof(StoryHelper), "GetAllItemTypes")]
		public string itemType;

		[Tooltip("if specified only maxAmount will be affected")]
		public int maxAmount;

		[StoryNodeTranslateFieldContent(null, "Node")]
		public string reason;

		private IEnumerable<GameItem> GetItems()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
