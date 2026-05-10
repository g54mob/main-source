using System;
using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.StateMachines
{
	public abstract class FSMNode : Node
	{
		public override bool allowAsPrime => false;

		public override bool canSelfConnect => false;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public sealed override Type outConnectionType => null;

		public sealed override Alignment2x2 commentsAlignment => default(Alignment2x2);

		public sealed override Alignment2x2 iconAlignment => default(Alignment2x2);

		public FSM FSM => null;
	}
}
