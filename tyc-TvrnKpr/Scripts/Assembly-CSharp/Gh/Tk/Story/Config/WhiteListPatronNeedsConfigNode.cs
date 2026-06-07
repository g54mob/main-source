using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Config
{
	[InitializeOnGameStarted]
	public class WhiteListPatronNeedsConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public bool enableAllUnlockedNeeds;

		[DropDownChoice(typeof(StoryHelper), "GetAllPatronNeedTypes")]
		public string[] enabledNeedTypes;

		private static WhiteListPatronNeedsConfigNode[] _nodes;

		private static WhiteListPatronNeedsConfigNode[] ActiveNodes => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateActiveNodes()
		{
		}

		public static bool IsNeedTypeDisabled(string needType)
		{
			return false;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}
	}
}
