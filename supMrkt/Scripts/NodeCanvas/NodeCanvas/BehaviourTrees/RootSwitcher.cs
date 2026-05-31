using System;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Obsolete]
	[Category("Mutators (beta)")]
	[Name("Root Switcher", 0)]
	[Description("Switch the root node of the behaviour tree to a new one defined by tag\nBeta Feature!")]
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
