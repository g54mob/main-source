using NodeCanvas.Framework;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	public class Jumper : DTNode, IHaveNodeReference, IGraphElement
	{
		[fsSerializeAs]
		public NodeReference<DTNode> _targetNode;

		INodeReference IHaveNodeReference.targetReference => null;

		private DTNode target => null;

		public override int maxOutConnections => 0;

		public override bool requireActorSelection => false;

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}
	}
}
