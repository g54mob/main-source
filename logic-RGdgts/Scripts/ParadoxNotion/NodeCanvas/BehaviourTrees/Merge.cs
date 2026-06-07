using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Merge : BTDecorator
	{
		public override int maxInConnections => 0;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
