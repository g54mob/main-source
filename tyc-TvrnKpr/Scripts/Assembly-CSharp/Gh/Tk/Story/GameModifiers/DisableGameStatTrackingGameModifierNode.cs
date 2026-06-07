using UnityEngine.Scripting;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	public class DisableGameStatTrackingGameModifierNode : GameModifierNode
	{
		private static bool? _state;

		public static bool IsGameStatTrackingDisabled => false;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateState()
		{
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
