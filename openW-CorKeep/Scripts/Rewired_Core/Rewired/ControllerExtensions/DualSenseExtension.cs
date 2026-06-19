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
		private class GcGgzHZvUQxhlltSpEdbmAkJiVFFA : IControllerExtensionSource
		{
			public readonly IDriver_DualSense aYupGxwiFUpSWyvqfsDIGlGaiIPU;

			public readonly bool JCHbXfGnuuHRRXUgZVdiBCuYBuCfb;

			public readonly int FqoEZNejulGVsuAIPuHNwePZBvPCb;

			public GcGgzHZvUQxhlltSpEdbmAkJiVFFA(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				aYupGxwiFUpSWyvqfsDIGlGaiIPU = P_0;
				JCHbXfGnuuHRRXUgZVdiBCuYBuCfb = P_1;
				FqoEZNejulGVsuAIPuHNwePZBvPCb = P_2;
			}
		}

		private GcGgzHZvUQxhlltSpEdbmAkJiVFFA GcyVONCkANBniEkMmguPROCNETUR;

		private bool WpgGhwbmazLToEHHPpeUHfbgfSbY;

		private TimerAbs[] DzHxVDKyJBrrqEPYhbRpFlhnseThA;

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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					return 0;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.FqoEZNejulGVsuAIPuHNwePZBvPCb;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return 0f;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorR;
			}
			set
			{
				if (WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorR = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return 0f;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorG;
			}
			set
			{
				if (WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorG = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return 0f;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorB;
			}
			set
			{
				if (WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorB = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.microphoneLightMode = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.otherLightBrightness = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
				{
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.playerLights = value;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					return 0;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.MaxTouches;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchCount();
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					return 0f;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.BatteryLevel;
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY)
				{
					return false;
				}
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.BatteryCharging;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.vendorId;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.productId;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.productName;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.manufacturer;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.usagePage;
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
				return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.usage;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new GcGgzHZvUQxhlltSpEdbmAkJiVFFA(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			DzHxVDKyJBrrqEPYhbRpFlhnseThA = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(DzHxVDKyJBrrqEPYhbRpFlhnseThA, 0, DzHxVDKyJBrrqEPYhbRpFlhnseThA.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				DzHxVDKyJBrrqEPYhbRpFlhnseThA = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				DzHxVDKyJBrrqEPYhbRpFlhnseThA = new TimerAbs[0];
			}
			ArrayTools.Populate(DzHxVDKyJBrrqEPYhbRpFlhnseThA, 0, DzHxVDKyJBrrqEPYhbRpFlhnseThA.Length);
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
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled && motorIndex >= 0 && motorIndex < GcyVONCkANBniEkMmguPROCNETUR.FqoEZNejulGVsuAIPuHNwePZBvPCb)
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
			{
				return 0f;
			}
			if (!GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LeftMotor, 
				1 => GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.RightMotor, 
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
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled && GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
			{
				for (int i = 0; i < GcyVONCkANBniEkMmguPROCNETUR.FqoEZNejulGVsuAIPuHNwePZBvPCb; i++)
				{
					DzHxVDKyJBrrqEPYhbRpFlhnseThA[i].Clear();
				}
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.StopVibration();
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
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled)
			{
				return 0f;
			}
			if (!GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LeftMotor, 
				1 => GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.RightMotor, 
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
				if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < GcyVONCkANBniEkMmguPROCNETUR.FqoEZNejulGVsuAIPuHNwePZBvPCb; i++)
					{
						DzHxVDKyJBrrqEPYhbRpFlhnseThA[i].Clear();
					}
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LeftMotor = motorLevel;
					break;
				case 1:
					GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				ixQOXqhVpBKjOvXZfFJHOWPXarts(motor, motorLevel, duration);
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
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled && GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
			{
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.RightMotor = MathTools.Clamp01(rightMotorLevel);
				ixQOXqhVpBKjOvXZfFJHOWPXarts(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				ixQOXqhVpBKjOvXZfFJHOWPXarts(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY)
			{
				return default(Color);
			}
			return new Color(GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorR, GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorG, GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
			{
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorR = color.r * color.a;
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorG = color.g * color.a;
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorB = color.b * color.a;
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
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
			{
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorR = red * intensity;
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorG = green * intensity;
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LightColorB = blue * intensity;
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.AccelerometerValueRaw;
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.AccelerometerValue;
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.Orientation;
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
			else if (WpgGhwbmazLToEHHPpeUHfbgfSbY)
			{
				GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.ResetOrientation();
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchIdAtIndex(index);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchPositionByIndex(index, out position);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchPositionByTouchId(touchId, out position);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.IsTouchingAtIndex(index);
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
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.IsTouchingAtTouchId(touchId);
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
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.SetTriggerEffect(trigger, effect);
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
			return GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU.GetTriggerEffectStates();
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
			if (WpgGhwbmazLToEHHPpeUHfbgfSbY && base.enabled)
			{
				lAxSNwxqsyLfjnRLqUycjpENDCgQ();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			GcyVONCkANBniEkMmguPROCNETUR = source as GcGgzHZvUQxhlltSpEdbmAkJiVFFA;
			WpgGhwbmazLToEHHPpeUHfbgfSbY = GcyVONCkANBniEkMmguPROCNETUR != null && GcyVONCkANBniEkMmguPROCNETUR.aYupGxwiFUpSWyvqfsDIGlGaiIPU != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void lAxSNwxqsyLfjnRLqUycjpENDCgQ()
		{
			if (!WpgGhwbmazLToEHHPpeUHfbgfSbY || !GcyVONCkANBniEkMmguPROCNETUR.JCHbXfGnuuHRRXUgZVdiBCuYBuCfb)
			{
				return;
			}
			for (int i = 0; i < GcyVONCkANBniEkMmguPROCNETUR.FqoEZNejulGVsuAIPuHNwePZBvPCb; i++)
			{
				if (DzHxVDKyJBrrqEPYhbRpFlhnseThA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void ixQOXqhVpBKjOvXZfFJHOWPXarts(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				DzHxVDKyJBrrqEPYhbRpFlhnseThA[num].Clear();
			}
			else
			{
				DzHxVDKyJBrrqEPYhbRpFlhnseThA[num].Start(P_2);
			}
		}
	}
}
