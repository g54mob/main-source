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
			if (value < min)
			{
				goto IL_0004;
			}
			goto IL_005c;
			IL_0004:
			int num = 1771472838;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num ^ 0x699687C2)
				{
				case 5:
					break;
				case 2:
					goto IL_002e;
				case 0:
					goto IL_005c;
				case 4:
					value = min;
					num = 1771472832;
					continue;
				case 1:
					goto IL_0074;
				default:
					return value;
				}
				break;
			}
			goto IL_0004;
			IL_005c:
			if (value > max)
			{
				value = max;
				num = 1771472832;
				goto IL_0009;
			}
			goto IL_002e;
			IL_0074:
			value = MathTools.ValueInNewRange(value, min, zero, -1f, 0f);
			num = 1771472833;
			goto IL_0009;
			IL_002e:
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if (value > zero)
			{
				value = MathTools.ValueInNewRange(value, zero, max, 0f, 1f);
				num = 1771472833;
				goto IL_0009;
			}
			goto IL_0074;
		}

		public static float GetCalibratedAxisValueClamped(float value, float zero, float min, float max, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (!(value < min))
			{
				goto IL_00ac;
			}
			value = min;
			goto IL_00f8;
			IL_0014:
			int num;
			while (true)
			{
				switch (num ^ 0x656C2B8B)
				{
				case 2:
					num = 1701587843;
					continue;
				case 11:
					break;
				case 0:
					if (applySensitivity)
					{
						value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
						num = 1701587840;
						continue;
					}
					break;
				case 3:
					if (invert)
					{
						value *= -1f;
						num = 1701587850;
						continue;
					}
					goto default;
				case 8:
					goto end_IL_0014;
				case 6:
					if (!(value > 1f))
					{
						goto IL_00c5;
					}
					goto case 14;
				case 14:
					value = 1f;
					num = 1701587848;
					continue;
				case 9:
					goto IL_00f8;
				case 10:
					goto IL_0126;
				case 5:
					goto IL_0134;
				case 7:
					value = -1f;
					num = 1701587848;
					continue;
				case 12:
					return 0f;
				case 13:
					goto IL_0191;
				case 4:
					if (!(value < 0f))
					{
						goto case 3;
					}
					if (value < -1f)
					{
						goto case 7;
					}
					goto IL_01b5;
				default:
					return value;
				}
				int num2;
				if (value <= 0f)
				{
					num = 1701587855;
					num2 = num;
				}
				else
				{
					num = 1701587853;
					num2 = num;
				}
				continue;
				IL_01b5:
				int num3;
				if (value + 1f <= 0.001f)
				{
					num = 1701587852;
					num3 = num;
				}
				else
				{
					num = 1701587848;
					num3 = num;
				}
				continue;
				IL_0191:
				if (value >= zero - deadZone)
				{
					num = 1701587847;
					continue;
				}
				goto IL_016c;
				IL_00c5:
				int num4;
				if (1f - value > 0.001f)
				{
					num = 1701587848;
					num4 = num;
				}
				else
				{
					num = 1701587845;
					num4 = num;
				}
				continue;
				end_IL_0014:
				break;
			}
			goto IL_00ac;
			IL_00f8:
			if (MathTools.Approximately(value, zero))
			{
				return 0f;
			}
			if (value > zero)
			{
				int num5;
				if (!(value <= zero + deadZone))
				{
					num = 1701587841;
					num5 = num;
				}
				else
				{
					num = 1701587847;
					num5 = num;
				}
				goto IL_0014;
			}
			goto IL_0126;
			IL_0134:
			value = MathTools.ValueInNewRange(value, min, zero - deadZone, -1f, 0f);
			num = 1701587851;
			goto IL_0014;
			IL_0126:
			if (value < zero)
			{
				num = 1701587846;
				goto IL_0014;
			}
			goto IL_016c;
			IL_00ac:
			if (value > max)
			{
				value = max;
				num = 1701587842;
				goto IL_0014;
			}
			goto IL_00f8;
			IL_016c:
			if (value > zero)
			{
				value = MathTools.ValueInNewRange(value, zero + deadZone, max, 0f, 1f);
				num = 1701587851;
				goto IL_0014;
			}
			goto IL_0134;
		}

		public static float GetCalibratedAxisValue(float value, float deadZone, bool invert, bool applySensitivity, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			if (MathTools.Approximately(value, 0f))
			{
				return 0f;
			}
			if (value > 0f)
			{
				if (!(value <= 0f + deadZone))
				{
					goto IL_0025;
				}
				goto IL_0066;
			}
			goto IL_007f;
			IL_007f:
			int num;
			if (!(value < 0f) || !(value >= 0f - deadZone))
			{
				value -= deadZone * MathTools.Sign(value);
				num = -1550181843;
			}
			else
			{
				num = -1550181848;
			}
			goto IL_002a;
			IL_0066:
			return 0f;
			IL_0025:
			num = -1550181847;
			goto IL_002a;
			IL_002a:
			while (true)
			{
				switch (num ^ -1550181843)
				{
				case 2:
					break;
				case 3:
					if (invert)
					{
						value *= -1f;
						num = -1550181844;
						continue;
					}
					goto default;
				case 5:
					goto IL_0066;
				case 4:
					goto IL_007f;
				case 6:
					value = ApplySensitivity(value, sensitivityType, sensitivity, sensitivityCurve);
					num = -1550181842;
					continue;
				case 0:
					goto IL_00b0;
				default:
					return value;
				}
				break;
				IL_00b0:
				int num2;
				if (!applySensitivity)
				{
					num = -1550181842;
					num2 = num;
				}
				else
				{
					num = -1550181845;
					num2 = num;
				}
			}
			goto IL_0025;
		}

		public static Vector2 ApplyRadialDeadZone(float xValue, float yValue, float deadzone)
		{
			Vector2 result = new Vector2(xValue, yValue);
			if (result.magnitude < deadzone)
			{
				goto IL_0013;
			}
			float num = (result.magnitude - deadzone) / (1f - deadzone);
			result.Normalize();
			int num2 = -359521577;
			goto IL_0018;
			IL_0018:
			while (true)
			{
				switch (num2 ^ -359521580)
				{
				case 2:
					break;
				case 1:
					return Vector2.zero;
				case 3:
					goto IL_005b;
				default:
					return result;
				}
				break;
				IL_005b:
				result.x = MathTools.Clamp(result.x * num, -1f, 1f);
				result.y = MathTools.Clamp(result.y * num, -1f, 1f);
				num2 = -359521580;
			}
			goto IL_0013;
			IL_0013:
			num2 = -359521579;
			goto IL_0018;
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
				goto IL_00a0;
			case AxisSensitivityType.Power:
				goto IL_00a4;
			case AxisSensitivityType.Curve:
				goto IL_00e0;
			}
			int num = 1191576119;
			goto IL_000d;
			IL_00e0:
			float num2 = default(float);
			if (sensitivityCurve != null)
			{
				num2 = MathTools.Clamp(value, -1f, 1f);
				num = 1191576112;
			}
			else
			{
				num = 1191576118;
			}
			goto IL_000d;
			IL_00a4:
			if (sensitivity < 0f)
			{
				return 0f;
			}
			if (value > 0f)
			{
				num = 1191576116;
				goto IL_000d;
			}
			return MathTools.Pow(value * -1f, sensitivity) * -1f;
			IL_0008:
			num = 1191576113;
			goto IL_000d;
			IL_00a0:
			return value * sensitivity;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x47060234)
				{
				case 6:
					break;
				case 2:
					return value;
				case 4:
					if (!iHQGiOszYBROeLaUEVQxthMaEeU(sensitivityCurve))
					{
						num2 = MathTools.Abs(num2);
						num = 1191576115;
						continue;
					}
					goto default;
				case 5:
					return 0f;
				case 1:
					goto IL_00a0;
				case 0:
					return MathTools.Pow(value, sensitivity);
				default:
					return value * sensitivityCurve.Evaluate(num2);
				case 3:
					throw new NotImplementedException();
				}
				break;
			}
			goto IL_0008;
		}

		private static bool iHQGiOszYBROeLaUEVQxthMaEeU(AnimationCurve P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			int length = P_0.length;
			int num2 = default(int);
			while (true)
			{
				int num = 1182992254;
				while (true)
				{
					switch (num ^ 0x4683077D)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = 1182992252;
						continue;
					case 2:
						if (P_0[num2].time < -0.2f)
						{
							return true;
						}
						num2++;
						num = 1182992252;
						continue;
					default:
						if (num2 >= length)
						{
							return false;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public static void ApplyRadialSensitivity(ref Vector2 value, AxisSensitivityType sensitivityType, float sensitivity, AnimationCurve sensitivityCurve)
		{
			float magnitude;
			float num3;
			switch (sensitivityType)
			{
			case AxisSensitivityType.Curve:
				while (true)
				{
					if (sensitivityCurve == null)
					{
						return;
					}
					while (true)
					{
						IL_0063:
						float time = MathTools.Clamp01(value.magnitude);
						float num = sensitivityCurve.Evaluate(time);
						value.x *= num;
						value.y *= num;
						int num2 = 707399874;
						while (true)
						{
							switch (num2 ^ 0x2A2A10C1)
							{
							case 5:
								num2 = 707399872;
								continue;
							case 4:
								break;
							case 3:
								return;
							case 6:
								goto IL_0063;
							case 2:
								goto end_IL_0050;
							case 1:
								goto IL_00d6;
							case 7:
								goto IL_00fd;
							default:
								goto end_IL_0005;
							}
							break;
						}
						break;
					}
					continue;
					end_IL_0050:
					break;
				}
				goto IL_009a;
			case AxisSensitivityType.Multiplier:
				goto IL_00d6;
			case AxisSensitivityType.Power:
				goto IL_00fd;
				IL_00fd:
				if (sensitivity < 0f)
				{
					value.x = 0f;
					value.y = 0f;
					return;
				}
				goto IL_009a;
				IL_009a:
				magnitude = value.magnitude;
				num3 = MathTools.Pow(magnitude, sensitivity);
				value.Normalize();
				value.x *= num3;
				value.y *= num3;
				return;
				IL_00d6:
				value.x *= sensitivity;
				value.y *= sensitivity;
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
					int num = -1587944071;
					while (true)
					{
						switch (num ^ -1587944072)
						{
						case 2:
							break;
						case 1:
							str = string.Empty;
							num = -1587944072;
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

		public static void CompareLastActiveController(Controller controller, ref Controller lastController, ref float lastTime)
		{
			if (controller == null)
			{
				return;
			}
			while (true)
			{
				float lastTimeAnyElementChanged = controller.GetLastTimeAnyElementChanged();
				if (lastTimeAnyElementChanged == 0f)
				{
					break;
				}
				while (true)
				{
					int num;
					int num2;
					if (lastController == null)
					{
						num = 1302544262;
						num2 = num;
					}
					else
					{
						num = 1302544260;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x4DA33F87)
						{
						case 5:
							num = 1302544259;
							continue;
						case 1:
							lastController = controller;
							num = 1302544263;
							continue;
						case 3:
							if (lastTimeAnyElementChanged <= lastTime)
							{
								return;
							}
							goto case 1;
						case 2:
							break;
						case 4:
							goto end_IL_0045;
						default:
							lastTime = lastTimeAnyElementChanged;
							return;
						}
						break;
					}
					continue;
					end_IL_0045:
					break;
				}
			}
		}

		public static bool IsMappableControllerElementType(object type)
		{
			if (type == null)
			{
				goto IL_0003;
			}
			Type type2 = type.GetType();
			int num = -1120263589;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1120263589)
				{
				case 4:
					break;
				case 3:
					return false;
				case 1:
					return IsMappableType((ControllerElementType)type);
				case 0:
					if (!object.ReferenceEquals(type2, typeof(ControllerElementType)))
					{
						if (!object.ReferenceEquals(type2, typeof(ControllerTemplateElementType)))
						{
							throw new NotImplementedException();
						}
						num = -1120263591;
					}
					else
					{
						num = -1120263590;
					}
					continue;
				default:
					return IsMappableType((ControllerTemplateElementType)type);
				}
				break;
			}
			goto IL_0003;
			IL_0003:
			num = -1120263592;
			goto IL_0008;
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
