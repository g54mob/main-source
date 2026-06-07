using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Navigation/Back Button", 50, false, false)]
	public class BackButtonNode : Node
	{
		public enum BackButtonState
		{
			Disable = 0,
			Enable = 1,
			EnableByForce = 2
		}

		public BackButtonState BackButtonAction;

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

		private void ExecuteActions()
		{
		}
	}
}
