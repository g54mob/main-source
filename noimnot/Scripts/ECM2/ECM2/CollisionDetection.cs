using UnityEngine;

namespace ECM2
{
	public static class CollisionDetection
	{
		private const int kMaxHits = 8;

		private static readonly RaycastHit[] HitsBuffer;

		public static int Raycast(Vector3 origin, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit closestHit, RaycastHit[] hits, IColliderFilter colliderFilter)
		{
			closestHit = default(RaycastHit);
			return 0;
		}

		public static int SphereCast(Vector3 origin, float radius, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit closestHit, RaycastHit[] hits, IColliderFilter colliderFilter, float backStepDistance)
		{
			closestHit = default(RaycastHit);
			return 0;
		}

		public static int CapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance, int layerMask, QueryTriggerInteraction queryTriggerInteraction, out RaycastHit closestHit, RaycastHit[] hits, IColliderFilter colliderFilter, float backStepDistance)
		{
			closestHit = default(RaycastHit);
			return 0;
		}

		public static int OverlapCapsule(Vector3 point1, Vector3 point2, float radius, int layerMask, QueryTriggerInteraction queryTriggerInteraction, Collider[] results, IColliderFilter colliderFilter)
		{
			return 0;
		}
	}
}
