using System;
using System.Text.RegularExpressions;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false)]
	internal static class InputTools
	{
		[CustomObfuscation(rename = false)]
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public struct ClampAxis2D
		{
			[CustomObfuscation(rename = false)]
			public enum ClampMode
			{
				None = 0,
				Radial = 1,
				Axial = 2
			}

			private ClampMode FNdWuFrMBZHaijrOpRdqoSqXNecfb;

			private float KLnBFARCykgVpaJswPlIiuyYDLqT;

			private float IefXwHvxKMCUdYyWQgyCrANSCzbG;

			private float eBQBimFgARWMXyTcccGFFnrLTglZ;

			private float RPSwqZhgBwymPkvGGKrbVFeuqlg;

			public ClampMode clampMode
			{
				get
				{
					return FNdWuFrMBZHaijrOpRdqoSqXNecfb;
				}
				set
				{
					FNdWuFrMBZHaijrOpRdqoSqXNecfb = value;
				}
			}

			public float minX
			{
				get
				{
					return KLnBFARCykgVpaJswPlIiuyYDLqT;
				}
				set
				{
					KLnBFARCykgVpaJswPlIiuyYDLqT = value;
				}
			}

			public float maxX
			{
				get
				{
					return IefXwHvxKMCUdYyWQgyCrANSCzbG;
				}
				set
				{
					IefXwHvxKMCUdYyWQgyCrANSCzbG = value;
				}
			}

			public float minY
			{
				get
				{
					return eBQBimFgARWMXyTcccGFFnrLTglZ;
				}
				set
				{
					eBQBimFgARWMXyTcccGFFnrLTglZ = value;
				}
			}

			public float maxY
			{
				get
				{
					return RPSwqZhgBwymPkvGGKrbVFeuqlg;
				}
				set
				{
					RPSwqZhgBwymPkvGGKrbVFeuqlg = value;
				}
			}

			public float maxRadius
			{
				get
				{
					return IefXwHvxKMCUdYyWQgyCrANSCzbG;
				}
				set
				{
					IefXwHvxKMCUdYyWQgyCrANSCzbG = MathTools.Abs(value);
				}
			}

			public static ClampAxis2D AxialNormalSigned => new ClampAxis2D
			{
				FNdWuFrMBZHaijrOpRdqoSqXNecfb = ClampMode.Axial,
				KLnBFARCykgVpaJswPlIiuyYDLqT = -1f,
				IefXwHvxKMCUdYyWQgyCrANSCzbG = 1f,
				eBQBimFgARWMXyTcccGFFnrLTglZ = -1f,
				RPSwqZhgBwymPkvGGKrbVFeuqlg = 1f
			};

			public static ClampAxis2D RadialNormal => new ClampAxis2D
			{
				FNdWuFrMBZHaijrOpRdqoSqXNecfb = ClampMode.Radial,
				maxRadius = 1f
			};

			public static ClampAxis2D None => new ClampAxis2D
			{
				FNdWuFrMBZHaijrOpRdqoSqXNecfb = ClampMode.None
			};
		}

		public static float TransformAxis2DComponentValue(float value, float oldZero, float oldMin, float oldMax, float newZero, float newMin, float newMax, bool clamp)
		{
			if (clamp)
			{
				if (value < oldMin)
				{
					value = oldMin;
				}
				else if (value > oldMax)
				{
					value = oldMax;
				}
			}
			if (MathTools.Approximately(value, oldZero))
			{
				return 0f;
			}
			value = ((!(value > oldZero)) ? MathTools.ValueInNewRange(value, oldMin, oldZero, newMin, newZero, clamp) : MathTools.ValueInNewRange(value, oldZero, oldMax, newZero, newMax, clamp));
			return value;
		}

		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			value = ((!(value > zero)) ? MathTools.ValueInNewRange(value, min, zero, -1f, 0f) : MathTools.ValueInNewRange(value, zero, max, 0f, 1f));
			return value;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, float upperDeadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (deadZone < 0f)
			{
				deadZone = 0f;
			}
			if (upperDeadZone < 0f)
			{
				upperDeadZone = 0f;
			}
			if (value < min)
			{
				value = min;
			}
			else if (value > max)
			{
				value = max;
			}
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if ((value > zero && value <= zero + deadZone) || (value < zero && value >= zero - deadZone))
			{
				return 0f;
			}
			if (upperDeadZone > 0f)
			{
				if (upperDeadZone + deadZone >= MathTools.Abs(max - min) * 0.5f)
				{
					return 0f;
				}
				bool num = min > max;
				max = ((!num) ? (max - upperDeadZone) : (max + upperDeadZone));
				min = ((!num) ? (min + upperDeadZone) : (min - upperDeadZone));
			}
			value = ((!(value > zero)) ? MathTools.ValueInNewRange(value, min, zero - deadZone, -1f, 0f) : MathTools.ValueInNewRange(value, zero + deadZone, max, 0f, 1f));
			if (applySensitivity)
			{
				value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
			}
			if (value > 0f)
			{
				if (value > 1f || 1f - value <= 0.001f)
				{
					value = 1f;
				}
			}
			else if (value < 0f && (value < -1f || value + 1f <= 0.001f))
			{
				value = -1f;
			}
			if (invert)
			{
				value *= -1f;
			}
			return value;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			return GetCalibratedAxisValueClamped(value, zero, min, max, deadZone, 0f, invert, applySensitivity, sensitivityType, sensitivity, sensitivityCurve);
		}

		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if ((value > 0f && value <= 0f + deadZone) || (value < 0f && value >= 0f - deadZone))
			{
				return 0f;
			}
			value -= deadZone * MathTools.Sign(value);
			if (applySensitivity)
			{
				value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
			}
			if (invert)
			{
				value *= -1f;
			}
			return value;
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			return ApplyRadialDeadZone(xValue, yValue, deadzone, 0f, 1f, ClampAxis2D.AxialNormalSigned);
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float lowerDeadzone, float upperDeadzone, float inputScalingMaxMagnitude, ClampAxis2D clampOptions)
		{
			if (lowerDeadzone < 0f)
			{
				lowerDeadzone = 0f;
			}
			if (upperDeadzone < 0f)
			{
				upperDeadzone = 0f;
			}
			if (inputScalingMaxMagnitude < 0f)
			{
				inputScalingMaxMagnitude = 0f;
			}
			Vector2 result = new Vector2(xValue, yValue);
			float magnitude = result.magnitude;
			if (magnitude < lowerDeadzone)
			{
				return default(Vector2);
			}
			if (upperDeadzone > 0f && inputScalingMaxMagnitude > 0f)
			{
				inputScalingMaxMagnitude -= upperDeadzone;
				if (inputScalingMaxMagnitude <= lowerDeadzone)
				{
					return default(Vector2);
				}
			}
			if (inputScalingMaxMagnitude > 0f)
			{
				float num = (magnitude - lowerDeadzone) / (inputScalingMaxMagnitude - lowerDeadzone);
				result = result.normalized * num;
			}
			switch (clampOptions.clampMode)
			{
			case ClampAxis2D.ClampMode.Radial:
				if (result.sqrMagnitude > clampOptions.maxRadius * clampOptions.maxRadius)
				{
					result = result.normalized * clampOptions.maxRadius;
				}
				break;
			case ClampAxis2D.ClampMode.Axial:
				result.x = MathTools.Clamp(result.x, clampOptions.minX, clampOptions.maxX);
				result.y = MathTools.Clamp(result.y, clampOptions.minY, clampOptions.maxY);
				break;
			default:
				throw new NotImplementedException();
			case ClampAxis2D.ClampMode.None:
				break;
			}
			return result;
		}

		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value == 0f)
			{
				return 0f;
			}
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				return value * sensitivity;
			case AxisSensitivityType.Power:
				if (sensitivity < 0f)
				{
					return 0f;
				}
				if (value > 0f)
				{
					return MathTools.Pow(value, sensitivity);
				}
				return MathTools.Pow(value * -1f, sensitivity) * -1f;
			case AxisSensitivityType.Curve:
			{
				if (sensitivityCurve == null)
				{
					return value;
				}
				float num = MathTools.Clamp(value, -1f, 1f);
				if (!gjKaCyewvqibVgfMgPvlvrddxdIl(sensitivityCurve))
				{
					num = MathTools.Abs(num);
				}
				return value * sensitivityCurve.Evaluate(num);
			}
			default:
				throw new NotImplementedException();
			}
		}

		private static bool gjKaCyewvqibVgfMgPvlvrddxdIl(AnimationCurve P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			int length = P_0.length;
			for (int i = 0; i < length; i++)
			{
				if (P_0[i].time < -0.2f)
				{
					return true;
				}
			}
			return false;
		}

		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				value.x *= sensitivity;
				value.y *= sensitivity;
				break;
			case AxisSensitivityType.Power:
			{
				if (sensitivity < 0f)
				{
					value.x = 0f;
					value.y = 0f;
					break;
				}
				float num2 = MathTools.Pow(value.magnitude, sensitivity);
				value.Normalize();
				value.x *= num2;
				value.y *= num2;
				break;
			}
			case AxisSensitivityType.Curve:
				if (sensitivityCurve != null)
				{
					float time = MathTools.Clamp01(value.magnitude);
					float num = sensitivityCurve.Evaluate(time);
					value.x *= num;
					value.y *= num;
				}
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public static string FormatHardwareIdentifierString(string str)
		{
			if (str == null)
			{
				str = string.Empty;
			}
			str = Regex.Replace(str, "\\s*", string.Empty);
			return str;
		}

		public static AxisRange InvertAxisRange(AxisRange axisRange)
		{
			return axisRange switch
			{
				AxisRange.Full => AxisRange.Full, 
				AxisRange.Positive => AxisRange.Negative, 
				AxisRange.Negative => AxisRange.Positive, 
				_ => throw new NotImplementedException(), 
			};
		}

		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref double lastTime)
		{
			if (controller != null)
			{
				double lastTimeAnyElementChanged = controller.GetLastTimeAnyElementChanged();
				if (lastTimeAnyElementChanged != 0.0 && (lastController == null || !(lastTimeAnyElementChanged <= lastTime)))
				{
					lastController = controller;
					lastTime = lastTimeAnyElementChanged;
				}
			}
		}

		public static bool IsMappableControllerElementType(object type)
		{
			if (type == null)
			{
				return false;
			}
			Type type2 = type.GetType();
			if ((object)type2 == typeof(ControllerElementType))
			{
				return IsMappableType((ControllerElementType)type);
			}
			if ((object)type2 == typeof(ControllerTemplateElementType))
			{
				return IsMappableType((ControllerTemplateElementType)type);
			}
			throw new NotImplementedException();
		}

		public static bool IsMappableType(ControllerElementType type)
		{
			return type < ControllerElementType.CompoundElement;
		}

		public static bool IsMappableType(ControllerTemplateElementType type)
		{
			if (type != ControllerTemplateElementType.Axis)
			{
				return type == ControllerTemplateElementType.Button;
			}
			return true;
		}

		public static bool HandleForced4WayHatsOnUnknownControllers(int direction, ref HatType hatType)
		{
			if (hatType != HatType.EightWay)
			{
				return true;
			}
			if (!ReInput.configVars.force4WayHats)
			{
				return true;
			}
			if (direction % 2 != 0)
			{
				return false;
			}
			hatType = HatType.FourWay;
			return true;
		}

		public static float AxisToDigitalValue(float value)
		{
			if (MathTools.ApproximatelyZero(value))
			{
				return 0f;
			}
			if (value > 0f)
			{
				return 1f;
			}
			return -1f;
		}

		public static float AxisToDigitalValue(float value, float threshold)
		{
			if (MathTools.IsNearZero(value, threshold))
			{
				return 0f;
			}
			if (value > 0f)
			{
				return 1f;
			}
			return -1f;
		}
	}
}
