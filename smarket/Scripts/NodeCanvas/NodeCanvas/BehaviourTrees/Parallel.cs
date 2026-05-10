using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Parallel", 8)]
	[Category("Composites")]
	[Description("Executes all children simultaneously and return Success or Failure depending on the selected Policy.")]
	[Icon("Parallel", false, null)]
	[Color("ff64cb")]
	public class Parallel : BTComposite
	{
		public enum ParallelPolicy
		{
			FirstFailure = 0,
			FirstSuccess = 1,
			FirstSuccessOrFailure = 2
		}

		[Tooltip("The policy determines when the Parallel node will end and return its Status.")]
		public ParallelPolicy policy;

		[Name("Repeat", 0)]
		[Tooltip("If true, finished children are repeated until the Policy set is met, or until all children have had a chance to finish at least once.")]
		public bool dynamic;

		private bool[] finishedConnections;

		private int finishedConnectionsCount;

		public override void OnGraphStarted()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}

		private void ResetRunning()
		{
		}
	}
}
