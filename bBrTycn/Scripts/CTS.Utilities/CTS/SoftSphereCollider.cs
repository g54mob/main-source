using System;
using UnityEngine;

namespace CTS
{
	public class SoftSphereCollider : SoftCollider
	{
		[SerializeField]
		private Vector3 _center;

		[SerializeField]
		[Min(0f)]
		private float _radius = 0.5f;

		public override Vector3 Center { get; }

		public override int Overlap(Collider[] p_results, int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = base.transform.lossyScale;
			float radius = Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z) * _radius;
			return Physics.OverlapSphereNonAlloc(base.transform.TransformPoint(_center), radius, p_results, p_layerMask, p_triggerInteraction);
		}

		public override bool Check(int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = base.transform.lossyScale;
			float radius = Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z) * _radius;
			return Physics.CheckSphere(base.transform.TransformPoint(_center), radius, p_layerMask, p_triggerInteraction);
		}

		private void OnDrawGizmosSelected()
		{
			Vector3 lossyScale = base.transform.lossyScale;
			Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z);
			_ = _radius;
			base.transform.TransformPoint(_center);
			Gizmos.color = new Color(0f, 1f, 0.56f);
		}
	}
}
