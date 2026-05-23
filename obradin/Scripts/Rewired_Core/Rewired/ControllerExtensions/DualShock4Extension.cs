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
		private class KrXnTiadYcUSOCDdyHYMgnVlgaq : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 rLHrbkzJrdcRLAiOSFvKCmkcJdEM;

			public readonly bool wweKDPecOEKQRjeLwREKUOeenHA;

			public readonly int dFeMnzRTSNcMYNGuAWZUeFGTLNj;

			public KrXnTiadYcUSOCDdyHYMgnVlgaq(IDriver_DualShock4 driver, bool supportsVibration, int vibrationMotorCount)
			{
				rLHrbkzJrdcRLAiOSFvKCmkcJdEM = driver;
				wweKDPecOEKQRjeLwREKUOeenHA = supportsVibration;
				dFeMnzRTSNcMYNGuAWZUeFGTLNj = vibrationMotorCount;
			}
		}

		private KrXnTiadYcUSOCDdyHYMgnVlgaq PESlCqcuFEdCgwfIyyIoKbUwani;

		private bool jTKQutBMGFjJXeKoLKVbSPcEzifU;

		private TimerAbs[] pSngNFXjFJqIDusOVrrEyDkmFgW;

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
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					return 0;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.dFeMnzRTSNcMYNGuAWZUeFGTLNj;
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
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					if (!base.enabled)
					{
						num = 1106225780;
						goto IL_001e;
					}
					return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorR;
				}
				goto IL_0054;
				IL_001e:
				switch (num ^ 0x41EFAA75)
				{
				case 0:
					break;
				case 2:
					return 0f;
				default:
					goto IL_0054;
				}
				goto IL_0019;
				IL_0019:
				num = 1106225783;
				goto IL_001e;
				IL_0054:
				return 0f;
			}
			set
			{
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorR = value;
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
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU || !base.enabled)
				{
					return 0f;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorG;
			}
			set
			{
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorG = value;
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
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					num = 173415443;
					num2 = num;
				}
				else
				{
					num = 173415440;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = 173415442;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ 0xA561C11)
					{
					case 0:
						break;
					case 3:
						return 0f;
					case 2:
						if (!base.enabled)
						{
							goto IL_0062;
						}
						return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorB;
					default:
						return 0f;
					}
					break;
					IL_0062:
					num = 173415440;
				}
				goto IL_0019;
			}
			set
			{
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorB = value;
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
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					return 0;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.MaxTouches;
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
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchCount();
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
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					return 0f;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 driver)
			: base(new KrXnTiadYcUSOCDdyHYMgnVlgaq(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(pSngNFXjFJqIDusOVrrEyDkmFgW, 0, pSngNFXjFJqIDusOVrrEyDkmFgW.Length);
		}

		private DualShock4Extension(DualShock4Extension source)
			: base(source)
		{
			try
			{
				pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[0];
			}
			ArrayTools.Populate(pSngNFXjFJqIDusOVrrEyDkmFgW, 0, pSngNFXjFJqIDusOVrrEyDkmFgW.Length);
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
				goto IL_000d;
			}
			goto IL_006e;
			IL_000d:
			int num = -844633198;
			goto IL_0012;
			IL_0012:
			DualShock4MotorType motor = default(DualShock4MotorType);
			while (true)
			{
				switch (num ^ -844633190)
				{
				case 0:
					break;
				case 8:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					return;
				case 7:
					goto IL_006e;
				case 5:
					motor = DualShock4MotorType.RightMotor;
					num = -844633188;
					continue;
				case 1:
					goto IL_009b;
				case 9:
					switch (motorIndex)
					{
					case 1:
						break;
					case 0:
						goto IL_009b;
					default:
						goto IL_00b7;
					}
					goto case 5;
				case 10:
					return;
				case 4:
					goto IL_00cc;
				case 3:
					throw new NotImplementedException();
				case 11:
					goto IL_00f4;
				default:
					{
						SetVibration(motor, motorLevel, duration, stopOtherMotors);
						return;
					}
					IL_00b7:
					num = -844633191;
					continue;
					IL_009b:
					motor = DualShock4MotorType.LeftMotor;
					num = -844633188;
					continue;
				}
				break;
				IL_00f4:
				int num2;
				if (motorIndex >= PESlCqcuFEdCgwfIyyIoKbUwani.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
				{
					num = -844633192;
					num2 = num;
				}
				else
				{
					num = -844633197;
					num2 = num;
				}
				continue;
				IL_00cc:
				int num3;
				if (motorIndex < 0)
				{
					num = -844633192;
					num3 = num;
				}
				else
				{
					num = -844633199;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_006e:
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num4;
				if (!base.enabled)
				{
					num = -844633200;
					num4 = num;
				}
				else
				{
					num = -844633186;
					num4 = num;
				}
				goto IL_0012;
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			int num = default(int);
			int num2;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				if (!base.enabled)
				{
					goto IL_002f;
				}
				if (PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
				{
					num = motorIndex;
					num2 = -1102796770;
				}
				else
				{
					num2 = -1102796773;
				}
				goto IL_0034;
			}
			goto IL_007b;
			IL_0034:
			switch (num2 ^ -1102796769)
			{
			case 2:
				break;
			case 1:
				goto IL_0055;
			case 4:
				return 0f;
			case 3:
				goto IL_007b;
			default:
				goto IL_0095;
			}
			goto IL_002f;
			IL_0055:
			switch (num)
			{
			case 0:
				break;
			case 1:
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.RightMotor;
			default:
				return 0f;
			}
			goto IL_0095;
			IL_0095:
			return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LeftMotor;
			IL_007b:
			return 0f;
			IL_002f:
			num2 = -1102796772;
			goto IL_0034;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			goto IL_0076;
			IL_0076:
			int num;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num2;
				if (base.enabled)
				{
					num = -1208519869;
					num2 = num;
				}
				else
				{
					num = -1208519861;
					num2 = num;
				}
				goto IL_001e;
			}
			return;
			IL_0019:
			num = -1208519864;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1208519862)
				{
				case 6:
					break;
				case 9:
					if (!PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
					{
						return;
					}
					goto case 4;
				case 5:
					num3++;
					num = -1208519862;
					continue;
				case 3:
					goto IL_0076;
				case 4:
					num3 = 0;
					num = -1208519862;
					continue;
				case 8:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num3].Clear();
					num = -1208519857;
					continue;
				case 0:
					goto IL_00ba;
				case 1:
					return;
				case 2:
					return;
				default:
					PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.StopVibration();
					return;
				}
				break;
				IL_00ba:
				int num4;
				if (num3 < PESlCqcuFEdCgwfIyyIoKbUwani.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
				{
					num = -1208519870;
					num4 = num;
				}
				else
				{
					num = -1208519859;
					num4 = num;
				}
			}
			goto IL_0019;
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				num = 882168034;
				num2 = num;
			}
			else
			{
				num = 882168033;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 882168037;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3494D0E0)
				{
				case 0:
					break;
				case 5:
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				case 1:
					return 0f;
				case 2:
					if (base.enabled)
					{
						if (!PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
						{
							return 0f;
						}
						switch ((int)motor)
						{
						default:
							num = 882168036;
							continue;
						case 0:
							break;
						case 1:
							return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.RightMotor;
						}
						goto default;
					}
					num = 882168033;
					continue;
				default:
					return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LeftMotor;
				case 4:
					throw new NotImplementedException();
				}
				break;
			}
			goto IL_000d;
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
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num3 = default(int);
			while (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = -915660324;
					num2 = num;
				}
				else
				{
					num = -915660325;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -915660325)
					{
					case 2:
						num = -915660331;
						continue;
					case 5:
						num = -915660341;
						continue;
					case 8:
						num = -915660330;
						continue;
					case 9:
						pSngNFXjFJqIDusOVrrEyDkmFgW[num3].Clear();
						num = -915660329;
						continue;
					case 7:
					{
						int num4;
						if (PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
						{
							num = -915660323;
							num4 = num;
						}
						else
						{
							num = -915660332;
							num4 = num;
						}
						continue;
					}
					case 6:
						if (stopOtherMotors)
						{
							num3 = 0;
							num = -915660333;
							continue;
						}
						goto case 4;
					case 4:
						motorLevel = MathTools.Clamp01(motorLevel);
						switch ((int)motor)
						{
						case 1:
							goto IL_00fb;
						case 0:
							goto IL_015a;
						}
						num = -915660322;
						continue;
					case 12:
						num3++;
						num = -915660330;
						continue;
					case 11:
						goto IL_00fb;
					case 14:
						break;
					case 0:
						return;
					case 10:
						num = -915660328;
						continue;
					case 15:
						return;
					case 1:
						goto IL_015a;
					case 13:
						if (num3 >= PESlCqcuFEdCgwfIyyIoKbUwani.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
						{
							PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.StopVibration();
							num = -915660321;
							continue;
						}
						goto case 9;
					case 16:
						throw new NotImplementedException();
					default:
						{
							PkvIixiBJQgzJxQXdAWDrKLgpHX(motor, motorLevel, duration);
							return;
						}
						IL_015a:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LeftMotor = motorLevel;
						num = -915660335;
						continue;
						IL_00fb:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.RightMotor = motorLevel;
						num = -915660328;
						continue;
					}
					break;
				}
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = 1194647242;
					num2 = num;
				}
				else
				{
					num = 1194647240;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4734DECB)
					{
					case 4:
						num = 1194647246;
						continue;
					case 5:
						break;
					case 3:
						return;
					case 1:
						if (!PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
						{
							return;
						}
						goto case 0;
					case 0:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LeftMotor = MathTools.Clamp01(leftMotorLevel);
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.RightMotor = MathTools.Clamp01(rightMotorLevel);
						PkvIixiBJQgzJxQXdAWDrKLgpHX(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
						num = 1194647241;
						continue;
					default:
						PkvIixiBJQgzJxQXdAWDrKLgpHX(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
						return;
					}
					break;
				}
			}
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				num = -1000383123;
				goto IL_0012;
			}
			return new Color(PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorR, PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorG, PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorB, 1f);
			IL_000d:
			num = -1000383121;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1000383122)
				{
				case 0:
					break;
				case 1:
					goto IL_002f;
				case 2:
					return default(Color);
				default:
					return default(Color);
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(_reInputId);
				num = -1000383124;
			}
			goto IL_000d;
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
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					num = 2030746313;
					num2 = num;
				}
				else
				{
					num = 2030746317;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x790ABACD)
					{
					case 2:
						num = 2030746316;
						continue;
					case 1:
						break;
					case 4:
						return;
					case 0:
					{
						int num3;
						if (base.enabled)
						{
							num = 2030746318;
							num3 = num;
						}
						else
						{
							num = 2030746313;
							num3 = num;
						}
						continue;
					}
					default:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorR = color.r * color.a;
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorG = color.g * color.a;
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorB = color.b * color.a;
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
				while (true)
				{
					switch (-1605462436 ^ -1605462435)
					{
					case 0:
						continue;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			SetLightColor(red, green, blue, 1f);
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = -822352400;
					num2 = num;
				}
				else
				{
					num = -822352393;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -822352397)
					{
					case 2:
						num = -822352398;
						continue;
					case 3:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorR = red * intensity;
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorG = green * intensity;
						num = -822352397;
						continue;
					case 4:
						return;
					case 1:
						break;
					default:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightColorB = blue * intensity;
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
			while (true)
			{
				int num;
				int num2;
				if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					num = -507365048;
					num2 = num;
				}
				else
				{
					num = -507365044;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -507365047)
					{
					case 4:
						num = -507365045;
						continue;
					default:
						return;
					case 2:
						break;
					case 1:
					{
						int num3;
						if (base.enabled)
						{
							num = -507365046;
							num3 = num;
						}
						else
						{
							num = -507365044;
							num3 = num;
						}
						continue;
					}
					case 3:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightFlashOnDuration = onDuration;
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LightFlashOffDuration = offDuration;
						num = -507365047;
						continue;
					case 5:
						return;
					case 0:
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
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
				{
					num = -1811444937;
					num2 = num;
				}
				else
				{
					num = -1811444941;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1811444941)
					{
					case 3:
						num = -1811444942;
						continue;
					case 1:
						break;
					case 0:
					{
						int num3;
						if (!base.enabled)
						{
							num = -1811444937;
							num3 = num;
						}
						else
						{
							num = -1811444943;
							num3 = num;
						}
						continue;
					}
					case 4:
						return;
					default:
						PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.StopLightFlash();
						return;
					}
					break;
				}
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				while (true)
				{
					int num = -1925432225;
					while (true)
					{
						switch (num ^ -1925432226)
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
							goto end_IL_0027;
						}
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = -1925432226;
							continue;
						}
						return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.AccelerometerValueRaw;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
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
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				int num2;
				if (!base.enabled)
				{
					num = 2022700303;
					num2 = num;
				}
				else
				{
					num = 2022700300;
					num2 = num;
				}
				goto IL_001e;
			}
			goto IL_0071;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x788FF50D)
				{
				case 0:
					break;
				case 3:
					return Vector3.zero;
				case 1:
					goto IL_0062;
				default:
					goto IL_0071;
				}
				break;
				IL_0062:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 2022700303;
					continue;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.AccelerometerValue;
			}
			goto IL_0019;
			IL_0019:
			num = 2022700302;
			goto IL_001e;
			IL_0071:
			return Vector3.zero;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				while (true)
				{
					int num = -2017924602;
					while (true)
					{
						switch (num ^ -2017924604)
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
							num = -2017924603;
							continue;
						}
						return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.LastGyroscopeValue;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return Vector3.zero;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				num = -1730128319;
				num2 = num;
			}
			else
			{
				num = -1730128316;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -1730128314;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1730128315)
				{
				case 0:
					break;
				case 2:
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = -1730128319;
						continue;
					}
					return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GyroscopeValueRaw;
				case 1:
				{
					int num3;
					if (base.enabled)
					{
						num = -1730128313;
						num3 = num;
					}
					else
					{
						num = -1730128319;
						num3 = num;
					}
					continue;
				}
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return Vector3.zero;
				default:
					return Vector3.zero;
				}
				break;
			}
			goto IL_000d;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1374011598;
					goto IL_0012;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.Orientation;
			}
			goto IL_005c;
			IL_005c:
			return default(Quaternion);
			IL_0012:
			switch (num ^ -1374011597)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			default:
				goto IL_005c;
			}
			goto IL_000d;
			IL_000d:
			num = -1374011599;
			goto IL_0012;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0047;
			IL_000d:
			int num = -753097119;
			goto IL_0012;
			IL_0012:
			switch (num ^ -753097117)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 1:
				goto IL_0047;
			case 3:
				goto IL_0057;
			case 4:
				return;
			}
			goto IL_000d;
			IL_0047:
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				return;
			}
			goto IL_0057;
			IL_0057:
			PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.ResetOrientation();
			num = -753097113;
			goto IL_0012;
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1846420188;
					goto IL_0012;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchIdAtIndex(index);
			}
			goto IL_0058;
			IL_0058:
			return -1;
			IL_0012:
			switch (num ^ 0x6E0E22DD)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return -1;
			default:
				goto IL_0058;
			}
			goto IL_000d;
			IL_000d:
			num = 1846420191;
			goto IL_0012;
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 660962763;
					goto IL_0012;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchPositionByIndex(index, out position);
			}
			goto IL_0063;
			IL_0063:
			position = Vector2.zero;
			return false;
			IL_0012:
			switch (num ^ 0x27657DCA)
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
			num = 660962760;
			goto IL_0012;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1820826464;
					goto IL_0012;
				}
				return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchPositionByTouchId(touchId, out position);
			}
			goto IL_0067;
			IL_0067:
			position = Vector2.zero;
			num = -1820826461;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1820826464)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			case 0:
				goto IL_0067;
			default:
				return false;
			}
			goto IL_000d;
			IL_000d:
			num = -1820826463;
			goto IL_0012;
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
			position = new Vector2(positionX, positionY);
			return touchPositionAbsoluteByIndex;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				bool touchPositionAbsoluteByTouchId = default(bool);
				while (true)
				{
					int num = 537157715;
					while (true)
					{
						switch (num ^ 0x20046051)
						{
						case 0:
							break;
						case 2:
							goto IL_0050;
						case 1:
							goto end_IL_002e;
						default:
							return touchPositionAbsoluteByTouchId;
						}
						break;
						IL_0050:
						if (!base.enabled)
						{
							goto end_IL_002e;
						}
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 537157712;
							continue;
						}
						int positionX;
						int positionY;
						touchPositionAbsoluteByTouchId = PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
						position = new Vector2(positionX, positionY);
						num = 537157714;
					}
					continue;
					end_IL_002e:
					break;
				}
			}
			position = Vector2.zero;
			return false;
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				while (true)
				{
					int num = 1221255926;
					while (true)
					{
						switch (num ^ 0x48CAE2F7)
						{
						case 0:
							break;
						case 1:
							goto IL_0041;
						default:
							goto end_IL_0023;
						}
						break;
						IL_0041:
						if (!base.enabled)
						{
							goto end_IL_0023;
						}
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 1221255925;
							continue;
						}
						return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.IsTouchingAtIndex(index);
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return false;
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM.IsTouchingAtTouchId(touchId);
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
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				return;
			}
			if (!base.enabled)
			{
				while (true)
				{
					switch (0x7FEAB18B ^ 0x7FEAB18A)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			qxBgmSGduLZblrclmRJKaMoDcVOA();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
			PESlCqcuFEdCgwfIyyIoKbUwani = P_0 as KrXnTiadYcUSOCDdyHYMgnVlgaq;
			jTKQutBMGFjJXeKoLKVbSPcEzifU = PESlCqcuFEdCgwfIyyIoKbUwani != null && PESlCqcuFEdCgwfIyyIoKbUwani.rLHrbkzJrdcRLAiOSFvKCmkcJdEM != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void qxBgmSGduLZblrclmRJKaMoDcVOA()
		{
			if (!jTKQutBMGFjJXeKoLKVbSPcEzifU)
			{
				return;
			}
			while (PESlCqcuFEdCgwfIyyIoKbUwani.wweKDPecOEKQRjeLwREKUOeenHA)
			{
				while (true)
				{
					IL_0076:
					int num = 0;
					int num2 = -646555593;
					while (true)
					{
						switch (num2 ^ -646555593)
						{
						case 2:
							num2 = -646555594;
							continue;
						case 3:
							if (pSngNFXjFJqIDusOVrrEyDkmFgW[num].Update())
							{
								SetVibration(num, 0f, false);
								num2 = -646555597;
								continue;
							}
							goto case 4;
						case 4:
							num++;
							num2 = -646555593;
							continue;
						case 1:
							break;
						case 5:
							goto IL_0076;
						default:
							if (num >= PESlCqcuFEdCgwfIyyIoKbUwani.dFeMnzRTSNcMYNGuAWZUeFGTLNj)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
					break;
				}
			}
		}

		private void PkvIixiBJQgzJxQXdAWDrKLgpHX(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2;
			switch (P_0)
			{
			case DualShock4MotorType.LeftMotor:
				num = 0;
				num2 = 1303990994;
				goto IL_001a;
			case DualShock4MotorType.RightMotor:
				goto IL_00d1;
				IL_001a:
				while (true)
				{
					switch (num2 ^ 0x4DB952D5)
					{
					case 5:
						num2 = 1303991004;
						continue;
					default:
						return;
					case 9:
						break;
					case 3:
						if (!(P_1 <= 0f))
						{
							goto IL_0067;
						}
						goto case 6;
					case 10:
						return;
					case 1:
						pSngNFXjFJqIDusOVrrEyDkmFgW[num].Start(P_2);
						num2 = 1303990997;
						continue;
					case 7:
						num2 = 1303990998;
						continue;
					case 8:
						goto end_IL_0003;
					case 6:
						pSngNFXjFJqIDusOVrrEyDkmFgW[num].Clear();
						num2 = 1303991007;
						continue;
					case 2:
						goto IL_00d1;
					case 4:
						num2 = 1303990998;
						continue;
					case 0:
						return;
					}
					break;
					IL_0067:
					int num3;
					if (P_2 > 0f)
					{
						num2 = 1303990996;
						num3 = num2;
					}
					else
					{
						num2 = 1303990995;
						num3 = num2;
					}
				}
				goto case DualShock4MotorType.LeftMotor;
				IL_00d1:
				num = 1;
				num2 = 1303990993;
				goto IL_001a;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
