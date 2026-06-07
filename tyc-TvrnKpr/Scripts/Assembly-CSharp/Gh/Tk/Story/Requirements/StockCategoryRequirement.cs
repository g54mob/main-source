using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StockCategoryRequirement : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllItemCategories")]
		public string itemCategory;

		public int minCount;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnStockChanged(ActiveStory data, GameItemTemplate template)
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory data)
		{
			return false;
		}
	}
}
