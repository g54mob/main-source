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
		private class BrFKpgEOoTbAQgWqoOqwgQyYYyLs : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 HEaaOHwJPGbesCaMltnDBjCpWrVr;

			public readonly bool EraHJLGaTeRsWropEkckLkBMOxXM;

			public readonly int godrtkakNewsrLMcWpexIAwxWJcJ;

			public BrFKpgEOoTbAQgWqoOqwgQyYYyLs(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				HEaaOHwJPGbesCaMltnDBjCpWrVr = P_0;
				EraHJLGaTeRsWropEkckLkBMOxXM = P_1;
				godrtkakNewsrLMcWpexIAwxWJcJ = P_2;
			}
		}

		private BrFKpgEOoTbAQgWqoOqwgQyYYyLs nSehWOjGhPbtUaxdxWCABdNMVdDB;

		private bool BILDhxADrpaBuCejJPJviyCrympac;

		private TimerAbs[] FyFBCYcYLfbutmUeSqVLrEQrNfHj;

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
				if (!BILDhxADrpaBuCejJPJviyCrympac)
				{
					return 0;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.godrtkakNewsrLMcWpexIAwxWJcJ;
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
				if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled)
				{
					return 0f;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorR;
			}
			set
			{
				if (BILDhxADrpaBuCejJPJviyCrympac)
				{
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorR = value;
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
				if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled)
				{
					return 0f;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorG;
			}
			set
			{
				if (BILDhxADrpaBuCejJPJviyCrympac)
				{
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorG = value;
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
				if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled)
				{
					return 0f;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorB;
			}
			set
			{
				if (BILDhxADrpaBuCejJPJviyCrympac)
				{
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorB = value;
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
				if (!BILDhxADrpaBuCejJPJviyCrympac)
				{
					return 0;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.MaxTouches;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchCount();
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
				if (!BILDhxADrpaBuCejJPJviyCrympac)
				{
					return 0f;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.BatteryLevel;
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
				if (!BILDhxADrpaBuCejJPJviyCrympac)
				{
					return false;
				}
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.BatteryCharging;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.vendorId;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.productId;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.productName;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.manufacturer;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.usagePage;
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
				return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.usage;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new BrFKpgEOoTbAQgWqoOqwgQyYYyLs(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			FyFBCYcYLfbutmUeSqVLrEQrNfHj = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(FyFBCYcYLfbutmUeSqVLrEQrNfHj, 0, FyFBCYcYLfbutmUeSqVLrEQrNfHj.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				FyFBCYcYLfbutmUeSqVLrEQrNfHj = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				FyFBCYcYLfbutmUeSqVLrEQrNfHj = new TimerAbs[0];
			}
			ArrayTools.Populate(FyFBCYcYLfbutmUeSqVLrEQrNfHj, 0, FyFBCYcYLfbutmUeSqVLrEQrNfHj.Length);
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
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled && motorIndex >= 0 && motorIndex < nSehWOjGhPbtUaxdxWCABdNMVdDB.godrtkakNewsrLMcWpexIAwxWJcJ)
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled)
			{
				return 0f;
			}
			if (!nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LeftMotor, 
				1 => nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.RightMotor, 
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
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled && nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
			{
				for (int i = 0; i < nSehWOjGhPbtUaxdxWCABdNMVdDB.godrtkakNewsrLMcWpexIAwxWJcJ; i++)
				{
					FyFBCYcYLfbutmUeSqVLrEQrNfHj[i].Clear();
				}
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.StopVibration();
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled)
			{
				return 0f;
			}
			if (!nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LeftMotor, 
				1 => nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.RightMotor, 
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
				if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < nSehWOjGhPbtUaxdxWCABdNMVdDB.godrtkakNewsrLMcWpexIAwxWJcJ; i++)
					{
						FyFBCYcYLfbutmUeSqVLrEQrNfHj[i].Clear();
					}
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LeftMotor = motorLevel;
					break;
				case 1:
					nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				hoIDCTjveBpTUFSmpnDFaafgQmoJb(motor, motorLevel, duration);
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
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled && nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.RightMotor = MathTools.Clamp01(rightMotorLevel);
				hoIDCTjveBpTUFSmpnDFaafgQmoJb(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				hoIDCTjveBpTUFSmpnDFaafgQmoJb(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac)
			{
				return default(Color);
			}
			return new Color(nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorR, nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorG, nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorR = color.r * color.a;
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorG = color.g * color.a;
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorB = color.b * color.a;
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
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorR = red * intensity;
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorG = green * intensity;
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightColorB = blue * intensity;
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
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightFlashOnDuration = onDuration;
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.AccelerometerValueRaw;
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.AccelerometerValue;
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.Orientation;
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
			else if (BILDhxADrpaBuCejJPJviyCrympac)
			{
				nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.ResetOrientation();
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchIdAtIndex(index);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchPositionByIndex(index, out position);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchPositionByTouchId(touchId, out position);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.IsTouchingAtIndex(index);
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
			if (!BILDhxADrpaBuCejJPJviyCrympac || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr.IsTouchingAtTouchId(touchId);
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
			if (BILDhxADrpaBuCejJPJviyCrympac && base.enabled)
			{
				joTmbSeUPiKWDTfehHtRFgIadwCe();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			nSehWOjGhPbtUaxdxWCABdNMVdDB = source as BrFKpgEOoTbAQgWqoOqwgQyYYyLs;
			BILDhxADrpaBuCejJPJviyCrympac = nSehWOjGhPbtUaxdxWCABdNMVdDB != null && nSehWOjGhPbtUaxdxWCABdNMVdDB.HEaaOHwJPGbesCaMltnDBjCpWrVr != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void joTmbSeUPiKWDTfehHtRFgIadwCe()
		{
			if (!BILDhxADrpaBuCejJPJviyCrympac || !nSehWOjGhPbtUaxdxWCABdNMVdDB.EraHJLGaTeRsWropEkckLkBMOxXM)
			{
				return;
			}
			for (int i = 0; i < nSehWOjGhPbtUaxdxWCABdNMVdDB.godrtkakNewsrLMcWpexIAwxWJcJ; i++)
			{
				if (FyFBCYcYLfbutmUeSqVLrEQrNfHj[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void hoIDCTjveBpTUFSmpnDFaafgQmoJb(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				FyFBCYcYLfbutmUeSqVLrEQrNfHj[num].Clear();
			}
			else
			{
				FyFBCYcYLfbutmUeSqVLrEQrNfHj[num].Start(P_2);
			}
		}
	}
}
