using System;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class SimpleGuidanceSystem
	{
		public class SimpleGuidanceConfiguration
		{
			public float AltitudeBoostMax { get; set; }

			public float AltitudeBoostMin { get; set; }

			public float AltitudeBoostRange { get; set; }

			public float GuidanceDelay { get; set; }

			public float LiftScale { get; set; }

			public float MaxLift { get; set; }

			public float RotationSpeed { get; internal set; }
		}

		private SimpleGuidanceConfiguration _configuration;

		private float _guidanceStartTimer = 0.1f;

		private Rigidbody _rigidBody;

		private Target _target;

		private Transform _transform;

		public SimpleGuidanceSystem(Rigidbody body, Target target, SimpleGuidanceConfiguration configuration)
		{
			_configuration = configuration;
			_guidanceStartTimer = configuration.GuidanceDelay;
			_target = target;
			_rigidBody = body;
			_transform = body.transform;
		}

		public void Update()
		{
			if (_guidanceStartTimer > 0f)
			{
				_guidanceStartTimer -= Time.deltaTime;
				return;
			}
			RotateTowardsTarget();
			ApplyLiftForce();
		}

		private void ApplyLiftForce()
		{
			Rigidbody rigidBody = _rigidBody;
			if (rigidBody.linearVelocity.magnitude > 0f)
			{
				float magnitude = rigidBody.linearVelocity.magnitude;
				Vector3 normalized = rigidBody.linearVelocity.normalized;
				Vector3 vector = ApplyLiftForceForVector(_transform.right, normalized, magnitude);
				Vector3 vector2 = ApplyLiftForceForVector(_transform.up, normalized, magnitude);
				rigidBody.AddForce(vector + vector2);
			}
		}

		private Vector3 ApplyLiftForceForVector(Vector3 direction, Vector3 velocityNormalized, float speed)
		{
			float num = 0f - Vector3.Dot(velocityNormalized, direction);
			float num2 = Mathf.Clamp(_configuration.LiftScale * num * speed * speed, 0f - _configuration.MaxLift, _configuration.MaxLift);
			return direction * num2;
		}

		private Vector3 CalculateTargetPosition(float distance)
		{
			float y = Mathf.Lerp(_configuration.AltitudeBoostMin, _configuration.AltitudeBoostMax, distance / _configuration.AltitudeBoostRange);
			return _target.Position + new Vector3(0f, y, 0f);
		}

		private void RotateTowardsTarget()
		{
			Vector3 vector = _target.Position - _transform.position;
			vector.y = 0f;
			Vector3 normalized = (CalculateTargetPosition(vector.magnitude) - _transform.position).normalized;
			Vector3 forward = _transform.forward;
			float num = _configuration.RotationSpeed * Time.fixedDeltaTime;
			Vector3 forward2 = Vector3.RotateTowards(forward, normalized, num * (MathF.PI / 180f), 0f);
			_rigidBody.MoveRotation(Quaternion.LookRotation(forward2));
		}
	}
}
