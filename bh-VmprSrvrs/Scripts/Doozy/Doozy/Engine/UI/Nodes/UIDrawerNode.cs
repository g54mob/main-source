using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("Navigation/UIDrawer", 50, false, false)]
	public class UIDrawerNode : Node
	{
		public enum DrawerAction
		{
			Open = 0,
			Close = 1,
			Toggle = 2
		}

		public string DrawerName;

		public bool CustomDrawerName;

		public DrawerAction Action;

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

		public override void CheckForErrors()
		{
		}
	}
}
