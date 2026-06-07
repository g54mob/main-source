using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CanSeeTarget : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> target;

		public BBParameter<float> maxDistance;

		public BBParameter<LayerMask> layerMask;

		public BBParameter<float> awarnessDistance;

		public BBParameter<float> viewAngle;

		public Vector3 offset;

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
