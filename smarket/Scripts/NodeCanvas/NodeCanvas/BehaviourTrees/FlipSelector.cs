using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Works like a normal Selector, but when a child returns Success, that child will be moved to the end.\nAs a result, previously Failed children will always be checked first and recently Successful children last.")]
	[Icon("FlipSelector", false, null)]
	[Color("b3ff7f")]
	public class FlipSelector : BTComposite
	{
		private int current;

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		private void SendToBack(int i)
		{
		}

		protected override void OnReset()
		{
		}
	}
}
