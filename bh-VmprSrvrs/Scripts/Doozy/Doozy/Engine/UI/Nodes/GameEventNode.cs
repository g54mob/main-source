using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Game Event", 1, false, false)]
	public class GameEventNode : Node
	{
		public string GameEvent;

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public override void CheckForErrors()
		{
		}

		private void SendGameEvent()
		{
		}
	}
}
