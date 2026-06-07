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
		private class SioPzDNflmQdBGScWCHPMwikAkdN : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 SvXIbinBGtiNrIOGDzKitHGXgbzAA;

			public readonly bool VULMZuHSYDoNXhQpgLNJzLJoAlpv;

			public readonly int hWOdTudzrFRcBJMPgYEbqgWRUEJb;

			public SioPzDNflmQdBGScWCHPMwikAkdN(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				SvXIbinBGtiNrIOGDzKitHGXgbzAA = P_0;
				VULMZuHSYDoNXhQpgLNJzLJoAlpv = P_1;
				hWOdTudzrFRcBJMPgYEbqgWRUEJb = P_2;
			}
		}

		private SioPzDNflmQdBGScWCHPMwikAkdN sLPflhyTxwKGcgrrLnDvjxJwFyTe;

		private bool IzaYrAWNaCpapepvjdcKbQEYJmLMA;

		private TimerAbs[] KyqPqttyYQEUqocyyXQoBRYHXflF;

		private Joystick ztLVNAnnhKpTsrFIvhaOKxwOLANi => GetController<Joystick>();

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					return 0;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.hWOdTudzrFRcBJMPgYEbqgWRUEJb;
			}
		}

		public float lightColorRed
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled)
				{
					return 0f;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorR;
			}
			set
			{
				if (IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorR = value;
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
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled)
				{
					return 0f;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorG;
			}
			set
			{
				if (IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorG = value;
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
					return 0f;
				}
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled)
				{
					return 0f;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorB;
			}
			set
			{
				if (IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorB = value;
				}
			}
		}

		int IDualShock4Extension.maxTouches
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					return 0;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.MaxTouches;
			}
		}

		int IDualShock4Extension.touchCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchCount();
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
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA)
				{
					return 0f;
				}
				return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new SioPzDNflmQdBGScWCHPMwikAkdN(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			KyqPqttyYQEUqocyyXQoBRYHXflF = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(KyqPqttyYQEUqocyyXQoBRYHXflF, 0, KyqPqttyYQEUqocyyXQoBRYHXflF.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				KyqPqttyYQEUqocyyXQoBRYHXflF = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				KyqPqttyYQEUqocyyXQoBRYHXflF = new TimerAbs[0];
			}
			ArrayTools.Populate(KyqPqttyYQEUqocyyXQoBRYHXflF, 0, KyqPqttyYQEUqocyyXQoBRYHXflF.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled && motorIndex >= 0 && motorIndex < sLPflhyTxwKGcgrrLnDvjxJwFyTe.hWOdTudzrFRcBJMPgYEbqgWRUEJb)
			{
				SetVibration(motorIndex switch
				{
					0 => DualShock4MotorType.LeftMotor, 
					1 => DualShock4MotorType.RightMotor, 
					_ => throw new NotImplementedException(), 
				}, motorLevel, duration, stopOtherMotors);
			}
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled)
			{
				return 0f;
			}
			if (!sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LeftMotor, 
				1 => sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.RightMotor, 
				_ => 0f, 
			};
		}

		float IControllerVibrator.GetVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetVibration
			return this.GetVibration(motorIndex);
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled && sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
			{
				for (int i = 0; i < sLPflhyTxwKGcgrrLnDvjxJwFyTe.hWOdTudzrFRcBJMPgYEbqgWRUEJb; i++)
				{
					KyqPqttyYQEUqocyyXQoBRYHXflF[i].Clear();
				}
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.StopVibration();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled)
			{
				return 0f;
			}
			if (!sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LeftMotor, 
				1 => sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.RightMotor, 
				_ => throw new NotImplementedException(), 
			};
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
			}
			else
			{
				if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < sLPflhyTxwKGcgrrLnDvjxJwFyTe.hWOdTudzrFRcBJMPgYEbqgWRUEJb; i++)
					{
						KyqPqttyYQEUqocyyXQoBRYHXflF[i].Clear();
					}
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LeftMotor = motorLevel;
					break;
				case 1:
					sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				unbzGisXzadaNYzeLequUKloBeGw(motor, motorLevel, duration);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
		}

		void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(leftMotorLevel, rightMotorLevel);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled && sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.RightMotor = MathTools.Clamp01(rightMotorLevel);
				unbzGisXzadaNYzeLequUKloBeGw(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				unbzGisXzadaNYzeLequUKloBeGw(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		void IDualShock4Extension.SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(leftMotorLevel, rightMotorLevel, leftMotorDuration, rightMotorDuration);
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA)
			{
				return default(Color);
			}
			return new Color(sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorR, sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorG, sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorR = color.r * color.a;
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorG = color.g * color.a;
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorB = color.b * color.a;
			}
		}

		void IDualShock4Extension.SetLightColor(Color color)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(color);
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

		void IDualShock4Extension.SetLightColor(float red, float green, float blue)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue);
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorR = red * intensity;
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorG = green * intensity;
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightColorB = blue * intensity;
			}
		}

		void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue, intensity);
		}

		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightFlashOnDuration = onDuration;
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.AccelerometerValueRaw;
		}

		Vector3 IDualShock4Extension.GetAccelerometerValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValueRaw
			return this.GetAccelerometerValueRaw();
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.AccelerometerValue;
		}

		Vector3 IDualShock4Extension.GetAccelerometerValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetAccelerometerValue
			return this.GetAccelerometerValue();
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.Orientation;
		}

		Quaternion IDualShock4Extension.GetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetOrientation
			return this.GetOrientation();
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (IzaYrAWNaCpapepvjdcKbQEYJmLMA)
			{
				sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.ResetOrientation();
			}
		}

		void IDualShock4Extension.ResetOrientation()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ResetOrientation
			this.ResetOrientation();
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchIdAtIndex(index);
		}

		int IDualShock4Extension.GetTouchId(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchId
			return this.GetTouchId(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchPositionByIndex(index, out position);
		}

		bool IDualShock4Extension.GetTouchPosition(int index, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPosition
			return this.GetTouchPosition(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchPositionByTouchId(touchId, out position);
		}

		bool IDualShock4Extension.GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTouchPositionByTouchId
			return this.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
			position = new Vector2(positionX, positionY);
			return touchPositionAbsoluteByTouchId;
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.IsTouchingAtIndex(index);
		}

		bool IDualShock4Extension.IsTouching(int index)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouching
			return this.IsTouching(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA.IsTouchingAtTouchId(touchId);
		}

		bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
			return this.IsTouchingByTouchId(touchId);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return GetGyroscopeValueRaw();
		}

		internal void LwuKmRHkAZDtvkijEXHwvvvOtOEVA(UpdateLoopType P_0)
		{
			if (IzaYrAWNaCpapepvjdcKbQEYJmLMA && base.enabled)
			{
				cfaabhdjXZzSCJtnDilszPyYpAai();
			}
		}

		internal void xXwScniPmIASxhVAYHozIEIHTgCMb(IControllerExtensionSource P_0)
		{
			sLPflhyTxwKGcgrrLnDvjxJwFyTe = P_0 as SioPzDNflmQdBGScWCHPMwikAkdN;
			IzaYrAWNaCpapepvjdcKbQEYJmLMA = sLPflhyTxwKGcgrrLnDvjxJwFyTe != null && sLPflhyTxwKGcgrrLnDvjxJwFyTe.SvXIbinBGtiNrIOGDzKitHGXgbzAA != null;
		}

		internal Controller.Extension WvAevALUvwGLrFyZzbeBLLpYzYDCA()
		{
			return new DualShock4Extension(this);
		}

		private void cfaabhdjXZzSCJtnDilszPyYpAai()
		{
			if (!IzaYrAWNaCpapepvjdcKbQEYJmLMA || !sLPflhyTxwKGcgrrLnDvjxJwFyTe.VULMZuHSYDoNXhQpgLNJzLJoAlpv)
			{
				return;
			}
			for (int i = 0; i < sLPflhyTxwKGcgrrLnDvjxJwFyTe.hWOdTudzrFRcBJMPgYEbqgWRUEJb; i++)
			{
				if (KyqPqttyYQEUqocyyXQoBRYHXflF[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void unbzGisXzadaNYzeLequUKloBeGw(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				KyqPqttyYQEUqocyyXQoBRYHXflF[num].Clear();
			}
			else
			{
				KyqPqttyYQEUqocyyXQoBRYHXflF[num].Start(P_2);
			}
		}
	}
}
