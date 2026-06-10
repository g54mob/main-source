using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.BehaviourTrees
{
	[Category("Composites")]
	[Description("Selects a child to execute based on its chance to be selected and returns Success if the child returns Success, otherwise picks another child.\nReturns Failure if all children return Failure, or a direct 'Failure Chance' is introduced.")]
	[ParadoxNotion.Design.Icon("ProbabilitySelector", false, "")]
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
			if (childWeights == null)
			{
				childWeights = new List<BBParameter<float>>();
			}
			if (childWeights.Count < base.outConnections.Count)
			{
				childWeights.Insert(index, new BBParameter<float>
				{
					value = 1f,
					bb = base.graphBlackboard
				});
			}
		}

		public override void OnChildDisconnected(int index)
		{
			childWeights.RemoveAt(index);
		}

		public override void OnGraphStarted()
		{
			OnReset();
		}

		protected override Status OnExecute(Component agent, IBlackboard blackboard)
		{
			if (base.status == Status.Resting)
			{
				tmpDice = Random.value;
				tmpFailWeight = failChance.value;
				tmpTotal = tmpFailWeight;
				for (int i = 0; i < childWeights.Count; i++)
				{
					float value = childWeights[i].value;
					tmpTotal += value;
					tmpWeights[i] = value;
				}
			}
			float num = tmpFailWeight / tmpTotal;
			if (tmpDice < num)
			{
				return Status.Failure;
			}
			for (int j = 0; j < base.outConnections.Count; j++)
			{
				if (indexFailed[j])
				{
					continue;
				}
				num += tmpWeights[j] / tmpTotal;
				if (tmpDice <= num)
				{
					base.status = base.outConnections[j].Execute(agent, blackboard);
					if (base.status == Status.Success || base.status == Status.Running)
					{
						return base.status;
					}
					if (base.status == Status.Failure)
					{
						indexFailed[j] = true;
						tmpTotal -= tmpWeights[j];
						return Status.Running;
					}
				}
			}
			return Status.Failure;
		}

		protected override void OnReset()
		{
			tmpWeights = new float[base.outConnections.Count];
			indexFailed = new bool[base.outConnections.Count];
		}
	}
}
