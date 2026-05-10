using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Play Animation", 0)]
	[Category("Animator")]
	public class MecanimPlayAnimation : ActionTask<Animator>
	{
		public BBParameter<int> layerIndex;

		[RequiredField]
		public BBParameter<string> stateName;

		[SliderField(0, 1)]
		public float transitTime;

		public bool waitUntilFinish;

		private AnimatorStateInfo stateInfo;

		private bool played;

		protected override string info => null;

		protected override void OnExecute()
		{
		}

		protected override void OnUpdate()
		{
		}
	}
}
