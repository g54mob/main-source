using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class QOdDAjipcJPwgZuTsFEhhEYyIafH : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource QhiXIzSBnzSGaWwDVddQlyhdvkF;

			public QOdDAjipcJPwgZuTsFEhhEYyIafH(IPS4ControllerExtensionSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				QhiXIzSBnzSGaWwDVddQlyhdvkF = source;
			}
		}

		private readonly TimerAbs[] zmxGOJkPYLhUdcrIkgYFpHzgdPkg;

		private IPS4ControllerExtensionSource Source => (GetSource() as QOdDAjipcJPwgZuTsFEhhEYyIafH).QhiXIzSBnzSGaWwDVddQlyhdvkF;

		internal Joystick joystick => GetController<Joystick>();

		public int deviceHandle
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return Source.OrOuibLvsvPjyZcUWHLRgFffOID();
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
				return Source.TuyqAEjWTpwLXlPVeJBhmmYeiw();
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
				return Source.TsHBUyXOxyECRHasPhTFTGGeeit();
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
				return Source.FEFCWXKKrQhtfLyWQGjbsbNUprL();
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
				return Source.HJqsHddrOPzPrXcsxZuVgnadHlW();
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
				return Source.aOPfKWuNjpVaOjrETNxMRtjcXsW();
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
				return Source.BkoXGvRKlYCFRLixWgByUhGAtZQ();
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
			: base(new QOdDAjipcJPwgZuTsFEhhEYyIafH(source))
		{
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg = new TimerAbs[source.vibrationMotorCount];
			ArrayTools.Populate(zmxGOJkPYLhUdcrIkgYFpHzgdPkg, 0, zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length);
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
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
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				while (true)
				{
					switch (-1614547493 ^ -1614547494)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
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
				goto IL_000d;
			}
			goto IL_0066;
			IL_000d:
			int num = -380873406;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -380873397)
				{
				case 0:
					break;
				default:
					return;
				case 8:
					motorLevel = MathTools.Clamp01(motorLevel);
					num = -380873399;
					continue;
				case 1:
					if (stopOtherMotors)
					{
						num2 = 0;
						num = -380873394;
						continue;
					}
					goto case 8;
				case 3:
					goto IL_0066;
				case 2:
					Source.SetVibration(motorIndex, motorLevel);
					TzfDwdqMmCsJvyIzIMpUAOlpgRjg(motorIndex, motorLevel, duration);
					num = -380873393;
					continue;
				case 5:
					if (num2 >= zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length)
					{
						Source.StopVibration();
						num = -380873405;
						continue;
					}
					goto case 7;
				case 7:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num2].Clear();
					num2++;
					num = -380873394;
					continue;
				case 9:
					ReInput.CheckInitialized(_reInputId);
					return;
				case 6:
					return;
				case 4:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_0066:
			if (motorIndex >= 0)
			{
				int num3;
				if (motorIndex < Source.vibrationMotorCount)
				{
					num = -380873398;
					num3 = num;
				}
				else
				{
					num = -380873395;
					num3 = num;
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
				goto IL_0019;
			}
			goto IL_004c;
			IL_0043:
			int num = 0;
			int num2 = 1428005419;
			goto IL_001e;
			IL_0019:
			num2 = 1428005421;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x551DA228)
				{
				case 0:
					break;
				case 2:
					goto IL_0043;
				case 4:
					goto IL_004c;
				case 1:
					zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Clear();
					num++;
					num2 = 1428005419;
					continue;
				case 5:
					return;
				default:
					if (num >= zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length)
					{
						Source.StopVibration();
						return;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0019;
			IL_004c:
			if (!Source.supportsVibration)
			{
				return;
			}
			goto IL_0043;
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					int num = -35747706;
					while (true)
					{
						switch (num ^ -35747708)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return Vector3.zero;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = -35747707;
					}
				}
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
				goto IL_000d;
			}
			goto IL_0043;
			IL_000d:
			int num = 1754727854;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x689705AC)
			{
			case 3:
				break;
			default:
				return;
			case 2:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 1:
				goto IL_0043;
			case 0:
				return;
			}
			goto IL_000d;
			IL_0043:
			Source.ResetOrientation();
			num = 1754727852;
			goto IL_0012;
		}

		public void SetMotionSensorState(bool enabled)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0043;
			IL_000d:
			int num = 385628641;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x16FC39E2)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 2:
				goto IL_0043;
			case 1:
				return;
			}
			goto IL_000d;
			IL_0043:
			Source.SetMotionSensorState(enabled);
			num = 385628643;
			goto IL_0012;
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
				while (true)
				{
					switch (0x37B69880 ^ 0x37B69881)
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
			Source.SetAngularVelocityDeadbandState(enabled);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				while (true)
				{
					switch (-311575970 ^ -311575972)
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
			SetLightColor(color.r, color.g, color.b, color.a);
		}

		public void SetLightColor(float red, float green, float blue)
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_0043;
			IL_000d:
			int num = 328815083;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x139951EA)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				ReInput.CheckInitialized(_reInputId);
				return;
			case 3:
				goto IL_0043;
			case 2:
				return;
			}
			goto IL_000d;
			IL_0043:
			SetLightColor(red, green, blue, 1f);
			num = 328815080;
			goto IL_0012;
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				goto IL_001c;
			}
			goto IL_00bd;
			IL_00bd:
			int num;
			if (!(red < 0f))
			{
				int num2;
				if (red <= 1f)
				{
					num = 970574700;
					num2 = num;
				}
				else
				{
					num = 970574695;
					num2 = num;
				}
				goto IL_0021;
			}
			goto IL_012a;
			IL_001c:
			num = 970574698;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num ^ 0x39D9CB6E)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (!(intensity < 0f))
					{
						goto IL_006d;
					}
					goto case 3;
				case 2:
					if (!(green < 0f))
					{
						goto IL_008f;
					}
					goto case 10;
				case 5:
					blue = MathTools.Clamp01(blue);
					num = 970574703;
					continue;
				case 8:
					goto IL_00bd;
				case 7:
					if (blue < 0f)
					{
						goto case 5;
					}
					goto IL_00e9;
				case 10:
					green = MathTools.Clamp01(green);
					num = 970574697;
					continue;
				case 3:
					intensity = MathTools.Clamp01(intensity);
					num = 970574693;
					continue;
				case 9:
					goto IL_012a;
				case 11:
					Source.SetLightColor(MathTools.Clamp((int)(red * intensity * 255f), 0, 255), MathTools.Clamp((int)(green * intensity * 255f), 0, 255), MathTools.Clamp((int)(blue * intensity * 255f), 0, 255));
					num = 970574696;
					continue;
				case 4:
					return;
				case 6:
					return;
				}
				break;
				IL_00e9:
				int num3;
				if (blue <= 1f)
				{
					num = 970574703;
					num3 = num;
				}
				else
				{
					num = 970574699;
					num3 = num;
				}
				continue;
				IL_008f:
				int num4;
				if (green > 1f)
				{
					num = 970574692;
					num4 = num;
				}
				else
				{
					num = 970574697;
					num4 = num;
				}
				continue;
				IL_006d:
				int num5;
				if (intensity <= 1f)
				{
					num = 970574693;
					num5 = num;
				}
				else
				{
					num = 970574701;
					num5 = num;
				}
			}
			goto IL_001c;
			IL_012a:
			red = MathTools.Clamp01(red);
			num = 970574700;
			goto IL_0021;
		}

		public void ResetLight()
		{
			if (ReInput._id != _reInputId)
			{
				goto IL_000d;
			}
			goto IL_004e;
			IL_000d:
			int num = -627552326;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -627552328)
				{
				case 4:
					break;
				default:
					return;
				case 2:
					ReInput.CheckInitialized(_reInputId);
					num = -627552327;
					continue;
				case 1:
					return;
				case 0:
					goto IL_004e;
				case 3:
					return;
				}
				break;
			}
			goto IL_000d;
			IL_004e:
			Source.ResetLight();
			num = -627552325;
			goto IL_0012;
		}

		internal virtual void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
			adBKkIfVoFTvDlZNRkPVjUCCRov();
		}

		internal virtual void fIBaXcnjmllWSuIUKZjDotVxWIx(IControllerExtensionSource P_0)
		{
		}

		internal virtual Controller.Extension EilcbgeeBHODbenDzVGhaquGLZK()
		{
			return new PS4ControllerExtension(this);
		}

		private void adBKkIfVoFTvDlZNRkPVjUCCRov()
		{
			if (!Source.supportsVibration)
			{
				return;
			}
			while (true)
			{
				int num = 0;
				int num2 = 989199885;
				while (true)
				{
					switch (num2 ^ 0x3AF5FE0C)
					{
					case 2:
						num2 = 989199880;
						continue;
					case 4:
						break;
					case 0:
					{
						int num3;
						if (zmxGOJkPYLhUdcrIkgYFpHzgdPkg[num].Update())
						{
							num2 = 989199887;
							num3 = num2;
						}
						else
						{
							num2 = 989199881;
							num3 = num2;
						}
						continue;
					}
					case 3:
						SetVibration(num, 0f, stopOtherMotors: false);
						num2 = 989199881;
						continue;
					case 5:
						num++;
						num2 = 989199885;
						continue;
					default:
						if (num >= zmxGOJkPYLhUdcrIkgYFpHzgdPkg.Length)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private void TzfDwdqMmCsJvyIzIMpUAOlpgRjg(int P_0, float P_1, float P_2)
		{
			if ((uint)P_0 > (uint)Source.vibrationMotorCount)
			{
				return;
			}
			while (!(P_1 <= 0f))
			{
				int num;
				int num2;
				if (P_2 > 0f)
				{
					num = -167960139;
					num2 = num;
				}
				else
				{
					num = -167960144;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -167960140)
					{
					case 0:
						num = -167960137;
						continue;
					default:
						return;
					case 3:
						break;
					case 4:
						goto end_IL_0035;
					case 1:
						zmxGOJkPYLhUdcrIkgYFpHzgdPkg[P_0].Start(P_2);
						num = -167960138;
						continue;
					case 2:
						return;
					}
					break;
				}
				continue;
				end_IL_0035:
				break;
			}
			zmxGOJkPYLhUdcrIkgYFpHzgdPkg[P_0].Clear();
		}
	}
}
