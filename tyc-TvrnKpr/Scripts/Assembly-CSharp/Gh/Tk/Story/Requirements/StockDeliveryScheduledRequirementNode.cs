using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StockDeliveryScheduledRequirementNode : RequirementNode
	{
		public enum FilterType
		{
			ByItemType = 0,
			ByTemplateId = 1,
			ByCategory = 2
		}

		[Header("Filter")]
		public FilterType filterType;

		[DropDownChoice(typeof(StoryHelper), "GetAllItemTypes")]
		public string itemType;

		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string templateId;

		[DropDownChoice(typeof(StoryHelper), "GetAllItemCategories")]
		public string category;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
