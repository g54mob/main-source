using Coherence.Common;
using UnityEngine;

namespace Coherence.Interpolation
{
	public static class InterpolationUtils
	{
		public static float ClampFloat(float value)
		{
			return 0f;
		}

		public static Quaternion SmoothDampQuaternion(Quaternion current, Quaternion target, ref Vector4d currentVelocity, float smoothTime, float maxSpeed, float deltaTime)
		{
			return default(Quaternion);
		}

		public static double SmoothMixDouble(double current, double target, ref double velocity, float smoothTime, double maxSpeed, float deltaTime)
		{
			return 0.0;
		}

		public static double SmoothDampDouble(double current, double target, ref double velocity, float smoothTime, double maxSpeed, float deltaTime)
		{
			return 0.0;
		}

		public static double PoorMansLerpDouble(double current, double target, ref double velocity, float smoothTime, double maxSpeed, float deltaTime)
		{
			return 0.0;
		}

		private static double ClampDouble(double value, double min, double max)
		{
			return 0.0;
		}

		private static bool IsValid(this Quaternion q)
		{
			return false;
		}

		public static void ToAngleAxisShortest(this Quaternion q, out float angle, out Vector3 axis)
		{
			angle = default(float);
			axis = default(Vector3);
		}
	}
}
