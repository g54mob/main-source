using UnityEngine;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class VelocityComponent : MonoBehaviour
	{
		public Vector3 Velocity;

		public float AccelerationCoefficient = 10f;

		public float AccelerationCoefficientMultiplier = 1f;

		public float MaxSpeed;

		private void AccelerateToVelocity(Vector3 targetVelocity)
		{
			Velocity = Vector3Damp(Velocity, targetVelocity, AccelerationCoefficient * AccelerationCoefficientMultiplier, Time.deltaTime);
		}

		public void AccelerateInDirection(Vector3 direction)
		{
			AccelerateToVelocity(MaxSpeed * direction);
		}

		public Vector3 GetMaxVelocity(Vector3 direction)
		{
			return MaxSpeed * direction;
		}

		public void MaximizeVelocity(Vector3 direction)
		{
			Velocity = GetMaxVelocity(direction);
		}

		public void Decelerate()
		{
			AccelerateToVelocity(Vector3.zero);
		}

		public void MoveRigidbody(Rigidbody rigidbody)
		{
			_ = (bool)rigidbody;
		}

		public void MoveTransform(Transform transform)
		{
			transform.position += Velocity * Time.deltaTime;
		}

		public void SetMaxSpeed(float newSpeed)
		{
			MaxSpeed = newSpeed;
		}

		public static Vector3 Vector3Damp(Vector3 source, Vector3 target, float accelCoefficient, float deltaTime)
		{
			return Vector3.Lerp(source, target, 1f - Mathf.Exp((0f - accelCoefficient) * deltaTime));
		}

		public void AccelerateToRandomDirection()
		{
			AccelerateInDirection(Random.insideUnitSphere);
		}
	}
}
