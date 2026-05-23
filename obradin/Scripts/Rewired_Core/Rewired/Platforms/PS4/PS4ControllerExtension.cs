using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class IpBevHdFLSGMfSpPencGlqkvcLP : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource WVeuvvGVKxuwIVofyhIJOpLcDjb;

			public IpBevHdFLSGMfSpPencGlqkvcLP(IPS4ControllerExtensionSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				WVeuvvGVKxuwIVofyhIJOpLcDjb = source;
			}
		}

		private readonly TimerAbs[] pSngNFXjFJqIDusOVrrEyDkmFgW;

		private IPS4ControllerExtensionSource Source
		{
			get
			{
				return (GetSource() as IpBevHdFLSGMfSpPencGlqkvcLP).WVeuvvGVKxuwIVofyhIJOpLcDjb;
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
					ReInput.CheckInitialized(_reInputId);
					return -1;
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
			: base(new IpBevHdFLSGMfSpPencGlqkvcLP(source))
		{
			pSngNFXjFJqIDusOVrrEyDkmFgW = new TimerAbs[source.vibrationMotorCount];
			ArrayTools.Populate(pSngNFXjFJqIDusOVrrEyDkmFgW, 0, pSngNFXjFJqIDusOVrrEyDkmFgW.Length);
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
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
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_0019;
			}
			goto IL_0043;
			IL_0043:
			SetVibration(motorIndex, motorLevel, 0f, false);
			int num = -1972484717;
			goto IL_001e;
			IL_0019:
			num = -1972484719;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1972484720)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0043;
			case 3:
				return;
			}
			goto IL_0019;
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
				goto IL_0010;
			}
			goto IL_00b3;
			IL_0010:
			int num = -2072908048;
			goto IL_0015;
			IL_0015:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -2072908047)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(_reInputId);
					num = -2072908041;
					continue;
				case 7:
					motorLevel = MathTools.Clamp01(motorLevel);
					num = -2072908043;
					continue;
				case 3:
					goto IL_0073;
				case 2:
					if (num2 >= pSngNFXjFJqIDusOVrrEyDkmFgW.Length)
					{
						Source.StopVibration();
						num = -2072908042;
						continue;
					}
					goto case 5;
				case 6:
					return;
				case 8:
					goto IL_00b3;
				case 10:
					return;
				case 9:
					num2 = 0;
					num = -2072908045;
					continue;
				case 5:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Clear();
					num2++;
					num = -2072908045;
					continue;
				default:
					Source.SetVibration(motorIndex, motorLevel);
					PkvIixiBJQgzJxQXdAWDrKLgpHX(motorIndex, motorLevel, duration);
					return;
				}
				break;
				IL_0073:
				int num3;
				if (!stopOtherMotors)
				{
					num = -2072908042;
					num3 = num;
				}
				else
				{
					num = -2072908040;
					num3 = num;
				}
			}
			goto IL_0010;
			IL_00b3:
			if (motorIndex >= 0)
			{
				int num4;
				if (motorIndex >= Source.vibrationMotorCount)
				{
					num = -2072908037;
					num4 = num;
				}
				else
				{
					num = -2072908046;
					num4 = num;
				}
				goto IL_0015;
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
				goto IL_000d;
			}
			goto IL_0084;
			IL_000d:
			int num = -1374082126;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -1374082121)
				{
				case 6:
					break;
				default:
					return;
				case 5:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 3:
					if (num2 >= pSngNFXjFJqIDusOVrrEyDkmFgW.Length)
					{
						Source.StopVibration();
						num = -1374082121;
						continue;
					}
					goto case 2;
				case 2:
					pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Clear();
					num2++;
					num = -1374082124;
					continue;
				case 1:
					goto IL_0084;
				case 4:
					goto IL_009c;
				case 0:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0084:
			if (!Source.supportsVibration)
			{
				return;
			}
			goto IL_009c;
			IL_009c:
			num2 = 0;
			num = -1374082124;
			goto IL_0012;
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
			}
			else
			{
				Source.ResetOrientation();
			}
		}

		public void SetMotionSensorState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				Source.SetMotionSensorState(enabled);
			}
		}

		public void SetTiltCorrectionState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				Source.SetTiltCorrectionState(enabled);
			}
		}

		public void SetAngularVelocityDeadbandState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (-2073043576 ^ -2073043575)
					{
					case 2:
						continue;
					case 1:
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
			}
			else
			{
				SetLightColor(color.r, color.g, color.b, color.a);
			}
		}

		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (-1158930956 ^ -1158930955)
					{
					case 0:
						continue;
					case 1:
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
				goto IL_001c;
			}
			goto IL_00c7;
			IL_00c7:
			int num;
			int num2;
			if (!(red < 0f))
			{
				num = -1026536382;
				num2 = num;
			}
			else
			{
				num = -1026536373;
				num2 = num;
			}
			goto IL_0021;
			IL_001c:
			num = -1026536384;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ -1026536373)
				{
				case 6:
					break;
				default:
					return;
				case 11:
					return;
				case 7:
					intensity = MathTools.Clamp01(intensity);
					num = -1026536374;
					continue;
				case 8:
					if (intensity < 0f)
					{
						goto case 7;
					}
					goto IL_0086;
				case 2:
					if (!(blue < 0f))
					{
						goto IL_00ab;
					}
					goto case 5;
				case 4:
					goto IL_00c7;
				case 12:
					if (!(green < 0f))
					{
						goto IL_00ee;
					}
					goto case 3;
				case 0:
					red = MathTools.Clamp01(red);
					num = -1026536377;
					continue;
				case 1:
					Source.SetLightColor(MathTools.Clamp((int)(red * intensity * 255f), 0, 255), MathTools.Clamp((int)(green * intensity * 255f), 0, 255), MathTools.Clamp((int)(blue * intensity * 255f), 0, 255));
					num = -1026536383;
					continue;
				case 3:
					green = MathTools.Clamp01(green);
					num = -1026536375;
					continue;
				case 5:
					blue = MathTools.Clamp01(blue);
					num = -1026536381;
					continue;
				case 9:
					goto IL_0197;
				case 10:
					return;
				}
				break;
				IL_0197:
				int num3;
				if (red > 1f)
				{
					num = -1026536373;
					num3 = num;
				}
				else
				{
					num = -1026536377;
					num3 = num;
				}
				continue;
				IL_00ab:
				int num4;
				if (blue > 1f)
				{
					num = -1026536370;
					num4 = num;
				}
				else
				{
					num = -1026536381;
					num4 = num;
				}
				continue;
				IL_0086:
				int num5;
				if (intensity > 1f)
				{
					num = -1026536372;
					num5 = num;
				}
				else
				{
					num = -1026536374;
					num5 = num;
				}
				continue;
				IL_00ee:
				int num6;
				if (green > 1f)
				{
					num = -1026536376;
					num6 = num;
				}
				else
				{
					num = -1026536375;
					num6 = num;
				}
			}
			goto IL_001c;
		}

		public void ResetLight()
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (0x9C91585 ^ 0x9C91584)
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
			Source.ResetLight();
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			qxBgmSGduLZblrclmRJKaMoDcVOA();
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return new PS4ControllerExtension(this);
		}

		private void qxBgmSGduLZblrclmRJKaMoDcVOA()
		{
			if (!Source.supportsVibration)
			{
				goto IL_000d;
			}
			goto IL_0046;
			IL_000d:
			int num = 762956630;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x2D79CB50)
				{
				case 0:
					break;
				case 2:
					num2++;
					num = 762956629;
					continue;
				case 1:
					goto IL_0046;
				case 6:
					return;
				case 3:
					num = 762956629;
					continue;
				case 4:
					if (pSngNFXjFJqIDusOVrrEyDkmFgW[num2].Update())
					{
						SetVibration(num2, 0f, false);
						num = 762956626;
						continue;
					}
					goto case 2;
				default:
					if (num2 >= pSngNFXjFJqIDusOVrrEyDkmFgW.Length)
					{
						return;
					}
					goto case 4;
				}
				break;
			}
			goto IL_000d;
			IL_0046:
			num2 = 0;
			num = 762956627;
			goto IL_0012;
		}

		private void PkvIixiBJQgzJxQXdAWDrKLgpHX(int P_0, float P_1, float P_2)
		{
			if ((uint)P_0 > (uint)Source.vibrationMotorCount)
			{
				goto IL_000e;
			}
			goto IL_0040;
			IL_000e:
			int num = -2089193749;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ -2089193751)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					return;
				case 4:
					goto IL_0040;
				case 3:
					pSngNFXjFJqIDusOVrrEyDkmFgW[P_0].Start(P_2);
					num = -2089193748;
					continue;
				case 1:
					goto IL_0076;
				case 5:
					return;
				}
				break;
			}
			goto IL_000e;
			IL_0076:
			pSngNFXjFJqIDusOVrrEyDkmFgW[P_0].Clear();
			return;
			IL_0040:
			if (!(P_1 <= 0f))
			{
				int num2;
				if (P_2 > 0f)
				{
					num = -2089193750;
					num2 = num;
				}
				else
				{
					num = -2089193752;
					num2 = num;
				}
				goto IL_0013;
			}
			goto IL_0076;
		}
	}
}
