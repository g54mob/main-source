using ParadoxNotion;

namespace NodeCanvas.BehaviourTrees
{
	public abstract class BTComposite : BTNode
	{
		public override string name => null;

		public sealed override int maxOutConnections => 0;

		public sealed override Alignment2x2 commentsAlignment => default(Alignment2x2);
	}
}
