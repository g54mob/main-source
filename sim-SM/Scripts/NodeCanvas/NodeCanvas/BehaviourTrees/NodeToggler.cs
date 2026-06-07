using System;
using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Obsolete]
	[Category("Mutators (beta)")]
	[Name("Node Toggler", 0)]
	[Description("Enable, Disable or Toggle one or more nodes with provided tag. In practise their incomming connections are disabled\nBeta Feature!")]
	public class NodeToggler : BTNode
	{
		public enum ToggleMode
		{
			Enable = 0,
			Disable = 1,
			Toggle = 2
		}

		public ToggleMode toggleMode;

		public string targetNodeTag;

		private List<Node> targetNodes;

		public override void OnGraphStarted()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
