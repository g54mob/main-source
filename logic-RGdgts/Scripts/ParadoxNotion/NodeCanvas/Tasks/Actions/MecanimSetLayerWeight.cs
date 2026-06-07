using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class MecanimSetLayerWeight : ActionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		public BBParameter<float> layerWeight;

		public float transitTime;

		private float currentValue;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
