using UnityEngine;

namespace GameCreator.Runtime.Common
{
	public static class QuaternionUtils
	{
		public static float ClampAngle(float angle, float min, float max)
		{
			angle = Mathf.Repeat(angle, 360f);
			if (angle > 180f)
			{
				angle -= 360f;
			}
			min = Mathf.Repeat(min, 360f);
			max = Mathf.Repeat(max, 360f);
			if (min > 180f)
			{
				min -= 360f;
			}
			if (max > 180f)
			{
				max -= 360f;
			}
			return Mathf.Clamp(angle, min, max);
		}

		public static float Convert180(float angle)
		{
			return Mathf.Repeat(angle + 180f, 360f) - 180f;
		}

		public static Quaternion SmoothDamp(Quaternion current, Quaternion target, ref Quaternion velocity, float smoothTime, float deltaTime)
		{
			if (deltaTime < Mathf.Epsilon)
			{
				return current;
			}
			float num = ((Quaternion.Dot(current, target) > 0f) ? 1f : (-1f));
			target.x *= num;
			target.y *= num;
			target.z *= num;
			target.w *= num;
			Vector4 b = ((deltaTime > float.Epsilon) ? new Vector4(Mathf.SmoothDamp(current.x, target.x, ref velocity.x, smoothTime, float.PositiveInfinity, deltaTime), Mathf.SmoothDamp(current.y, target.y, ref velocity.y, smoothTime, float.PositiveInfinity, deltaTime), Mathf.SmoothDamp(current.z, target.z, ref velocity.z, smoothTime, float.PositiveInfinity, deltaTime), Mathf.SmoothDamp(current.w, target.w, ref velocity.w, smoothTime, float.PositiveInfinity, deltaTime)).normalized : new Vector4(current.x, current.y, current.z, current.w).normalized);
			Vector4 vector = Vector4.Project(new Vector4(velocity.x, velocity.y, velocity.z, velocity.w), b);
			velocity.x -= vector.x;
			velocity.y -= vector.y;
			velocity.z -= vector.z;
			velocity.w -= vector.w;
			return new Quaternion(b.x, b.y, b.z, b.w);
		}

		public static Quaternion ProjectToPlane(Quaternion rotation, Vector3 normal)
		{
			return ProjectToPlane(rotation * Vector3.forward, normal);
		}

		public static Quaternion ProjectToPlane(Vector3 direction, Vector3 normal)
		{
			return Quaternion.LookRotation(Vector3.ProjectOnPlane(direction, normal.normalized).normalized);
		}

		public static Vector3 RotateAroundPivot(Vector3 pivot, Vector3 point, Quaternion rotation)
		{
			Vector3 vector = point - pivot;
			return rotation * vector + pivot;
		}
	}
}
