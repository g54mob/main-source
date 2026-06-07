using UnityEngine;

namespace ScheduleOne
{
	public struct TransformData
	{
		public Vector3 Position;

		public Quaternion Rotation;

		public Vector3 Scale;

		public TransformData(Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Position = default(Vector3);
			Rotation = default(Quaternion);
			Scale = default(Vector3);
		}

		public void ApplyToWorldTransform(Transform transform)
		{
		}

		public void ApplyToLocalTransform(Transform transform, bool setScale = true)
		{
		}

		public static TransformData FromTransform(Transform transform)
		{
			return default(TransformData);
		}

		public static TransformData Lerp(TransformData a, TransformData b, float t)
		{
			return default(TransformData);
		}
	}
}
