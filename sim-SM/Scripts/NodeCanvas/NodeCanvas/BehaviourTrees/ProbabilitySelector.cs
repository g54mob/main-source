using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Selects a child to execute based on its chance to be selected and returns Success if the child returns Success, otherwise picks another child.\nReturns Failure if all children return Failure, or a direct 'Failure Chance' is introduced.")]
	[Icon("ProbabilitySelector", false, null)]
	[Color("b3ff7f")]
	public class ProbabilitySelector : BTComposite
	{
		[AutoSortWithChildrenConnections]
		[Tooltip("The weights of the children.")]
		public List<BBParameter<float>> childWeights;

		[Tooltip("A chance for the node to fail immediately.")]
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
