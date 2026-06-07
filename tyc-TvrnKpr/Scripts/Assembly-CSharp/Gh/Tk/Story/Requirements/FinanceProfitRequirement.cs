using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class FinanceProfitRequirement : PipProgressBaseRequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetFinanceCategories")]
		public string category;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override int GetCurrentValue(ActiveStory story)
		{
			return 0;
		}
	}
}
