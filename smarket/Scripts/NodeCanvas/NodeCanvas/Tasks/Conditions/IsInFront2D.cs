using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Name("Target In View Angle 2D", 0)]
	[Category("GameObject")]
	[Description("Checks whether the target is in the view angle of the agent")]
	public class IsInFront2D : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> checkTarget;

		[SliderField(1, 180)]
		public BBParameter<float> viewAngle;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}

		public override void OnDrawGizmosSelected()
		{
		}
	}
}
