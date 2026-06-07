using System;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualSenseExtension, IDualShock4Extension, IHIDControllerExtension
	{
		private class ZfiGurFKzwXYncFvIrUVBomSgNCHb : IControllerExtensionSource
		{
			public readonly IDriver_DualSense yDAUNClHHiAuOvIuDIwdGGkWSXRe;

			public readonly bool rPrsppgJoLZNESoZrflzwqCEQiFO;

			public readonly int gExXpPJRmQHjBkMeRNtbKgelRgwx;

			public ZfiGurFKzwXYncFvIrUVBomSgNCHb(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				yDAUNClHHiAuOvIuDIwdGGkWSXRe = P_0;
				rPrsppgJoLZNESoZrflzwqCEQiFO = P_1;
				gExXpPJRmQHjBkMeRNtbKgelRgwx = P_2;
			}
		}

		private ZfiGurFKzwXYncFvIrUVBomSgNCHb CLFHWOuPSRLahPSSrSHZoiqMbYrk;

		private bool khVRRDZeyAQMCtyEScaUzBYcNoig;

		private TimerAbs[] yekhXxBxPOvvGNgoOsAvEoxWLuBV;

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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.gExXpPJRmQHjBkMeRNtbKgelRgwx;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return 0f;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorR;
			}
			set
			{
				if (khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorR = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return 0f;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorG;
			}
			set
			{
				if (khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorG = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return 0f;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorB;
			}
			set
			{
				if (khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorB = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.microphoneLightMode = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.otherLightBrightness = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
				{
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.playerLights = value;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					return 0;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.MaxTouches;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchCount();
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					return 0f;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.BatteryLevel;
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
				{
					return false;
				}
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.BatteryCharging;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.vendorId;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.productId;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.productName;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.manufacturer;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.usagePage;
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
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.usage;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new ZfiGurFKzwXYncFvIrUVBomSgNCHb(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			yekhXxBxPOvvGNgoOsAvEoxWLuBV = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(yekhXxBxPOvvGNgoOsAvEoxWLuBV, 0, yekhXxBxPOvvGNgoOsAvEoxWLuBV.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV = new TimerAbs[P_0.vibrationMotorCount];
			}
			catch
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV = new TimerAbs[0];
			}
			ArrayTools.Populate(yekhXxBxPOvvGNgoOsAvEoxWLuBV, 0, yekhXxBxPOvvGNgoOsAvEoxWLuBV.Length);
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
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled && motorIndex >= 0 && motorIndex < CLFHWOuPSRLahPSSrSHZoiqMbYrk.gExXpPJRmQHjBkMeRNtbKgelRgwx)
			{
				DualShock4MotorType motor;
				switch (motorIndex)
				{
				case 0:
					motor = DualShock4MotorType.LeftMotor;
					break;
				case 1:
					motor = DualShock4MotorType.RightMotor;
					break;
				default:
					throw new NotImplementedException();
				}
				SetVibration(motor, motorLevel, duration, stopOtherMotors);
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
			{
				return 0f;
			}
			if (!CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			case 0:
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LeftMotor;
			case 1:
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.RightMotor;
			default:
				return 0f;
			}
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled && CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				for (int i = 0; i < CLFHWOuPSRLahPSSrSHZoiqMbYrk.gExXpPJRmQHjBkMeRNtbKgelRgwx; i++)
				{
					yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
				}
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.StopVibration();
			}
		}

		public DualSenseVibrationMode GetVibrationMode()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return DualSenseVibrationMode.Compatible2;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled)
			{
				return 0f;
			}
			if (!CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return 0f;
			}
			switch ((int)motor)
			{
			case 0:
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LeftMotor;
			case 1:
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.RightMotor;
			default:
				throw new NotImplementedException();
			}
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
				if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < CLFHWOuPSRLahPSSrSHZoiqMbYrk.gExXpPJRmQHjBkMeRNtbKgelRgwx; i++)
					{
						yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
					}
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LeftMotor = motorLevel;
					break;
				case 1:
					CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(motor, motorLevel, duration);
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
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled && CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.RightMotor = MathTools.Clamp01(rightMotorLevel);
				QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig)
			{
				return default(Color);
			}
			return new Color(CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorR, CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorG, CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorR = color.r * color.a;
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorG = color.g * color.a;
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorB = color.b * color.a;
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
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorR = red * intensity;
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorG = green * intensity;
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LightColorB = blue * intensity;
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.AccelerometerValueRaw;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.AccelerometerValue;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.Orientation;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (khVRRDZeyAQMCtyEScaUzBYcNoig)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.ResetOrientation();
			}
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.IsTouchingAtIndex(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.IsTouchingAtTouchId(touchId);
		}

		public bool SetTriggerEffect(DualSenseTriggerType trigger, IDualSenseTriggerEffect effect)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.SetTriggerEffect(trigger, effect);
		}

		public DualSenseTriggerEffectStates GetTriggerEffectStates()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(DualSenseTriggerEffectStates);
			}
			return CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe.GetTriggerEffectStates();
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
			if (khVRRDZeyAQMCtyEScaUzBYcNoig && base.enabled)
			{
				pPYHierAOCbwuFIlzImlapEvgaTbA();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			CLFHWOuPSRLahPSSrSHZoiqMbYrk = source as ZfiGurFKzwXYncFvIrUVBomSgNCHb;
			khVRRDZeyAQMCtyEScaUzBYcNoig = CLFHWOuPSRLahPSSrSHZoiqMbYrk != null && CLFHWOuPSRLahPSSrSHZoiqMbYrk.yDAUNClHHiAuOvIuDIwdGGkWSXRe != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void pPYHierAOCbwuFIlzImlapEvgaTbA()
		{
			if (!khVRRDZeyAQMCtyEScaUzBYcNoig || !CLFHWOuPSRLahPSSrSHZoiqMbYrk.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return;
			}
			for (int i = 0; i < CLFHWOuPSRLahPSSrSHZoiqMbYrk.gExXpPJRmQHjBkMeRNtbKgelRgwx; i++)
			{
				if (yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num;
			switch (P_0)
			{
			case DualShock4MotorType.LeftMotor:
				num = 0;
				break;
			case DualShock4MotorType.RightMotor:
				num = 1;
				break;
			default:
				throw new NotImplementedException();
			}
			if (P_1 <= 0f || P_2 <= 0f)
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[num].Clear();
			}
			else
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[num].Start(P_2);
			}
		}
	}
}
