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
		private class WOpcwZOOeIcSSeSveZiCTmShPGZgb : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 SYCFdmyRlDehaWRLxpblZmNQVwLe;

			public readonly bool HRWaKuGYTjxgWKbuWseSJBzpEFHnA;

			public readonly int xtXemLcUazeShJSBKlpTEeCMqZeF;

			public WOpcwZOOeIcSSeSveZiCTmShPGZgb(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				SYCFdmyRlDehaWRLxpblZmNQVwLe = P_0;
				HRWaKuGYTjxgWKbuWseSJBzpEFHnA = P_1;
				xtXemLcUazeShJSBKlpTEeCMqZeF = P_2;
			}
		}

		private WOpcwZOOeIcSSeSveZiCTmShPGZgb aSOqpztWUEhpjkWcxAjcTbJlhtxx;

		private bool WcbmiGFqdacHgBieRNNPHisJFInsA;

		private TimerAbs[] KBdYYjwZqmdPnodtYyLrrwoQrKHC;

		private Joystick nWAQQIqgNcWzarXDZIeLqQxRzrtc => GetController<Joystick>();

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					return 0;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.xtXemLcUazeShJSBKlpTEeCMqZeF;
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled)
				{
					return 0f;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorR;
			}
			set
			{
				if (WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorR = value;
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled)
				{
					return 0f;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorG;
			}
			set
			{
				if (WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorG = value;
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled)
				{
					return 0f;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorB;
			}
			set
			{
				if (WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorB = value;
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					return 0;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.MaxTouches;
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
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchCount();
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA)
				{
					return 0f;
				}
				return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new WOpcwZOOeIcSSeSveZiCTmShPGZgb(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			KBdYYjwZqmdPnodtYyLrrwoQrKHC = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(KBdYYjwZqmdPnodtYyLrrwoQrKHC, 0, KBdYYjwZqmdPnodtYyLrrwoQrKHC.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				KBdYYjwZqmdPnodtYyLrrwoQrKHC = new TimerAbs[P_0.Rewired_002EInterfaces_002EIControllerVibrator_002EvibrationMotorCount];
			}
			catch
			{
				KBdYYjwZqmdPnodtYyLrrwoQrKHC = new TimerAbs[0];
			}
			ArrayTools.Populate(KBdYYjwZqmdPnodtYyLrrwoQrKHC, 0, KBdYYjwZqmdPnodtYyLrrwoQrKHC.Length);
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled && motorIndex >= 0 && motorIndex < aSOqpztWUEhpjkWcxAjcTbJlhtxx.xtXemLcUazeShJSBKlpTEeCMqZeF)
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled)
			{
				return 0f;
			}
			if (!aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LeftMotor, 
				1 => aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.RightMotor, 
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled && aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
			{
				for (int i = 0; i < aSOqpztWUEhpjkWcxAjcTbJlhtxx.xtXemLcUazeShJSBKlpTEeCMqZeF; i++)
				{
					KBdYYjwZqmdPnodtYyLrrwoQrKHC[i].Clear();
				}
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.StopVibration();
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled)
			{
				return 0f;
			}
			if (!aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LeftMotor, 
				1 => aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.RightMotor, 
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
				if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < aSOqpztWUEhpjkWcxAjcTbJlhtxx.xtXemLcUazeShJSBKlpTEeCMqZeF; i++)
					{
						KBdYYjwZqmdPnodtYyLrrwoQrKHC[i].Clear();
					}
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LeftMotor = motorLevel;
					break;
				case 1:
					aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				iQkjVmhMuACDWCxlnrDzwJBlEAwaA(motor, motorLevel, duration);
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled && aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.RightMotor = MathTools.Clamp01(rightMotorLevel);
				iQkjVmhMuACDWCxlnrDzwJBlEAwaA(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				iQkjVmhMuACDWCxlnrDzwJBlEAwaA(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA)
			{
				return default(Color);
			}
			return new Color(aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorR, aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorG, aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorR = color.r * color.a;
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorG = color.g * color.a;
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorB = color.b * color.a;
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorR = red * intensity;
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorG = green * intensity;
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightColorB = blue * intensity;
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightFlashOnDuration = onDuration;
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.AccelerometerValueRaw;
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.AccelerometerValue;
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.Orientation;
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
			else if (WcbmiGFqdacHgBieRNNPHisJFInsA)
			{
				aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.ResetOrientation();
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchIdAtIndex(index);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchPositionByIndex(index, out position);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchPositionByTouchId(touchId, out position);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.IsTouchingAtIndex(index);
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
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe.IsTouchingAtTouchId(touchId);
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

		internal void PCpZnLGkZdPUkmXswEihBTJTkqyO(UpdateLoopType P_0)
		{
			if (WcbmiGFqdacHgBieRNNPHisJFInsA && base.enabled)
			{
				gLrahrsnMnfQJjVwnnRxgVGLBVIcb();
			}
		}

		internal void trpfjfbZlwNpsHZZgHZwkAkEcQqx(IControllerExtensionSource P_0)
		{
			aSOqpztWUEhpjkWcxAjcTbJlhtxx = P_0 as WOpcwZOOeIcSSeSveZiCTmShPGZgb;
			WcbmiGFqdacHgBieRNNPHisJFInsA = aSOqpztWUEhpjkWcxAjcTbJlhtxx != null && aSOqpztWUEhpjkWcxAjcTbJlhtxx.SYCFdmyRlDehaWRLxpblZmNQVwLe != null;
		}

		internal Controller.Extension GYVNqKSYcGkkushCFCLYdKPLCufiA()
		{
			return new DualShock4Extension(this);
		}

		private void gLrahrsnMnfQJjVwnnRxgVGLBVIcb()
		{
			if (!WcbmiGFqdacHgBieRNNPHisJFInsA || !aSOqpztWUEhpjkWcxAjcTbJlhtxx.HRWaKuGYTjxgWKbuWseSJBzpEFHnA)
			{
				return;
			}
			for (int i = 0; i < aSOqpztWUEhpjkWcxAjcTbJlhtxx.xtXemLcUazeShJSBKlpTEeCMqZeF; i++)
			{
				if (KBdYYjwZqmdPnodtYyLrrwoQrKHC[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void iQkjVmhMuACDWCxlnrDzwJBlEAwaA(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				KBdYYjwZqmdPnodtYyLrrwoQrKHC[num].Clear();
			}
			else
			{
				KBdYYjwZqmdPnodtYyLrrwoQrKHC[num].Start(P_2);
			}
		}
	}
}
