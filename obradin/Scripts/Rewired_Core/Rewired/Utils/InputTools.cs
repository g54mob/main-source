using System;
using System.Text.RegularExpressions;
using Rewired.Data.Mapping;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class InputTools
	{
		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			if (!(value < min))
			{
				goto IL_002f;
			}
			value = min;
			goto IL_003d;
			IL_000e:
			int num;
			while (true)
			{
				switch (num ^ -1645857729)
				{
				case 3:
					num = -1645857730;
					continue;
				case 1:
					break;
				case 2:
					goto IL_003d;
				case 4:
					goto IL_006b;
				default:
					return value;
				}
				break;
			}
			goto IL_002f;
			IL_003d:
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if (value > zero)
			{
				value = MathTools.ValueInNewRange(value, zero, max, 0f, 1f);
				num = -1645857729;
				goto IL_000e;
			}
			goto IL_006b;
			IL_002f:
			if (value > max)
			{
				value = max;
				num = -1645857731;
				goto IL_000e;
			}
			goto IL_003d;
			IL_006b:
			value = MathTools.ValueInNewRange(value, min, zero, -1f, 0f);
			num = -1645857729;
			goto IL_000e;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value < min)
			{
				goto IL_0007;
			}
			goto IL_0123;
			IL_0007:
			int num = -833357553;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -833357567)
				{
				case 16:
					break;
				case 2:
					if (invert)
					{
						value *= -1f;
						num = -833357563;
						continue;
					}
					goto default;
				case 12:
					goto IL_007b;
				case 13:
					num = -833357561;
					continue;
				case 7:
					if (value > 0f)
					{
						goto IL_00b2;
					}
					goto case 5;
				case 17:
					value = 1f;
					num = -833357565;
					continue;
				case 9:
					goto IL_00df;
				case 14:
					value = min;
					num = -833357567;
					continue;
				case 10:
					goto IL_010e;
				case 3:
					goto IL_0123;
				case 1:
					return 0f;
				case 11:
					value = -1f;
					num = -833357565;
					continue;
				case 6:
					if (applySensitivity)
					{
						value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
						num = -833357562;
						continue;
					}
					goto case 7;
				case 15:
					goto IL_0192;
				case 0:
					goto IL_01b3;
				case 5:
					if (!(value < 0f))
					{
						goto case 2;
					}
					goto IL_01d1;
				case 8:
					return 0f;
				default:
					return value;
				}
				break;
				IL_00df:
				int num2;
				if (value + 1f <= 0.001f)
				{
					num = -833357558;
					num2 = num;
				}
				else
				{
					num = -833357565;
					num2 = num;
				}
				continue;
				IL_01d1:
				int num3;
				if (!(value >= -1f))
				{
					num = -833357558;
					num3 = num;
				}
				else
				{
					num = -833357560;
					num3 = num;
				}
				continue;
				IL_007b:
				int num4;
				if (1f - value <= 0.001f)
				{
					num = -833357552;
					num4 = num;
				}
				else
				{
					num = -833357565;
					num4 = num;
				}
				continue;
				IL_00b2:
				int num5;
				if (!(value > 1f))
				{
					num = -833357555;
					num5 = num;
				}
				else
				{
					num = -833357552;
					num5 = num;
				}
			}
			goto IL_0007;
			IL_010e:
			if (value < zero && value >= zero - deadZone)
			{
				num = -833357568;
			}
			else
			{
				if (!(value > zero))
				{
					goto IL_0192;
				}
				value = MathTools.ValueInNewRange(value, zero + deadZone, max, 0f, 1f);
				num = -833357556;
			}
			goto IL_000c;
			IL_0123:
			if (value > max)
			{
				value = max;
				num = -833357567;
				goto IL_000c;
			}
			goto IL_01b3;
			IL_01b3:
			if (MathTools.Approximately(value, zero))
			{
				num = -833357559;
			}
			else
			{
				if (!(value > zero))
				{
					goto IL_010e;
				}
				int num6;
				if (!(value <= zero + deadZone))
				{
					num = -833357557;
					num6 = num;
				}
				else
				{
					num = -833357568;
					num6 = num;
				}
			}
			goto IL_000c;
			IL_0192:
			value = MathTools.ValueInNewRange(value, min, zero - deadZone, -1f, 0f);
			num = -833357561;
			goto IL_000c;
		}

		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (!(value > 0f))
			{
				goto IL_0094;
			}
			if (!(value <= 0f + deadZone))
			{
				goto IL_0025;
			}
			goto IL_00a3;
			IL_0094:
			int num;
			if (value < 0f)
			{
				num = -1732224626;
				goto IL_002a;
			}
			goto IL_00a9;
			IL_00a9:
			value -= deadZone * MathTools.Sign(value);
			num = -1732224631;
			goto IL_002a;
			IL_0025:
			num = -1732224625;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ -1732224628)
				{
				case 0:
					break;
				case 5:
					if (applySensitivity)
					{
						value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
						num = -1732224627;
						continue;
					}
					goto IL_006f;
				case 1:
					goto IL_006f;
				case 2:
					goto IL_0083;
				case 3:
					goto IL_0094;
				case 6:
					goto IL_00a3;
				case 7:
					value *= -1f;
					num = -1732224632;
					continue;
				default:
					return value;
				}
				break;
				IL_0083:
				if (value >= 0f - deadZone)
				{
					num = -1732224630;
					continue;
				}
				goto IL_00a9;
				IL_006f:
				int num2;
				if (!invert)
				{
					num = -1732224632;
					num2 = num;
				}
				else
				{
					num = -1732224629;
					num2 = num;
				}
			}
			goto IL_0025;
			IL_00a3:
			return 0f;
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			Vector2 result = new Vector2(xValue, yValue);
			if (result.magnitude < deadzone)
			{
				return Vector2.zero;
			}
			float num = (result.magnitude - deadzone) / (1f - deadzone);
			result.Normalize();
			result.x = MathTools.Clamp(result.x * num, -1f, 1f);
			result.y = MathTools.Clamp(result.y * num, -1f, 1f);
			return result;
		}

		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value == 0f)
			{
				goto IL_0008;
			}
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				break;
			case AxisSensitivityType.Power:
				goto IL_0054;
			case AxisSensitivityType.Curve:
				goto IL_0086;
			default:
				throw new NotImplementedException();
			}
			goto IL_0050;
			IL_0086:
			if (sensitivityCurve == null)
			{
				return value;
			}
			float num = MathTools.Clamp(value, -1f, 1f);
			int num2;
			if (!LVGLpLUSMJQnNnrJupUjKtKwGrX(sensitivityCurve))
			{
				num = MathTools.Abs(num);
				num2 = -2102401791;
				goto IL_000d;
			}
			goto IL_00b5;
			IL_0054:
			if (sensitivity < 0f)
			{
				return 0f;
			}
			if (value > 0f)
			{
				return MathTools.Pow(value, sensitivity);
			}
			return MathTools.Pow(value * -1f, sensitivity) * -1f;
			IL_0008:
			num2 = -2102401789;
			goto IL_000d;
			IL_0050:
			return value * sensitivity;
			IL_000d:
			switch (num2 ^ -2102401792)
			{
			case 0:
				break;
			case 3:
				return 0f;
			case 2:
				goto IL_0050;
			default:
				goto IL_00b5;
			}
			goto IL_0008;
			IL_00b5:
			return value * sensitivityCurve.Evaluate(num);
		}

		private static bool LVGLpLUSMJQnNnrJupUjKtKwGrX(AnimationCurve P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			int length = P_0.length;
			int num = 0;
			while (num < length)
			{
				while (true)
				{
					int num2;
					if (P_0[num].time < -0.2f)
					{
						num2 = -1182615930;
					}
					else
					{
						num++;
						num2 = -1182615931;
					}
					while (true)
					{
						switch (num2 ^ -1182615931)
						{
						case 2:
							num2 = -1182615932;
							continue;
						case 1:
							break;
						case 3:
							return true;
						default:
							goto end_IL_0032;
						}
						break;
					}
					continue;
					end_IL_0032:
					break;
				}
			}
			return false;
		}

		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			float num3 = default(float);
			float num2 = default(float);
			while (true)
			{
				int num = 686143120;
				while (true)
				{
					int num4;
					switch (num ^ 0x28E5B692)
					{
					case 8:
						break;
					case 5:
						if (sensitivity < 0f)
						{
							value.x = 0f;
							num = 686143128;
							continue;
						}
						goto case 7;
					case 7:
					{
						float magnitude = value.magnitude;
						num3 = MathTools.Pow(magnitude, sensitivity);
						value.Normalize();
						num = 686143121;
						continue;
					}
					case 6:
					{
						float time = MathTools.Clamp01(value.magnitude);
						num2 = sensitivityCurve.Evaluate(time);
						value.x *= num2;
						num = 686143122;
						continue;
					}
					case 11:
						goto IL_00ae;
					case 3:
						value.x *= num3;
						value.y *= num3;
						num = 686143134;
						continue;
					case 9:
						goto IL_00eb;
					case 0:
						value.y *= num2;
						return;
					case 12:
						return;
					case 2:
						switch (sensitivityType)
						{
						case AxisSensitivityType.Power:
							break;
						case AxisSensitivityType.Curve:
							goto IL_00ae;
						case AxisSensitivityType.Multiplier:
							goto IL_00eb;
						default:
							goto IL_0149;
						}
						goto case 5;
					case 4:
						return;
					case 10:
						value.y = 0f;
						return;
					default:
						{
							throw new NotImplementedException();
						}
						IL_0149:
						num = 686143123;
						continue;
						IL_00eb:
						value.x *= sensitivity;
						value.y *= sensitivity;
						return;
						IL_00ae:
						if (sensitivityCurve == null)
						{
							num = 686143126;
							num4 = num;
						}
						else
						{
							num = 686143124;
							num4 = num;
						}
						continue;
					}
					break;
				}
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
			switch (axisRange)
			{
			case AxisRange.Full:
				return AxisRange.Full;
			case AxisRange.Positive:
				return AxisRange.Negative;
			case AxisRange.Negative:
				return AxisRange.Positive;
			default:
				throw new NotImplementedException();
			}
		}

		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref float lastTime)
		{
			if (controller == null)
			{
				return;
			}
			while (true)
			{
				float lastTimeAnyElementChanged = controller.GetLastTimeAnyElementChanged();
				int num = -697016034;
				while (true)
				{
					switch (num ^ -697016037)
					{
					case 4:
						num = -697016040;
						continue;
					case 3:
						break;
					case 5:
						if (lastTimeAnyElementChanged == 0f)
						{
							return;
						}
						goto case 1;
					case 0:
						if (lastTimeAnyElementChanged <= lastTime)
						{
							return;
						}
						goto default;
					case 1:
					{
						int num2;
						if (lastController != null)
						{
							num = -697016037;
							num2 = num;
						}
						else
						{
							num = -697016039;
							num2 = num;
						}
						continue;
					}
					default:
						lastController = controller;
						lastTime = lastTimeAnyElementChanged;
						return;
					}
					break;
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
			if (object.ReferenceEquals(type2, typeof(ControllerElementType)))
			{
				return IsMappableType((ControllerElementType)type);
			}
			if (object.ReferenceEquals(type2, typeof(ControllerTemplateElementType)))
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
				goto IL_001a;
			}
			hatType = HatType.FourWay;
			int num = 150612676;
			goto IL_001f;
			IL_001a:
			num = 150612677;
			goto IL_001f;
			IL_001f:
			switch (num ^ 0x8FA2AC4)
			{
			case 2:
				break;
			case 1:
				return false;
			default:
				return true;
			}
			goto IL_001a;
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
