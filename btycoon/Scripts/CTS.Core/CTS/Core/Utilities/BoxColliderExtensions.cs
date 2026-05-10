using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class BoxColliderExtensions
	{
		public static void AutoSet(this BoxCollider boxCollider, Bounds p_bounds)
		{
			boxCollider.center = p_bounds.center - boxCollider.transform.position;
			boxCollider.size = p_bounds.size;
		}

		public static bool CheckPhysics(this BoxCollider p_collider, int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = p_collider.transform.lossyScale;
			lossyScale.Scale(p_collider.size);
			Transform transform = p_collider.transform;
			using (new TemporaryColliderEnable(p_collider, isEnabled: false))
			{
				return Physics.CheckBox(transform.TransformPoint(p_collider.center), lossyScale * 0.5f, transform.rotation, p_layerMask, p_triggerInteraction);
			}
		}

		public static int OverlapNonAlloc(this BoxCollider p_collider, Collider[] p_results, int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = p_collider.transform.lossyScale;
			lossyScale.Scale(p_collider.size);
			Transform transform = p_collider.transform;
			p_collider.Overlap();
			using (new TemporaryColliderEnable(p_collider, isEnabled: false))
			{
				return Physics.OverlapBoxNonAlloc(transform.TransformPoint(p_collider.center), lossyScale * 0.5f, p_results, transform.rotation, p_layerMask, p_triggerInteraction);
			}
		}

		public static Collider[] Overlap(this BoxCollider p_collider, int p_layerMask = -1, QueryTriggerInteraction p_triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			Vector3 lossyScale = p_collider.transform.lossyScale;
			lossyScale.Scale(p_collider.size);
			Transform transform = p_collider.transform;
			using (new TemporaryColliderEnable(p_collider, isEnabled: false))
			{
				return Physics.OverlapBox(transform.TransformPoint(p_collider.center), lossyScale * 0.5f, transform.rotation, p_layerMask, p_triggerInteraction);
			}
		}
	}
}
