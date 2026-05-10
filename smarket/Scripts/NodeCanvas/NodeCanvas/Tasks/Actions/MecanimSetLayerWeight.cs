using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Layer Weight", 0)]
	[Category("Animator")]
	public class MecanimSetLayerWeight : ActionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		[SliderField(0, 1)]
		public BBParameter<float> layerWeight;

		[SliderField(0, 1)]
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
