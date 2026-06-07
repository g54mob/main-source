using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StockTypeRequirement : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllItemTypes")]
		public string itemType;

		public int minCount;

		public bool onlyCountPlayerMade;

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
