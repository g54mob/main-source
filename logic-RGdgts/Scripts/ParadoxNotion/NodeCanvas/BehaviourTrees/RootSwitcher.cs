using System;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Obsolete]
	public class RootSwitcher : BTNode
	{
		public string targetNodeTag;

		private Node targetNode;

		public override void OnGraphStarted()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
