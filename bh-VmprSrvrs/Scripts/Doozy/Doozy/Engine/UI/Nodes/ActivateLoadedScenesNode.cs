using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Scene Management/Activate Loaded Scenes", 50, false, false)]
	public class ActivateLoadedScenesNode : Node
	{
		private const float NODE_WIDTH = 236f;

		public override void OnCreate()
		{
		}

		public override float GetDefaultNodeWidth()
		{
			return 0f;
		}

		public override void AddDefaultSockets()
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}
	}
}
