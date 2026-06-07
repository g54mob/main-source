using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class BuildMenuStateRequirementNode : RequirementNode
	{
		public BuildMenuState targetState;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void OnBuildMenuStateChanged(object sender, ValueChangedEventArgs<BuildMenuState> e)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
