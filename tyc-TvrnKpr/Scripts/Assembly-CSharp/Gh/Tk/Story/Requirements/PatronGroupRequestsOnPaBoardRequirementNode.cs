using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class PatronGroupRequestsOnPaBoardRequirementNode : RequirementNode
	{
		private static readonly string[] _relevantGameStats;

		public int minGroupRequestsOnBoard;

		public int maxAcceptedRequestsOnBoard;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void GameStatChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
