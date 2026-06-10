using UnityEngine;

namespace Aura2API
{
	public abstract class CullableObject : MonoBehaviour
	{
		private BoundingSphere _boundingSphere;

		public BoundingSphere BoundingSphere => _boundingSphere;

		public void UpdateBoundingSphere(Vector3 position, float radius)
		{
			_boundingSphere.position = position;
			_boundingSphere.radius = radius;
		}

		public void UpdateBoundingSphere(BoundingSphere boundingSphere)
		{
			_boundingSphere = boundingSphere;
		}

		public bool CheckFrustumOverlap(Plane[] frustumPlanes)
		{
			for (int i = 0; i < frustumPlanes.Length; i++)
			{
				if (frustumPlanes[i].GetDistanceToPoint(BoundingSphere.position) < 0f - BoundingSphere.radius)
				{
					return false;
				}
			}
			return true;
		}
	}
}
