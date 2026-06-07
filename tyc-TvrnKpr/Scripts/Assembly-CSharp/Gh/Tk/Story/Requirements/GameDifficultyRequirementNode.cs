using UnityEngine.Scripting;

namespace Gh.Tk.Story.Requirements
{
	[InitializeOnGameStarted]
	public class GameDifficultyRequirementNode : RequirementNode
	{
		public DifficultyPreset targetSetting;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void SettingsChanged(object sender, object obj)
		{
		}

		protected override bool IsMetInternal(ActiveStory story)
		{
			return false;
		}
	}
}
