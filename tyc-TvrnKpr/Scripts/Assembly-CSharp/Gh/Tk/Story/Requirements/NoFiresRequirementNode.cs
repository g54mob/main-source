using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class NoFiresRequirementNode : RequirementNode
	{
		[Preserve]
		private static void OnGameStarted()
		{
		}

		public override string GetLabelKey(ActiveStory story)
		{
			return null;
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
