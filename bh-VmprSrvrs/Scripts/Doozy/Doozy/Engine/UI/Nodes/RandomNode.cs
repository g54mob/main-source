using System.Collections.Generic;
using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;

namespace Doozy.Engine.UI.Nodes
{
	[NodeMenu("System/Random", 50, false, false)]
	public class RandomNode : Node
	{
		private readonly List<int> m_selectChances;

		public int MaxChance { get; private set; }

		public int ConnectedOutputSockets { get; private set; }

		public override void OnCreate()
		{
		}

		public override void AddDefaultSockets()
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public void UpdateMaxChance()
		{
		}

		public void UpdateConnectedOutputSockets()
		{
		}

		private void SelectRandomOutputSocket()
		{
		}
	}
}
