using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.Nody.Nodes
{
	[NodeMenu(null, 0, false, false)]
	public class ExitNode : Node
	{
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

		public override void CheckForErrors()
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}
	}
}
