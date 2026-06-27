namespace SleepyNodes
{
	[CreateNodeMenu("Wait/Barrier")]
	[NodeName("Wait Barrier")]
	[NodeWidth(400)]
	public class State_WaitBarrier : StateNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, connectionType = ConnectionType.Override, backingValue = ShowBackingValue.Never)]
		public StateNode To;

		public int Count;

		public bool AutoReset;

		public bool StopAfter;

		private int current;

		public override void ResetNode()
		{
		}

		public override void OnEnter(NodeExecutionState state)
		{
		}

		public override void OnExecute(NodeExecutionState state)
		{
		}
	}
}
