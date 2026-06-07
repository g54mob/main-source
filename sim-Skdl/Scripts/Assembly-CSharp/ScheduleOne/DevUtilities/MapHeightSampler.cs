using UnityEngine;

namespace ScheduleOne.DevUtilities
{
	public static class MapHeightSampler
	{
		private const float SampleHeight = 100f;

		private const float SampleDistance = 200f;

		public static bool TrySample(float x, float z, out Vector3 hitPoint)
		{
			hitPoint = default(Vector3);
			return false;
		}
	}
}
