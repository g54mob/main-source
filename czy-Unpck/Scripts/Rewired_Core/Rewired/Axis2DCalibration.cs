using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Axis2DCalibration
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The calculation type for the dead zone.")]
		private DeadZone2DType _deadZoneType = DeadZone2DType.Radial;

		[Tooltip("Calculation type for sensitivity on 2D axes.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private AxisSensitivity2DType _sensitivityType;

		public DeadZone2DType deadZoneType
		{
			get
			{
				return _deadZoneType;
			}
			set
			{
				_deadZoneType = value;
			}
		}

		public AxisSensitivity2DType sensitivityType
		{
			get
			{
				return _sensitivityType;
			}
			set
			{
				_sensitivityType = value;
			}
		}

		internal Axis2DCalibration()
		{
		}

		internal Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis)
		{
			return GetCalibrated2DValue(valueRawX, valueRawY, xAxis, yAxis, _deadZoneType, _sensitivityType);
		}

		internal static Vector2 GetCalibrated2DValue(float valueRawX, float valueRawY, AxisCalibration xAxis, AxisCalibration yAxis, DeadZone2DType deadZoneType, AxisSensitivity2DType sensitivityType)
		{
			Vector2 value = default(Vector2);
			bool flag = xAxis != null;
			bool flag2 = yAxis != null;
			float num = default(float);
			int num2;
			AxisSensitivity2DType axisSensitivity2DType = default(AxisSensitivity2DType);
			switch (deadZoneType)
			{
			case DeadZone2DType.Radial:
				num = (flag ? xAxis.deadZone : (flag2 ? yAxis.deadZone : 0f));
				num2 = 607053616;
				goto IL_0037;
			case DeadZone2DType.Axial:
				goto IL_0402;
				IL_0402:
				value.x = (flag ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, applySensitivity: false, applyInversion: false) : valueRawX);
				value.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, applySensitivity: false, applyInversion: false) : valueRawY);
				num2 = 607053613;
				goto IL_0037;
				IL_0037:
				while (true)
				{
					switch (num2 ^ 0x242EE72A)
					{
					case 5:
						num2 = 607053601;
						continue;
					case 3:
						value.x = 1f;
						num2 = 607053607;
						continue;
					case 7:
						axisSensitivity2DType = sensitivityType;
						num2 = 607053624;
						continue;
					case 1:
						if (!yAxis.applyRangeCalibration)
						{
							goto case 12;
						}
						if (!(value.y > 0f))
						{
							goto case 10;
						}
						if (!(value.y > 1f))
						{
							goto IL_0104;
						}
						goto case 21;
					case 23:
						if (flag && xAxis.applyRangeCalibration)
						{
							if (value.x > 0f)
							{
								if (value.x > 1f)
								{
									goto case 3;
								}
								goto IL_015f;
							}
							goto case 8;
						}
						goto IL_0387;
					case 4:
						num2 = 607053613;
						continue;
					case 14:
						throw new NotImplementedException();
					case 6:
						break;
					case 24:
					{
						AxisCalibration axisCalibration = (flag ? xAxis : yAxis);
						if (axisCalibration != null)
						{
							InputTools.ApplyRadialSensitivity(ref value, axisCalibration.sensitivityType, axisCalibration.sensitivity, axisCalibration.sensitivityCurve);
							num2 = 607053629;
							continue;
						}
						goto case 23;
					}
					case 18:
						switch (axisSensitivity2DType)
						{
						case AxisSensitivity2DType.Radial:
							break;
						default:
							goto IL_01f6;
						case AxisSensitivity2DType.Axial:
							goto IL_04cf;
						}
						goto case 24;
					case 9:
						value.x = (flag ? InputTools.TransformAxis2DComponentValue(valueRawX, xAxis.calibratedZero, xAxis.calibratedMin, xAxis.calibratedMax) : valueRawX);
						value.y = (flag2 ? InputTools.TransformAxis2DComponentValue(valueRawY, yAxis.calibratedZero, yAxis.calibratedMin, yAxis.calibratedMax) : valueRawY);
						value = InputTools.ApplyRadialDeadZone(value.x, value.y, num);
						num2 = 607053614;
						continue;
					case 17:
						value.x = -1f;
						num2 = 607053607;
						continue;
					case 25:
						num2 = 607053606;
						continue;
					case 8:
						if (value.x < 0f)
						{
							if (value.x < -1f)
							{
								goto case 17;
							}
							goto IL_02a8;
						}
						goto IL_0387;
					case 16:
						value.y = -1f;
						num2 = 607053606;
						continue;
					case 26:
						if (MathTools.ApproximatelyZero(num))
						{
							value.x = (flag ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, applySensitivity: false, applyInversion: false) : valueRawX);
							value.y = (flag2 ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, applySensitivity: false, applyInversion: false) : valueRawY);
							num2 = 607053613;
							continue;
						}
						goto case 9;
					case 20:
						goto end_IL_0037;
					case 15:
						if (flag2 && yAxis.invert)
						{
							value.y *= -1f;
							num2 = 607053608;
							continue;
						}
						goto default;
					case 13:
						goto IL_0387;
					case 19:
						if (flag2)
						{
							value.y = InputTools.ApplySensitivity(value.y, yAxis.sensitivityType, yAxis.sensitivity, yAxis.sensitivityCurve);
							num2 = 607053629;
							continue;
						}
						goto case 23;
					case 22:
						value.x = InputTools.ApplySensitivity(value.x, xAxis.sensitivityType, xAxis.sensitivity, xAxis.sensitivityCurve);
						num2 = 607053625;
						continue;
					case 11:
						goto IL_0402;
					case 12:
						if (flag && xAxis.invert)
						{
							value.x *= -1f;
							num2 = 607053605;
							continue;
						}
						goto case 15;
					case 10:
						if (!(value.y < 0f))
						{
							goto case 12;
						}
						if (value.y < -1f)
						{
							goto case 16;
						}
						goto IL_0491;
					case 21:
						value.y = 1f;
						num2 = 607053619;
						continue;
					case 0:
						goto IL_04cf;
					default:
						{
							return value;
						}
						IL_01f6:
						num2 = 607053604;
						continue;
					}
					goto end_IL_0020;
					IL_04cf:
					int num3;
					if (!flag)
					{
						num2 = 607053625;
						num3 = num2;
					}
					else
					{
						num2 = 607053628;
						num3 = num2;
					}
					continue;
					IL_0387:
					int num4;
					if (flag2)
					{
						num2 = 607053611;
						num4 = num2;
					}
					else
					{
						num2 = 607053606;
						num4 = num2;
					}
					continue;
					IL_0491:
					int num5;
					if (value.y + 1f <= 0.001f)
					{
						num2 = 607053626;
						num5 = num2;
					}
					else
					{
						num2 = 607053606;
						num5 = num2;
					}
					continue;
					IL_015f:
					int num6;
					if (1f - value.x > 0.001f)
					{
						num2 = 607053607;
						num6 = num2;
					}
					else
					{
						num2 = 607053609;
						num6 = num2;
					}
					continue;
					IL_0104:
					int num7;
					if (1f - value.y <= 0.001f)
					{
						num2 = 607053631;
						num7 = num2;
					}
					else
					{
						num2 = 607053606;
						num7 = num2;
					}
					continue;
					IL_02a8:
					int num8;
					if (value.x + 1f > 0.001f)
					{
						num2 = 607053607;
						num8 = num2;
					}
					else
					{
						num2 = 607053627;
						num8 = num2;
					}
					continue;
					end_IL_0037:
					break;
				}
				goto case DeadZone2DType.Radial;
				end_IL_0020:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
