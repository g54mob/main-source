using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Name("Invert", 0)]
	[Category("Decorators")]
	[Description("Inverts Success to Failure and Failure to Success.")]
	[Icon("Remap", false, null)]
	public class Inverter : BTDecorator
	{
		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
