using UnityEngine;

namespace Lightbug.Utilities
{
	public sealed class RigidbodyComponent2D : RigidbodyComponent
	{
		private Rigidbody2D rigidbody;

		private RaycastHit2D[] sweepBuffer = new RaycastHit2D[10];

		protected override bool IsUsingContinuousCollisionDetection => rigidbody.collisionDetectionMode > CollisionDetectionMode2D.None;

		public override bool Is2D => true;

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
				return rigidbody.bodyType == RigidbodyType2D.Kinematic;
			}
			set
			{
				bool num = rigidbody.bodyType == RigidbodyType2D.Kinematic;
				if (value)
				{
					ContinuousCollisionDetection = false;
					rigidbody.bodyType = RigidbodyType2D.Kinematic;
				}
				else
				{
					rigidbody.bodyType = RigidbodyType2D.Dynamic;
					ContinuousCollisionDetection = previousContinuousCollisionDetection;
				}
				if (!(num & (rigidbody.bodyType == RigidbodyType2D.Kinematic)))
				{
					OnBodyTypeChangeInternal();
				}
			}
		}

		public override bool UseGravity
		{
			get
			{
				return rigidbody.gravityScale != 0f;
			}
			set
			{
				rigidbody.gravityScale = (value ? 1f : 0f);
			}
		}

		public override bool UseInterpolation
		{
			get
			{
				return rigidbody.interpolation == RigidbodyInterpolation2D.Interpolate;
			}
			set
			{
				rigidbody.interpolation = (value ? RigidbodyInterpolation2D.Interpolate : RigidbodyInterpolation2D.None);
			}
		}

		public override bool ContinuousCollisionDetection
		{
			get
			{
				return rigidbody.collisionDetectionMode == CollisionDetectionMode2D.Continuous;
			}
			set
			{
				rigidbody.collisionDetectionMode = (value ? CollisionDetectionMode2D.Continuous : CollisionDetectionMode2D.None);
			}
		}

		public override RigidbodyConstraints Constraints
		{
			get
			{
				return rigidbody.constraints switch
				{
					RigidbodyConstraints2D.None => RigidbodyConstraints.None, 
					RigidbodyConstraints2D.FreezeAll => RigidbodyConstraints.FreezeAll, 
					RigidbodyConstraints2D.FreezePosition => RigidbodyConstraints.FreezePosition, 
					RigidbodyConstraints2D.FreezePositionX => RigidbodyConstraints.FreezePositionX, 
					RigidbodyConstraints2D.FreezePositionY => RigidbodyConstraints.FreezePositionY, 
					RigidbodyConstraints2D.FreezeRotation => RigidbodyConstraints.FreezeRotationZ, 
					_ => RigidbodyConstraints.None, 
				};
			}
			set
			{
				switch (value)
				{
				case RigidbodyConstraints.None:
					rigidbody.constraints = RigidbodyConstraints2D.None;
					break;
				case RigidbodyConstraints.FreezeAll:
					rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
					break;
				case RigidbodyConstraints.FreezePosition:
					rigidbody.constraints = RigidbodyConstraints2D.FreezePosition;
					break;
				case RigidbodyConstraints.FreezePositionX:
					rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
					break;
				case RigidbodyConstraints.FreezePositionY:
					rigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;
					break;
				case RigidbodyConstraints.FreezeRotation:
					rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
					break;
				case RigidbodyConstraints.FreezeRotationZ:
					rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
					break;
				default:
					rigidbody.constraints = RigidbodyConstraints2D.None;
					break;
				}
			}
		}

		public override Vector3 Position
		{
			get
			{
				return new Vector3(rigidbody.position.x, rigidbody.position.y, base.transform.position.z);
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
				return Quaternion.Euler(0f, 0f, rigidbody.rotation);
			}
			set
			{
				rigidbody.rotation = value.eulerAngles.z;
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
				return new Vector3(0f, 0f, rigidbody.angularVelocity);
			}
			set
			{
				rigidbody.angularVelocity = value.z;
			}
		}

		public override HitInfo Sweep(Vector3 position, Vector3 direction, float distance)
		{
			Vector3 position2 = Position;
			Position = position;
			int length = rigidbody.Cast(direction, sweepBuffer, distance);
			Position = position2;
			sweepBuffer.GetClosestHit(out var hitInfo, length, null);
			return new HitInfo(ref hitInfo, direction);
		}

		protected override void Awake()
		{
			base.Awake();
			rigidbody = base.gameObject.GetOrAddComponent<Rigidbody2D>();
			rigidbody.hideFlags = HideFlags.NotEditable;
			previousContinuousCollisionDetection = IsUsingContinuousCollisionDetection;
		}

		public override void Interpolate(Vector3 position)
		{
			rigidbody.MovePosition(position);
		}

		public override void Interpolate(Quaternion rotation)
		{
			rigidbody.MoveRotation(rotation.eulerAngles.z);
		}

		public override Vector3 GetPointVelocity(Vector3 point)
		{
			return rigidbody.GetPointVelocity(point);
		}

		public override void AddForceToRigidbody(Vector3 force, ForceMode forceMode = ForceMode.Force)
		{
			ForceMode2D mode = ForceMode2D.Force;
			if (forceMode == ForceMode.Impulse || forceMode == ForceMode.VelocityChange)
			{
				mode = ForceMode2D.Impulse;
			}
			rigidbody.AddForce(force, mode);
		}

		public override void AddExplosionForceToRigidbody(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f)
		{
			Debug.LogWarning("AddExplosionForce is not available for 2D physics");
		}
	}
}
