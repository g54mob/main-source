using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Selector", 9)]
	[Category("Composites")]
	[Description("Executes its childrfen in order and returns Failure if all children return Failure. As soon as a child returns Success, the Selector will stop and return Success as well.")]
	[Icon("Selector", false, null)]
	[Color("b3ff7f")]
	public class Selector : BTComposite
	{
		[Tooltip("If true, then higher priority children are re-evaluated per frame and if either returns Success, then the Selector will immediately stop and return Success as well.")]
		public bool dynamic;

		[Tooltip("If true, the children order of execution is shuffled each time the Selector resets.")]
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
