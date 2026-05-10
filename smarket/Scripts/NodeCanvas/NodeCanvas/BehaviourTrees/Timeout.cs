using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Decorators")]
	[Description("Interupts decorated child node and returns Failure if the child node is still Running after the timeout period.")]
	[Icon("Timeout", false, null)]
	public class Timeout : BTDecorator
	{
		[Tooltip("The timeout period in seconds.")]
		public BBParameter<float> timeout;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}
	}
}
