using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameStatChangedRequirementNode : RequirementNode
	{
		public string gameStatKey;

		private bool _hasChanged;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void StatChanged(object sender, EventArgs<(string key, int value)> e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
