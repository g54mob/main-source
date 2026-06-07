using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomObfuscation]
	[CustomClassObfuscation]
	internal static class InputTools
	{
		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			return 0f;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			return 0f;
		}

		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			return 0f;
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			return default(Vector2);
		}

		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			return 0f;
		}

		private static bool vGTPDassMWcHgAnjAiXqPvXRQSAqA(AnimationCurve P_0)
		{
			return false;
		}

		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
		}

		public static string FormatHardwareIdentifierString(string str)
		{
			return null;
		}

		public static AxisRange InvertAxisRange(AxisRange axisRange)
		{
			return default(AxisRange);
		}

		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref double lastTime)
		{
		}

		public static bool IsMappableControllerElementType(object type)
		{
			return false;
		}

		public static bool IsMappableType(ControllerElementType type)
		{
			return false;
		}

		public static bool IsMappableType(ControllerTemplateElementType type)
		{
			return false;
		}

		public static bool HandleForced4WayHatsOnUnknownControllers(int direction, ref HatType hatType)
		{
			return false;
		}

		public static float AxisToDigitalValue(float value)
		{
			return 0f;
		}

		public static float AxisToDigitalValue(float value, float threshold)
		{
			return 0f;
		}
	}
}
