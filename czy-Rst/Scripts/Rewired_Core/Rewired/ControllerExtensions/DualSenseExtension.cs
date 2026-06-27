using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension, IDualSenseExtension, IHIDControllerExtension
	{
		private class LlhvBXadvKBJqgTmFDPMIAjFiamBA : IControllerExtensionSource
		{
			public readonly IDriver_DualSense fHLKedZuLQiDPdfOPpKbeMLgdcam;

			public readonly bool UZyaNrWmBqXzKHhWnmRZcvfIIDdt;

			public readonly int EyVJJZWuLfjxhFagjdLcIgCJIAqo;

			public LlhvBXadvKBJqgTmFDPMIAjFiamBA(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				fHLKedZuLQiDPdfOPpKbeMLgdcam = P_0;
				UZyaNrWmBqXzKHhWnmRZcvfIIDdt = P_1;
				EyVJJZWuLfjxhFagjdLcIgCJIAqo = P_2;
			}
		}

		private LlhvBXadvKBJqgTmFDPMIAjFiamBA XkDChJdgtLbHzLfwSrYatrBBEyto;

		private bool PrLDCgHYJrXdtPNzjBFlxdugapSoA;

		private TimerAbs[] IJgCRFbOwFfFrgVoZynUfHersBuY;

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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					return 0;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.EyVJJZWuLfjxhFagjdLcIgCJIAqo;
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return 0f;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorR;
			}
			set
			{
				if (PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorR = value;
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return 0f;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorG;
			}
			set
			{
				if (PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorG = value;
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return 0f;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorB;
			}
			set
			{
				if (PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorB = value;
				}
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSenseMicrophoneLightMode.Off;
				}
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.microphoneLightMode = value;
				}
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return DualSenseOtherLightBrightness.High;
				}
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.otherLightBrightness = value;
				}
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
				{
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.playerLights = value;
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					return 0;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.MaxTouches;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchCount();
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					return 0f;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.BatteryLevel;
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA)
				{
					return false;
				}
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.BatteryCharging;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.vendorId;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.productId;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.productName;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.manufacturer;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.usagePage;
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
				return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.usage;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new LlhvBXadvKBJqgTmFDPMIAjFiamBA(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			IJgCRFbOwFfFrgVoZynUfHersBuY = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(IJgCRFbOwFfFrgVoZynUfHersBuY, 0, IJgCRFbOwFfFrgVoZynUfHersBuY.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				IJgCRFbOwFfFrgVoZynUfHersBuY = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				IJgCRFbOwFfFrgVoZynUfHersBuY = new TimerAbs[0];
			}
			ArrayTools.Populate(IJgCRFbOwFfFrgVoZynUfHersBuY, 0, IJgCRFbOwFfFrgVoZynUfHersBuY.Length);
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
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled && motorIndex >= 0 && motorIndex < XkDChJdgtLbHzLfwSrYatrBBEyto.EyVJJZWuLfjxhFagjdLcIgCJIAqo)
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
			{
				return 0f;
			}
			if (!XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LeftMotor, 
				1 => XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.RightMotor, 
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
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled && XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
			{
				for (int i = 0; i < XkDChJdgtLbHzLfwSrYatrBBEyto.EyVJJZWuLfjxhFagjdLcIgCJIAqo; i++)
				{
					IJgCRFbOwFfFrgVoZynUfHersBuY[i].Clear();
				}
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.StopVibration();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public DualSenseVibrationMode GetVibrationMode()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSenseVibrationMode.Compatible2;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled)
			{
				return 0f;
			}
			if (!XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LeftMotor, 
				1 => XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.RightMotor, 
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
				if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < XkDChJdgtLbHzLfwSrYatrBBEyto.EyVJJZWuLfjxhFagjdLcIgCJIAqo; i++)
					{
						IJgCRFbOwFfFrgVoZynUfHersBuY[i].Clear();
					}
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LeftMotor = motorLevel;
					break;
				case 1:
					XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				lIpTGuWOJVBqRyhgHzacgSVXCCGh(motor, motorLevel, duration);
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
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled && XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
			{
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.RightMotor = MathTools.Clamp01(rightMotorLevel);
				lIpTGuWOJVBqRyhgHzacgSVXCCGh(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				lIpTGuWOJVBqRyhgHzacgSVXCCGh(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA)
			{
				return default(Color);
			}
			return new Color(XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorR, XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorG, XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
			{
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorR = color.r * color.a;
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorG = color.g * color.a;
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorB = color.b * color.a;
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
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
			{
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorR = red * intensity;
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorG = green * intensity;
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LightColorB = blue * intensity;
			}
		}

		void IDualShock4Extension.SetLightColor(float red, float green, float blue, float intensity)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetLightColor
			this.SetLightColor(red, green, blue, intensity);
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.AccelerometerValueRaw;
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.AccelerometerValue;
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.Orientation;
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
			else if (PrLDCgHYJrXdtPNzjBFlxdugapSoA)
			{
				XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.ResetOrientation();
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchIdAtIndex(index);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchPositionByIndex(index, out position);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchPositionByTouchId(touchId, out position);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.IsTouchingAtIndex(index);
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
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.IsTouchingAtTouchId(touchId);
		}

		bool IDualShock4Extension.IsTouchingByTouchId(int touchId)
		{
			//ILSpy generated this explicit interface implementation from .override directive in IsTouchingByTouchId
			return this.IsTouchingByTouchId(touchId);
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.SetTriggerEffect(trigger, effect);
		}

		bool IDualSenseExtension.SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetTriggerEffect
			return this.SetTriggerEffect(trigger, effect);
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(DualSenseTriggerEffectStates);
			}
			return XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam.GetTriggerEffectStates();
		}

		DualSenseTriggerEffectStates IDualSenseExtension.GetTriggerEffectStates()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetTriggerEffectStates
			return this.GetTriggerEffectStates();
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
			if (PrLDCgHYJrXdtPNzjBFlxdugapSoA && base.enabled)
			{
				sYIFcsSBJqNgJevAKIPJBFOFpNpb();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			XkDChJdgtLbHzLfwSrYatrBBEyto = source as LlhvBXadvKBJqgTmFDPMIAjFiamBA;
			PrLDCgHYJrXdtPNzjBFlxdugapSoA = XkDChJdgtLbHzLfwSrYatrBBEyto != null && XkDChJdgtLbHzLfwSrYatrBBEyto.fHLKedZuLQiDPdfOPpKbeMLgdcam != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void sYIFcsSBJqNgJevAKIPJBFOFpNpb()
		{
			if (!PrLDCgHYJrXdtPNzjBFlxdugapSoA || !XkDChJdgtLbHzLfwSrYatrBBEyto.UZyaNrWmBqXzKHhWnmRZcvfIIDdt)
			{
				return;
			}
			for (int i = 0; i < XkDChJdgtLbHzLfwSrYatrBBEyto.EyVJJZWuLfjxhFagjdLcIgCJIAqo; i++)
			{
				if (IJgCRFbOwFfFrgVoZynUfHersBuY[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void lIpTGuWOJVBqRyhgHzacgSVXCCGh(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				IJgCRFbOwFfFrgVoZynUfHersBuY[num].Clear();
			}
			else
			{
				IJgCRFbOwFfFrgVoZynUfHersBuY[num].Start(P_2);
			}
		}
	}
}
