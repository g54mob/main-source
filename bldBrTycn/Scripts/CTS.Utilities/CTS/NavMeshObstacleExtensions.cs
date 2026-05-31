using UnityEngine;
using UnityEngine.AI;

namespace CTS
{
	public static class NavMeshObstacleExtensions
	{
		public static int OverlapNonAlloc(this NavMeshObstacle navObstacle, Collider[] results, int layerMask = -1, QueryTriggerInteraction triggerInteraction = QueryTriggerInteraction.UseGlobal)
		{
			bool enabled = navObstacle.enabled;
			navObstacle.enabled = false;
			Vector3 lossyScale = navObstacle.transform.lossyScale;
			lossyScale.Scale(navObstacle.size);
			Transform transform = navObstacle.transform;
			int result = Physics.OverlapBoxNonAlloc(transform.TransformPoint(navObstacle.center), lossyScale * 0.5f, results, transform.rotation, layerMask, triggerInteraction);
			navObstacle.enabled = enabled;
			return result;
		}
	}
}
