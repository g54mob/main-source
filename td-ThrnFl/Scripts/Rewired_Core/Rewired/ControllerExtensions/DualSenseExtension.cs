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
		private class hxejSstGzMTgYbQpQEGpGnTQIQQYA : IControllerExtensionSource
		{
			public readonly IDriver_DualSense NWSxzOWyaCtZzenTKhmMPvdnPVSJ;

			public readonly bool osfogONGDcUQoItDqrOyHfNBpjHs;

			public readonly int akWkcuXoNrKOZCszkEuPlIqQbaEz;

			public hxejSstGzMTgYbQpQEGpGnTQIQQYA(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				NWSxzOWyaCtZzenTKhmMPvdnPVSJ = P_0;
				osfogONGDcUQoItDqrOyHfNBpjHs = P_1;
				akWkcuXoNrKOZCszkEuPlIqQbaEz = P_2;
			}
		}

		private hxejSstGzMTgYbQpQEGpGnTQIQQYA hvYmpwwhbTWmRGEbXiZNMTpKGYHz;

		private bool pcMrXZJJjnCFRYaoeWBCWCvtDVmD;

		private TimerAbs[] eVnquksyuPdaTOsrGuRruyYopxUE;

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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					return 0;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.akWkcuXoNrKOZCszkEuPlIqQbaEz;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return 0f;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorR;
			}
			set
			{
				if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorR = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return 0f;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorG;
			}
			set
			{
				if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorG = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return 0f;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorB;
			}
			set
			{
				if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorB = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.microphoneLightMode = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.otherLightBrightness = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
				{
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.playerLights = value;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					return 0;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.MaxTouches;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchCount();
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					return 0f;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.BatteryLevel;
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
				{
					return false;
				}
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.BatteryCharging;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.vendorId;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.productId;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.productName;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.manufacturer;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.usagePage;
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
				return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.usage;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new hxejSstGzMTgYbQpQEGpGnTQIQQYA(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			eVnquksyuPdaTOsrGuRruyYopxUE = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(eVnquksyuPdaTOsrGuRruyYopxUE, 0, eVnquksyuPdaTOsrGuRruyYopxUE.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				eVnquksyuPdaTOsrGuRruyYopxUE = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				eVnquksyuPdaTOsrGuRruyYopxUE = new TimerAbs[0];
			}
			ArrayTools.Populate(eVnquksyuPdaTOsrGuRruyYopxUE, 0, eVnquksyuPdaTOsrGuRruyYopxUE.Length);
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
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled && motorIndex >= 0 && motorIndex < hvYmpwwhbTWmRGEbXiZNMTpKGYHz.akWkcuXoNrKOZCszkEuPlIqQbaEz)
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
			{
				return 0f;
			}
			if (!hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LeftMotor, 
				1 => hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.RightMotor, 
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
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled && hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
			{
				for (int i = 0; i < hvYmpwwhbTWmRGEbXiZNMTpKGYHz.akWkcuXoNrKOZCszkEuPlIqQbaEz; i++)
				{
					eVnquksyuPdaTOsrGuRruyYopxUE[i].Clear();
				}
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.StopVibration();
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
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.vibrationMode;
		}

		public void SetVibrationMode(DualSenseVibrationMode mode)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.vibrationMode = mode;
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled)
			{
				return 0f;
			}
			if (!hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LeftMotor, 
				1 => hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.RightMotor, 
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
				if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < hvYmpwwhbTWmRGEbXiZNMTpKGYHz.akWkcuXoNrKOZCszkEuPlIqQbaEz; i++)
					{
						eVnquksyuPdaTOsrGuRruyYopxUE[i].Clear();
					}
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LeftMotor = motorLevel;
					break;
				case 1:
					hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				LXwXwPZvEHLmlzTqUvsLLFsEqqsm(motor, motorLevel, duration);
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
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled && hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
			{
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.RightMotor = MathTools.Clamp01(rightMotorLevel);
				LXwXwPZvEHLmlzTqUvsLLFsEqqsm(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				LXwXwPZvEHLmlzTqUvsLLFsEqqsm(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
			{
				return default(Color);
			}
			return new Color(hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorR, hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorG, hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
			{
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorR = color.r * color.a;
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorG = color.g * color.a;
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorB = color.b * color.a;
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
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
			{
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorR = red * intensity;
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorG = green * intensity;
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LightColorB = blue * intensity;
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.AccelerometerValueRaw;
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.AccelerometerValue;
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.Orientation;
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
			else if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD)
			{
				hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.ResetOrientation();
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchIdAtIndex(index);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchPositionByIndex(index, out position);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchPositionByTouchId(touchId, out position);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.IsTouchingAtIndex(index);
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
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.IsTouchingAtTouchId(touchId);
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
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.SetTriggerEffect(trigger, effect);
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
			return hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ.GetTriggerEffectStates();
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
			if (pcMrXZJJjnCFRYaoeWBCWCvtDVmD && base.enabled)
			{
				IuPwuXDtXqimIxucLTPiumrKHVxS();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			hvYmpwwhbTWmRGEbXiZNMTpKGYHz = source as hxejSstGzMTgYbQpQEGpGnTQIQQYA;
			pcMrXZJJjnCFRYaoeWBCWCvtDVmD = hvYmpwwhbTWmRGEbXiZNMTpKGYHz != null && hvYmpwwhbTWmRGEbXiZNMTpKGYHz.NWSxzOWyaCtZzenTKhmMPvdnPVSJ != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualSenseExtension(this);
		}

		private void IuPwuXDtXqimIxucLTPiumrKHVxS()
		{
			if (!pcMrXZJJjnCFRYaoeWBCWCvtDVmD || !hvYmpwwhbTWmRGEbXiZNMTpKGYHz.osfogONGDcUQoItDqrOyHfNBpjHs)
			{
				return;
			}
			for (int i = 0; i < hvYmpwwhbTWmRGEbXiZNMTpKGYHz.akWkcuXoNrKOZCszkEuPlIqQbaEz; i++)
			{
				if (eVnquksyuPdaTOsrGuRruyYopxUE[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void LXwXwPZvEHLmlzTqUvsLLFsEqqsm(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				eVnquksyuPdaTOsrGuRruyYopxUE[num].Clear();
			}
			else
			{
				eVnquksyuPdaTOsrGuRruyYopxUE[num].Start(P_2);
			}
		}
	}
}
