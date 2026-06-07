using UnityEngine;

namespace Simulator
{
	public struct RectBoundary
	{
		public readonly Vector3 Min;

		public readonly Vector3 Max;

		public RectBoundary(Vector3 min, Vector3 max)
		{
			Min = min;
			Max = max;
		}
	}
}
