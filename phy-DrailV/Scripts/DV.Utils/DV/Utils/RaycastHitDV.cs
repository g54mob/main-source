using UnityEngine;

namespace DV.Utils
{
	public readonly struct RaycastHitDV
	{
		public readonly Collider collider;

		public readonly Vector3 point;

		public readonly Vector3 normal;

		public readonly float distance;

		public Transform transform
		{
			get
			{
				Rigidbody rigidbody = this.rigidbody;
				if (rigidbody != null)
				{
					return rigidbody.transform;
				}
				if (!(collider != null))
				{
					return null;
				}
				return collider.transform;
			}
		}

		public Rigidbody rigidbody
		{
			get
			{
				if (!(collider != null))
				{
					return null;
				}
				return collider.attachedRigidbody;
			}
		}

		public RaycastHitDV(Collider collider, Vector3 point, Vector3 normal, float distance)
		{
			this.collider = collider;
			this.point = point;
			this.normal = normal;
			this.distance = distance;
		}

		public RaycastHitDV(RaycastHit hit)
		{
			collider = hit.collider;
			point = hit.point;
			normal = hit.normal;
			distance = hit.distance;
		}
	}
}
