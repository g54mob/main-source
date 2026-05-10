using System.Collections.Generic;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("GameObject")]
	[Description("A combination of line of sight and view angle check")]
	public class CanSeeTargetAny : ConditionTask<Transform>
	{
		public BBParameter<List<GameObject>> targetObjects;

		public BBParameter<float> maxDistance;

		public BBParameter<LayerMask> layerMask;

		public BBParameter<float> awarnessDistance;

		[SliderField(1, 180)]
		public BBParameter<float> viewAngle;

		public Vector3 offset;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> allResults;

		[BlackboardOnly]
		public BBParameter<GameObject> closerResult;

		private RaycastHit hit;

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
