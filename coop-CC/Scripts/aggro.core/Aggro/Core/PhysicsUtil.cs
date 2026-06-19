using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public static class PhysicsUtil
	{
		public const float DOT_EPSILON = 0.001f;

		private const float CIRCLING_SPEED_MIN = 0.01f;

		private const int CAPSULE_AXIS_X = 0;

		private const int CAPSULE_AXIS_Y = 1;

		private const int CAPSULE_AXIS_Z = 2;

		private const float FIXED_DELTA_TIME = 1f / 60f;

		private static Collider[] _colliders = new Collider[128];

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ApplyDrag(float v, float drag)
		{
			return v * (1f - math.saturate(1f / 60f * drag));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ApplyDrag(Vector3 v, float drag)
		{
			return v * (1f - math.saturate(1f / 60f * drag));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ApplyAirDrag(Vector3 v, float drag)
		{
			v.x = ApplyDrag(v.x, drag);
			v.z = ApplyDrag(v.z, drag);
			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ApplyAxisDrag(Vector3 v, float drag, Vector3 normalizedAxis)
		{
			Vector3 vector = Vector3.Project(v, normalizedAxis);
			v -= vector;
			v = ApplyDrag(v, drag);
			return v + vector;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float InverseDrag(float v, float drag)
		{
			return v / (1f - math.saturate(1f / 60f * drag));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 InverseDrag(Vector3 v, float drag)
		{
			return v / (1f - math.saturate(1f / 60f * drag));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 InverseAirDrag(Vector3 v, float drag)
		{
			v.x = InverseDrag(v.x, drag);
			v.y = InverseDrag(v.y, drag);
			return v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetViewDir(Vector3 heading, Vector3 dir, float lerpPerSecond)
		{
			Vector3 vector = Vector3.Slerp(heading, dir, 1f / 60f * lerpPerSecond);
			if (Vector3.Dot(vector, dir) > Vector3.Dot(heading, dir))
			{
				return vector;
			}
			return heading;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetCirclingVelocity(float sideSpeed, Vector3 myPosition, Vector3 targetPosition)
		{
			return GetCirclingVelocity(sideSpeed, myPosition, targetPosition, math.distance(myPosition, targetPosition));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetCirclingVelocity(float sideSpeed, Vector3 myPosition, Vector3 targetPosition, float distance)
		{
			GetCirclingVelocity(sideSpeed, myPosition, targetPosition, distance, out var circlingVelocityDir, out var circlingSpeed);
			return circlingVelocityDir * circlingSpeed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetCirclingVelocity(float sideSpeed, Vector3 myPosition, Vector3 targetPosition, float distance, out Vector3 circlingVelocityDir, out float circlingSpeed)
		{
			if (math.abs(sideSpeed) < 0.01f)
			{
				circlingVelocityDir = Vector3.zero;
				circlingSpeed = 0f;
				return;
			}
			float num = sideSpeed * (1f / 60f);
			Quaternion quaternion2 = Quaternion.AngleAxis(0f - 360f * num / (MathF.PI * 2f * distance), Vector3.up);
			Vector3 vector = myPosition - targetPosition;
			Vector3 vector2 = targetPosition + quaternion2 * vector - myPosition;
			circlingVelocityDir = vector2 / (1f / 60f);
			circlingSpeed = circlingVelocityDir.magnitude;
			circlingVelocityDir /= circlingSpeed;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetCirclingSideSpeed(Vector3 velocity, Vector3 right)
		{
			if (velocity.sqrMagnitude > 0f)
			{
				velocity = Vector3.Project(velocity, right);
				if (Vector3.Dot(velocity, right) >= 0f)
				{
					return velocity.magnitude;
				}
				return 0f - velocity.magnitude;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetCirclingForwardsSpeed(Vector3 velocity, Vector3 forward)
		{
			if (velocity.sqrMagnitude > 0f)
			{
				velocity = Vector3.Project(velocity, forward);
				if (Vector3.Dot(velocity, forward) >= 0f)
				{
					return velocity.magnitude;
				}
				return 0f - velocity.magnitude;
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ApplyAcceleration(Vector3 curVelocity, Vector3 direction, float acceleration, float maxSpeed, float drag)
		{
			if (acceleration != 0f)
			{
				Vector3 vector = Vector3.Project(curVelocity, direction);
				Vector3 vector2 = vector + direction * (acceleration * (1f / 60f));
				Vector3 v = Vector3.Project(curVelocity, -MathUtil.GetOrtho(direction, Vector3.up));
				v = ApplyAirDrag(v, drag);
				if (Vector3.Dot(vector2, direction) > 0f)
				{
					if (vector.sqrMagnitude <= maxSpeed * maxSpeed)
					{
						if (vector2.sqrMagnitude > maxSpeed * maxSpeed)
						{
							vector2 = direction * maxSpeed;
						}
					}
					else if (Vector3.Dot(vector, vector2) > 0f)
					{
						float magnitude = vector2.magnitude;
						vector2 /= magnitude;
						magnitude = math.max(maxSpeed, ApplyDrag(magnitude, drag));
						vector2 *= magnitude;
					}
					else if (vector2.sqrMagnitude > maxSpeed * maxSpeed)
					{
						vector2 = direction * maxSpeed;
					}
				}
				else
				{
					vector2 = ApplyAirDrag(vector2, drag);
				}
				return vector2 + v;
			}
			return ApplyAirDrag(curVelocity, drag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ApplyAcceleration(float curSpeed, float direction, float acceleration, float maxSpeed, float drag)
		{
			if (acceleration != 0f)
			{
				float num = curSpeed + direction * (acceleration * (1f / 60f));
				bool flag;
				if (curSpeed * num < 0f)
				{
					flag = true;
					num = ApplyDrag(num, drag);
				}
				else
				{
					flag = false;
				}
				if (flag || math.abs(curSpeed) <= maxSpeed)
				{
					num = math.clamp(num, 0f - maxSpeed, maxSpeed);
				}
				else if (math.abs(num) > maxSpeed)
				{
					num = ApplyDrag(num, drag);
					num = ((!(num > 0f)) ? math.min(0f - maxSpeed, num) : math.max(maxSpeed, num));
				}
				return num;
			}
			return ApplyDrag(curSpeed, drag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 ApplyNoInputSlowDown(Vector3 flatVelocity, Vector3 actualVelocity, float drag)
		{
			actualVelocity.y = 0f;
			if (Vector3.Dot(actualVelocity, flatVelocity) > 0f)
			{
				return ApplyAirDrag(flatVelocity, drag);
			}
			return new Vector3(0f, flatVelocity.y, 0f);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ApplyNoInputSlowDown(float speed, float actualSpeed, float drag)
		{
			if (speed * actualSpeed > 0f)
			{
				return ApplyDrag(speed, drag);
			}
			return 0f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetForceVelocity(Vector3 amount, float mass, ForceMode mode)
		{
			return mode switch
			{
				ForceMode.Acceleration => amount * (1f / 60f), 
				ForceMode.Force => amount * (1f / 60f / mass), 
				ForceMode.VelocityChange => amount, 
				ForceMode.Impulse => amount / mass, 
				_ => throw new InvalidEnumException(), 
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetForceTorque(Vector3 amount, Vector3 position, Vector3 centerOfMass, Quaternion rotation, float mass, Vector3 inertiaTensor, ForceMode mode)
		{
			Vector3 vector = Vector3.Cross(position - centerOfMass, amount);
			switch (mode)
			{
			case ForceMode.Acceleration:
				vector *= 1f / 60f;
				inertiaTensor /= mass;
				break;
			case ForceMode.Force:
				vector *= 1f / 60f;
				break;
			case ForceMode.VelocityChange:
				inertiaTensor /= mass;
				break;
			default:
				throw new InvalidEnumException();
			case ForceMode.Impulse:
				break;
			}
			Vector3 vector2 = Quaternion.Inverse(rotation) * vector;
			if (inertiaTensor.x != 0f)
			{
				vector2.x /= inertiaTensor.x;
			}
			if (inertiaTensor.y != 0f)
			{
				vector2.y /= inertiaTensor.y;
			}
			if (inertiaTensor.z != 0f)
			{
				vector2.z /= inertiaTensor.z;
			}
			return rotation * vector2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 RemoveValue(Vector3 current, Vector3 remove)
		{
			current.x = RemoveValue(current.x, remove.x);
			current.y = RemoveValue(current.y, remove.y);
			current.z = RemoveValue(current.z, remove.z);
			return current;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static float RemoveValue(float current, float remove)
		{
			if (current * remove > 0f)
			{
				current = ((!(remove > 0f)) ? math.min(current - remove, 0f) : math.max(current - remove, 0f));
			}
			return current;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetTimeForFall(float fallDistance, float gravityAcceleration)
		{
			return math.sqrt(2f * fallDistance / gravityAcceleration);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float GetDistanceForFall(float time, float gravityAcceleration)
		{
			return 0.5f * gravityAcceleration * time * time;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLobAngles(float distance, float height, float speed, float gravity, out float angleRadians1, out float angleRadians2)
		{
			float num = distance * distance;
			float num2 = (0f - gravity) * num / (2f * speed * speed);
			float x = 2f * num2;
			float num3 = num - 4f * num2 * (height + num2);
			if (num3 < 0f)
			{
				angleRadians1 = float.NaN;
				angleRadians2 = float.NaN;
				return false;
			}
			float num4 = math.sqrt(num3);
			angleRadians1 = MathF.PI + math.atan2(0f - distance + num4, x);
			angleRadians2 = MathF.PI + math.atan2(0f - distance - num4, x);
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLobAngles(Vector3 from, Vector3 to, float speed, float gravity, out float angleRadians1, out float angleRadians2)
		{
			Vector3 vector = to - from;
			vector.y = 0f;
			return TryGetLobAngles(vector.magnitude, from.y - to.y, speed, gravity, out angleRadians1, out angleRadians2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryGetLobDirections(Vector3 from, Vector3 to, float speed, float gravity, out Vector3 dir1, out Vector3 dir2)
		{
			Vector3 vector = to - from;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			vector /= magnitude;
			if (!TryGetLobAngles(magnitude, from.y - to.y, speed, gravity, out var angleRadians, out var angleRadians2))
			{
				dir1 = MathUtil.VECTOR3_NAN;
				dir2 = MathUtil.VECTOR3_NAN;
				return false;
			}
			Vector3 ortho = MathUtil.GetOrtho(vector, Vector3.up);
			dir1 = Quaternion.AngleAxis(math.degrees(angleRadians), ortho) * vector;
			dir2 = Quaternion.AngleAxis(math.degrees(angleRadians2), ortho) * vector;
			return true;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetLobPosition(Vector3 from, Vector3 forwards, float cosAngle, float sinAngle, float speed, float gravity, float time)
		{
			float num = speed * time;
			float num2 = num * cosAngle;
			Vector3 vector = new Vector3(forwards.x * num2, (0f - gravity) * time * time / 2f + num * sinAngle, forwards.z * num2);
			return from + vector;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetLobPosition(Vector3 from, Vector3 dir, float speed, float gravity, float time)
		{
			GetLobInfo(dir, out var forwards, out var upwardsAngleRadians);
			return GetLobPosition(from, forwards, math.cos(upwardsAngleRadians), math.sin(upwardsAngleRadians), speed, gravity, time);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetLobVelocity(Vector3 dir, float speed, float gravity, float time)
		{
			GetLobInfo(dir, out var forwards, out var upwardsAngleRadians);
			return GetLobVelocity(forwards, math.cos(upwardsAngleRadians), math.sin(upwardsAngleRadians), speed, gravity, time);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Vector3 GetLobVelocity(Vector3 forwards, float cosAngle, float sinAngle, float speed, float gravity, float time)
		{
			float num = speed * cosAngle;
			return new Vector3(forwards.x * num, (0f - gravity) * time + speed * sinAngle, forwards.z * num);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void GetLobInfo(Vector3 dir, out Vector3 forwards, out float upwardsAngleRadians)
		{
			forwards = dir;
			forwards.y = 0f;
			forwards.Normalize();
			Vector3 vector = MathUtil.GetOrtho(forwards, dir);
			if (dir.y < 0f)
			{
				vector = -vector;
			}
			upwardsAngleRadians = math.radians(Vector3.SignedAngle(forwards, dir, vector));
		}

		public static void GetCapsuleLocalScaledInfo(CapsuleCollider capsule, Vector3 lossyScale, out float radius, out float height, out Vector3 dir)
		{
			radius = capsule.radius;
			height = capsule.height;
			switch (capsule.direction)
			{
			case 0:
				radius *= math.max(lossyScale.y, lossyScale.z);
				height *= lossyScale.x;
				dir = Vector3.right;
				break;
			case 1:
				radius *= math.max(lossyScale.x, lossyScale.z);
				height *= lossyScale.y;
				dir = Vector3.up;
				break;
			case 2:
				radius *= math.max(lossyScale.x, lossyScale.y);
				height *= lossyScale.z;
				dir = Vector3.forward;
				break;
			default:
				throw new InvalidCastException($"Unknown capsule collider direction ({capsule.direction})");
			}
		}

		public static void OverlapCollider(Collider collider, List<Collider> results, int layerMask = -1)
		{
			if (collider != null)
			{
				OverlapCollider(collider, collider.transform, results, layerMask);
			}
		}

		public static void OverlapCollider(Collider collider, Transform colliderTransform, List<Collider> results, int layerMask = -1)
		{
			int num2;
			if (collider is SphereCollider sphereCollider)
			{
				Vector3 vector = math.abs(colliderTransform.lossyScale);
				float num = math.max(vector.x, math.max(vector.y, vector.z));
				float radius = sphereCollider.radius * num;
				num2 = Physics.OverlapSphereNonAlloc(colliderTransform.TransformPoint(sphereCollider.center), radius, _colliders, layerMask);
			}
			else if (collider is BoxCollider boxCollider)
			{
				Vector3 vector2 = math.abs(colliderTransform.lossyScale);
				Vector3 size = boxCollider.size;
				size.x *= vector2.x;
				size.y *= vector2.y;
				size.z *= vector2.z;
				num2 = Physics.OverlapBoxNonAlloc(colliderTransform.TransformPoint(boxCollider.center), size / 2f, _colliders, colliderTransform.rotation, layerMask);
			}
			else
			{
				if (!(collider is CapsuleCollider capsuleCollider))
				{
					if (collider != null)
					{
						Debug.LogError("Unsupported capsule type for PhysicsUtil.OverlapCollider!", collider);
					}
					return;
				}
				Vector3 lossyScale = math.abs(colliderTransform.lossyScale);
				GetCapsuleLocalScaledInfo(capsuleCollider, lossyScale, out var radius2, out var height, out var dir);
				dir = colliderTransform.TransformDirection(dir);
				Vector3 vector3 = colliderTransform.TransformPoint(capsuleCollider.center);
				float num3 = height / 2f - radius2;
				num2 = ((!(num3 > 0f)) ? Physics.OverlapSphereNonAlloc(vector3, radius2, _colliders, layerMask) : Physics.OverlapCapsuleNonAlloc(vector3 + dir * num3, vector3 + -dir * num3, radius2, _colliders, layerMask));
			}
			if (num2 == _colliders.Length)
			{
				_colliders = new Collider[Mathf.NextPowerOfTwo(_colliders.Length + 1)];
				OverlapCollider(collider, colliderTransform, results, layerMask);
				return;
			}
			for (int i = 0; i < num2; i++)
			{
				results.Add(_colliders[i]);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion ConstrainUpRight(Quaternion rot)
		{
			Vector3 eulerAngles = rot.eulerAngles;
			eulerAngles.x = 0f;
			eulerAngles.z = 0f;
			return Quaternion.Euler(eulerAngles);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Quaternion Constrain(Quaternion rot, RigidbodyConstraints constraints)
		{
			Vector3 eulerAngles = rot.eulerAngles;
			if ((constraints & RigidbodyConstraints.FreezeRotationX) != RigidbodyConstraints.None)
			{
				eulerAngles.x = 0f;
			}
			if ((constraints & RigidbodyConstraints.FreezeRotationY) != RigidbodyConstraints.None)
			{
				eulerAngles.y = 0f;
			}
			if ((constraints & RigidbodyConstraints.FreezeRotationZ) != RigidbodyConstraints.None)
			{
				eulerAngles.z = 0f;
			}
			return Quaternion.Euler(eulerAngles);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool IsConstrainingRotation(RigidbodyConstraints constraints)
		{
			if ((constraints & RigidbodyConstraints.FreezeRotationX) != RigidbodyConstraints.None)
			{
				return true;
			}
			if ((constraints & RigidbodyConstraints.FreezeRotationY) != RigidbodyConstraints.None)
			{
				return true;
			}
			if ((constraints & RigidbodyConstraints.FreezeRotationZ) != RigidbodyConstraints.None)
			{
				return true;
			}
			return false;
		}
	}
}
