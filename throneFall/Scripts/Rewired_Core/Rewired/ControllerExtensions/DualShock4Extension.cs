using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IHIDControllerExtension
	{
		private class hYAUXTBNeRtjuNGdxIrRXRQDISbS : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 lQhNlazzFOWLWFkFuCmcFwicnJtFA;

			public readonly bool sYxqHqRTRmNniqDkZfALwgrXIDrq;

			public readonly int KicaSTIdgofXJCAFcLkMDjWEokkYc;

			public hYAUXTBNeRtjuNGdxIrRXRQDISbS(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				lQhNlazzFOWLWFkFuCmcFwicnJtFA = P_0;
				sYxqHqRTRmNniqDkZfALwgrXIDrq = P_1;
				KicaSTIdgofXJCAFcLkMDjWEokkYc = P_2;
			}
		}

		private hYAUXTBNeRtjuNGdxIrRXRQDISbS NHbYMpuPSTiKRragwtFzegBFUzDV;

		private bool lnMYyQCzAlsRMreSSIqKHcqvSbNG;

		private TimerAbs[] fpKjyxzdXdXGPrivLIpoALaeidpjA;

		private Joystick joystick => GetController<Joystick>();

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.KicaSTIdgofXJCAFcLkMDjWEokkYc;
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled)
				{
					return 0f;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorR;
			}
			set
			{
				if (lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorR = value;
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled)
				{
					return 0f;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorG;
			}
			set
			{
				if (lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorG = value;
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled)
				{
					return 0f;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorB;
			}
			set
			{
				if (lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorB = value;
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.MaxTouches;
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
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchCount();
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					return 0f;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.BatteryLevel;
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG)
				{
					return false;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.BatteryCharging;
			}
		}

		ushort IHIDControllerExtension.vendorId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.vendorId;
			}
		}

		ushort IHIDControllerExtension.productId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.productId;
			}
		}

		string IHIDControllerExtension.productName
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.productName;
			}
		}

		string IHIDControllerExtension.manufacturer
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return string.Empty;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.manufacturer;
			}
		}

		ushort IHIDControllerExtension.usagePage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.usagePage;
			}
		}

		ushort IHIDControllerExtension.usage
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.usage;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new hYAUXTBNeRtjuNGdxIrRXRQDISbS(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			fpKjyxzdXdXGPrivLIpoALaeidpjA = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(fpKjyxzdXdXGPrivLIpoALaeidpjA, 0, fpKjyxzdXdXGPrivLIpoALaeidpjA.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				fpKjyxzdXdXGPrivLIpoALaeidpjA = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				fpKjyxzdXdXGPrivLIpoALaeidpjA = new TimerAbs[0];
			}
			ArrayTools.Populate(fpKjyxzdXdXGPrivLIpoALaeidpjA, 0, fpKjyxzdXdXGPrivLIpoALaeidpjA.Length);
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled && motorIndex >= 0 && motorIndex < NHbYMpuPSTiKRragwtFzegBFUzDV.KicaSTIdgofXJCAFcLkMDjWEokkYc)
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled)
			{
				return 0f;
			}
			if (!NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LeftMotor, 
				1 => NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.RightMotor, 
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled && NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
			{
				for (int i = 0; i < NHbYMpuPSTiKRragwtFzegBFUzDV.KicaSTIdgofXJCAFcLkMDjWEokkYc; i++)
				{
					fpKjyxzdXdXGPrivLIpoALaeidpjA[i].Clear();
				}
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.StopVibration();
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled)
			{
				return 0f;
			}
			if (!NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LeftMotor, 
				1 => NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.RightMotor, 
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
				if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < NHbYMpuPSTiKRragwtFzegBFUzDV.KicaSTIdgofXJCAFcLkMDjWEokkYc; i++)
					{
						fpKjyxzdXdXGPrivLIpoALaeidpjA[i].Clear();
					}
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LeftMotor = motorLevel;
					break;
				case 1:
					NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				LaDxXqosEHiHwTbGeOfaXkJJKZOJ(motor, motorLevel, duration);
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled && NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.RightMotor = MathTools.Clamp01(rightMotorLevel);
				LaDxXqosEHiHwTbGeOfaXkJJKZOJ(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				LaDxXqosEHiHwTbGeOfaXkJJKZOJ(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG)
			{
				return default(Color);
			}
			return new Color(NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorR, NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorG, NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorR = color.r * color.a;
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorG = color.g * color.a;
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorB = color.b * color.a;
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorR = red * intensity;
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorG = green * intensity;
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightColorB = blue * intensity;
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightFlashOnDuration = onDuration;
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.AccelerometerValueRaw;
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.AccelerometerValue;
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.Orientation;
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
			else if (lnMYyQCzAlsRMreSSIqKHcqvSbNG)
			{
				NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.ResetOrientation();
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchIdAtIndex(index);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchPositionByIndex(index, out position);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchPositionByTouchId(touchId, out position);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.IsTouchingAtIndex(index);
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
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA.IsTouchingAtTouchId(touchId);
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

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			if (lnMYyQCzAlsRMreSSIqKHcqvSbNG && base.enabled)
			{
				FcWBLfehGmmphBWsksKuAiUcvFwbB();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			NHbYMpuPSTiKRragwtFzegBFUzDV = source as hYAUXTBNeRtjuNGdxIrRXRQDISbS;
			lnMYyQCzAlsRMreSSIqKHcqvSbNG = NHbYMpuPSTiKRragwtFzegBFUzDV != null && NHbYMpuPSTiKRragwtFzegBFUzDV.lQhNlazzFOWLWFkFuCmcFwicnJtFA != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void FcWBLfehGmmphBWsksKuAiUcvFwbB()
		{
			if (!lnMYyQCzAlsRMreSSIqKHcqvSbNG || !NHbYMpuPSTiKRragwtFzegBFUzDV.sYxqHqRTRmNniqDkZfALwgrXIDrq)
			{
				return;
			}
			for (int i = 0; i < NHbYMpuPSTiKRragwtFzegBFUzDV.KicaSTIdgofXJCAFcLkMDjWEokkYc; i++)
			{
				if (fpKjyxzdXdXGPrivLIpoALaeidpjA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void LaDxXqosEHiHwTbGeOfaXkJJKZOJ(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				fpKjyxzdXdXGPrivLIpoALaeidpjA[num].Clear();
			}
			else
			{
				fpKjyxzdXdXGPrivLIpoALaeidpjA[num].Start(P_2);
			}
		}
	}
}
