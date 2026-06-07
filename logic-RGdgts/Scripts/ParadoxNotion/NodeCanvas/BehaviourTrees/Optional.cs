using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Optional : BTDecorator
	{
		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
