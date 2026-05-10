using UnityEngine;

namespace ECM2
{
	public struct FindGroundResult
	{
		public bool hitGround;

		public bool isWalkable;

		public Vector3 position;

		public Vector3 surfaceNormal;

		public Collider collider;

		public float groundDistance;

		public bool isRaycastResult;

		public float raycastDistance;

		public RaycastHit hitResult;

		public bool isWalkableGround => false;

		public Vector3 point => default(Vector3);

		public Vector3 normal => default(Vector3);

		public Rigidbody rigidbody => null;

		public Transform transform => null;

		public float GetDistanceToGround()
		{
			return 0f;
		}

		public void SetFromSweepResult(bool hitGround, bool isWalkable, Vector3 position, float sweepDistance, ref RaycastHit inHit, Vector3 surfaceNormal)
		{
		}

		public void SetFromSweepResult(bool hitGround, bool isWalkable, Vector3 position, Vector3 point, Vector3 normal, Vector3 surfaceNormal, Collider collider, float sweepDistance)
		{
		}

		public void SetFromRaycastResult(bool hitGround, bool isWalkable, Vector3 position, float sweepDistance, float castDistance, ref RaycastHit inHit)
		{
		}
	}
}
