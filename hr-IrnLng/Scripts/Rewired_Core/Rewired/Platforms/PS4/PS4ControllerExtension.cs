using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class eNGxyyCaaufbYfgDISdfwRfUBWY : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource ahVlanlbOCBOWeBnfSIFVGtHSeq;

			public eNGxyyCaaufbYfgDISdfwRfUBWY(IPS4ControllerExtensionSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				ahVlanlbOCBOWeBnfSIFVGtHSeq = source;
			}
		}

		private readonly TimerAbs[] ZmIYmGkyAuhZVDRUIGpXvAIJRaR;

		private IPS4ControllerExtensionSource Source => (GetSource() as eNGxyyCaaufbYfgDISdfwRfUBWY).ahVlanlbOCBOWeBnfSIFVGtHSeq;

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
				return Source.qSvSpwilSIMEEnCakcqNGgeZlms();
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
				return Source.fLJQlPlGmyvobbPQtikNBBRuXkB();
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
				return Source.tgMbrOaGBgTosbobbMXoxlMCPIN();
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
				return Source.fEemFUrFxhgtZbVGaEGfAbkqaEy();
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
				return Source.jlJAfgcSWwRGPKnwBHLJRQTLDOjf();
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
				return Source.AOaVwNDHlCiKcBqWxumSrHWQraz();
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
				return Source.bkBFigHkpnoKrNxtkAoiGyzcOgbD();
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
			: base(new eNGxyyCaaufbYfgDISdfwRfUBWY(source))
		{
			ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[source.vibrationMotorCount];
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
			: base(source)
		{
			try
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[0];
			}
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
			}
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
			}
			else
			{
				if (motorIndex < 0 || motorIndex >= Source.vibrationMotorCount)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length; i++)
					{
						ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
					}
					Source.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				Source.SetVibration(motorIndex, motorLevel);
				vAQoCgVfelQQROodmbOGmxKBFeC(motorIndex, motorLevel, duration);
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
			}
			else if (Source.supportsVibration)
			{
				for (int i = 0; i < ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length; i++)
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
				}
				Source.StopVibration();
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
			}
			else
			{
				Source.SetAngularVelocityDeadbandState(enabled);
			}
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
			if (red < 0f || red > 1f)
			{
				red = MathTools.Clamp01(red);
			}
			if (green < 0f || green > 1f)
			{
				green = MathTools.Clamp01(green);
			}
			if (blue < 0f || blue > 1f)
			{
				blue = MathTools.Clamp01(blue);
			}
			if (intensity < 0f || intensity > 1f)
			{
				intensity = MathTools.Clamp01(intensity);
			}
			Source.SetLightColor(MathTools.Clamp((int)(red * intensity * 255f), 0, 255), MathTools.Clamp((int)(green * intensity * 255f), 0, 255), MathTools.Clamp((int)(blue * intensity * 255f), 0, 255));
		}

		public void ResetLight()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				Source.ResetLight();
			}
		}

		internal virtual void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			AdgerJOJHeELnHnJdXbVLfbiaXX();
		}

		internal virtual void FIsQjdAAyWEysCgIuJuNAowHchI(IControllerExtensionSource P_0)
		{
		}

		internal virtual Controller.Extension cGSBTlPoJoSUBEuZRjRzMJDgwjh()
		{
			return new PS4ControllerExtension(this);
		}

		private void AdgerJOJHeELnHnJdXbVLfbiaXX()
		{
			if (!Source.supportsVibration)
			{
				return;
			}
			for (int i = 0; i < ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length; i++)
			{
				if (ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void vAQoCgVfelQQROodmbOGmxKBFeC(int P_0, float P_1, float P_2)
		{
			if ((uint)P_0 <= (uint)Source.vibrationMotorCount)
			{
				if (P_1 <= 0f || P_2 <= 0f)
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[P_0].Clear();
				}
				else
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[P_0].Start(P_2);
				}
			}
		}
	}
}
