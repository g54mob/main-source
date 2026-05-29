using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Icon("Selector", false, null)]
	[Name("Multiple Task Condition", 0)]
	[Category("Branch")]
	[Description("Will continue with the first child node which condition returns true. The Dialogue Actor selected will be used for the checks")]
	[Color("b3ff7f")]
	public class MultipleConditionNode : DTNode
	{
		[SerializeField]
		[AutoSortWithChildrenConnections]
		private List<ConditionTask> conditions;

		public override int maxOutConnections => 0;

		public override void OnChildConnected(int index)
		{
		}

		public override void OnChildDisconnected(int index)
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard bb)
		{
			return default(Status);
		}
	}
}
