using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public class PS4ControllerExtension : Controller.Extension, IControllerVibrator
	{
		internal class UWcfTIdEHroICcszHTlgcXEeRHe : IControllerExtensionSource
		{
			public readonly IPS4ControllerExtensionSource UdjCSEOPIRsTIjnUgCiPBbbzKWS;

			public UWcfTIdEHroICcszHTlgcXEeRHe(IPS4ControllerExtensionSource source)
			{
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				UdjCSEOPIRsTIjnUgCiPBbbzKWS = source;
			}
		}

		private readonly TimerAbs[] xZuKFmRpvbeqPEKkNilOfJfximjg;

		private IPS4ControllerExtensionSource Source => (GetSource() as UWcfTIdEHroICcszHTlgcXEeRHe).UdjCSEOPIRsTIjnUgCiPBbbzKWS;

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
				return Source.CpDdzGPDGNInYkPAhekOSmJrapI();
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
				return Source.HiptkvIzblAdhsHlqeeKVnyAeJl();
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
				return Source.NECADNTmvWmyeglKuUNEtfQuKDm();
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
				return Source.ToSJaQUUsuXVHqyptCmZYHEKEGl();
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
				return Source.HOdlKWlsfvkrVwFOSZZOMootFKL();
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
				return Source.mYUyKjoCcBnroCuxaeeBbfSyyDX();
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
				return Source.NuvNLUNESmefzCgNbOyrZuQKOwH();
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
			: base(new UWcfTIdEHroICcszHTlgcXEeRHe(source))
		{
			xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[source.vibrationMotorCount];
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
		}

		protected PS4ControllerExtension(PS4ControllerExtension source)
			: base(source)
		{
			try
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[0];
			}
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
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
					for (int i = 0; i < xZuKFmRpvbeqPEKkNilOfJfximjg.Length; i++)
					{
						xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
					}
					Source.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				Source.SetVibration(motorIndex, motorLevel);
				PrmctIckVmyxTVxTdzKFusfbJqiG(motorIndex, motorLevel, duration);
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
				for (int i = 0; i < xZuKFmRpvbeqPEKkNilOfJfximjg.Length; i++)
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
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

		internal virtual void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			iqIALhjYezdflYrpgSZUFTUYBiz();
		}

		internal virtual void tmEnLTdHsRVxaDmExqmMETendBa(IControllerExtensionSource P_0)
		{
		}

		internal virtual Controller.Extension AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return new PS4ControllerExtension(this);
		}

		private void iqIALhjYezdflYrpgSZUFTUYBiz()
		{
			if (!Source.supportsVibration)
			{
				return;
			}
			for (int i = 0; i < xZuKFmRpvbeqPEKkNilOfJfximjg.Length; i++)
			{
				if (xZuKFmRpvbeqPEKkNilOfJfximjg[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void PrmctIckVmyxTVxTdzKFusfbJqiG(int P_0, float P_1, float P_2)
		{
			if ((uint)P_0 <= (uint)Source.vibrationMotorCount)
			{
				if (P_1 <= 0f || P_2 <= 0f)
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[P_0].Clear();
				}
				else
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[P_0].Start(P_2);
				}
			}
		}
	}
}
