using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class MissileFlightPhysicsLegacy : IMissileFlightPhysics
	{
		private Transform _centerOfThrust;

		private float _guidanceDelay;

		private bool _maxSpeedReached;

		private MissileScript _missile;

		public MissileData Modifier => _missile.Modifier;

		public MissileFlightPhysicsLegacy(MissileScript missile, Transform centerOfThrust)
		{
			_guidanceDelay = missile.Modifier.GuidanceActivationDelay;
			_missile = missile;
			_centerOfThrust = centerOfThrust;
		}

		public void OnFire(Vector3 toTarget)
		{
		}

		public void UpdatePhysics(bool locked, Rigidbody body, MissileScript.FrameStats stats, MissileScript.FrameStats previousStats, float deltaTime)
		{
			if (!_missile.Fired)
			{
				_missile.AdjustFreeFallHeading();
				return;
			}
			body.angularVelocity = Vector3.zero;
			if (_guidanceDelay > 0f)
			{
				_guidanceDelay -= deltaTime;
			}
			else if (locked)
			{
				float num = Mathf.Max(Mathf.Pow(Mathf.Clamp01(Mathf.Max(Mathf.Abs(stats.AdjustedTargetAngles.x), Mathf.Abs(stats.AdjustedTargetAngles.y)) / 5f), 2f), 0.2f);
				float num2 = Modifier.MaxHeadingAngleAdjustmentRate * Mathf.Clamp(stats.Speed / Modifier.MaxSpeed, 0.3f, 1f);
				if (!_missile.OutOfFuel)
				{
					num2 += Modifier.MaxThrustVectoringRate;
				}
				num2 *= num;
				float num3 = Modifier.MaxVelocityAngleAdjustmentRate * (MathF.PI / 180f) * Mathf.Clamp(stats.Speed / Modifier.MaxSpeed, 0.3f, 1f);
				Quaternion to = body.rotation * Quaternion.Euler(stats.AdjustedTargetAngles.x, stats.AdjustedTargetAngles.y, stats.AdjustedTargetAngles.z);
				body.rotation = Quaternion.RotateTowards(body.rotation, to, num2 * Time.deltaTime);
				body.linearVelocity = Vector3.RotateTowards(body.linearVelocity, _centerOfThrust.forward * stats.Speed, num3 * Time.deltaTime, 1f);
			}
			if (!_missile.OutOfFuel && !_maxSpeedReached && stats.Speed <= Modifier.MaxSpeed)
			{
				Vector3 force = _centerOfThrust.forward * (Modifier.MaxForwardThrustForce * 0.01f);
				body.AddForceAtPosition(force, _centerOfThrust.position, ForceMode.Force);
			}
			LimitVelocity(body, stats, previousStats, deltaTime);
		}

		private void LimitVelocity(Rigidbody body, MissileScript.FrameStats stats, MissileScript.FrameStats previousStats, float deltaTime)
		{
			if (_maxSpeedReached)
			{
				float num = ((stats.Speed > 0.1f) ? (Modifier.MaxSpeed / stats.Speed) : 1f);
				body.linearVelocity *= num;
				stats.Speed *= num;
			}
			else if (stats.Speed > Modifier.MaxSpeed)
			{
				if (previousStats.Speed < Modifier.MaxSpeed)
				{
					_maxSpeedReached = true;
				}
				float num2 = ((stats.Speed > 0.1f) ? ((stats.Speed - 20f * deltaTime) / stats.Speed) : 1f);
				body.linearVelocity *= num2;
				stats.Speed *= num2;
				if (stats.Speed <= Modifier.MaxSpeed)
				{
					_maxSpeedReached = true;
				}
				if (_maxSpeedReached)
				{
					num2 = ((stats.Speed > 0.1f) ? (Modifier.MaxSpeed / stats.Speed) : 1f);
					body.linearVelocity *= num2;
					stats.Speed *= num2;
				}
			}
		}
	}
}
