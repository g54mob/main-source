using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class MecanimIsInTransition : ConditionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
