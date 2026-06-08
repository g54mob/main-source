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
		private class QPBhzisHhegimVBLPIbZPhbkpuC : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 vULJPazKWrfClTuqhWeDZYCbvZw;

			public readonly bool gkkruTywtCSgfaMjHfnJvKIxFVy;

			public readonly int hSqMknHvfLaCaSKUtNrDJWiYQVX;

			public QPBhzisHhegimVBLPIbZPhbkpuC(IDriver_DualShock4 driver, bool supportsVibration, int vibrationMotorCount)
			{
				while (true)
				{
					int num = -212293840;
					while (true)
					{
						switch (num ^ -212293839)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							vULJPazKWrfClTuqhWeDZYCbvZw = driver;
							num = -212293838;
							continue;
						case 3:
							gkkruTywtCSgfaMjHfnJvKIxFVy = supportsVibration;
							hSqMknHvfLaCaSKUtNrDJWiYQVX = vibrationMotorCount;
							num = -212293839;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
		}

		private QPBhzisHhegimVBLPIbZPhbkpuC FzAfZmFeJSmPEcrqFTJfQfeHdrSY;

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
					ReInput.CheckInitialized(_reInputId);
					goto IL_0019;
				}
				int num;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = 620458912;
						goto IL_001e;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR;
				}
				goto IL_0054;
				IL_001e:
				switch (num ^ 0x24FB73A2)
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
				num = 620458915;
				goto IL_001e;
				IL_0054:
				return 0f;
			}
			set
			{
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					while (true)
					{
						switch (0x7D0EB059 ^ 0x7D0EB058)
						{
						case 0:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = value;
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
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					while (true)
					{
						int num = 1913653057;
						while (true)
						{
							switch (num ^ 0x72100743)
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
								num = 1913653058;
								continue;
							}
							return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG;
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
					goto IL_000d;
				}
				int num;
				if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					if (!base.enabled)
					{
						num = -146018179;
						goto IL_0012;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB;
				}
				goto IL_005f;
				IL_0012:
				while (true)
				{
					switch (num ^ -146018178)
					{
					case 0:
						break;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						num = -146018180;
						continue;
					case 2:
						return 0f;
					default:
						goto IL_005f;
					}
					break;
				}
				goto IL_000d;
				IL_000d:
				num = -146018177;
				goto IL_0012;
				IL_005f:
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

		public int maxTouches
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
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.MaxTouches;
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

		internal DualShock4Extension(IDriver_DualShock4 driver)
			: base(new QPBhzisHhegimVBLPIbZPhbkpuC(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		private DualShock4Extension(DualShock4Extension source)
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
				goto IL_0010;
			}
			goto IL_0127;
			IL_0010:
			int num = 1630185994;
			goto IL_0015;
			IL_0015:
			DualShock4MotorType motor = default(DualShock4MotorType);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x612AAA00)
				{
				case 11:
					break;
				default:
					return;
				case 10:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					motor = DualShock4MotorType.RightMotor;
					num = 1630185993;
					continue;
				case 6:
					num2 = motorIndex;
					num = 1630185991;
					continue;
				case 3:
					return;
				case 0:
					goto IL_008f;
				case 4:
					num = 1630185993;
					continue;
				case 5:
					goto IL_00bb;
				case 1:
					return;
				case 13:
					throw new NotImplementedException();
				case 9:
					SetVibration(motor, motorLevel, duration, stopOtherMotors);
					num = 1630185992;
					continue;
				case 14:
					goto IL_00f7;
				case 7:
					switch (num2)
					{
					case 1:
						break;
					case 0:
						goto IL_00bb;
					default:
						goto IL_011d;
					}
					goto case 2;
				case 12:
					goto IL_0127;
				case 8:
					return;
					IL_011d:
					num = 1630185997;
					continue;
					IL_00bb:
					motor = DualShock4MotorType.LeftMotor;
					num = 1630185988;
					continue;
				}
				break;
				IL_00f7:
				int num3;
				if (motorIndex < 0)
				{
					num = 1630185987;
					num3 = num;
				}
				else
				{
					num = 1630185984;
					num3 = num;
				}
				continue;
				IL_008f:
				int num4;
				if (motorIndex >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
				{
					num = 1630185987;
					num4 = num;
				}
				else
				{
					num = 1630185990;
					num4 = num;
				}
			}
			goto IL_0010;
			IL_0127:
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return;
			}
			int num5;
			if (base.enabled)
			{
				num = 1630185998;
				num5 = num;
			}
			else
			{
				num = 1630185985;
				num5 = num;
			}
			goto IL_0015;
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				goto IL_0058;
			}
			int num;
			if (!base.enabled)
			{
				num = 1009788404;
				goto IL_001e;
			}
			if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			case 0:
				break;
			case 1:
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor;
			default:
				return 0f;
			}
			goto IL_008a;
			IL_008a:
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor;
			IL_0019:
			num = 1009788406;
			goto IL_001e;
			IL_0058:
			return 0f;
			IL_001e:
			switch (num ^ 0x3C3025F5)
			{
			case 0:
				break;
			case 3:
				return 0f;
			case 1:
				goto IL_0058;
			default:
				goto IL_008a;
			}
			goto IL_0019;
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			goto IL_006b;
			IL_006b:
			int num;
			int num2;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = -596169265;
				num2 = num;
			}
			else
			{
				num = -596169268;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -596169270;
			goto IL_001e;
			IL_001e:
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -596169267)
				{
				case 0:
					break;
				case 1:
					goto IL_0052;
				case 5:
					goto IL_006b;
				case 4:
					if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
					{
						return;
					}
					goto case 8;
				case 7:
					return;
				case 2:
					return;
				case 6:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num3].Clear();
					num3++;
					num = -596169266;
					continue;
				case 8:
					num3 = 0;
					num = -596169266;
					continue;
				default:
					if (num3 >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
					{
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.StopVibration();
						return;
					}
					goto case 6;
				}
				break;
				IL_0052:
				int num4;
				if (base.enabled)
				{
					num = -596169271;
					num4 = num;
				}
				else
				{
					num = -596169265;
					num4 = num;
				}
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
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				goto IL_0051;
			}
			if (!base.enabled)
			{
				goto IL_002f;
			}
			int num;
			if (!FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
			{
				num = -1964863358;
				goto IL_0034;
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
			goto IL_008c;
			IL_008c:
			return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor;
			IL_0034:
			switch (num ^ -1964863357)
			{
			case 3:
				break;
			case 2:
				goto IL_0051;
			case 1:
				return 0f;
			default:
				goto IL_008c;
			}
			goto IL_002f;
			IL_002f:
			num = -1964863359;
			goto IL_0034;
			IL_0051:
			return 0f;
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
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num5 = default(int);
			int num3 = default(int);
			while (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num;
				int num2;
				if (base.enabled)
				{
					num = -1928308763;
					num2 = num;
				}
				else
				{
					num = -1928308762;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1928308765)
					{
					case 14:
						num = -1928308760;
						continue;
					case 4:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor = motorLevel;
						num = -1928308765;
						continue;
					case 1:
						if (num5 >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
						{
							FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.StopVibration();
							num = -1928308753;
							continue;
						}
						goto case 7;
					case 13:
						switch (num3)
						{
						case 1:
							break;
						default:
							goto IL_00c7;
						case 0:
							goto IL_011b;
						}
						goto case 4;
					case 2:
						num = -1928308758;
						continue;
					case 9:
						throw new NotImplementedException();
					case 16:
						num5 = 0;
						num = -1928308766;
						continue;
					case 11:
						break;
					case 8:
						goto IL_011b;
					case 6:
					{
						int num6;
						if (FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
						{
							num = -1928308768;
							num6 = num;
						}
						else
						{
							num = -1928308759;
							num6 = num;
						}
						continue;
					}
					case 5:
						return;
					case 3:
					{
						int num4;
						if (!stopOtherMotors)
						{
							num = -1928308753;
							num4 = num;
						}
						else
						{
							num = -1928308749;
							num4 = num;
						}
						continue;
					}
					case 7:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num5].Clear();
						num5++;
						num = -1928308766;
						continue;
					case 12:
						motorLevel = MathTools.Clamp01(motorLevel);
						num = -1928308756;
						continue;
					case 10:
						return;
					case 15:
						num3 = (int)motor;
						num = -1928308754;
						continue;
					default:
						{
							TzfDwdqMmCsJvyIzIMpUAOlpgRjg(motor, motorLevel, duration);
							return;
						}
						IL_011b:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor = motorLevel;
						num = -1928308765;
						continue;
						IL_00c7:
						num = -1928308767;
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
				goto IL_000d;
			}
			goto IL_007d;
			IL_000d:
			int num = -1430865114;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1430865115)
				{
				case 2:
					break;
				case 1:
					return;
				case 4:
					return;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 6:
					goto IL_005f;
				case 0:
					goto IL_007d;
				default:
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LeftMotor = MathTools.Clamp01(leftMotorLevel);
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.RightMotor = MathTools.Clamp01(rightMotorLevel);
					TzfDwdqMmCsJvyIzIMpUAOlpgRjg(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
					TzfDwdqMmCsJvyIzIMpUAOlpgRjg(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
					return;
				}
				break;
				IL_005f:
				int num2;
				if (FzAfZmFeJSmPEcrqFTJfQfeHdrSY.gkkruTywtCSgfaMjHfnJvKIxFVy)
				{
					num = -1430865120;
					num2 = num;
				}
				else
				{
					num = -1430865119;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_007d:
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				return;
			}
			int num3;
			if (!base.enabled)
			{
				num = -1430865116;
				num3 = num;
			}
			else
			{
				num = -1430865117;
				num3 = num;
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
				if (base.enabled)
				{
					num = -1237355580;
					num2 = num;
				}
				else
				{
					num = -1237355584;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1237355584)
					{
					case 2:
						num = -1237355583;
						continue;
					case 1:
						break;
					case 0:
						return;
					case 4:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = color.r * color.a;
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG = color.g * color.a;
						num = -1237355581;
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
				goto IL_000d;
			}
			goto IL_006c;
			IL_000d:
			int num = -1797255582;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1797255581)
				{
				case 5:
					break;
				case 0:
					goto IL_0037;
				case 3:
					return;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 2:
					goto IL_006c;
				default:
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorR = red * intensity;
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorG = green * intensity;
					FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightColorB = blue * intensity;
					return;
				}
				break;
				IL_0037:
				int num2;
				if (base.enabled)
				{
					num = -1797255577;
					num2 = num;
				}
				else
				{
					num = -1797255584;
					num2 = num;
				}
			}
			goto IL_000d;
			IL_006c:
			int num3;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = -1797255581;
				num3 = num;
			}
			else
			{
				num = -1797255584;
				num3 = num;
			}
			goto IL_0012;
		}

		public void SetLightFlash(float onDuration, float offDuration)
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
					num = -905132177;
					num2 = num;
				}
				else
				{
					num = -905132179;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -905132180)
					{
					case 0:
						goto IL_001a;
					case 2:
						break;
					case 3:
						return;
					default:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightFlashOnDuration = onDuration;
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LightFlashOffDuration = offDuration;
						return;
					}
					break;
					IL_001a:
					num = -905132178;
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
				if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
				{
					num = 1734185480;
					num2 = num;
				}
				else
				{
					num = 1734185484;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x675D9209)
					{
					case 2:
						num = 1734185485;
						continue;
					default:
						return;
					case 1:
						return;
					case 5:
					{
						int num3;
						if (!base.enabled)
						{
							num = 1734185480;
							num3 = num;
						}
						else
						{
							num = 1734185482;
							num3 = num;
						}
						continue;
					}
					case 3:
						FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.StopLightFlash();
						num = 1734185481;
						continue;
					case 4:
						break;
					case 0:
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
				goto IL_0019;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1486837648;
					goto IL_001e;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.AccelerometerValueRaw;
			}
			goto IL_005c;
			IL_001e:
			switch (num ^ -1486837647)
			{
			case 0:
				break;
			case 2:
				return Vector3.zero;
			default:
				goto IL_005c;
			}
			goto IL_0019;
			IL_005c:
			return Vector3.zero;
			IL_0019:
			num = -1486837645;
			goto IL_001e;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				while (true)
				{
					int num = 276352751;
					while (true)
					{
						switch (num ^ 0x1078CEED)
						{
						case 3:
							break;
						case 2:
							goto IL_0049;
						case 1:
							goto IL_0062;
						default:
							goto end_IL_0027;
						}
						break;
						IL_0062:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 276352749;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.AccelerometerValue;
						IL_0049:
						int num2;
						if (!base.enabled)
						{
							num = 276352749;
							num2 = num;
						}
						else
						{
							num = 276352748;
							num2 = num;
						}
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return Vector3.zero;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 1218343830;
				num2 = num;
			}
			else
			{
				num = 1218343829;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1218343831;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x489E7396)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					return Vector3.zero;
				case 0:
					if (base.enabled)
					{
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							goto IL_006a;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LastGyroscopeValueRaw;
					}
					goto default;
				default:
					return Vector3.zero;
				}
				break;
				IL_006a:
				num = 1218343829;
			}
			goto IL_000d;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 272178833;
				num2 = num;
			}
			else
			{
				num = 272178834;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 272178835;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x10391E90)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return Vector3.zero;
				case 1:
					if (base.enabled)
					{
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							goto IL_006a;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.LastGyroscopeValue;
					}
					goto default;
				default:
					return Vector3.zero;
				}
				break;
				IL_006a:
				num = 272178834;
			}
			goto IL_000d;
		}

		public Vector3 GetGyroscopeValueRaw()
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
					num = -2111115256;
					goto IL_0012;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GyroscopeValueRaw;
			}
			goto IL_005c;
			IL_005c:
			return Vector3.zero;
			IL_0012:
			switch (num ^ -2111115255)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			default:
				goto IL_005c;
			}
			goto IL_000d;
			IL_000d:
			num = -2111115253;
			goto IL_0012;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				while (true)
				{
					int num = 312509047;
					while (true)
					{
						switch (num ^ 0x12A08276)
						{
						case 2:
							break;
						case 1:
							goto IL_0049;
						case 0:
							goto IL_0062;
						default:
							goto end_IL_0027;
						}
						break;
						IL_0062:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 312509045;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GyroscopeValue;
						IL_0049:
						int num2;
						if (base.enabled)
						{
							num = 312509046;
							num2 = num;
						}
						else
						{
							num = 312509045;
							num2 = num;
						}
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return Vector3.zero;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.Orientation;
				}
				goto IL_0037;
			}
			goto IL_0055;
			IL_0037:
			int num = -1842710957;
			goto IL_003c;
			IL_003c:
			Quaternion result = default(Quaternion);
			switch (num ^ -1842710958)
			{
			case 2:
				break;
			case 1:
				goto IL_0055;
			default:
				return result;
			}
			goto IL_0037;
			IL_0055:
			result = default(Quaternion);
			num = -1842710958;
			goto IL_003c;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0047;
			IL_000d:
			int num = 1660294922;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x62F6170B)
			{
			case 3:
				break;
			case 1:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 4:
				goto IL_0047;
			case 2:
				return;
			default:
				FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.ResetOrientation();
				return;
			}
			goto IL_000d;
			IL_0047:
			int num2;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 1660294921;
				num2 = num;
			}
			else
			{
				num = 1660294923;
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
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				while (true)
				{
					int num = 515854728;
					while (true)
					{
						switch (num ^ 0x1EBF5189)
						{
						case 2:
							break;
						case 1:
							goto IL_0049;
						default:
							goto end_IL_002b;
						}
						break;
						IL_0049:
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 515854729;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchIdAtIndex(index);
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
				goto IL_000d;
			}
			int num;
			int num2;
			if (!ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 784243659;
				num2 = num;
			}
			else
			{
				num = 784243658;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 784243660;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2EBE9BC8)
				{
				case 0:
					break;
				case 3:
					position = Vector2.zero;
					num = 784243657;
					continue;
				case 2:
					if (base.enabled)
					{
						if (!ReInput.IsInputAllowed(ControllerType.Joystick))
						{
							num = 784243659;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionByIndex(index, out position);
					}
					goto case 3;
				case 4:
					ReInput.CheckInitialized(_reInputId);
					position = Vector2.zero;
					return false;
				default:
					return false;
				}
				break;
			}
			goto IL_000d;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num2;
				if (base.enabled)
				{
					num = 1533601170;
					num2 = num;
				}
				else
				{
					num = 1533601175;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_007c;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x5B68E596)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					position = Vector2.zero;
					return false;
				case 4:
					goto IL_006d;
				case 1:
					goto IL_007c;
				default:
					return false;
				}
				break;
				IL_006d:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1533601175;
					continue;
				}
				return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionByTouchId(touchId, out position);
			}
			goto IL_000d;
			IL_000d:
			num = 1533601172;
			goto IL_0012;
			IL_007c:
			position = Vector2.zero;
			num = 1533601173;
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
			bool touchPositionAbsoluteByIndex = default(bool);
			int positionX = default(int);
			int positionY = default(int);
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE && base.enabled)
			{
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = 1661297573;
				}
				else
				{
					touchPositionAbsoluteByIndex = FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
					num = 1661297574;
				}
				goto IL_001e;
			}
			goto IL_006b;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x630563A4)
				{
				case 4:
					break;
				case 3:
					position = Vector2.zero;
					return false;
				case 1:
					goto IL_006b;
				case 2:
					position = new Vector2(positionX, positionY);
					num = 1661297572;
					continue;
				default:
					return touchPositionAbsoluteByIndex;
				}
				break;
			}
			goto IL_0019;
			IL_006b:
			position = Vector2.zero;
			return false;
			IL_0019:
			num = 1661297575;
			goto IL_001e;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			int num;
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				int num2;
				if (base.enabled)
				{
					num = -1683410940;
					num2 = num;
				}
				else
				{
					num = -1683410938;
					num2 = num;
				}
				goto IL_0012;
			}
			goto IL_0078;
			IL_0012:
			while (true)
			{
				switch (num ^ -1683410938)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					position = Vector2.zero;
					return false;
				case 2:
					goto IL_0069;
				default:
					goto IL_0078;
				}
				break;
				IL_0069:
				if (!ReInput.IsInputAllowed(ControllerType.Joystick))
				{
					num = -1683410938;
					continue;
				}
				int positionX;
				int positionY;
				bool touchPositionAbsoluteByTouchId = FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
				position = new Vector2(positionX, positionY);
				return touchPositionAbsoluteByTouchId;
			}
			goto IL_000d;
			IL_000d:
			num = -1683410937;
			goto IL_0012;
			IL_0078:
			position = Vector2.zero;
			return false;
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
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				num = 1784739457;
				num2 = num;
			}
			else
			{
				num = 1784739456;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 1784739463;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x6A60F683)
				{
				case 0:
					break;
				case 1:
					if (!ReInput.IsInputAllowed(ControllerType.Joystick))
					{
						num = 1784739456;
						continue;
					}
					return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.IsTouchingAtIndex(index);
				case 2:
				{
					int num3;
					if (!base.enabled)
					{
						num = 1784739456;
						num3 = num;
					}
					else
					{
						num = 1784739458;
						num3 = num;
					}
					continue;
				}
				case 4:
					return false;
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
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				while (true)
				{
					int num = -162201011;
					while (true)
					{
						switch (num ^ -162201012)
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
							num = -162201010;
							continue;
						}
						return FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw.IsTouchingAtTouchId(touchId);
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return false;
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
			if (ltUCirDrbTngxJGUkcmqmAQBhwLE)
			{
				if (!base.enabled)
				{
					goto IL_0010;
				}
				goto IL_003a;
			}
			return;
			IL_003a:
			adBKkIfVoFTvDlZNRkPVjUCCRov();
			int num = 1482638021;
			goto IL_0015;
			IL_0010:
			num = 1482638023;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x585F42C4)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 2:
				goto IL_003a;
			case 1:
				return;
			}
			goto IL_0010;
		}

		internal void fIBaXcnjmllWSuIUKZjDotVxWIx(IControllerExtensionSource P_0)
		{
			FzAfZmFeJSmPEcrqFTJfQfeHdrSY = P_0 as QPBhzisHhegimVBLPIbZPhbkpuC;
			ltUCirDrbTngxJGUkcmqmAQBhwLE = FzAfZmFeJSmPEcrqFTJfQfeHdrSY != null && FzAfZmFeJSmPEcrqFTJfQfeHdrSY.vULJPazKWrfClTuqhWeDZYCbvZw != null;
		}

		internal Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new DualShock4Extension(this);
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
					IL_0081:
					int num = 0;
					int num2 = -1843161175;
					while (true)
					{
						switch (num2 ^ -1843161176)
						{
						case 6:
							num2 = -1843161173;
							continue;
						case 5:
							if (zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Update())
							{
								SetVibration(num, 0f, stopOtherMotors: false);
								num2 = -1843161176;
								continue;
							}
							goto case 0;
						case 0:
							num++;
							num2 = -1843161174;
							continue;
						case 1:
							num2 = -1843161174;
							continue;
						case 3:
							break;
						case 4:
							goto IL_0081;
						default:
							if (num >= FzAfZmFeJSmPEcrqFTJfQfeHdrSY.hSqMknHvfLaCaSKUtNrDJWiYQVX)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
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
			case DualShock4MotorType.LeftMotor:
				num = 0;
				num2 = 630273951;
				goto IL_001a;
			case DualShock4MotorType.RightMotor:
				goto IL_0091;
				IL_001a:
				while (true)
				{
					switch (num2 ^ 0x2591379D)
					{
					case 6:
						num2 = 630273950;
						continue;
					default:
						return;
					case 3:
						break;
					case 5:
						if (!(P_1 <= 0f))
						{
							goto IL_005c;
						}
						goto case 4;
					case 2:
						num2 = 630273944;
						continue;
					case 4:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
						return;
					case 8:
						goto IL_0091;
					case 0:
						goto end_IL_0003;
					case 1:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Start(P_2);
						num2 = 630273946;
						continue;
					case 7:
						return;
					}
					break;
					IL_005c:
					int num3;
					if (P_2 > 0f)
					{
						num2 = 630273948;
						num3 = num2;
					}
					else
					{
						num2 = 630273945;
						num3 = num2;
					}
				}
				goto case DualShock4MotorType.LeftMotor;
				IL_0091:
				num = 1;
				num2 = 630273944;
				goto IL_001a;
				end_IL_0003:
				break;
			}
			throw new NotImplementedException();
		}
	}
}
