using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class CodexEntrySeenRequirementNode : RequirementNode
	{
		public string targetCodexId;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void CodexVisitedChanged(object sender, EventArgs<string> e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
