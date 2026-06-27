namespace SleepyNodes
{
	[CreateNodeMenu("Wait/For Seconds")]
	[NodeName("Wait Seconds")]
	[NodeWidth(300)]
	public class State_WaitSeconds : StateNode
	{
		[Output(ShowBackingValue.Never, ConnectionType.Multiple, TypeConstraint.None, false, connectionType = ConnectionType.Override, backingValue = ShowBackingValue.Never)]
		public StateNode To;

		public float Seconds;

		public override void OnEnter(NodeExecutionState state)
		{
		}

		public override void OnExecute(NodeExecutionState state)
		{
		}
	}
}
