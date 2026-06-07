using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class SampleCurve : ActionTask
	{
		[RequiredField]
		public BBParameter<AnimationCurve> curve;

		public BBParameter<float> sampleAt;

		[BlackboardOnly]
		public BBParameter<float> saveAs;

		protected override void OnExecute()
		{
		}
	}
}
