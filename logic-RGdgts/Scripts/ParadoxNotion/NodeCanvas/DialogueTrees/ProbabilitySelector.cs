using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.DialogueTrees
{
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
