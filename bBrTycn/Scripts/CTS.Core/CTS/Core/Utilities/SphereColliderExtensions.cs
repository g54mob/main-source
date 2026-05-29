using System;
using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class SphereColliderExtensions
	{
		public static bool CheckPhysics(this SphereCollider collider, int layerMask = -1, QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = collider.transform.lossyScale;
			float radius = Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z) * collider.radius;
			Transform transform = collider.transform;
			using (new TemporaryColliderEnable(collider, isEnabled: false))
			{
				return Physics.CheckSphere(transform.TransformPoint(collider.center), radius, layerMask, triggerInteraction);
			}
		}

		public static int OverlapNonAlloc(this SphereCollider collider, Collider[] results, int layerMask = -1, QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = collider.transform.lossyScale;
			float radius = Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z) * collider.radius;
			Transform transform = collider.transform;
			using (new TemporaryColliderEnable(collider, isEnabled: false))
			{
				return Physics.OverlapSphereNonAlloc(transform.TransformPoint(collider.center), radius, results, layerMask, triggerInteraction);
			}
		}

		public static Collider[] Overlap(this SphereCollider collider, int layerMask = -1, QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = collider.transform.lossyScale;
			float radius = Math.Max(Math.Max(lossyScale.x, lossyScale.y), lossyScale.z) * collider.radius;
			Transform transform = collider.transform;
			using (new TemporaryColliderEnable(collider, isEnabled: false))
			{
				return Physics.OverlapSphere(transform.TransformPoint(collider.center), radius, layerMask, triggerInteraction);
			}
		}
	}
}
