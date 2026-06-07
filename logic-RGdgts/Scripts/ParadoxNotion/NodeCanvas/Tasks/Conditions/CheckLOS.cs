using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckLOS : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> LOSTarget;

		public BBParameter<LayerMask> layerMask;

		public Vector3 offset;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

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
