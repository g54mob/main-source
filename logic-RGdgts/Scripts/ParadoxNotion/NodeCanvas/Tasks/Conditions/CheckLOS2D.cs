using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckLOS2D : ConditionTask<Transform>
	{
		[RequiredField]
		public BBParameter<GameObject> LOSTarget;

		public BBParameter<LayerMask> layerMask;

		[BlackboardOnly]
		public BBParameter<float> saveDistanceAs;

		[GetFromAgent]
		protected Collider2D agentCollider;

		private RaycastHit2D[] hits;

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
