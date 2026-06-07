using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class StockRequirement : PipProgressBaseRequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string itemKey;

		[Tooltip("If true, containers will be counted as one item, if false, the contents of the containers will be counted")]
		public bool countContainersAsOne;

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

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
