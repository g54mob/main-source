using UnityEngine;

namespace UMA.Examples
{
	public class UMAGlobalForceApplier : MonoBehaviour
	{
		public float MinGlobalForce;

		public float MaxGlobalForce;

		public float ForceMultiplier;

		public bool ApplyGlobalForces;

		public Transform MovementTracker;

		public Rigidbody AttachedRigidBody;

		public Vector3 parentPosLastFrame;

		public void Update()
		{
		}
	}
}
