using UnityEngine;

namespace Assets.Scripts.Environment.Roads.Data
{
	public class IntersectionRoad : MonoBehaviour
	{
		public string roadType;

		public float speedMultiplier = 1f;

		public int RoadID { get; set; }

		[ContextMenu("Snap Points To Road")]
		public void SnapPointsToRoad()
		{
			foreach (Transform item in base.transform)
			{
				if (Physics.Raycast(new Ray(item.position + Vector3.up * 100f, Vector3.down), out var hitInfo, 10000f, 4096))
				{
					item.transform.position = hitInfo.point;
				}
			}
		}

		protected void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			foreach (Transform item in base.transform)
			{
				Gizmos.DrawSphere(item.position, 0.5f);
			}
		}
	}
}
