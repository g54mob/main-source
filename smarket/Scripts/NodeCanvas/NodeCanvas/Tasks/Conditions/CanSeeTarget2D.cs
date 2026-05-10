using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	[Description("A combination of line of sight and view angle check")]
	public class CanSeeTarget2D : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		[Tooltip("Distance within which to look out for.")]
		public BBParameter<float> maxDistance;

		[Tooltip("A layer mask to use for the line of sight check.")]
		public BBParameter<LayerMask> layerMask;

		[Tooltip("Distance within which the target can be seen (or rather sensed) regardless of view angle.")]
		public BBParameter<float> awarnessDistance;

		[SliderField(1, 180)]
		public BBParameter<float> viewAngle;

		public Vector2 offset;

		private RaycastHit2D hit;

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
