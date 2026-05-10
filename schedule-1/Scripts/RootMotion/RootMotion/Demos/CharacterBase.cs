using UnityEngine;

namespace RootMotion.Demos
{
	public abstract class CharacterBase : MonoBehaviour
	{
		[Tooltip("If specified, will use the direction from the character to this Transform as the gravity vector instead of Physics.gravity. Physics.gravity.magnitude will be used as the magnitude of the gravity vector.")]
		[Header("Base Parameters")]
		public Transform gravityTarget;

		[Tooltip("Multiplies gravity applied to the character even if 'Individual Gravity' is unchecked.")]
		public float gravityMultiplier;

		public float airborneThreshold;

		public float slopeStartAngle;

		public float slopeEndAngle;

		public float spherecastRadius;

		public LayerMask groundLayers;

		private PhysicMaterial zeroFrictionMaterial;

		private PhysicMaterial highFrictionMaterial;

		protected Rigidbody r;

		protected const float half = 0.5f;

		protected float originalHeight;

		protected Vector3 originalCenter;

		protected CapsuleCollider capsule;

		public abstract void Move(Vector3 deltaPosition, Quaternion deltaRotation);

		protected Vector3 GetGravity()
		{
			return default(Vector3);
		}

		protected virtual void Start()
		{
		}

		protected virtual RaycastHit GetSpherecastHit()
		{
			return default(RaycastHit);
		}

		public float GetAngleFromForward(Vector3 worldDirection)
		{
			return 0f;
		}

		protected void RigidbodyRotateAround(Vector3 point, Vector3 axis, float angle)
		{
		}

		protected void ScaleCapsule(float mlp)
		{
		}

		protected void HighFriction()
		{
		}

		protected void ZeroFriction()
		{
		}

		protected float GetSlopeDamper(Vector3 velocity, Vector3 groundNormal)
		{
			return 0f;
		}
	}
}
