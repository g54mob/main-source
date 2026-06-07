using System.Collections.Generic;
using NodeCanvas.Framework;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CanSeeTargetAny2D : ConditionTask<Transform>
	{
		public BBParameter<List<GameObject>> targetObjects;

		public BBParameter<float> maxDistance;

		public BBParameter<LayerMask> layerMask;

		public BBParameter<float> awarnessDistance;

		public BBParameter<float> viewAngle;

		public Vector2 offset;

		[BlackboardOnly]
		public BBParameter<List<GameObject>> allResults;

		[BlackboardOnly]
		public BBParameter<GameObject> closerResult;

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
