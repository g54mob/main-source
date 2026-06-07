using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class HaveCraftableIngredientRequestedRequirementNode : RequirementNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllItemTypes")]
		public string gameItemType;

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
