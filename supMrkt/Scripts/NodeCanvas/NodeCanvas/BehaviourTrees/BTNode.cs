using System;
using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.BehaviourTrees
{
	public abstract class BTNode : Node
	{
		public sealed override Type outConnectionType => null;

		public sealed override bool allowAsPrime => false;

		public sealed override bool canSelfConnect => false;

		public override Alignment2x2 commentsAlignment => default(Alignment2x2);

		public override Alignment2x2 iconAlignment => default(Alignment2x2);

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public T AddChild<T>(int childIndex)
		{
			return default(T);
		}

		public T AddChild<T>()
		{
			return default(T);
		}
	}
}
