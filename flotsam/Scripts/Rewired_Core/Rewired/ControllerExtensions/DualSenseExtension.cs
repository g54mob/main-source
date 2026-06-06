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
		private class OVEDfSdyaYjRNKysiuuMxpqyYVZi : IControllerExtensionSource
		{
			public readonly IDriver_DualSense wUatYyMxhIOTwBsSiUNnLxMDNTXj;

			public readonly bool JeBNFkPWEkQLpzfKAmmFRVwxgzAv;

			public readonly int BJqhDOLHIvXHMjWoIwKupWJkvcVV;

			public OVEDfSdyaYjRNKysiuuMxpqyYVZi(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				wUatYyMxhIOTwBsSiUNnLxMDNTXj = P_0;
				JeBNFkPWEkQLpzfKAmmFRVwxgzAv = P_1;
				BJqhDOLHIvXHMjWoIwKupWJkvcVV = P_2;
			}
		}

		private OVEDfSdyaYjRNKysiuuMxpqyYVZi QzcsQGmwcHzwOrgkzGdwSjAooUUt;

		private bool WSuYBvJGVvHyUnjlAcHbSjMLZFnd;

		private TimerAbs[] XTZLJYwVhHtpSzFygPWMevlYrfFu;

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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					return 0;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.BJqhDOLHIvXHMjWoIwKupWJkvcVV;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return 0f;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorR;
			}
			set
			{
				if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorR = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return 0f;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorG;
			}
			set
			{
				if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorG = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return 0f;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorB;
			}
			set
			{
				if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorB = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.microphoneLightMode = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.otherLightBrightness = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
				{
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.playerLights = value;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					return 0;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.MaxTouches;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchCount();
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					return 0f;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.BatteryLevel;
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
				{
					return false;
				}
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.BatteryCharging;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.vendorId;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.productId;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.productName;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.manufacturer;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.usagePage;
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
				return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.usage;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new OVEDfSdyaYjRNKysiuuMxpqyYVZi(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			XTZLJYwVhHtpSzFygPWMevlYrfFu = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(XTZLJYwVhHtpSzFygPWMevlYrfFu, 0, XTZLJYwVhHtpSzFygPWMevlYrfFu.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				XTZLJYwVhHtpSzFygPWMevlYrfFu = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				XTZLJYwVhHtpSzFygPWMevlYrfFu = new TimerAbs[0];
			}
			ArrayTools.Populate(XTZLJYwVhHtpSzFygPWMevlYrfFu, 0, XTZLJYwVhHtpSzFygPWMevlYrfFu.Length);
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
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled && motorIndex >= 0 && motorIndex < QzcsQGmwcHzwOrgkzGdwSjAooUUt.BJqhDOLHIvXHMjWoIwKupWJkvcVV)
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
			{
				return 0f;
			}
			if (!QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LeftMotor, 
				1 => QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.RightMotor, 
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
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled && QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
			{
				for (int i = 0; i < QzcsQGmwcHzwOrgkzGdwSjAooUUt.BJqhDOLHIvXHMjWoIwKupWJkvcVV; i++)
				{
					XTZLJYwVhHtpSzFygPWMevlYrfFu[i].Clear();
				}
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.StopVibration();
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
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled)
			{
				return 0f;
			}
			if (!QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LeftMotor, 
				1 => QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.RightMotor, 
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
				if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < QzcsQGmwcHzwOrgkzGdwSjAooUUt.BJqhDOLHIvXHMjWoIwKupWJkvcVV; i++)
					{
						XTZLJYwVhHtpSzFygPWMevlYrfFu[i].Clear();
					}
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LeftMotor = motorLevel;
					break;
				case 1:
					QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				yTWsNxXjRVizuQRbgHIiXTFgaont(motor, motorLevel, duration);
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
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled && QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
			{
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.RightMotor = MathTools.Clamp01(rightMotorLevel);
				yTWsNxXjRVizuQRbgHIiXTFgaont(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				yTWsNxXjRVizuQRbgHIiXTFgaont(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
			{
				return default(Color);
			}
			return new Color(QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorR, QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorG, QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
			{
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorR = color.r * color.a;
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorG = color.g * color.a;
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorB = color.b * color.a;
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
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
			{
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorR = red * intensity;
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorG = green * intensity;
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LightColorB = blue * intensity;
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.AccelerometerValueRaw;
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.AccelerometerValue;
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.Orientation;
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
			else if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd)
			{
				QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.ResetOrientation();
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchIdAtIndex(index);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchPositionByIndex(index, out position);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchPositionByTouchId(touchId, out position);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.IsTouchingAtIndex(index);
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
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.IsTouchingAtTouchId(touchId);
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
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.SetTriggerEffect(trigger, effect);
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
			return QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj.GetTriggerEffectStates();
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
			if (WSuYBvJGVvHyUnjlAcHbSjMLZFnd && base.enabled)
			{
				rDtWVxPOSuvdJEKphJzDyyIeBBmP();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			QzcsQGmwcHzwOrgkzGdwSjAooUUt = source as OVEDfSdyaYjRNKysiuuMxpqyYVZi;
			WSuYBvJGVvHyUnjlAcHbSjMLZFnd = QzcsQGmwcHzwOrgkzGdwSjAooUUt != null && QzcsQGmwcHzwOrgkzGdwSjAooUUt.wUatYyMxhIOTwBsSiUNnLxMDNTXj != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void rDtWVxPOSuvdJEKphJzDyyIeBBmP()
		{
			if (!WSuYBvJGVvHyUnjlAcHbSjMLZFnd || !QzcsQGmwcHzwOrgkzGdwSjAooUUt.JeBNFkPWEkQLpzfKAmmFRVwxgzAv)
			{
				return;
			}
			for (int i = 0; i < QzcsQGmwcHzwOrgkzGdwSjAooUUt.BJqhDOLHIvXHMjWoIwKupWJkvcVV; i++)
			{
				if (XTZLJYwVhHtpSzFygPWMevlYrfFu[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void yTWsNxXjRVizuQRbgHIiXTFgaont(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				XTZLJYwVhHtpSzFygPWMevlYrfFu[num].Clear();
			}
			else
			{
				XTZLJYwVhHtpSzFygPWMevlYrfFu[num].Start(P_2);
			}
		}
	}
}
