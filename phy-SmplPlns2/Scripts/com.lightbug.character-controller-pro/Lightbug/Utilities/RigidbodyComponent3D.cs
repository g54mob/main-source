using UnityEngine;

namespace Lightbug.Utilities
{
	public sealed class RigidbodyComponent3D : RigidbodyComponent
	{
		private Rigidbody rigidbody;

		protected override bool IsUsingContinuousCollisionDetection => rigidbody.collisionDetectionMode > CollisionDetectionMode.Discrete;

		public override bool Is2D => false;

		public override float Mass
		{
			get
			{
				return rigidbody.mass;
			}
			set
			{
				rigidbody.mass = value;
			}
		}

		public override float LinearDrag
		{
			get
			{
				return rigidbody.linearDamping;
			}
			set
			{
				rigidbody.linearDamping = value;
			}
		}

		public override float AngularDrag
		{
			get
			{
				return rigidbody.angularDamping;
			}
			set
			{
				rigidbody.angularDamping = value;
			}
		}

		public override bool IsKinematic
		{
			get
			{
				return rigidbody.isKinematic;
			}
			set
			{
				bool isKinematic = rigidbody.isKinematic;
				if (value)
				{
					ContinuousCollisionDetection = false;
					rigidbody.isKinematic = true;
				}
				else
				{
					rigidbody.isKinematic = false;
					ContinuousCollisionDetection = previousContinuousCollisionDetection;
				}
				if (!(isKinematic & rigidbody.isKinematic))
				{
					OnBodyTypeChangeInternal();
				}
			}
		}

		public override bool UseGravity
		{
			get
			{
				return rigidbody.useGravity;
			}
			set
			{
				rigidbody.useGravity = value;
			}
		}

		public override bool UseInterpolation
		{
			get
			{
				return rigidbody.interpolation == RigidbodyInterpolation.Interpolate;
			}
			set
			{
				rigidbody.interpolation = (value ? RigidbodyInterpolation.Interpolate : RigidbodyInterpolation.None);
			}
		}

		public override bool ContinuousCollisionDetection
		{
			get
			{
				return rigidbody.collisionDetectionMode == CollisionDetectionMode.Continuous;
			}
			set
			{
				rigidbody.collisionDetectionMode = (value ? CollisionDetectionMode.Continuous : CollisionDetectionMode.Discrete);
			}
		}

		public override RigidbodyConstraints Constraints
		{
			get
			{
				return rigidbody.constraints;
			}
			set
			{
				rigidbody.constraints = value;
			}
		}

		public override Vector3 Position
		{
			get
			{
				return rigidbody.position;
			}
			set
			{
				rigidbody.position = value;
			}
		}

		public override Quaternion Rotation
		{
			get
			{
				return rigidbody.rotation;
			}
			set
			{
				rigidbody.rotation = value;
			}
		}

		public override Vector3 Velocity
		{
			get
			{
				return rigidbody.linearVelocity;
			}
			set
			{
				rigidbody.linearVelocity = value;
			}
		}

		public override Vector3 AngularVelocity
		{
			get
			{
				return rigidbody.angularVelocity;
			}
			set
			{
				rigidbody.angularVelocity = value;
			}
		}

		public override HitInfo Sweep(Vector3 position, Vector3 direction, float distance)
		{
			Vector3 position2 = Position;
			Position = position;
			rigidbody.SweepTest(direction, out var hitInfo, distance);
			Position = position2;
			return new HitInfo(ref hitInfo, direction);
		}

		protected override void Awake()
		{
			base.Awake();
			rigidbody = base.gameObject.GetOrAddComponent<Rigidbody>();
			rigidbody.hideFlags = HideFlags.NotEditable;
			previousContinuousCollisionDetection = IsUsingContinuousCollisionDetection;
		}

		public override void Interpolate(Vector3 position)
		{
			rigidbody.MovePosition(position);
		}

		public override void Interpolate(Quaternion rotation)
		{
			rigidbody.MoveRotation(rotation);
		}

		public override Vector3 GetPointVelocity(Vector3 point)
		{
			return rigidbody.GetPointVelocity(point);
		}

		public override void AddForceToRigidbody(Vector3 force, ForceMode forceMode = ForceMode.Force)
		{
			rigidbody.AddForce(force, forceMode);
		}

		public override void AddExplosionForceToRigidbody(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f)
		{
			rigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, upwardsModifier);
		}
	}
}
