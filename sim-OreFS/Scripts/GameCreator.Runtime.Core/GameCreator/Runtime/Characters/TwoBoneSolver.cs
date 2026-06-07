using UnityEngine;

namespace GameCreator.Runtime.Characters
{
	public static class TwoBoneSolver
	{
		private const float SQRT_EPSILON = 1E-08f;

		private const float ERROR_MARGIN = 0.001f;

		public static TwoBoneData Run(TwoBoneData data, Vector3 targetPosition, Quaternion targetRotation, Transform hint, float hintWeight)
		{
			Vector3 rootPosition = data.RootPosition;
			Vector3 bodyPosition = data.BodyPosition;
			Vector3 headPosition = data.HeadPosition;
			bool flag = hint != null && hintWeight > 0f;
			Vector3 lhs = bodyPosition - rootPosition;
			Vector3 rhs = headPosition - bodyPosition;
			Vector3 vector = headPosition - rootPosition;
			Vector3 vector2 = targetPosition - rootPosition;
			float magnitude = lhs.magnitude;
			float magnitude2 = rhs.magnitude;
			float magnitude3 = vector.magnitude;
			float magnitude4 = vector2.magnitude;
			float num = TriangleAngle(magnitude3, magnitude, magnitude2);
			float num2 = TriangleAngle(magnitude4, magnitude, magnitude2);
			Vector3 value = Vector3.Cross(lhs, rhs);
			if (value.sqrMagnitude < 1E-08f)
			{
				value = (flag ? Vector3.Cross(hint.position - rootPosition, rhs) : Vector3.zero);
				if (value.sqrMagnitude < 1E-08f)
				{
					value = Vector3.Cross(vector2, rhs);
				}
				if (value.sqrMagnitude < 1E-08f)
				{
					value = Vector3.up;
				}
			}
			value = Vector3.Normalize(value);
			float f = 0.5f * (num - num2);
			float num3 = Mathf.Sin(f);
			float w = Mathf.Cos(f);
			Quaternion quaternion = new Quaternion(value.x * num3, value.y * num3, value.z * num3, w);
			data.BodyRotation = quaternion * data.BodyRotation;
			vector = data.HeadPosition - rootPosition;
			data.RootRotation = Quaternion.FromToRotation(vector, vector2) * data.RootRotation;
			if (flag)
			{
				float sqrMagnitude = vector.sqrMagnitude;
				if (sqrMagnitude > 0f)
				{
					bodyPosition = data.BodyPosition;
					Vector3 headPosition2 = data.HeadPosition;
					lhs = bodyPosition - rootPosition;
					vector = headPosition2 - rootPosition;
					Vector3 vector3 = vector / Mathf.Sqrt(sqrMagnitude);
					Vector3 vector4 = hint.position - rootPosition;
					Vector3 fromDirection = lhs - vector3 * Vector3.Dot(lhs, vector3);
					Vector3 toDirection = vector4 - vector3 * Vector3.Dot(vector4, vector3);
					float num4 = magnitude + magnitude2;
					if (fromDirection.sqrMagnitude > num4 * num4 * 0.001f && toDirection.sqrMagnitude > 0f)
					{
						Quaternion q = Quaternion.FromToRotation(fromDirection, toDirection);
						q.x *= hintWeight;
						q.y *= hintWeight;
						q.z *= hintWeight;
						q = Quaternion.Normalize(q);
						data.RootRotation = q * data.RootRotation;
					}
				}
			}
			data.HeadRotation = targetRotation;
			return data;
		}

		private static float TriangleAngle(float aLen, float aLen1, float aLen2)
		{
			return Mathf.Acos(Mathf.Clamp((aLen1 * aLen1 + aLen2 * aLen2 - aLen * aLen) / (aLen1 * aLen2) / 2f, -1f, 1f));
		}
	}
}
