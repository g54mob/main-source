using System;
using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension
	{
		private class OOUAzmhrmdRifinivBwnHgrxziSTA : IControllerExtensionSource
		{
			public readonly IDriver_DualSense kKuOeEGGvjLJGbXOhYBGKmNMfnUJ;

			public readonly bool PHZTeYBuSHCqVVZIJmJsCwnsPzNi;

			public readonly int ROePjaXEAAiQeLOaVcYRuoIbrKMR;

			public OOUAzmhrmdRifinivBwnHgrxziSTA(IDriver_DualSense P_0, bool P_1, int P_2)
			{
				kKuOeEGGvjLJGbXOhYBGKmNMfnUJ = P_0;
				PHZTeYBuSHCqVVZIJmJsCwnsPzNi = P_1;
				ROePjaXEAAiQeLOaVcYRuoIbrKMR = P_2;
			}
		}

		private OOUAzmhrmdRifinivBwnHgrxziSTA UdqOtqqtoimuaFQiwzlZVPTvoIVf;

		private bool EqaYWXTrOKfAcLNvBBmOFJmCLbkJA;

		private TimerAbs[] LLBHokuuxiwQgJikbAGvjfeVKRGT;

		private Joystick AEiljGkodtLrPnOsXtxoWaZQFOmn => GetController<Joystick>();

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					return 0;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.ROePjaXEAAiQeLOaVcYRuoIbrKMR;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return 0f;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorR;
			}
			set
			{
				if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorR = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return 0f;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorG;
			}
			set
			{
				if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorG = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return 0f;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorB;
			}
			set
			{
				if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorB = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.microphoneLightMode = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.otherLightBrightness = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
				{
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.playerLights = value;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					return 0;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.MaxTouches;
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
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchCount();
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					return 0f;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.BatteryLevel;
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
				{
					return false;
				}
				return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.BatteryCharging;
			}
		}

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base(new OOUAzmhrmdRifinivBwnHgrxziSTA(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			LLBHokuuxiwQgJikbAGvjfeVKRGT = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(LLBHokuuxiwQgJikbAGvjfeVKRGT, 0, LLBHokuuxiwQgJikbAGvjfeVKRGT.Length);
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base(P_0)
		{
			try
			{
				LLBHokuuxiwQgJikbAGvjfeVKRGT = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				LLBHokuuxiwQgJikbAGvjfeVKRGT = new TimerAbs[0];
			}
			ArrayTools.Populate(LLBHokuuxiwQgJikbAGvjfeVKRGT, 0, LLBHokuuxiwQgJikbAGvjfeVKRGT.Length);
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
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled && motorIndex >= 0 && motorIndex < UdqOtqqtoimuaFQiwzlZVPTvoIVf.ROePjaXEAAiQeLOaVcYRuoIbrKMR)
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
			{
				return 0f;
			}
			if (!UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LeftMotor, 
				1 => UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.RightMotor, 
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
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled && UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
			{
				for (int i = 0; i < UdqOtqqtoimuaFQiwzlZVPTvoIVf.ROePjaXEAAiQeLOaVcYRuoIbrKMR; i++)
				{
					LLBHokuuxiwQgJikbAGvjfeVKRGT[i].Clear();
				}
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.StopVibration();
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled)
			{
				return 0f;
			}
			if (!UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LeftMotor, 
				1 => UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.RightMotor, 
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
				if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < UdqOtqqtoimuaFQiwzlZVPTvoIVf.ROePjaXEAAiQeLOaVcYRuoIbrKMR; i++)
					{
						LLBHokuuxiwQgJikbAGvjfeVKRGT[i].Clear();
					}
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LeftMotor = motorLevel;
					break;
				case 1:
					UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				ojCXIFLkFqgaSwOvzSbHCLGjKruh(motor, motorLevel, duration);
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
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled && UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
			{
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.RightMotor = MathTools.Clamp01(rightMotorLevel);
				ojCXIFLkFqgaSwOvzSbHCLGjKruh(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				ojCXIFLkFqgaSwOvzSbHCLGjKruh(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
			{
				return default(Color);
			}
			return new Color(UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorR, UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorG, UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
			{
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorR = color.r * color.a;
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorG = color.g * color.a;
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorB = color.b * color.a;
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
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
			{
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorR = red * intensity;
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorG = green * intensity;
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LightColorB = blue * intensity;
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.AccelerometerValueRaw;
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.AccelerometerValue;
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.Orientation;
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
			else if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA)
			{
				UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.ResetOrientation();
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchIdAtIndex(index);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchPositionByIndex(index, out position);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchPositionByTouchId(touchId, out position);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.IsTouchingAtIndex(index);
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
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ.IsTouchingAtTouchId(touchId);
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

		internal void MHWyfHLgYnboodsAqPtGGKEIkzVLB(UpdateLoopType P_0)
		{
			if (EqaYWXTrOKfAcLNvBBmOFJmCLbkJA && base.enabled)
			{
				nFtNlZTCwBulKmhCslBolPxrjNle();
			}
		}

		internal void DwBsbaXonGDVpDsDRTlBUNROhhAmA(IControllerExtensionSource P_0)
		{
			UdqOtqqtoimuaFQiwzlZVPTvoIVf = P_0 as OOUAzmhrmdRifinivBwnHgrxziSTA;
			EqaYWXTrOKfAcLNvBBmOFJmCLbkJA = UdqOtqqtoimuaFQiwzlZVPTvoIVf != null && UdqOtqqtoimuaFQiwzlZVPTvoIVf.kKuOeEGGvjLJGbXOhYBGKmNMfnUJ != null;
		}

		internal Controller.Extension HoyGkDvcSUuCTFdWYIAZqplLeMuO()
		{
			return new DualSenseExtension(this);
		}

		private void nFtNlZTCwBulKmhCslBolPxrjNle()
		{
			if (!EqaYWXTrOKfAcLNvBBmOFJmCLbkJA || !UdqOtqqtoimuaFQiwzlZVPTvoIVf.PHZTeYBuSHCqVVZIJmJsCwnsPzNi)
			{
				return;
			}
			for (int i = 0; i < UdqOtqqtoimuaFQiwzlZVPTvoIVf.ROePjaXEAAiQeLOaVcYRuoIbrKMR; i++)
			{
				if (LLBHokuuxiwQgJikbAGvjfeVKRGT[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void ojCXIFLkFqgaSwOvzSbHCLGjKruh(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				LLBHokuuxiwQgJikbAGvjfeVKRGT[num].Clear();
			}
			else
			{
				LLBHokuuxiwQgJikbAGvjfeVKRGT[num].Start(P_2);
			}
		}
	}
}
