using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class StepIterator : BTComposite
	{
		private int current;

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
	}
}
