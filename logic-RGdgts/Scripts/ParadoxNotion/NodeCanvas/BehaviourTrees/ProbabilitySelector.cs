using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	public class ProbabilitySelector : BTComposite
	{
		[AutoSortWithChildrenConnections]
		public List<BBParameter<float>> childWeights;

		public BBParameter<float> failChance;

		private bool[] indexFailed;

		private float[] tmpWeights;

		private float tmpFailWeight;

		private float tmpTotal;

		private float tmpDice;

		public override void OnChildConnected(int index)
		{
		}

		public override void OnChildDisconnected(int index)
		{
		}

		public override void OnGraphStarted()
		{
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			return default(Status);
		}

		protected override void OnReset()
		{
		}
	}
}
