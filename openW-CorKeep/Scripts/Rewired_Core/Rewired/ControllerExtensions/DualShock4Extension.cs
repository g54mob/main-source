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
		private class MoiheqxcDZiFDJWKQCNZCIhWRbmJ : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 KHLuMBNsyUAhdNfcDKZqzgFlWScN;

			public readonly bool BoNDsNnIsgUfFiEJuIYBzXEACUmt;

			public readonly int jPUipwNTLabOoMTwwBSGszzbvKZi;

			public MoiheqxcDZiFDJWKQCNZCIhWRbmJ(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				KHLuMBNsyUAhdNfcDKZqzgFlWScN = P_0;
				BoNDsNnIsgUfFiEJuIYBzXEACUmt = P_1;
				jPUipwNTLabOoMTwwBSGszzbvKZi = P_2;
			}
		}

		private MoiheqxcDZiFDJWKQCNZCIhWRbmJ knLQlMEZpXLPctYHXWuhxDeGLgWS;

		private bool KegfgrwnQthEltcTlbzOKlFyfBOo;

		private TimerAbs[] WDagFCFTwnSNiDdKsnGgkRHfMakqA;

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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					return 0;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.jPUipwNTLabOoMTwwBSGszzbvKZi;
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled)
				{
					return 0f;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorR;
			}
			set
			{
				if (KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorR = value;
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled)
				{
					return 0f;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorG;
			}
			set
			{
				if (KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorG = value;
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled)
				{
					return 0f;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorB;
			}
			set
			{
				if (KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorB = value;
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					return 0;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.MaxTouches;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchCount();
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					return 0f;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.BatteryLevel;
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo)
				{
					return false;
				}
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.BatteryCharging;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.vendorId;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.productId;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.productName;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.manufacturer;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.usagePage;
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
				return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.usage;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new MoiheqxcDZiFDJWKQCNZCIhWRbmJ(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			WDagFCFTwnSNiDdKsnGgkRHfMakqA = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(WDagFCFTwnSNiDdKsnGgkRHfMakqA, 0, WDagFCFTwnSNiDdKsnGgkRHfMakqA.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				WDagFCFTwnSNiDdKsnGgkRHfMakqA = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				WDagFCFTwnSNiDdKsnGgkRHfMakqA = new TimerAbs[0];
			}
			ArrayTools.Populate(WDagFCFTwnSNiDdKsnGgkRHfMakqA, 0, WDagFCFTwnSNiDdKsnGgkRHfMakqA.Length);
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled && motorIndex >= 0 && motorIndex < knLQlMEZpXLPctYHXWuhxDeGLgWS.jPUipwNTLabOoMTwwBSGszzbvKZi)
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled)
			{
				return 0f;
			}
			if (!knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LeftMotor, 
				1 => knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.RightMotor, 
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled && knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
			{
				for (int i = 0; i < knLQlMEZpXLPctYHXWuhxDeGLgWS.jPUipwNTLabOoMTwwBSGszzbvKZi; i++)
				{
					WDagFCFTwnSNiDdKsnGgkRHfMakqA[i].Clear();
				}
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.StopVibration();
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled)
			{
				return 0f;
			}
			if (!knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LeftMotor, 
				1 => knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.RightMotor, 
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
				if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < knLQlMEZpXLPctYHXWuhxDeGLgWS.jPUipwNTLabOoMTwwBSGszzbvKZi; i++)
					{
						WDagFCFTwnSNiDdKsnGgkRHfMakqA[i].Clear();
					}
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LeftMotor = motorLevel;
					break;
				case 1:
					knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				aNlUfTITDNllTTxMBnvuGkeUTKNg(motor, motorLevel, duration);
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled && knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.RightMotor = MathTools.Clamp01(rightMotorLevel);
				aNlUfTITDNllTTxMBnvuGkeUTKNg(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				aNlUfTITDNllTTxMBnvuGkeUTKNg(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo)
			{
				return default(Color);
			}
			return new Color(knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorR, knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorG, knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorR = color.r * color.a;
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorG = color.g * color.a;
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorB = color.b * color.a;
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorR = red * intensity;
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorG = green * intensity;
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightColorB = blue * intensity;
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightFlashOnDuration = onDuration;
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.AccelerometerValueRaw;
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.AccelerometerValue;
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.Orientation;
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
			else if (KegfgrwnQthEltcTlbzOKlFyfBOo)
			{
				knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.ResetOrientation();
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchIdAtIndex(index);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchPositionByIndex(index, out position);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchPositionByTouchId(touchId, out position);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.IsTouchingAtIndex(index);
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
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN.IsTouchingAtTouchId(touchId);
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
			if (KegfgrwnQthEltcTlbzOKlFyfBOo && base.enabled)
			{
				cRuNuQBifgfsIWsDTNlslbvqMOrM();
			}
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			knLQlMEZpXLPctYHXWuhxDeGLgWS = source as MoiheqxcDZiFDJWKQCNZCIhWRbmJ;
			KegfgrwnQthEltcTlbzOKlFyfBOo = knLQlMEZpXLPctYHXWuhxDeGLgWS != null && knLQlMEZpXLPctYHXWuhxDeGLgWS.KHLuMBNsyUAhdNfcDKZqzgFlWScN != null;
		}

		internal override Controller.Extension Clone()
		{
			return new DualShock4Extension(this);
		}

		private void cRuNuQBifgfsIWsDTNlslbvqMOrM()
		{
			if (!KegfgrwnQthEltcTlbzOKlFyfBOo || !knLQlMEZpXLPctYHXWuhxDeGLgWS.BoNDsNnIsgUfFiEJuIYBzXEACUmt)
			{
				return;
			}
			for (int i = 0; i < knLQlMEZpXLPctYHXWuhxDeGLgWS.jPUipwNTLabOoMTwwBSGszzbvKZi; i++)
			{
				if (WDagFCFTwnSNiDdKsnGgkRHfMakqA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void aNlUfTITDNllTTxMBnvuGkeUTKNg(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				WDagFCFTwnSNiDdKsnGgkRHfMakqA[num].Clear();
			}
			else
			{
				WDagFCFTwnSNiDdKsnGgkRHfMakqA[num].Start(P_2);
			}
		}
	}
}
