using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Sequencer : BTComposite
	{
		public bool dynamic;

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
