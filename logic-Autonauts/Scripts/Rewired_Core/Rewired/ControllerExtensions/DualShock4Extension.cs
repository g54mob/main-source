using System;
using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension
	{
		private class xOPDMxWDKwUvhaMcKGCGBWDhIrpJ : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 WYZhcjTnddfwsuXVuPbKNLuuJgB;

			public readonly bool JgidXSSSAGvvkDcAIVICtlmgnKR;

			public readonly int QTcZLynCWHLLppDxcAAAPxKXLEc;

			public xOPDMxWDKwUvhaMcKGCGBWDhIrpJ(IDriver_DualShock4 driver, bool supportsVibration, int vibrationMotorCount)
			{
				WYZhcjTnddfwsuXVuPbKNLuuJgB = driver;
				JgidXSSSAGvvkDcAIVICtlmgnKR = supportsVibration;
				QTcZLynCWHLLppDxcAAAPxKXLEc = vibrationMotorCount;
			}
		}

		private xOPDMxWDKwUvhaMcKGCGBWDhIrpJ osAcqhQGqUOKZMlJKgeajFWwmnz;

		private bool AsIGpabQMBfkogwrlxBdKkoAAfgN;

		private TimerAbs[] EKvpQGhJhXJTuQtvfhYGZZMoAhR;

		private Joystick joystick
		{
			get
			{
				return GetController<Joystick>();
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					return 0;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.QTcZLynCWHLLppDxcAAAPxKXLEc;
			}
		}

		public float lightColorRed
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					goto IL_0019;
				}
				int num;
				if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					if (!base.enabled)
					{
						num = -149497831;
						goto IL_001e;
					}
					return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorR;
				}
				goto IL_0054;
				IL_001e:
				switch (num ^ -149497829)
				{
				case 0:
					break;
				case 1:
					return 0f;
				default:
					goto IL_0054;
				}
				goto IL_0019;
				IL_0019:
				num = -149497830;
				goto IL_001e;
				IL_0054:
				return 0f;
			}
			set
			{
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					return;
				}
				while (true)
				{
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorR = value;
					int num = -1683875983;
					while (true)
					{
						switch (num ^ -1683875981)
						{
						case 0:
							goto IL_0009;
						default:
							return;
						case 1:
							break;
						case 2:
							return;
						}
						break;
						IL_0009:
						num = -1683875982;
					}
				}
			}
		}

		public float lightColorGreen
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					while (true)
					{
						int num = -1826634798;
						while (true)
						{
							switch (num ^ -1826634797)
							{
							case 2:
								break;
							case 1:
								goto IL_0045;
							default:
								goto end_IL_0027;
							}
							break;
							IL_0045:
							if (!base.enabled)
							{
								num = -1826634797;
								continue;
							}
							return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorG;
						}
						continue;
						end_IL_0027:
						break;
					}
				}
				return 0f;
			}
			set
			{
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					return;
				}
				while (true)
				{
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorG = value;
					int num = 137488682;
					while (true)
					{
						switch (num ^ 0x831E92B)
						{
						case 0:
							goto IL_0009;
						default:
							return;
						case 2:
							break;
						case 1:
							return;
						}
						break;
						IL_0009:
						num = 137488681;
					}
				}
			}
		}

		public float lightColorBlue
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					goto IL_0019;
				}
				int num;
				int num2;
				if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					num = 776581975;
					num2 = num;
				}
				else
				{
					num = 776581973;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = 776581972;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ 0x2E49B355)
					{
					case 3:
						break;
					case 1:
						return 0f;
					case 2:
						if (!base.enabled)
						{
							goto IL_0062;
						}
						return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorB;
					default:
						return 0f;
					}
					break;
					IL_0062:
					num = 776581973;
				}
				goto IL_0019;
			}
			set
			{
				if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorB = value;
				}
			}
		}

		public int maxTouches
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					return 0;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.MaxTouches;
			}
		}

		public int touchCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchCount();
			}
		}

		public float batteryLevel
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					return 0f;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 driver)
			: base(new xOPDMxWDKwUvhaMcKGCGBWDhIrpJ(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(EKvpQGhJhXJTuQtvfhYGZZMoAhR, 0, EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length);
		}

		private DualShock4Extension(DualShock4Extension source)
			: base(source)
		{
			try
			{
				EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[0];
			}
			ArrayTools.Populate(EKvpQGhJhXJTuQtvfhYGZZMoAhR, 0, EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			DualShock4MotorType motor = default(DualShock4MotorType);
			while (true)
			{
				int num;
				int num2;
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					num = 1053848074;
					num2 = num;
				}
				else
				{
					num = 1053848077;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x3ED07201)
					{
					case 10:
						num = 1053848068;
						continue;
					case 1:
						if (motorIndex >= 0)
						{
							int num4;
							if (motorIndex >= osAcqhQGqUOKZMlJKgeajFWwmnz.QTcZLynCWHLLppDxcAAAPxKXLEc)
							{
								num = 1053848066;
								num4 = num;
							}
							else
							{
								num = 1053848073;
								num4 = num;
							}
							continue;
						}
						return;
					case 3:
						return;
					case 11:
						return;
					case 8:
						switch (motorIndex)
						{
						case 0:
							goto IL_00b3;
						case 1:
							goto IL_00db;
						}
						num = 1053848072;
						continue;
					case 2:
						goto IL_00b3;
					case 5:
						break;
					case 6:
						goto IL_00db;
					case 4:
						num = 1053848070;
						continue;
					case 12:
					{
						int num3;
						if (base.enabled)
						{
							num = 1053848064;
							num3 = num;
						}
						else
						{
							num = 1053848074;
							num3 = num;
						}
						continue;
					}
					case 9:
						throw new NotImplementedException();
					case 0:
						num = 1053848070;
						continue;
					default:
						{
							SetVibration(motor, motorLevel, duration, stopOtherMotors);
							return;
						}
						IL_00db:
						motor = DualShock4MotorType.RightMotor;
						num = 1053848065;
						continue;
						IL_00b3:
						motor = DualShock4MotorType.LeftMotor;
						num = 1053848069;
						continue;
					}
					break;
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				if (base.enabled)
				{
					if (!osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
					{
						return 0f;
					}
					switch (motorIndex)
					{
					case 0:
						break;
					case 1:
						return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.RightMotor;
					default:
						return 0f;
					}
					goto IL_007f;
				}
				while (true)
				{
					switch (-2014514529 ^ -2014514531)
					{
					case 0:
						break;
					case 2:
						goto end_IL_002f;
					default:
						goto IL_007f;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return 0f;
			IL_007f:
			return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LeftMotor;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num3 = default(int);
			while (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = 1178548868;
					num2 = num;
				}
				else
				{
					num = 1178548870;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x463F3A84)
					{
					case 3:
						num = 1178548864;
						continue;
					case 4:
						break;
					case 5:
						num3 = 0;
						num = 1178548869;
						continue;
					case 0:
						return;
					case 6:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num3].Clear();
						num3++;
						num = 1178548869;
						continue;
					case 2:
					{
						int num5;
						if (osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
						{
							num = 1178548865;
							num5 = num;
						}
						else
						{
							num = 1178548876;
							num5 = num;
						}
						continue;
					}
					case 8:
						return;
					case 1:
					{
						int num4;
						if (num3 < osAcqhQGqUOKZMlJKgeajFWwmnz.QTcZLynCWHLLppDxcAAAPxKXLEc)
						{
							num = 1178548866;
							num4 = num;
						}
						else
						{
							num = 1178548867;
							num4 = num;
						}
						continue;
					}
					default:
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.StopVibration();
						return;
					}
					break;
				}
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_0010;
			}
			int num;
			int num2;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				num = 289531599;
				num2 = num;
			}
			else
			{
				num = 289531592;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = 289531595;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ 0x1141E6CC)
				{
				case 5:
					break;
				case 4:
					return 0f;
				case 0:
					switch (num3)
					{
					default:
						num = 289531597;
						continue;
					case 0:
						break;
					case 1:
						return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.RightMotor;
					}
					goto default;
				case 7:
					ReInput.CheckInitialized(_reInputId);
					num = 289531594;
					continue;
				case 6:
					return 0f;
				case 3:
					if (base.enabled)
					{
						if (!osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
						{
							return 0f;
						}
						num3 = (int)motor;
						num = 289531596;
					}
					else
					{
						num = 289531592;
					}
					continue;
				default:
					return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LeftMotor;
				case 1:
					throw new NotImplementedException();
				}
				break;
			}
			goto IL_0010;
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, false);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, false);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_0010;
			}
			goto IL_0107;
			IL_0010:
			int num = -1518119440;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1518119427)
				{
				case 0:
					break;
				default:
					return;
				case 11:
					switch (num2)
					{
					case 0:
						goto IL_008b;
					case 1:
						goto IL_00ec;
					}
					num = -1518119439;
					continue;
				case 2:
					motorLevel = MathTools.Clamp01(motorLevel);
					num = -1518119431;
					continue;
				case 1:
					goto IL_008b;
				case 8:
					uvdRZwKNKWMEiNFUBKZVMFXyWAY(motor, motorLevel, duration);
					num = -1518119430;
					continue;
				case 15:
					return;
				case 3:
					if (num3 >= osAcqhQGqUOKZMlJKgeajFWwmnz.QTcZLynCWHLLppDxcAAAPxKXLEc)
					{
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.StopVibration();
						num = -1518119425;
						continue;
					}
					goto case 6;
				case 5:
					goto IL_00ec;
				case 14:
					goto IL_0107;
				case 6:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[num3].Clear();
					num3++;
					num = -1518119426;
					continue;
				case 12:
					throw new NotImplementedException();
				case 10:
					if (!osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
					{
						return;
					}
					goto case 9;
				case 9:
					if (stopOtherMotors)
					{
						num3 = 0;
						num = -1518119426;
						continue;
					}
					goto case 2;
				case 4:
					num2 = (int)motor;
					num = -1518119434;
					continue;
				case 13:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 7:
					return;
					IL_00ec:
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.RightMotor = motorLevel;
					num = -1518119435;
					continue;
					IL_008b:
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LeftMotor = motorLevel;
					num = -1518119435;
					continue;
				}
				break;
			}
			goto IL_0010;
			IL_0107:
			if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				return;
			}
			int num4;
			if (base.enabled)
			{
				num = -1518119433;
				num4 = num;
			}
			else
			{
				num = -1518119438;
				num4 = num;
			}
			goto IL_0015;
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_003f;
			IL_000d:
			int num = -875184970;
			goto IL_0012;
			IL_0012:
			switch (num ^ -875184972)
			{
			case 5:
				break;
			case 4:
				return;
			case 3:
				goto IL_003f;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 1:
				if (!osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
				{
					return;
				}
				goto default;
			default:
				osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.RightMotor = MathTools.Clamp01(rightMotorLevel);
				uvdRZwKNKWMEiNFUBKZVMFXyWAY(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				uvdRZwKNKWMEiNFUBKZVMFXyWAY(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
				return;
			}
			goto IL_000d;
			IL_003f:
			if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				return;
			}
			int num2;
			if (!base.enabled)
			{
				num = -875184976;
				num2 = num;
			}
			else
			{
				num = -875184971;
				num2 = num;
			}
			goto IL_0012;
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				return default(Color);
			}
			return new Color(osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorR, osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorG, osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					num = 1286396430;
					num2 = num;
				}
				else
				{
					num = 1286396427;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4CACDA0B)
					{
					case 4:
						num = 1286396426;
						continue;
					default:
						return;
					case 1:
						break;
					case 5:
						return;
					case 0:
					{
						int num3;
						if (base.enabled)
						{
							num = 1286396424;
							num3 = num;
						}
						else
						{
							num = 1286396430;
							num3 = num;
						}
						continue;
					}
					case 3:
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorR = color.r * color.a;
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorG = color.g * color.a;
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorB = color.b * color.a;
						num = 1286396425;
						continue;
					case 2:
						return;
					}
					break;
				}
			}
		}

		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				SetLightColor(red, green, blue, 1f);
			}
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
				{
					num = -193001694;
					num2 = num;
				}
				else
				{
					num = -193001693;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -193001689)
					{
					case 3:
						num = -193001690;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorR = red * intensity;
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorG = green * intensity;
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightColorB = blue * intensity;
						num = -193001689;
						continue;
					case 5:
						return;
					case 4:
					{
						int num3;
						if (!base.enabled)
						{
							num = -193001694;
							num3 = num;
						}
						else
						{
							num = -193001691;
							num3 = num;
						}
						continue;
					}
					case 0:
						return;
					}
					break;
				}
			}
		}

		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = -758179288;
					num2 = num;
				}
				else
				{
					num = -758179286;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -758179285)
					{
					case 0:
						num = -758179287;
						continue;
					default:
						return;
					case 3:
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightFlashOnDuration = onDuration;
						num = -758179281;
						continue;
					case 1:
						return;
					case 4:
						osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LightFlashOffDuration = offDuration;
						num = -758179282;
						continue;
					case 2:
						break;
					case 5:
						return;
					}
					break;
				}
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_004b;
			IL_000d:
			int num = 19849395;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x12EE0B5)
				{
				case 3:
					break;
				case 5:
					return;
				case 1:
					return;
				case 0:
					goto IL_004b;
				case 6:
					ReInput.CheckInitialized(_reInputId);
					num = 19849396;
					continue;
				case 2:
					goto IL_0077;
				default:
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.StopLightFlash();
					return;
				}
				break;
				IL_0077:
				int num2;
				if (!base.enabled)
				{
					num = 19849392;
					num2 = num;
				}
				else
				{
					num = 19849393;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_004b:
			int num3;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				num = 19849399;
				num3 = num;
			}
			else
			{
				num = 19849392;
				num3 = num;
			}
			goto IL_0012;
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				int num2;
				if (base.enabled)
				{
					num = -631605198;
					num2 = num;
				}
				else
				{
					num = -631605195;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_007c;
			IL_0012:
			while (true)
			{
				switch (num ^ -631605194)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					num = -631605194;
					continue;
				case 0:
					return Vector3.zero;
				case 4:
					goto IL_006d;
				default:
					goto IL_007c;
				}
				break;
				IL_006d:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -631605195;
					continue;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.AccelerometerValueRaw;
			}
			goto IL_000d;
			IL_000d:
			num = -631605193;
			goto IL_0012;
			IL_007c:
			return Vector3.zero;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				int num2;
				if (!base.enabled)
				{
					num = -68199121;
					num2 = num;
				}
				else
				{
					num = -68199123;
					num2 = num;
				}
				goto IL_001e;
			}
			goto IL_0071;
			IL_001e:
			while (true)
			{
				switch (num ^ -68199123)
				{
				case 3:
					break;
				case 1:
					return Vector3.zero;
				case 0:
					goto IL_0062;
				default:
					goto IL_0071;
				}
				break;
				IL_0062:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -68199121;
					continue;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.AccelerometerValue;
			}
			goto IL_0019;
			IL_0019:
			num = -68199124;
			goto IL_001e;
			IL_0071:
			return Vector3.zero;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				int num2;
				if (!base.enabled)
				{
					num = 1067889256;
					num2 = num;
				}
				else
				{
					num = 1067889262;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_007c;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3FA6B26C)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					num = 1067889261;
					continue;
				case 1:
					return Vector3.zero;
				case 2:
					goto IL_006d;
				default:
					goto IL_007c;
				}
				break;
				IL_006d:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1067889256;
					continue;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LastGyroscopeValueRaw;
			}
			goto IL_000d;
			IL_000d:
			num = 1067889263;
			goto IL_0012;
			IL_007c:
			return Vector3.zero;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				num = 308043702;
				num2 = num;
			}
			else
			{
				num = 308043699;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 308043700;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x125C5FB7)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return Vector3.zero;
				case 1:
				{
					int num3;
					if (!base.enabled)
					{
						num = 308043699;
						num3 = num;
					}
					else
					{
						num = 308043701;
						num3 = num;
					}
					continue;
				}
				case 2:
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = 308043699;
						continue;
					}
					return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.LastGyroscopeValue;
				default:
					return Vector3.zero;
				}
				break;
			}
			goto IL_000d;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				while (true)
				{
					int num = 1944212640;
					while (true)
					{
						switch (num ^ 0x73E254A2)
						{
						case 0:
							break;
						case 2:
							goto IL_0045;
						default:
							goto end_IL_0027;
						}
						break;
						IL_0045:
						if (!base.enabled)
						{
							goto end_IL_0027;
						}
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 1944212643;
							continue;
						}
						return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GyroscopeValueRaw;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return Vector3.zero;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1494697570;
					goto IL_0012;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GyroscopeValue;
			}
			goto IL_005c;
			IL_005c:
			return Vector3.zero;
			IL_0012:
			switch (num ^ 0x59174660)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			default:
				goto IL_005c;
			}
			goto IL_000d;
			IL_000d:
			num = 1494697569;
			goto IL_0012;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				goto IL_002f;
			}
			goto IL_0060;
			IL_0034:
			int num;
			Quaternion result = default(Quaternion);
			while (true)
			{
				switch (num ^ -1068134386)
				{
				case 0:
					break;
				case 1:
					goto IL_0051;
				case 3:
					goto IL_0060;
				default:
					return result;
				}
				break;
				IL_0051:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1068134387;
					continue;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.Orientation;
			}
			goto IL_002f;
			IL_0060:
			result = default(Quaternion);
			num = -1068134388;
			goto IL_0034;
			IL_002f:
			num = -1068134385;
			goto IL_0034;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0037;
			IL_000d:
			int num = -1755739844;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1755739841)
				{
				case 0:
					break;
				case 5:
					goto IL_0037;
				case 1:
					return;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					num = -1755739842;
					continue;
				case 4:
					return;
				default:
					osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.ResetOrientation();
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0037:
			int num2;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				num = -1755739843;
				num2 = num;
			}
			else
			{
				num = -1755739845;
				num2 = num;
			}
			goto IL_0012;
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				while (true)
				{
					int num = 39784884;
					while (true)
					{
						switch (num ^ 0x25F11B6)
						{
						case 0:
							break;
						case 2:
							goto IL_0049;
						default:
							goto end_IL_002b;
						}
						break;
						IL_0049:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 39784887;
							continue;
						}
						return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchIdAtIndex(index);
					}
					continue;
					end_IL_002b:
					break;
				}
			}
			return -1;
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -988529529;
					goto IL_001e;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchPositionByIndex(index, out position);
			}
			goto IL_0067;
			IL_001e:
			switch (num ^ -988529529)
			{
			case 2:
				break;
			case 3:
				position = Vector2.zero;
				return false;
			case 0:
				goto IL_0067;
			default:
				return false;
			}
			goto IL_0019;
			IL_0067:
			position = Vector2.zero;
			num = -988529530;
			goto IL_001e;
			IL_0019:
			num = -988529532;
			goto IL_001e;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1250104199;
					goto IL_0012;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchPositionByTouchId(touchId, out position);
			}
			goto IL_006e;
			IL_006e:
			position = Vector2.zero;
			return false;
			IL_0012:
			while (true)
			{
				switch (num ^ -1250104199)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = -1250104200;
					continue;
				case 1:
					position = Vector2.zero;
					return false;
				default:
					goto IL_006e;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -1250104197;
			goto IL_0012;
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				goto IL_0024;
			}
			int num;
			bool touchPositionAbsoluteByIndex = default(bool);
			int positionX = default(int);
			int positionY = default(int);
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1454707585;
				}
				else
				{
					touchPositionAbsoluteByIndex = osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
					num = 1454707584;
				}
				goto IL_0029;
			}
			goto IL_0067;
			IL_0029:
			switch (num ^ 0x56B51380)
			{
			case 3:
				break;
			case 2:
				return false;
			case 1:
				goto IL_0067;
			default:
				position = new Vector2(positionX, positionY);
				return touchPositionAbsoluteByIndex;
			}
			goto IL_0024;
			IL_0067:
			position = Vector2.zero;
			return false;
			IL_0024:
			num = 1454707586;
			goto IL_0029;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1648252178;
					goto IL_0012;
				}
				int positionX;
				int positionY;
				bool touchPositionAbsoluteByTouchId = osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
				position = new Vector2(positionX, positionY);
				return touchPositionAbsoluteByTouchId;
			}
			goto IL_0063;
			IL_0063:
			position = Vector2.zero;
			return false;
			IL_0012:
			switch (num ^ -1648252177)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			default:
				goto IL_0063;
			}
			goto IL_000d;
			IL_000d:
			num = -1648252179;
			goto IL_0012;
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			int num;
			int num2;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				num = -274357883;
				num2 = num;
			}
			else
			{
				num = -274357882;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -274357885;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -274357881)
				{
				case 3:
					break;
				case 4:
					return false;
				case 2:
				{
					int num3;
					if (!base.enabled)
					{
						num = -274357882;
						num3 = num;
					}
					else
					{
						num = -274357881;
						num3 = num;
					}
					continue;
				}
				case 0:
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = -274357882;
						continue;
					}
					return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.IsTouchingAtIndex(index);
				default:
					return false;
				}
				break;
			}
			goto IL_0019;
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (AsIGpabQMBfkogwrlxBdKkoAAfgN && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 800919927;
					goto IL_0012;
				}
				return osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB.IsTouchingAtTouchId(touchId);
			}
			goto IL_0063;
			IL_0063:
			return false;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2FBD1177)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = 800919926;
					continue;
				case 1:
					return false;
				default:
					goto IL_0063;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 800919925;
			goto IL_0012;
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return GetGyroscopeValueRaw();
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				return;
			}
			if (!base.enabled)
			{
				while (true)
				{
					switch (0x655C65CD ^ 0x655C65CC)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			VJFYjFBUsXRKMAFoSRHQlMiHIYB();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			osAcqhQGqUOKZMlJKgeajFWwmnz = P_0 as xOPDMxWDKwUvhaMcKGCGBWDhIrpJ;
			AsIGpabQMBfkogwrlxBdKkoAAfgN = osAcqhQGqUOKZMlJKgeajFWwmnz != null && osAcqhQGqUOKZMlJKgeajFWwmnz.WYZhcjTnddfwsuXVuPbKNLuuJgB != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void VJFYjFBUsXRKMAFoSRHQlMiHIYB()
		{
			if (!AsIGpabQMBfkogwrlxBdKkoAAfgN)
			{
				return;
			}
			while (osAcqhQGqUOKZMlJKgeajFWwmnz.JgidXSSSAGvvkDcAIVICtlmgnKR)
			{
				while (true)
				{
					int num = 0;
					int num2 = -1148274995;
					while (true)
					{
						switch (num2 ^ -1148274993)
						{
						case 6:
							num2 = -1148274994;
							continue;
						default:
							return;
						case 2:
							break;
						case 5:
							goto end_IL_000e;
						case 0:
							if (EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Update())
							{
								SetVibration(num, 0f, false);
								num2 = -1148274997;
								continue;
							}
							goto case 4;
						case 1:
							goto end_IL_0056;
						case 4:
							num++;
							num2 = -1148274995;
							continue;
						case 3:
							return;
						}
						int num3;
						if (num < osAcqhQGqUOKZMlJKgeajFWwmnz.QTcZLynCWHLLppDxcAAAPxKXLEc)
						{
							num2 = -1148274993;
							num3 = num2;
						}
						else
						{
							num2 = -1148274996;
							num3 = num2;
						}
						continue;
						end_IL_000e:
						break;
					}
					continue;
					end_IL_0056:
					break;
				}
			}
		}

		private void uvdRZwKNKWMEiNFUBKZVMFXyWAY(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2;
			switch (P_0)
			{
			case DualShock4MotorType.LeftMotor:
				num = 0;
				num2 = 1749486177;
				goto IL_0017;
			case DualShock4MotorType.RightMotor:
				goto IL_00b6;
				IL_0017:
				while (true)
				{
					switch (num2 ^ 0x68470A67)
					{
					case 4:
						num2 = 1749486191;
						continue;
					default:
						return;
					case 1:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Start(P_2);
						num2 = 1749486176;
						continue;
					case 0:
						if (!(P_1 <= 0f))
						{
							goto IL_0065;
						}
						goto case 2;
					case 8:
						break;
					case 6:
						num2 = 1749486183;
						continue;
					case 3:
						goto end_IL_0003;
					case 2:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Clear();
						return;
					case 5:
						goto IL_00b6;
					case 7:
						return;
					}
					break;
					IL_0065:
					int num3;
					if (P_2 <= 0f)
					{
						num2 = 1749486181;
						num3 = num2;
					}
					else
					{
						num2 = 1749486182;
						num3 = num2;
					}
				}
				goto case DualShock4MotorType.LeftMotor;
				IL_00b6:
				num = 1;
				num2 = 1749486183;
				goto IL_0017;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
