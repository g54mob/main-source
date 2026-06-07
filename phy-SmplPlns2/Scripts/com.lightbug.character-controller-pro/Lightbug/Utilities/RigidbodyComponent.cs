using System;
using UnityEngine;

namespace Lightbug.Utilities
{
	public abstract class RigidbodyComponent : MonoBehaviour
	{
		protected bool previousContinuousCollisionDetection;

		public abstract bool Is2D { get; }

		public abstract float Mass { get; set; }

		public abstract float LinearDrag { get; set; }

		public abstract float AngularDrag { get; set; }

		public abstract bool IsKinematic { get; set; }

		public abstract bool UseGravity { get; set; }

		public abstract bool UseInterpolation { get; set; }

		public abstract bool ContinuousCollisionDetection { get; set; }

		public abstract RigidbodyConstraints Constraints { get; set; }

		protected abstract bool IsUsingContinuousCollisionDetection { get; }

		public abstract Vector3 Position { get; set; }

		public abstract Quaternion Rotation { get; set; }

		public abstract Vector3 Velocity { get; set; }

		public abstract Vector3 AngularVelocity { get; set; }

		public event Action OnBodyTypeChange;

		public abstract HitInfo Sweep(Vector3 position, Vector3 direction, float distance);

		protected void OnBodyTypeChangeInternal()
		{
			this.OnBodyTypeChange?.Invoke();
		}

		public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
		{
			Position = position;
			Rotation = rotation;
		}

		public abstract void Interpolate(Vector3 position);

		public abstract void Interpolate(Quaternion rotation);

		public void Interpolate(Vector3 position, Quaternion rotation)
		{
			Interpolate(position);
			Interpolate(rotation);
		}

		public void Move(Vector3 position)
		{
			if (IsKinematic)
			{
				Interpolate(position);
			}
			else
			{
				Velocity = (position - Position) / Time.deltaTime;
			}
		}

		public void Rotate(Quaternion rotation)
		{
			if (IsKinematic)
			{
				Interpolate(rotation);
				return;
			}
			Vector3 vector = MathF.PI / 180f * (rotation * Quaternion.Inverse(Rotation)).eulerAngles;
			AngularVelocity = vector / Time.deltaTime;
		}

		public void MoveAndRotate(Vector3 position, Quaternion rotation)
		{
			Move(position);
			Rotate(rotation);
		}

		public abstract Vector3 GetPointVelocity(Vector3 point);

		public abstract void AddForceToRigidbody(Vector3 force, ForceMode forceMode = ForceMode.Force);

		public abstract void AddExplosionForceToRigidbody(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f);

		public void AddForce(Vector3 force, bool ignoreMass = false, bool useImpulse = false)
		{
			if (useImpulse)
			{
				Vector3 vector = force / (ignoreMass ? 1f : Mathf.Max(0.01f, Mass));
				Velocity += vector * Time.fixedDeltaTime;
			}
			else
			{
				Vector3 vector2 = force / (ignoreMass ? 1f : Mathf.Max(0.01f, Mass));
				Velocity += vector2;
			}
		}

		public void AddExplosionForce(float explosionForce, Vector3 explosionPosition, float explosionRadius, float upwardsModifier = 0f)
		{
			float magnitude = (Position - explosionPosition).magnitude;
			if (!(magnitude > explosionRadius))
			{
				explosionPosition -= Vector3.up * upwardsModifier;
				Vector3 value = Position - explosionPosition;
				float num = explosionForce * ((explosionRadius - magnitude) / explosionRadius);
				Vector3 vector = Vector3.Normalize(value) * num / Mathf.Max(0.01f, Mass);
				Velocity += vector;
			}
		}

		public void AddTorque(Vector3 torque, bool ignoreMass = false)
		{
			Vector3 vector = torque / (ignoreMass ? 1f : Mathf.Max(0.01f, Mathf.Max(0.01f, Mass)));
			AngularVelocity += vector * Time.fixedDeltaTime;
		}

		protected virtual void Awake()
		{
		}

		public static RigidbodyComponent CreateInstance(GameObject gameObject)
		{
			Rigidbody2D component = gameObject.GetComponent<Rigidbody2D>();
			Rigidbody component2 = gameObject.GetComponent<Rigidbody>();
			if (component != null)
			{
				return gameObject.GetOrAddComponent<RigidbodyComponent2D>();
			}
			if (component2 != null)
			{
				return gameObject.GetOrAddComponent<RigidbodyComponent3D>();
			}
			return null;
		}
	}
}
