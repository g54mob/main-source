using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class InputTools
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		[CustomObfuscation(rename = false)]
		public struct ClampAxis2D
		{
			[CustomObfuscation(rename = false)]
			public enum ClampMode
			{
				None = 0,
				Radial = 1,
				Axial = 2
			}

			private ClampMode TqLCKdKERXSQbdPcidybtHATGQQs;

			private float KJZxxacYqsUzuyuCjyTZFcCAHrAs;

			private float YcJQIxAVYKyMmQsXXvwRYbjMwtTE;

			private float sceAWMDSUPiXOmbCtkBEKABRmUNM;

			private float RflqmYiQwJoOdPOTRVHyAAxyIONy;

			public ClampMode clampMode
			{
				get
				{
					return default(ClampMode);
				}
				set
				{
				}
			}

			public float minX
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float maxX
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float minY
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float maxY
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public float maxRadius
			{
				get
				{
					return 0f;
				}
				set
				{
				}
			}

			public static ClampAxis2D AxialNormalSigned => default(ClampAxis2D);

			public static ClampAxis2D RadialNormal => default(ClampAxis2D);

			public static ClampAxis2D None => default(ClampAxis2D);
		}

		public static float TransformAxis2DComponentValue(float value, float oldZero, float oldMin, float oldMax, float newZero, float newMin, float newMax, bool clamp)
		{
			return 0f;
		}

		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			return 0f;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, float upperDeadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
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

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float lowerDeadzone, float upperDeadzone, float inputScalingMaxMagnitude, ClampAxis2D clampOptions)
		{
			return default(Vector2);
		}

		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			return 0f;
		}

		private static bool qMyJUWRHawVWWgBqllGuIhFfhZot(AnimationCurve P_0)
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
