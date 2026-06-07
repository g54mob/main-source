using UnityEngine;

namespace FluffyUnderware.Curvy
{
	public static class CurvySplineSegmentDefaultValues
	{
		public const CurvyOrientationSwirl Swirl = CurvyOrientationSwirl.None;

		public const bool SynchronizeTCB = true;

		public const bool AutoHandles = true;

		public const float AutoHandleDistance = 0.39f;

		public static readonly Vector3 HandleIn;

		public static readonly Vector3 HandleOut;
	}
}
