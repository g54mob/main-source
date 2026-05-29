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

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
			bool flag2 = default(bool);
			bool flag = default(bool);
			DeadZone2DType deadZone2DType = default(DeadZone2DType);
			float num3 = default(float);
			AxisCalibration axisCalibration = default(AxisCalibration);
			while (true)
			{
				int num = -315422540;
				while (true)
				{
					AxisCalibration axisCalibration2;
					int num9;
					switch (num ^ -315422543)
					{
					case 12:
						break;
					case 29:
						throw new NotImplementedException();
					case 10:
						if (flag2)
						{
							value.x = InputTools.ApplySensitivity(value.x, xAxis.sensitivityType, xAxis.sensitivity, xAxis.sensitivityCurve);
							num = -315422558;
							continue;
						}
						goto case 19;
					case 27:
						axisCalibration2 = yAxis;
						goto IL_00e3;
					case 23:
						value.x = (flag2 ? InputTools.TransformAxis2DComponentValue(valueRawX, xAxis.calibratedZero, xAxis.calibratedMin, xAxis.calibratedMax) : valueRawX);
						num = -315422539;
						continue;
					case 19:
						if (flag)
						{
							value.y = InputTools.ApplySensitivity(value.y, yAxis.sensitivityType, yAxis.sensitivity, yAxis.sensitivityCurve);
							num = -315422538;
							continue;
						}
						goto case 15;
					case 15:
						if (flag2)
						{
							int num7;
							if (!xAxis.applyRangeCalibration)
							{
								num = -315422560;
								num7 = num;
							}
							else
							{
								num = -315422556;
								num7 = num;
							}
							continue;
						}
						goto case 17;
					case 16:
						goto IL_0180;
					case 14:
						throw new NotImplementedException();
					case 1:
						if (flag && yAxis.invert)
						{
							value.y *= -1f;
							num = -315422532;
							continue;
						}
						goto default;
					case 18:
						value.x = (flag2 ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
						value.y = (flag ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
						num = -315422534;
						continue;
					case 22:
						num = -315422534;
						continue;
					case 21:
						if (value.x > 0f)
						{
							if (!(value.x > 1f))
							{
								int num4;
								if (1f - value.x <= 0.001f)
								{
									num = -315422536;
									num4 = num;
								}
								else
								{
									num = -315422560;
									num4 = num;
								}
								continue;
							}
							goto case 9;
						}
						goto case 20;
					case 8:
						if (value.y < 0f)
						{
							if (!(value.y < -1f))
							{
								int num8;
								if (value.y + 1f > 0.001f)
								{
									num = -315422542;
									num8 = num;
								}
								else
								{
									num = -315422551;
									num8 = num;
								}
								continue;
							}
							goto case 24;
						}
						goto case 3;
					case 0:
						value.y = 1f;
						num = -315422546;
						continue;
					case 26:
						switch (deadZone2DType)
						{
						case DeadZone2DType.Axial:
							break;
						default:
							goto IL_02d5;
						case DeadZone2DType.Radial:
							goto IL_041a;
						}
						goto case 18;
					case 17:
						if (flag && yAxis.applyRangeCalibration)
						{
							int num5;
							if (value.y > 0f)
							{
								num = -315422547;
								num5 = num;
							}
							else
							{
								num = -315422535;
								num5 = num;
							}
							continue;
						}
						goto case 3;
					case 4:
						value.y = (flag ? InputTools.TransformAxis2DComponentValue(valueRawY, yAxis.calibratedZero, yAxis.calibratedMin, yAxis.calibratedMax) : valueRawY);
						value = InputTools.ApplyRadialDeadZone(value.x, value.y, num3);
						num = -315422534;
						continue;
					case 9:
						value.x = 1f;
						num = -315422560;
						continue;
					case 2:
						InputTools.ApplyRadialSensitivity(ref value, axisCalibration.sensitivityType, axisCalibration.sensitivity, axisCalibration.sensitivityCurve);
						num = -315422530;
						continue;
					case 24:
						value.y = -1f;
						num = -315422542;
						continue;
					case 6:
						deadZone2DType = deadZoneType;
						num = -315422549;
						continue;
					case 5:
						flag2 = xAxis != null;
						flag = yAxis != null;
						num = -315422537;
						continue;
					case 20:
						if (!(value.x < 0f))
						{
							goto case 17;
						}
						if (!(value.x < -1f))
						{
							int num6;
							if (value.x + 1f <= 0.001f)
							{
								num = -315422552;
								num6 = num;
							}
							else
							{
								num = -315422560;
								num6 = num;
							}
							continue;
						}
						goto case 25;
					case 30:
						goto IL_041a;
					case 7:
						num = -315422530;
						continue;
					case 11:
						switch (sensitivityType)
						{
						case AxisSensitivity2DType.Axial:
							break;
						case AxisSensitivity2DType.Radial:
							goto IL_0180;
						default:
							goto IL_04a0;
						}
						goto case 10;
					case 31:
						num = -315422542;
						continue;
					case 3:
						if (flag2 && xAxis.invert)
						{
							value.x *= -1f;
							num = -315422544;
							continue;
						}
						goto case 1;
					case 28:
						if (!(value.y > 1f))
						{
							int num2;
							if (1f - value.y <= 0.001f)
							{
								num = -315422543;
								num2 = num;
							}
							else
							{
								num = -315422542;
								num2 = num;
							}
							continue;
						}
						goto case 0;
					case 25:
						value.x = -1f;
						num = -315422560;
						continue;
					default:
						{
							return value;
						}
						IL_04a0:
						num = -315422548;
						continue;
						IL_041a:
						num3 = (flag2 ? xAxis.deadZone : (flag ? yAxis.deadZone : 0f));
						if (MathTools.ApproximatelyZero(num3))
						{
							value.x = (flag2 ? xAxis.GetCalibratedValue(valueRawX, xAxis.deadZone, false, false) : valueRawX);
							value.y = (flag ? yAxis.GetCalibratedValue(valueRawY, yAxis.deadZone, false, false) : valueRawY);
							num = -315422553;
							continue;
						}
						goto case 23;
						IL_0180:
						if (flag2)
						{
							axisCalibration2 = xAxis;
							goto IL_00e3;
						}
						num = -315422550;
						continue;
						IL_02d5:
						num = -315422529;
						continue;
						IL_00e3:
						axisCalibration = axisCalibration2;
						if (axisCalibration != null)
						{
							num = -315422541;
							num9 = num;
						}
						else
						{
							num = -315422530;
							num9 = num;
						}
						continue;
					}
					break;
				}
			}
		}
	}
}
