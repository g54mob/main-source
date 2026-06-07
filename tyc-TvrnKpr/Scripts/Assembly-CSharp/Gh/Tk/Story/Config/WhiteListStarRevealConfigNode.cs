using System.Collections.Generic;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Config
{
	[InitializeOnGameStarted]
	public class WhiteListStarRevealConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		public List<string> allowedStarReveals;

		private static WhiteListStarRevealConfigNode[] _nodes;

		private static WhiteListStarRevealConfigNode[] ActiveNodes => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateActiveNodes()
		{
		}

		public static IEnumerable<string> GetAllowedStarReveals()
		{
			return null;
		}
	}
}
