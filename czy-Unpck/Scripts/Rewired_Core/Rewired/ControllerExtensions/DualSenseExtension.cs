using System;
using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension
	{
		private class WRvebREDcxItMcxFseMdInwAvglC : IControllerExtensionSource
		{
			public readonly IDriver_DualSense vULJPazKWrfClTuqhWeDZYCbvZw;

			public readonly bool gkkruTywtCSgfaMjHfnJvKIxFVy;

			public readonly int hSqMknHvfLaCaSKUtNrDJWiYQVX;

			public WRvebREDcxItMcxFseMdInwAvglC(IDriver_DualSense driver, bool supportsVibration, int vibrationMotorCount)
			{
				while (true)
				{
					int num = 239706761;
					while (true)
					{
						switch (num ^ 0xE49A288)
						{
						case 3:
							break;
						default:
							return;
						case 1:
							vULJPazKWrfClTuqhWeDZYCbvZw = driver;
							gkkruTywtCSgfaMjHfnJvKIxFVy = supportsVibration;
							num = 239706762;
							continue;
						case 2:
							hSqMknHvfLaCaSKUtNrDJWiYQVX = vibrationMotorCount;
							num = 239706760;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		private WRvebREDcxItMcxFseMdInwAvglC FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

		private bool ltUCirDrbTngxJGUkcmqmAQBhwLE;

		private TimerAbs[] zmxGOJkPYLhUdcrIkgYFpHzgdPkg;

		private Joystick joystick => GetController<Joystick>();

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					return 0;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX;
			}
		}

		public float lightColorRed
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = -1794662043;
						goto IL_0012;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR;
				}
				goto IL_0054;
				IL_0012:
				switch (num ^ -1794662044)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				default:
					goto IL_0054;
				}
				goto IL_000d;
				IL_000d:
				num = -1794662042;
				goto IL_0012;
				IL_0054:
				return 0f;
			}
			set
			{
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					return;
				}
				while (true)
				{
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = value;
					int num = 887529498;
					while (true)
					{
						switch (num ^ 0x34E6A01B)
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
						num = 887529497;
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
					goto IL_0019;
				}
				int num;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = -575323310;
						goto IL_001e;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG;
				}
				goto IL_0054;
				IL_001e:
				switch (num ^ -575323310)
				{
				case 2:
					break;
				case 1:
					return 0f;
				default:
					goto IL_0054;
				}
				goto IL_0019;
				IL_0019:
				num = -575323309;
				goto IL_001e;
				IL_0054:
				return 0f;
			}
			set
			{
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG = value;
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
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = -873328015;
						goto IL_001e;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB;
				}
				goto IL_0054;
				IL_001e:
				switch (num ^ -873328016)
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
				num = -873328014;
				goto IL_001e;
				IL_0054:
				return 0f;
			}
			set
			{
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB = value;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = 423791378;
						goto IL_0012;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.microphoneLightMode;
				}
				goto IL_005b;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x19428B13)
					{
					case 0:
						break;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						num = 423791376;
						continue;
					case 3:
						return DualSenseMicrophoneLightMode.Off;
					default:
						goto IL_005b;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num = 423791377;
				goto IL_0012;
				IL_005b:
				return DualSenseMicrophoneLightMode.Off;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				goto IL_0047;
				IL_000d:
				int num = 1741663261;
				goto IL_0012;
				IL_0012:
				switch (num ^ 0x67CFAC19)
				{
				case 3:
					break;
				case 4:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 1:
					goto IL_0047;
				case 0:
					return;
				default:
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.microphoneLightMode = value;
					return;
				}
				goto IL_000d;
				IL_0047:
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					int num2;
					if (!base.enabled)
					{
						num = 1741663257;
						num2 = num;
					}
					else
					{
						num = 1741663259;
						num2 = num;
					}
					goto IL_0012;
				}
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				int num2;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = -1088548854;
					num2 = num;
				}
				else
				{
					num = -1088548856;
					num2 = num;
				}
				goto IL_0012;
				IL_000d:
				num = -1088548853;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ -1088548854)
					{
					case 3:
						break;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return DualSenseOtherLightBrightness.High;
					case 0:
						if (!base.enabled)
						{
							goto IL_005e;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.otherLightBrightness;
					default:
						return DualSenseOtherLightBrightness.High;
					}
					break;
					IL_005e:
					num = -1088548856;
				}
				goto IL_000d;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					goto IL_0019;
				}
				goto IL_006f;
				IL_006f:
				int num;
				int num2;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = 445664360;
					num2 = num;
				}
				else
				{
					num = 445664362;
					num2 = num;
				}
				goto IL_001e;
				IL_0019:
				num = 445664363;
				goto IL_001e;
				IL_001e:
				while (true)
				{
					switch (num ^ 0x1A904C6E)
					{
					case 0:
						break;
					default:
						return;
					case 5:
						return;
					case 1:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.otherLightBrightness = value;
						num = 445664365;
						continue;
					case 4:
						return;
					case 2:
						goto IL_006f;
					case 6:
						goto IL_0088;
					case 3:
						return;
					}
					break;
					IL_0088:
					int num3;
					if (!base.enabled)
					{
						num = 445664362;
						num3 = num;
					}
					else
					{
						num = 445664367;
						num3 = num;
					}
				}
				goto IL_0019;
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSensePlayerLightFlags.None;
				}
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				goto IL_006c;
				IL_000d:
				int num = 1948025499;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x741C829E)
					{
					case 2:
						break;
					case 4:
						goto IL_0037;
					case 1:
						return;
					case 5:
						ReInput.CheckInitialized(_reInputId);
						return;
					case 0:
						goto IL_006c;
					default:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.playerLights = value;
						return;
					}
					break;
					IL_0037:
					int num2;
					if (base.enabled)
					{
						num = 1948025501;
						num2 = num;
					}
					else
					{
						num = 1948025503;
						num2 = num;
					}
				}
				goto IL_000d;
				IL_006c:
				int num3;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = 1948025498;
					num3 = num;
				}
				else
				{
					num = 1948025503;
					num3 = num;
				}
				goto IL_0012;
			}
		}

		public int maxTouches
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					goto IL_000d;
				}
				int num;
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = 1638547110;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.MaxTouches;
				IL_000d:
				num = 1638547109;
				goto IL_0012;
				IL_0012:
				while (true)
				{
					switch (num ^ 0x61AA3EA4)
					{
					case 0:
						break;
					case 1:
						goto IL_002f;
					case 3:
						return 0;
					default:
						return 0;
					}
					break;
					IL_002f:
					ReInput.CheckInitialized(_reInputId);
					num = 1638547111;
				}
				goto IL_000d;
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
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchCount();
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
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					return 0f;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.BatteryLevel;
			}
		}

		public bool batteryCharging
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					return false;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.BatteryCharging;
			}
		}

		internal DualSenseExtension(IDriver_DualSense driver)
			: base(new WRvebREDcxItMcxFseMdInwAvglC(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		private DualSenseExtension(DualSenseExtension source)
			: base(source)
		{
			try
			{
				zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[0];
			}
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
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
			while (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = 1369911243;
					num2 = num;
				}
				else
				{
					num = 1369911232;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x51A72FC8)
					{
					case 2:
						num = 1369911244;
						continue;
					case 4:
						break;
					case 3:
						return;
					case 0:
						switch (motorIndex)
						{
						case 0:
							goto IL_00d8;
						case 1:
							goto IL_00e4;
						}
						num = 1369911245;
						continue;
					case 5:
						throw new NotImplementedException();
					case 6:
						return;
					case 8:
					{
						if (motorIndex < 0)
						{
							return;
						}
						int num3;
						if (motorIndex >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
						{
							num = 1369911246;
							num3 = num;
						}
						else
						{
							num = 1369911240;
							num3 = num;
						}
						continue;
					}
					case 7:
						goto IL_00d8;
					case 9:
						goto IL_00e4;
					default:
						{
							SetVibration(motor, motorLevel, duration, stopOtherMotors);
							return;
						}
						IL_00e4:
						motor = DualShock4MotorType.RightMotor;
						num = 1369911241;
						continue;
						IL_00d8:
						motor = DualShock4MotorType.LeftMotor;
						num = 1369911241;
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
				goto IL_000d;
			}
			int num;
			int num2;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 2009336692;
				num2 = num;
			}
			else
			{
				num = 2009336690;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 2009336688;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x77C40B71)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				case 5:
					return 0f;
				case 3:
					if (base.enabled)
					{
						if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
						{
							return 0f;
						}
						switch (motorIndex)
						{
						default:
							num = 2009336693;
							continue;
						case 0:
							break;
						case 1:
							return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor;
						}
						goto default;
					}
					num = 2009336692;
					continue;
				default:
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor;
				case 4:
					return 0f;
				}
				break;
			}
			goto IL_000d;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			goto IL_0074;
			IL_0074:
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num2;
				if (base.enabled)
				{
					num = -756512477;
					num2 = num;
				}
				else
				{
					num = -756512469;
					num2 = num;
				}
				goto IL_001e;
			}
			return;
			IL_0019:
			num = -756512470;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -756512469)
				{
				case 2:
					break;
				case 3:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num3].Clear();
					num = -756512468;
					continue;
				case 4:
					num3 = 0;
					num = -756512466;
					continue;
				case 1:
					return;
				case 6:
					goto IL_0074;
				case 7:
					num3++;
					num = -756512466;
					continue;
				case 0:
					return;
				case 8:
					if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
					{
						return;
					}
					goto case 4;
				default:
					if (num3 >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
					{
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.StopVibration();
						return;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0019;
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				if (base.enabled)
				{
					if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
					{
						return 0f;
					}
					switch ((int)motor)
					{
					case 0:
						break;
					case 1:
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor;
					default:
						throw new NotImplementedException();
					}
					goto IL_0081;
				}
				while (true)
				{
					switch (0x4099D22A ^ 0x4099D22B)
					{
					case 2:
						break;
					case 1:
						goto end_IL_002f;
					default:
						goto IL_0081;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return 0f;
			IL_0081:
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor;
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
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
			goto IL_00d3;
			IL_0010:
			int num = 1023238781;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x3CFD6276)
				{
				case 4:
					break;
				case 3:
					return;
				case 13:
					throw new NotImplementedException();
				case 16:
					num = 1023238779;
					continue;
				case 1:
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor = motorLevel;
					num = 1023238776;
					continue;
				case 2:
					num = 1023238776;
					continue;
				case 15:
					goto IL_00aa;
				case 6:
					num2++;
					num = 1023238783;
					continue;
				case 7:
					goto IL_00d3;
				case 9:
					if (num2 >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
					{
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.StopVibration();
						num = 1023238771;
						continue;
					}
					goto case 8;
				case 12:
					if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
					{
						return;
					}
					goto case 10;
				case 11:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 5:
					motorLevel = MathTools.Clamp01(motorLevel);
					switch ((int)motor)
					{
					case 0:
						break;
					case 1:
						goto IL_00aa;
					default:
						goto IL_0163;
					}
					goto case 1;
				case 10:
					if (stopOtherMotors)
					{
						num2 = 0;
						num = 1023238783;
						continue;
					}
					goto case 5;
				case 0:
					goto IL_017d;
				case 8:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num2].Clear();
					num = 1023238768;
					continue;
				default:
					{
						TzfDwdqMmCsJvyIzIMpUAOlpgRjg(motor, motorLevel, duration);
						return;
					}
					IL_0163:
					num = 1023238758;
					continue;
					IL_00aa:
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor = motorLevel;
					num = 1023238772;
					continue;
				}
				break;
				IL_017d:
				int num3;
				if (!base.enabled)
				{
					num = 1023238773;
					num3 = num;
				}
				else
				{
					num = 1023238778;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_00d3:
			int num4;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 1023238773;
				num4 = num;
			}
			else
			{
				num = 1023238774;
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
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				int num;
				int num2;
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = -2069339120;
					num2 = num;
				}
				else
				{
					num = -2069339116;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2069339115)
					{
					case 6:
						num = -2069339113;
						continue;
					case 4:
						return;
					case 3:
					{
						int num4;
						if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
						{
							num = -2069339119;
							num4 = num;
						}
						else
						{
							num = -2069339118;
							num4 = num;
						}
						continue;
					}
					case 7:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor = MathTools.Clamp01(leftMotorLevel);
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor = MathTools.Clamp01(rightMotorLevel);
						num = -2069339115;
						continue;
					case 1:
					{
						int num3;
						if (base.enabled)
						{
							num = -2069339114;
							num3 = num;
						}
						else
						{
							num = -2069339120;
							num3 = num;
						}
						continue;
					}
					case 2:
						break;
					case 5:
						return;
					default:
						TzfDwdqMmCsJvyIzIMpUAOlpgRjg(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
						TzfDwdqMmCsJvyIzIMpUAOlpgRjg(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return default(Color);
			}
			return new Color(FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR, FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG, FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = 1793741288;
					num2 = num;
				}
				else
				{
					num = 1793741291;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x6AEA51EB)
					{
					case 2:
						num = 1793741295;
						continue;
					case 4:
						break;
					case 3:
						return;
					case 0:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = color.r * color.a;
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG = color.g * color.a;
						num = 1793741290;
						continue;
					default:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB = color.b * color.a;
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
			while (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num;
				int num2;
				if (!base.enabled)
				{
					num = -350162777;
					num2 = num;
				}
				else
				{
					num = -350162782;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -350162781)
					{
					case 5:
						num = -350162784;
						continue;
					case 2:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG = green * intensity;
						num = -350162781;
						continue;
					case 4:
						return;
					case 1:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = red * intensity;
						num = -350162783;
						continue;
					case 3:
						break;
					default:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB = blue * intensity;
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
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.AccelerometerValueRaw;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				while (true)
				{
					int num = 1350395186;
					while (true)
					{
						switch (num ^ 0x507D6533)
						{
						case 0:
							break;
						case 1:
							goto IL_004d;
						default:
							goto end_IL_002f;
						}
						break;
						IL_004d:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 1350395185;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.AccelerometerValue;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return Vector3.zero;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1745220624;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LastGyroscopeValue;
			}
			goto IL_005c;
			IL_005c:
			return Vector3.zero;
			IL_0012:
			switch (num ^ 0x6805F410)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			default:
				goto IL_005c;
			}
			goto IL_000d;
			IL_000d:
			num = 1745220625;
			goto IL_0012;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 1554781993;
				num2 = num;
			}
			else
			{
				num = 1554781995;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1554781992;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x5CAC1729)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return Vector3.zero;
				case 2:
				{
					int num3;
					if (!base.enabled)
					{
						num = 1554781993;
						num3 = num;
					}
					else
					{
						num = 1554781997;
						num3 = num;
					}
					continue;
				}
				case 4:
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = 1554781993;
						continue;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GyroscopeValueRaw;
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
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				while (true)
				{
					int num = 462604871;
					while (true)
					{
						switch (num ^ 0x1B92CA45)
						{
						case 0:
							break;
						case 2:
							goto IL_004d;
						default:
							goto end_IL_002f;
						}
						break;
						IL_004d:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 462604868;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GyroscopeValue;
					}
					continue;
					end_IL_002f:
					break;
				}
			}
			return Vector3.zero;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -921229663;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.Orientation;
			}
			goto IL_0067;
			IL_0067:
			return default(Quaternion);
			IL_0012:
			while (true)
			{
				switch (num ^ -921229664)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = -921229661;
					continue;
				case 3:
					return Quaternion.identity;
				default:
					goto IL_0067;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -921229662;
			goto IL_0012;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x23780F0C ^ 0x23780F0D)
					{
					case 2:
						break;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return;
					case 0:
						goto end_IL_000d;
					default:
						goto IL_0053;
					}
					continue;
					end_IL_000d:
					break;
				}
			}
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return;
			}
			goto IL_0053;
			IL_0053:
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.ResetOrientation();
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 875318405;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchIdAtIndex(index);
			}
			goto IL_0058;
			IL_0058:
			return -1;
			IL_0012:
			switch (num ^ 0x342C4C84)
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
			num = 875318406;
			goto IL_0012;
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -446187273;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionByTouchId(touchId, out position);
			}
			goto IL_006e;
			IL_006e:
			position = Vector2.zero;
			return false;
			IL_0012:
			while (true)
			{
				switch (num ^ -446187276)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = -446187275;
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
			num = -446187274;
			goto IL_0012;
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			int num;
			int num2;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = -108989923;
				num2 = num;
			}
			else
			{
				num = -108989924;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -108989927;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -108989923)
				{
				case 2:
					break;
				case 4:
					position = Vector2.zero;
					return false;
				case 3:
				{
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = -108989924;
						continue;
					}
					int positionX;
					int positionY;
					bool touchPositionAbsoluteByIndex = FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
					position = new Vector2(positionX, positionY);
					return touchPositionAbsoluteByIndex;
				}
				case 0:
				{
					int num3;
					if (base.enabled)
					{
						num = -108989922;
						num3 = num;
					}
					else
					{
						num = -108989924;
						num3 = num;
					}
					continue;
				}
				default:
					position = Vector2.zero;
					return false;
				}
				break;
			}
			goto IL_0019;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				goto IL_0024;
			}
			bool touchPositionAbsoluteByTouchId = default(bool);
			int positionX = default(int);
			int positionY = default(int);
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					touchPositionAbsoluteByTouchId = FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
					num = 1220507372;
				}
				else
				{
					num = 1220507373;
				}
				goto IL_0029;
			}
			goto IL_0069;
			IL_0029:
			switch (num ^ 0x48BF76EE)
			{
			case 0:
				break;
			case 1:
				return false;
			case 3:
				goto IL_0069;
			case 4:
				return false;
			default:
				position = new Vector2(positionX, positionY);
				return touchPositionAbsoluteByTouchId;
			}
			goto IL_0024;
			IL_0069:
			position = Vector2.zero;
			num = 1220507375;
			goto IL_0029;
			IL_0024:
			num = 1220507370;
			goto IL_0029;
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num2;
				if (!base.enabled)
				{
					num = 815808894;
					num2 = num;
				}
				else
				{
					num = 815808892;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_006d;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x30A0417D)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					return false;
				case 1:
					goto IL_005e;
				default:
					goto IL_006d;
				}
				break;
				IL_005e:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 815808894;
					continue;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.IsTouchingAtIndex(index);
			}
			goto IL_000d;
			IL_000d:
			num = 815808895;
			goto IL_0012;
			IL_006d:
			return false;
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1516273600;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.IsTouchingAtTouchId(touchId);
			}
			goto IL_0058;
			IL_0058:
			return false;
			IL_0012:
			switch (num ^ -1516273599)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return false;
			default:
				goto IL_0058;
			}
			goto IL_000d;
			IL_000d:
			num = -1516273597;
			goto IL_0012;
		}

		private Vector3 qMGUMxVyHoDuqKBlLpAjAsNwabN()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in qMGUMxVyHoDuqKBlLpAjAsNwabN
			return this.qMGUMxVyHoDuqKBlLpAjAsNwabN();
		}

		private Vector3 GMLZXdBevCDWkYGHHeIyrdBYLgW()
		{
			return GetGyroscopeValueRaw();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GMLZXdBevCDWkYGHHeIyrdBYLgW
			return this.GMLZXdBevCDWkYGHHeIyrdBYLgW();
		}

		internal void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return;
			}
			while (true)
			{
				int num = -1542555494;
				while (true)
				{
					switch (num ^ -1542555493)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						adBKkIfVoFTvDlZNRkPVjUCCRov();
						num = -1542555493;
						continue;
					case 4:
						return;
					case 1:
					{
						int num2;
						if (base.enabled)
						{
							num = -1542555496;
							num2 = num;
						}
						else
						{
							num = -1542555489;
							num2 = num;
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

		internal void fIBaXcnjmllWSuIUKZjDotVxWIx(IControllerExtensionSource P_0)
		{
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY = P_0 as WRvebREDcxItMcxFseMdInwAvglC;
			ltUCirDrbTngxJGUkcmqmAQBhwLE = FzAfZmFeJSmPEcrqFTJfQfeHdrSY != null && FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw != null;
		}

		internal Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new DualSenseExtension(this);
		}

		private void adBKkIfVoFTvDlZNRkPVjUCCRov()
		{
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return;
			}
			while (FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				while (true)
				{
					int num = 0;
					int num2 = -1026886359;
					while (true)
					{
						switch (num2 ^ -1026886360)
						{
						case 6:
							num2 = -1026886355;
							continue;
						case 0:
							if (zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Update())
							{
								SetVibration(num, 0f, stopOtherMotors: false);
								num2 = -1026886358;
								continue;
							}
							goto case 2;
						case 3:
							break;
						case 1:
							num2 = -1026886356;
							continue;
						case 2:
							num++;
							num2 = -1026886356;
							continue;
						case 5:
							goto end_IL_005a;
						default:
							if (num >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
					continue;
					end_IL_005a:
					break;
				}
			}
		}

		private void TzfDwdqMmCsJvyIzIMpUAOlpgRjg(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num;
			int num2;
			switch (P_0)
			{
			case DualShock4MotorType.RightMotor:
				num = 1;
				num2 = -1884026729;
				goto IL_0017;
			case DualShock4MotorType.LeftMotor:
				goto IL_0062;
				IL_0017:
				while (true)
				{
					switch (num2 ^ -1884026736)
					{
					case 5:
						num2 = -1884026733;
						continue;
					case 4:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
						return;
					case 2:
						break;
					case 3:
						goto IL_0062;
					case 0:
						if (P_1 <= 0f)
						{
							goto case 4;
						}
						goto IL_0073;
					case 1:
						goto end_IL_0003;
					case 7:
						num2 = -1884026736;
						continue;
					default:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Start(P_2);
						return;
					}
					break;
					IL_0073:
					int num3;
					if (P_2 > 0f)
					{
						num2 = -1884026730;
						num3 = num2;
					}
					else
					{
						num2 = -1884026732;
						num3 = num2;
					}
				}
				goto case DualShock4MotorType.RightMotor;
				IL_0062:
				num = 0;
				num2 = -1884026736;
				goto IL_0017;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
