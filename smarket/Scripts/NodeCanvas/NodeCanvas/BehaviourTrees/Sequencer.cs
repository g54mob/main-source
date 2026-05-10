using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Sequencer", 10)]
	[Category("Composites")]
	[Description("Executes its children in order and returns Success if all children return Success. As soon as a child returns Failure, the Sequencer will stop and return Failure as well.")]
	[Icon("Sequencer", false, null)]
	[Color("bf7fff")]
	public class Sequencer : BTComposite
	{
		[Tooltip("If true, then higher priority children are re-evaluated per frame and if either returns Failure, then the Sequencer will immediately stop and return Failure as well.")]
		public bool dynamic;

		[Tooltip("If true, the children order of execution is shuffled each time the Sequencer resets.")]
		public bool random;

		private int lastRunningNodeIndex;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}

		public override void OnChildDisconnected(int index)
		{
		}

		public override void OnGraphStarted()
		{
		}
	}
}
