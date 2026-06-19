using UnityEngine;

namespace SimplySVG
{
	[RequireComponent(typeof(PolygonCollider2D))]
	public class ColliderHelper : MonoBehaviour
	{
		public CollisionShapeData collisionShapeData;

		public bool autoUpdateOnAwake = true;

		private PolygonCollider2D polygonCollider;

		public void UpdateColliderShape()
		{
			if (collisionShapeData == null)
			{
				Debug.LogError("No collision shape data selected");
				return;
			}
			if (polygonCollider == null)
			{
				polygonCollider = GetComponent<PolygonCollider2D>();
				if (polygonCollider == null)
				{
					polygonCollider = base.gameObject.AddComponent<PolygonCollider2D>();
				}
			}
			polygonCollider.pathCount = collisionShapeData.collisionPolygons.Count;
			for (int i = 0; i < collisionShapeData.collisionPolygons.Count; i++)
			{
				polygonCollider.SetPath(i, collisionShapeData.collisionPolygons[i].points.ToArray());
			}
		}

		private void Awake()
		{
			if (autoUpdateOnAwake)
			{
				UpdateColliderShape();
			}
		}
	}
}
