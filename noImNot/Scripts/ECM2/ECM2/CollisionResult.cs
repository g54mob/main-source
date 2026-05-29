using UnityEngine;

namespace ECM2
{
	public struct CollisionResult
	{
		public bool startPenetrating;

		public HitLocation hitLocation;

		public bool isWalkable;

		public Vector3 position;

		public Vector3 velocity;

		public Vector3 otherVelocity;

		public Vector3 point;

		public Vector3 normal;

		public Vector3 surfaceNormal;

		public Vector3 displacementToHit;

		public Vector3 remainingDisplacement;

		public Collider collider;

		public RaycastHit hitResult;

		public Rigidbody rigidbody => null;

		public Transform transform => null;
	}
}
