using NodeCanvas.Framework;

namespace NodeCanvas.StateMachines
{
	public class AnyState : FSMNode, IUpdatable, IGraphElement
	{
		public bool dontRetriggerStates;

		public override string name => null;

		public override int maxInConnections => 0;

		public override int maxOutConnections => 0;

		public override bool allowAsPrime => false;

		public override void OnGraphStarted()
		{
		}

		public override void OnGraphStoped()
		{
		}

		void IUpdatable.Update()
		{
		}
	}
}
