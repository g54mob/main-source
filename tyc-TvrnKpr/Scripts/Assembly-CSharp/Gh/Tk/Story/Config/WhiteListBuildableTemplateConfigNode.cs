using UnityEngine;
using UnityEngine.Scripting;
using XNode;

namespace Gh.Tk.Story.Config
{
	[InitializeOnGameStarted]
	public class WhiteListBuildableTemplateConfigNode : StoryNode
	{
		[Input(ShowBackingValue.Unconnected, ConnectionType.Multiple, TypeConstraint.None, false)]
		public NodeConnection parent;

		private static WhiteListBuildableTemplateConfigNode[] _nodes;

		[Tooltip("If true decorations will be filtered, otherwise props will be filtered")]
		public bool isDecorationWhitelist;

		public string[] enabledBuildableTemplateIds;

		private static WhiteListBuildableTemplateConfigNode[] ActiveNodes => null;

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private static void InvalidateActiveNodes()
		{
		}

		public static bool IsTemplateAllowed(BuildableTemplate template)
		{
			return false;
		}
	}
}
