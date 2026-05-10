using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
	[Category("Branch")]
	[Description("Select a child to execute based on it's chance to be selected. An optional pre-Condition Task can be assigned to filter the child in or out of the selection probability.\nThe actor selected will be used for the condition checks.")]
	[Icon("ProbabilitySelector", false, null)]
	[Color("b3ff7f")]
	public class ProbabilitySelector : DTNode
	{
		public class Option
		{
			public BBParameter<float> weight;

			public ConditionTask condition;

			public Option(float weightValue, IBlackboard bbValue)
			{
			}
		}

		[SerializeField]
		[AutoSortWithChildrenConnections]
		private List<Option> childOptions;

		private List<int> successIndeces;

		public override int maxOutConnections => 0;

		public override void OnChildConnected(int index)
		{
		}

		public override void OnChildDisconnected(int index)
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		private float GetTotal()
		{
			return 0f;
		}

		protected override void OnReset()
		{
		}
	}
}
