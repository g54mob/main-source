using UnityEngine;

namespace ScheduleOne
{
	public static class TransformExtensions
	{
		public static TransformData GetWorldTransformData(this Transform transform)
		{
			return default(TransformData);
		}

		public static TransformData GetLocalTransformData(this Transform transform)
		{
			return default(TransformData);
		}

		public static void SetLocalTransformData(this Transform transform, TransformData data, bool setScale = true)
		{
		}

		public static void SetWorldTransformData(this Transform transform, TransformData data)
		{
		}
	}
}
