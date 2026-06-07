using EasyRoads3Dv3;
using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	public class IntersectionRoadConnection : MonoBehaviour
	{
		public int entryConnectionIndex;

		public int entryLane = -1;

		public int exitConnectionIndex;

		public Transform from;

		public RoadNetworkData.RoadConnectionDirection fromDirection;

		public float probability = 0.25f;

		public bool reversed;

		public Transform to;

		protected void OnDrawGizmosSelected()
		{
			ERCrossingPrefabs componentInParent = GetComponentInParent<ERCrossingPrefabs>();
			if (componentInParent != null)
			{
				Vector3 vector = Vector3.zero;
				bool flag = false;
				if (from != null)
				{
					vector = from.position;
				}
				else if (entryConnectionIndex >= 0 && entryConnectionIndex < componentInParent.crossingElements.Count)
				{
					vector = componentInParent.transform.TransformPoint(componentInParent.crossingElements[entryConnectionIndex].centerPoint);
				}
				else
				{
					flag = true;
				}
				Vector3 vector2 = Vector3.zero;
				if (to != null)
				{
					vector2 = to.position;
				}
				else if (exitConnectionIndex >= 0 && exitConnectionIndex < componentInParent.crossingElements.Count)
				{
					vector2 = componentInParent.transform.TransformPoint(componentInParent.crossingElements[exitConnectionIndex].centerPoint);
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					float a = 0.5f;
					Gizmos.color = new Color(1f, 1f, 1f, a);
					Gizmos.DrawSphere(vector, 1f);
					Gizmos.color = new Color(1f, 1f, 0f, a);
					Gizmos.DrawSphere(vector2, 1f);
					Gizmos.color = new Color(1f, 1f, 1f, a);
					DrawArrow(vector, vector2, 0.5f, 30f);
				}
			}
		}

		private static void DrawArrow(Vector3 start, Vector3 end, float arrowHeadLength, float arrowHeadAngle)
		{
			Gizmos.DrawLine(start, end);
			Vector3 normalized = (end - start).normalized;
			Vector3 vector = Quaternion.LookRotation(normalized) * Quaternion.Euler(0f, 180f + arrowHeadAngle, 0f) * Vector3.forward;
			Vector3 vector2 = Quaternion.LookRotation(normalized) * Quaternion.Euler(0f, 180f - arrowHeadAngle, 0f) * Vector3.forward;
			Gizmos.DrawLine(end, end + vector * arrowHeadLength);
			Gizmos.DrawLine(end, end + vector2 * arrowHeadLength);
		}
	}
}
