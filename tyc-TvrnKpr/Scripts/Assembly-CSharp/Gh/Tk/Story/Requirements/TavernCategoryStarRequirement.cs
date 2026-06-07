using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class TavernCategoryStarRequirement : RequirementNode
	{
		public int stars;

		[DropDownChoice(typeof(StoryHelper), "GetStarRatingCategories")]
		public string category;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void OnStarsChanged(StarRatingManager manager)
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
