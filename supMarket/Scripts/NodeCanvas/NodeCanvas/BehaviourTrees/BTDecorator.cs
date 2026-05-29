using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.BehaviourTrees
{
	public abstract class BTDecorator : BTNode
	{
		public sealed override int maxOutConnections => 0;

		public sealed override Alignment2x2 commentsAlignment => default(Alignment2x2);

		protected Connection decoratedConnection => null;

		protected Node decoratedNode => null;
	}
}
