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
		public static float TransformAxis2DComponentValue(float value, float zero, float min, float max)
		{
			if (!(value < min))
			{
				goto IL_0066;
			}
			value = min;
			goto IL_0099;
			IL_0011:
			int num;
			while (true)
			{
				switch (num ^ 0xAE7655E)
				{
				case 4:
					num = 182936921;
					continue;
				case 0:
					value = MathTools.ValueInNewRange(value, min, zero, -1f, 0f);
					num = 182936927;
					continue;
				case 6:
					value = max;
					num = 182936925;
					continue;
				case 7:
					break;
				case 5:
					return 0f;
				case 3:
					goto IL_0099;
				case 2:
					value = MathTools.ValueInNewRange(value, zero, max, 0f, 1f);
					num = 182936927;
					continue;
				default:
					return value;
				}
				break;
			}
			goto IL_0066;
			IL_0099:
			if (!MathTools.Approximately(value, zero))
			{
				int num2;
				if (value <= zero)
				{
					num = 182936926;
					num2 = num;
				}
				else
				{
					num = 182936924;
					num2 = num;
				}
			}
			else
			{
				num = 182936923;
			}
			goto IL_0011;
			IL_0066:
			int num3;
			if (value <= max)
			{
				num = 182936925;
				num3 = num;
			}
			else
			{
				num = 182936920;
				num3 = num;
			}
			goto IL_0011;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value < min)
			{
				goto IL_0007;
			}
			goto IL_00df;
			IL_0007:
			int num = -516149790;
			goto IL_000c;
			IL_000c:
			while (true)
			{
				switch (num ^ -516149786)
				{
				case 7:
					break;
				case 6:
					num = -516149780;
					continue;
				case 13:
					return 0f;
				case 16:
					goto IL_0099;
				case 17:
					return 0f;
				case 1:
					goto IL_00cc;
				case 14:
					goto IL_00df;
				case 5:
					goto IL_00f0;
				case 0:
					if (value < 0f)
					{
						if (!(value < -1f))
						{
							goto IL_011f;
						}
						goto case 3;
					}
					goto case 10;
				case 15:
					value = 1f;
					num = -516149792;
					continue;
				case 2:
					goto IL_0152;
				case 3:
					value = -1f;
					num = -516149780;
					continue;
				case 4:
					value = min;
					num = -516149785;
					continue;
				case 9:
					if (value > 1f)
					{
						goto case 15;
					}
					goto IL_0193;
				case 12:
					goto IL_01b5;
				case 11:
					if (applySensitivity)
					{
						value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
						num = -516149789;
						continue;
					}
					goto IL_00f0;
				case 10:
					if (invert)
					{
						value *= -1f;
						num = -516149778;
						continue;
					}
					goto default;
				default:
					return value;
				}
				break;
				IL_0193:
				int num2;
				if (1f - value > 0.001f)
				{
					num = -516149780;
					num2 = num;
				}
				else
				{
					num = -516149783;
					num2 = num;
				}
				continue;
				IL_011f:
				int num3;
				if (value + 1f <= 0.001f)
				{
					num = -516149787;
					num3 = num;
				}
				else
				{
					num = -516149780;
					num3 = num;
				}
				continue;
				IL_00f0:
				int num4;
				if (value <= 0f)
				{
					num = -516149786;
					num4 = num;
				}
				else
				{
					num = -516149777;
					num4 = num;
				}
				continue;
				IL_0152:
				int num5;
				if (!(value <= zero + deadZone))
				{
					num = -516149770;
					num5 = num;
				}
				else
				{
					num = -516149781;
					num5 = num;
				}
				continue;
				IL_0099:
				if (!(value < zero) || !(value >= zero - deadZone))
				{
					if (value > zero)
					{
						value = MathTools.ValueInNewRange(value, zero + deadZone, max, 0f, 1f);
						num = -516149779;
						continue;
					}
					goto IL_01b5;
				}
				num = -516149781;
				continue;
				IL_01b5:
				value = MathTools.ValueInNewRange(value, min, zero - deadZone, -1f, 0f);
				num = -516149779;
			}
			goto IL_0007;
			IL_00cc:
			if (!MathTools.Approximately(value, zero))
			{
				int num6;
				if (value > zero)
				{
					num = -516149788;
					num6 = num;
				}
				else
				{
					num = -516149770;
					num6 = num;
				}
			}
			else
			{
				num = -516149769;
			}
			goto IL_000c;
			IL_00df:
			if (value > max)
			{
				value = max;
				num = -516149785;
				goto IL_000c;
			}
			goto IL_00cc;
		}

		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (!(value > 0f))
			{
				goto IL_004f;
			}
			if (!(value <= 0f + deadZone))
			{
				goto IL_0025;
			}
			goto IL_008c;
			IL_004f:
			int num;
			if (value < 0f && value >= 0f - deadZone)
			{
				num = 959666826;
			}
			else
			{
				value -= deadZone * MathTools.Sign(value);
				if (!applySensitivity)
				{
					goto IL_0068;
				}
				value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
				num = 959666824;
			}
			goto IL_002a;
			IL_0068:
			int num2;
			if (!invert)
			{
				num = 959666825;
				num2 = num;
			}
			else
			{
				num = 959666827;
				num2 = num;
			}
			goto IL_002a;
			IL_0025:
			num = 959666829;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ 0x39335A89)
				{
				case 5:
					break;
				case 4:
					goto IL_004f;
				case 1:
					goto IL_0068;
				case 2:
					value *= -1f;
					num = 959666825;
					continue;
				case 3:
					goto IL_008c;
				default:
					return value;
				}
				break;
			}
			goto IL_0025;
			IL_008c:
			return 0f;
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			Vector2 result = new Vector2(xValue, yValue);
			if (result.magnitude < deadzone)
			{
				goto IL_0013;
			}
			float num = (result.magnitude - deadzone) / (1f - deadzone);
			int num2 = -1431573396;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num2 ^ -1431573394)
				{
				case 0:
					break;
				case 3:
					return Vector2.zero;
				case 2:
					goto IL_0054;
				default:
					return result;
				}
				break;
				IL_0054:
				result.Normalize();
				result.x = MathTools.Clamp(result.x * num, -1f, 1f);
				result.y = MathTools.Clamp(result.y * num, -1f, 1f);
				num2 = -1431573393;
			}
			goto IL_0013;
			IL_0013:
			num2 = -1431573395;
			goto IL_0018;
		}

		public static float ApplySensitivity(float value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (value == 0f)
			{
				goto IL_000b;
			}
			switch (sensitivityType)
			{
			case AxisSensitivityType.Multiplier:
				break;
			case AxisSensitivityType.Power:
				goto IL_003c;
			case AxisSensitivityType.Curve:
				goto IL_006e;
			default:
				goto IL_00cb;
			}
			goto IL_0038;
			IL_006e:
			if (sensitivityCurve == null)
			{
				return value;
			}
			float num = MathTools.Clamp(value, -1f, 1f);
			int num2;
			int num3;
			if (HIMXhNCmlFTbjuBpNChyxaqfmjn(sensitivityCurve))
			{
				num2 = 2073875007;
				num3 = num2;
			}
			else
			{
				num2 = 2073875005;
				num3 = num2;
			}
			goto IL_0010;
			IL_003c:
			if (sensitivity < 0f)
			{
				return 0f;
			}
			if (value > 0f)
			{
				return MathTools.Pow(value, sensitivity);
			}
			return MathTools.Pow(value * -1f, sensitivity) * -1f;
			IL_000b:
			num2 = 2073875003;
			goto IL_0010;
			IL_0038:
			return value * sensitivity;
			IL_0010:
			while (true)
			{
				switch (num2 ^ 0x7B9CD23E)
				{
				case 4:
					break;
				case 2:
					goto IL_0038;
				case 3:
					num = MathTools.Abs(num);
					num2 = 2073875007;
					continue;
				case 5:
					return 0f;
				default:
					return value * sensitivityCurve.Evaluate(num);
				case 0:
					throw new NotImplementedException();
				}
				break;
			}
			goto IL_000b;
			IL_00cb:
			num2 = 2073875006;
			goto IL_0010;
		}

		private static bool HIMXhNCmlFTbjuBpNChyxaqfmjn(AnimationCurve P_0)
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
					if (P_0[num].time < -0.2f)
					{
						return true;
					}
					num++;
					int num2 = -1269687643;
					while (true)
					{
						switch (num2 ^ -1269687641)
						{
						case 0:
							num2 = -1269687642;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002e;
						}
						break;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			return false;
		}

		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			int num;
			float num2 = default(float);
			float time;
			float magnitude;
			float num3;
			switch (sensitivityType)
			{
			case AxisSensitivityType.Power:
				if (sensitivity < 0f)
				{
					value.x = 0f;
					value.y = 0f;
					return;
				}
				goto IL_00fb;
			case AxisSensitivityType.Multiplier:
				goto IL_00a9;
			case AxisSensitivityType.Curve:
				goto IL_00cf;
				IL_00a9:
				value.x *= sensitivity;
				value.y *= sensitivity;
				num = 1682862625;
				goto IL_0020;
				IL_0020:
				while (true)
				{
					switch (num ^ 0x644E7224)
					{
					case 0:
						num = 1682862629;
						continue;
					case 6:
						value.x *= num2;
						value.y *= num2;
						return;
					case 3:
						break;
					case 5:
						return;
					case 1:
						goto IL_00a9;
					case 7:
						goto IL_00cf;
					case 2:
						goto IL_00dd;
					case 8:
						goto IL_00fb;
					default:
						goto end_IL_0005;
					}
					break;
				}
				goto case AxisSensitivityType.Power;
				IL_00cf:
				if (sensitivityCurve == null)
				{
					return;
				}
				goto IL_00dd;
				IL_00dd:
				time = MathTools.Clamp01(value.magnitude);
				num2 = sensitivityCurve.Evaluate(time);
				num = 1682862626;
				goto IL_0020;
				IL_00fb:
				magnitude = value.magnitude;
				num3 = MathTools.Pow(magnitude, sensitivity);
				value.Normalize();
				value.x *= num3;
				value.y *= num3;
				return;
				end_IL_0005:
				break;
			}
			throw new NotImplementedException();
		}

		public static string FormatHardwareIdentifierString(string str)
		{
			if (str == null)
			{
				while (true)
				{
					int num = 1608175022;
					while (true)
					{
						switch (num ^ 0x5FDACDAF)
						{
						case 0:
							break;
						case 1:
							str = string.Empty;
							num = 1608175021;
							continue;
						default:
							goto end_IL_0003;
						}
						break;
					}
					continue;
					end_IL_0003:
					break;
				}
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

		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref double lastTime)
		{
			if (controller == null)
			{
				return;
			}
			while (true)
			{
				double lastTimeAnyElementChanged = controller.GetLastTimeAnyElementChanged();
				int num;
				int num2;
				if (lastTimeAnyElementChanged != 0.0)
				{
					num = -457741190;
					num2 = num;
				}
				else
				{
					num = -457741189;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -457741192)
					{
					case 0:
						num = -457741188;
						continue;
					case 1:
						if (lastTimeAnyElementChanged <= lastTime)
						{
							return;
						}
						goto case 5;
					case 3:
						return;
					case 4:
						break;
					case 2:
					{
						int num3;
						if (lastController == null)
						{
							num = -457741187;
							num3 = num;
						}
						else
						{
							num = -457741191;
							num3 = num;
						}
						continue;
					}
					case 5:
						lastController = controller;
						num = -457741186;
						continue;
					default:
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
