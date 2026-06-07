using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Remapper : BTDecorator
	{
		public enum RemapStatus
		{
			Failure = 0,
			Success = 1
		}

		public RemapStatus successRemap;

		public RemapStatus failureRemap;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
