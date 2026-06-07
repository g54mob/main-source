using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class Setter : BTDecorator
	{
		public bool revertToOriginal;

		public BBParameter<GameObject> newAgent;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
