using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions
{
	public class EvaluateCurve : ActionTask
	{
		[RequiredField]
		public BBParameter<AnimationCurve> curve;

		public BBParameter<float> from;

		public BBParameter<float> to;

		public BBParameter<float> time;

		[BlackboardOnly]
		public BBParameter<float> saveAs;

		protected override void OnUpdate()
		{
		}
	}
}
