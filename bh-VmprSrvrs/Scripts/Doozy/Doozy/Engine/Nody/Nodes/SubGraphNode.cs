using Doozy.Engine.Nody.Attributes;
using Doozy.Engine.Nody.Models;
using UnityEngine;

namespace Doozy.Engine.Nody.Nodes
{
	[NodeMenu("SubGraph", 1, true, false)]
	public class SubGraphNode : Node
	{
		[SerializeField]
		private Graph m_subGraph;

		public bool ErrorNoGraphReferenced;

		public bool ErrorReferencedGraphIsNotSubGraph;

		public Graph SubGraph => null;

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

		public override void CopyNode(Node original)
		{
		}

		public override void OnEnter(Node previousActiveNode, Connection connection)
		{
		}

		public void ExitSubGraphNode()
		{
		}
	}
}
