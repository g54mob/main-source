using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class tMnjgiHHTTrIlevqvfMwMIodhrI : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource pjmDqcGcEdmXbvnkITKNjUFiEooD;

			public tMnjgiHHTTrIlevqvfMwMIodhrI(IPS4ControllerExtensionSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				pjmDqcGcEdmXbvnkITKNjUFiEooD = source;
			}
		}

		private readonly TimerAbs[] EKvpQGhJhXJTuQtvfhYGZZMoAhR;

		private IPS4ControllerExtensionSource Source
		{
			get
			{
				return (GetSource() as tMnjgiHHTTrIlevqvfMwMIodhrI).pjmDqcGcEdmXbvnkITKNjUFiEooD;
			}
		}

		internal Joystick joystick
		{
			get
			{
				return GetController<Joystick>();
			}
		}

		public int userStatusCode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return Source.GetUserStatus();
			}
		}

		public bool userIsPrimary
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				return Source.GetUserIsPrimary();
			}
		}

		public int userId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return Source.GetUserId();
			}
		}

		public Color userColor
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return default(Color);
				}
				return Source.GetUserColor();
			}
		}

		public int userColorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					while (true)
					{
						int num = 2047700682;
						while (true)
						{
							switch (num ^ 0x7A0D6ECB)
							{
							case 0:
								break;
							case 1:
								goto IL_002b;
							default:
								return -1;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(_reInputId);
							num = 2047700681;
						}
					}
				}
				return Source.GetUserColorId();
			}
		}

		public string userName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return Source.GetUserName();
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
				return Source.vibrationMotorCount;
			}
		}

		internal PS4ControllerExtension(IPS4ControllerExtensionSource source)
			: base(new tMnjgiHHTTrIlevqvfMwMIodhrI(source))
		{
			EKvpQGhJhXJTuQtvfhYGZZMoAhR = new TimerAbs[source.vibrationMotorCount];
			ArrayTools.Populate(EKvpQGhJhXJTuQtvfhYGZZMoAhR, 0, EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length);
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
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
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (-888195554 ^ -888195556)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
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
			goto IL_0071;
			IL_000d:
			int num = 1428353242;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x5522F0D9)
				{
				case 9:
					break;
				case 3:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 0:
					motorLevel = MathTools.Clamp01(motorLevel);
					num = 1428353246;
					continue;
				case 8:
					goto IL_0071;
				case 2:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[num2].Clear();
					num2++;
					num = 1428353235;
					continue;
				case 6:
					if (stopOtherMotors)
					{
						num2 = 0;
						num = 1428353244;
						continue;
					}
					goto case 0;
				case 4:
					return;
				case 10:
					goto IL_00cd;
				case 5:
					num = 1428353235;
					continue;
				case 1:
					Source.StopVibration();
					num = 1428353241;
					continue;
				default:
					Source.SetVibration(motorIndex, motorLevel);
					uvdRZwKNKWMEiNFUBKZVMFXyWAY(motorIndex, motorLevel, duration);
					return;
				}
				break;
				IL_00cd:
				int num3;
				if (num2 >= EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length)
				{
					num = 1428353240;
					num3 = num;
				}
				else
				{
					num = 1428353243;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_0071:
			if (motorIndex >= 0)
			{
				int num4;
				if (motorIndex >= Source.vibrationMotorCount)
				{
					num = 1428353245;
					num4 = num;
				}
				else
				{
					num = 1428353247;
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
			if (!Source.supportsVibration)
			{
				return 0f;
			}
			return Source.GetVibration(motorIndex);
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			int num3 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (!Source.supportsVibration)
				{
					num = -1391098861;
					num2 = num;
				}
				else
				{
					num = -1391098858;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1391098858)
					{
					case 3:
						num = -1391098857;
						continue;
					case 1:
						break;
					case 5:
						return;
					case 4:
						EKvpQGhJhXJTuQtvfhYGZZMoAhR[num3].Clear();
						num3++;
						num = -1391098860;
						continue;
					case 0:
						num3 = 0;
						num = -1391098860;
						continue;
					default:
						if (num3 >= EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length)
						{
							Source.StopVibration();
							return;
						}
						goto case 4;
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
			return Source.GetLastAccelerationRaw();
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			return Source.GetLastAcceleration();
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			return Source.GetLastGyroRaw();
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			return Source.GetLastGyro();
		}

		public Quaternion GetOrientationRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			return Source.GetLastOrientationRaw();
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			return Source.GetLastOrientation();
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (0x3D950F25 ^ 0x3D950F27)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			Source.ResetOrientation();
		}

		public void SetMotionSensorState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			goto IL_0043;
			IL_0043:
			Source.SetMotionSensorState(enabled);
			int num = -1216421233;
			goto IL_001e;
			IL_0019:
			num = -1216421235;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1216421234)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				return;
			case 2:
				goto IL_0043;
			case 1:
				return;
			}
			goto IL_0019;
		}

		public void SetTiltCorrectionState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (-1377373944 ^ -1377373943)
					{
					case 2:
						continue;
					case 1:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			Source.SetTiltCorrectionState(enabled);
		}

		public void SetAngularVelocityDeadbandState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0xA7EF5AE ^ 0xA7EF5AC)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(_reInputId);
						return;
					}
					break;
				}
			}
			Source.SetAngularVelocityDeadbandState(enabled);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (-692189163 ^ -692189164)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			SetLightColor(color.r, color.g, color.b, color.a);
		}

		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				SetLightColor(red, green, blue, 1f);
				int num = 1873431415;
				while (true)
				{
					switch (num ^ 0x6FAA4B76)
					{
					case 0:
						goto IL_001a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_001a:
					num = 1873431412;
				}
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
				if (!(red < 0f))
				{
					num = -1863761083;
					num2 = num;
				}
				else
				{
					num = -1863761073;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1863761084)
					{
					case 12:
						num = -1863761081;
						continue;
					case 8:
					{
						int num7;
						if (intensity > 1f)
						{
							num = -1863761082;
							num7 = num;
						}
						else
						{
							num = -1863761086;
							num7 = num;
						}
						continue;
					}
					case 1:
					{
						int num4;
						if (red > 1f)
						{
							num = -1863761073;
							num4 = num;
						}
						else
						{
							num = -1863761087;
							num4 = num;
						}
						continue;
					}
					case 5:
					{
						int num6;
						if (!(green < 0f))
						{
							num = -1863761084;
							num6 = num;
						}
						else
						{
							num = -1863761075;
							num6 = num;
						}
						continue;
					}
					case 10:
						blue = MathTools.Clamp01(blue);
						num = -1863761085;
						continue;
					case 0:
					{
						int num8;
						if (green <= 1f)
						{
							num = -1863761088;
							num8 = num;
						}
						else
						{
							num = -1863761075;
							num8 = num;
						}
						continue;
					}
					case 3:
						break;
					case 4:
						if (!(blue < 0f))
						{
							int num5;
							if (blue > 1f)
							{
								num = -1863761074;
								num5 = num;
							}
							else
							{
								num = -1863761085;
								num5 = num;
							}
							continue;
						}
						goto case 10;
					case 9:
						green = MathTools.Clamp01(green);
						num = -1863761088;
						continue;
					case 7:
					{
						int num3;
						if (!(intensity >= 0f))
						{
							num = -1863761082;
							num3 = num;
						}
						else
						{
							num = -1863761076;
							num3 = num;
						}
						continue;
					}
					case 2:
						intensity = MathTools.Clamp01(intensity);
						num = -1863761086;
						continue;
					case 11:
						red = MathTools.Clamp01(red);
						num = -1863761087;
						continue;
					default:
						Source.SetLightColor(MathTools.Clamp((int)(red * intensity * 255f), 0, 255), MathTools.Clamp((int)(green * intensity * 255f), 0, 255), MathTools.Clamp((int)(blue * intensity * 255f), 0, 255));
						return;
					}
					break;
				}
			}
		}

		public void ResetLight()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return;
			}
			while (true)
			{
				Source.ResetLight();
				int num = -1185151772;
				while (true)
				{
					switch (num ^ -1185151771)
					{
					case 0:
						goto IL_001a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_001a:
					num = -1185151769;
				}
			}
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			VJFYjFBUsXRKMAFoSRHQlMiHIYB();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new PS4ControllerExtension(this);
		}

		private void VJFYjFBUsXRKMAFoSRHQlMiHIYB()
		{
			if (!Source.supportsVibration)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = -1081034255;
				while (true)
				{
					switch (num2 ^ -1081034252)
					{
					case 4:
						num2 = -1081034251;
						continue;
					default:
						return;
					case 2:
						num++;
						num2 = -1081034254;
						continue;
					case 5:
						num2 = -1081034254;
						continue;
					case 1:
						break;
					case 0:
						if (EKvpQGhJhXJTuQtvfhYGZZMoAhR[num].Update())
						{
							SetVibration(num, 0f, false);
							num2 = -1081034250;
							continue;
						}
						goto case 2;
					case 6:
					{
						int num3;
						if (num >= EKvpQGhJhXJTuQtvfhYGZZMoAhR.Length)
						{
							num2 = -1081034249;
							num3 = num2;
						}
						else
						{
							num2 = -1081034252;
							num3 = num2;
						}
						continue;
					}
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void uvdRZwKNKWMEiNFUBKZVMFXyWAY(int P_0, float P_1, float P_2)
		{
			if ((uint)P_0 > (uint)Source.vibrationMotorCount)
			{
				goto IL_000e;
			}
			goto IL_0061;
			IL_000e:
			int num = -1730797287;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -1730797286)
				{
				case 2:
					break;
				default:
					return;
				case 5:
					EKvpQGhJhXJTuQtvfhYGZZMoAhR[P_0].Start(P_2);
					num = -1730797286;
					continue;
				case 6:
					return;
				case 3:
					return;
				case 4:
					goto IL_0061;
				case 1:
					goto IL_0082;
				case 0:
					return;
				}
				break;
			}
			goto IL_000e;
			IL_0061:
			if (!(P_1 <= 0f))
			{
				int num2;
				if (P_2 <= 0f)
				{
					num = -1730797285;
					num2 = num;
				}
				else
				{
					num = -1730797281;
					num2 = num;
				}
				goto IL_0013;
			}
			goto IL_0082;
			IL_0082:
			EKvpQGhJhXJTuQtvfhYGZZMoAhR[P_0].Clear();
			num = -1730797284;
			goto IL_0013;
		}
	}
}
