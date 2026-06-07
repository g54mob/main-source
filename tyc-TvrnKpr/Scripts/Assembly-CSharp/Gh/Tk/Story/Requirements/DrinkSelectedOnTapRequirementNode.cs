using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class DrinkSelectedOnTapRequirementNode : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override string GetLabelKey(ActiveStory data)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
