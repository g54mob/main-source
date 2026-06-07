using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.GameModifiers
{
	[InitializeOnGameStarted]
	[NodeTint("#FF0000")]
	public class AllowPropBuildingEverywhereGameModifierNode : GameModifierNode
	{
		private static bool? _state;

		public static bool AllowedEverywhere => false;

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
