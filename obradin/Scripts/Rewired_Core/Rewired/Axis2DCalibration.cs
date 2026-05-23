using System;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = false, renamePubIntMembers = false)]
	public sealed class Axis2DCalibration
	{
		[SerializeField]
		[Tooltip("The calculation type for the dead zone.")]
		[CustomObfuscation(rename = false)]
		private DeadZone2DType _deadZoneType = DeadZone2DType.Radial;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Calculation type for sensitivity on 2D axes.")]
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
			AxisSensitivity2DType axisSensitivity2DType = default(AxisSensitivity2DType);
			bool flag2 = default(bool);
			bool flag = default(bool);
			float num5 = default(float);
			DeadZone2DType deadZone2DType = default(DeadZone2DType);
			while (true)
			{
				int num = -1011022644;
				while (true)
				{
					AxisCalibration axisCalibration;
					int num3;
					AxisCalibration axisCalibration2;
					switch (num ^ -1011022640)
					{
					case 31:
						break;
					case 15:
						value.y = 1f;
						num = -1011022648;
						continue;
					case 27:
						axisCalibration = yAxis;
						goto IL_00bb;
					case 24:
						num = -1011022640;
						continue;
					case 18:
						if (!(value.x < 0f))
						{
							goto case 16;
						}
						if (!(value.x < -1f))
						{
							int num10;
							if (value.x + 1f > 0.001f)
							{
								num = -1011022656;
								num10 = num;
							}
							else
							{
								num = -1011022649;
								num10 = num;
							}
							continue;
						}
						goto case 23;
					case 25:
						switch (axisSensitivity2DType)
						{
						case AxisSensitivity2DType.Axial:
							goto IL_0302;
						case AxisSensitivity2DType.Radial:
							goto IL_0404;
						}
						num = -1011022642;
						continue;
					case 30:
						throw new NotImplementedException();
					case 22:
						value.x = (flag2 ? InputTools.TransformAxis2DComponentValue(valueRawX, xAxis.calibratedZero, xAxis.calibratedMin, xAxis.calibratedMax) : valueRawX);
						value.y = (flag ? InputTools.TransformAxis2DComponentValue(valueRawY, yAxis.calibratedZero, yAxis.calibratedMin, yAxis.calibratedMax) : valueRawY);
						value = InputTools.ApplyRadialDeadZone(value.x, value.y, num5);
						num = -1011022633;
						continue;
					case 6:
						if (!(value.y < 0f))
						{
							goto case 0;
						}
						if (!(value.y < -1f))
						{
							int num9;
							if (value.y + 1f <= 0.001f)
							{
								num = -1011022632;
								num9 = num;
							}
							else
							{
								num = -1011022640;
								num9 = num;
							}
							continue;
						}
						goto case 8;
					case 10:
						num = -1011022633;
						continue;
					case 5:
						if (flag && yAxis.invert)
						{
							value.y *= -1f;
							num = -1011022626;
							continue;
						}
						goto default;
					case 13:
						value.x = (flag2 ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
						value.y = (flag ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
						num = -1011022630;
						continue;
					case 7:
						axisSensitivity2DType = sensitivityType;
						num = -1011022647;
						continue;
					case 12:
						if (MathTools.ApproximatelyZero(num5))
						{
							value.x = (flag2 ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
							num = -1011022651;
							continue;
						}
						goto case 22;
					case 29:
						value.x = InputTools.ApplySensitivity(value.x, xAxis.sensitivityType, xAxis.sensitivity, xAxis.sensitivityCurve);
						num = -1011022653;
						continue;
					case 9:
						goto IL_0302;
					case 28:
						flag2 = xAxis != null;
						flag = yAxis != null;
						deadZone2DType = deadZoneType;
						num = -1011022608;
						continue;
					case 1:
						value.x = 1f;
						num = -1011022656;
						continue;
					case 26:
						value.y = InputTools.ApplySensitivity(value.y, yAxis.sensitivityType, yAxis.sensitivity, yAxis.sensitivityCurve);
						num = -1011022629;
						continue;
					case 3:
					{
						int num8;
						if (1f - value.x > 0.001f)
						{
							num = -1011022656;
							num8 = num;
						}
						else
						{
							num = -1011022639;
							num8 = num;
						}
						continue;
					}
					case 32:
						switch (deadZone2DType)
						{
						case DeadZone2DType.Axial:
							break;
						default:
							goto IL_03b5;
						case DeadZone2DType.Radial:
							goto IL_043a;
						}
						goto case 13;
					case 0:
						if (flag2 && xAxis.invert)
						{
							value.x *= -1f;
							num = -1011022635;
							continue;
						}
						goto case 5;
					case 19:
					{
						int num4;
						if (!flag)
						{
							num = -1011022629;
							num4 = num;
						}
						else
						{
							num = -1011022646;
							num4 = num;
						}
						continue;
					}
					case 2:
						goto IL_0404;
					case 21:
						value.y = (flag ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
						num = -1011022633;
						continue;
					case 17:
						goto IL_043a;
					case 4:
						throw new NotImplementedException();
					case 16:
						if (flag && yAxis.applyRangeCalibration)
						{
							if (value.y > 0f)
							{
								int num7;
								if (!(value.y > 1f))
								{
									num = -1011022652;
									num7 = num;
								}
								else
								{
									num = -1011022625;
									num7 = num;
								}
								continue;
							}
							goto case 6;
						}
						goto case 0;
					case 11:
						if (flag2 && xAxis.applyRangeCalibration)
						{
							if (value.x > 0f)
							{
								int num6;
								if (!(value.x <= 1f))
								{
									num = -1011022639;
									num6 = num;
								}
								else
								{
									num = -1011022637;
									num6 = num;
								}
								continue;
							}
							goto case 18;
						}
						goto case 16;
					case 23:
						value.x = -1f;
						num = -1011022656;
						continue;
					case 20:
					{
						int num2;
						if (1f - value.y > 0.001f)
						{
							num = -1011022640;
							num2 = num;
						}
						else
						{
							num = -1011022625;
							num2 = num;
						}
						continue;
					}
					case 8:
						value.y = -1f;
						num = -1011022640;
						continue;
					default:
						{
							return value;
						}
						IL_0302:
						if (!flag2)
						{
							num = -1011022653;
							num3 = num;
						}
						else
						{
							num = -1011022643;
							num3 = num;
						}
						continue;
						IL_043a:
						num5 = (flag2 ? xAxis.deadZone : (flag ? yAxis.deadZone : 0f));
						num = -1011022628;
						continue;
						IL_00bb:
						axisCalibration2 = axisCalibration;
						if (axisCalibration2 != null)
						{
							InputTools.ApplyRadialSensitivity(ref value, axisCalibration2.sensitivityType, axisCalibration2.sensitivity, axisCalibration2.sensitivityCurve);
							num = -1011022629;
							continue;
						}
						goto case 11;
						IL_03b5:
						num = -1011022636;
						continue;
						IL_0404:
						if (flag2)
						{
							axisCalibration = xAxis;
							goto IL_00bb;
						}
						num = -1011022645;
						continue;
					}
					break;
				}
			}
		}
	}
}
