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
		private class sBCtbNQyQdHotAeHEOHNDdKYqVfu : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 HASpVVHfbqNxqOWsgCqNVQzLcYFw;

			public readonly bool QgfiOqAqKFgNutFnAbZVtqhHbmPt;

			public readonly int TvfyCOtyYKIlzJHUmJzZBRLesBkj;

			public sBCtbNQyQdHotAeHEOHNDdKYqVfu(IDriver_DualShock4 P_0, bool P_1, int P_2)
			{
				HASpVVHfbqNxqOWsgCqNVQzLcYFw = P_0;
				QgfiOqAqKFgNutFnAbZVtqhHbmPt = P_1;
				TvfyCOtyYKIlzJHUmJzZBRLesBkj = P_2;
			}
		}

		private sBCtbNQyQdHotAeHEOHNDdKYqVfu vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		private bool TDDNWUzJKMwhkWMQvgSgckxbIHat;

		private TimerAbs[] RmnWiflzWOKoiXCnMcRZqWFvqDq;

		private Joystick ncRBPRILXKISRDXTTSTeRKtkNzpTA => GetController<Joystick>();

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					return 0;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.TvfyCOtyYKIlzJHUmJzZBRLesBkj;
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled)
				{
					return 0f;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorR;
			}
			set
			{
				if (TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorR = value;
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled)
				{
					return 0f;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorG;
			}
			set
			{
				if (TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorG = value;
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled)
				{
					return 0f;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorB;
			}
			set
			{
				if (TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorB = value;
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					return 0;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.MaxTouches;
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
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchCount();
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat)
				{
					return 0f;
				}
				return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 P_0)
			: base(new sBCtbNQyQdHotAeHEOHNDdKYqVfu(P_0, P_0.VibrationMotorCount > 0, P_0.VibrationMotorCount))
		{
			RmnWiflzWOKoiXCnMcRZqWFvqDq = new TimerAbs[P_0.VibrationMotorCount];
			ArrayTools.Populate(RmnWiflzWOKoiXCnMcRZqWFvqDq, 0, RmnWiflzWOKoiXCnMcRZqWFvqDq.Length);
		}

		private DualShock4Extension(DualShock4Extension P_0)
			: base(P_0)
		{
			try
			{
				RmnWiflzWOKoiXCnMcRZqWFvqDq = new TimerAbs[P_0.vibrationMotorCount];
			}
			catch
			{
				RmnWiflzWOKoiXCnMcRZqWFvqDq = new TimerAbs[0];
			}
			ArrayTools.Populate(RmnWiflzWOKoiXCnMcRZqWFvqDq, 0, RmnWiflzWOKoiXCnMcRZqWFvqDq.Length);
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
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled && motorIndex >= 0 && motorIndex < vPTVBGMeTSLLhqcGnbvGjLFkMncb.TvfyCOtyYKIlzJHUmJzZBRLesBkj)
			{
				SetVibration(motorIndex switch
				{
					0 => DualShock4MotorType.LeftMotor, 
					1 => DualShock4MotorType.RightMotor, 
					_ => throw new NotImplementedException(), 
				}, motorLevel, duration, stopOtherMotors);
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled)
			{
				return 0f;
			}
			if (!vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LeftMotor, 
				1 => vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.RightMotor, 
				_ => 0f, 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled && vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				for (int i = 0; i < vPTVBGMeTSLLhqcGnbvGjLFkMncb.TvfyCOtyYKIlzJHUmJzZBRLesBkj; i++)
				{
					RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
				}
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.StopVibration();
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled)
			{
				return 0f;
			}
			if (!vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LeftMotor, 
				1 => vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.RightMotor, 
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
				if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < vPTVBGMeTSLLhqcGnbvGjLFkMncb.TvfyCOtyYKIlzJHUmJzZBRLesBkj; i++)
					{
						RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
					}
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LeftMotor = motorLevel;
					break;
				case 1:
					vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				xUiySGACDBhDcbetVeBYjAQZgkWMA(motor, motorLevel, duration);
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
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled && vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.RightMotor = MathTools.Clamp01(rightMotorLevel);
				xUiySGACDBhDcbetVeBYjAQZgkWMA(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				xUiySGACDBhDcbetVeBYjAQZgkWMA(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat)
			{
				return default(Color);
			}
			return new Color(vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorR, vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorG, vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorR = color.r * color.a;
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorG = color.g * color.a;
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorB = color.b * color.a;
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
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorR = red * intensity;
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorG = green * intensity;
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightColorB = blue * intensity;
			}
		}

		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightFlashOnDuration = onDuration;
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.AccelerometerValueRaw;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.AccelerometerValue;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.Orientation;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (TDDNWUzJKMwhkWMQvgSgckxbIHat)
			{
				vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.ResetOrientation();
			}
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.IsTouchingAtIndex(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw.IsTouchingAtTouchId(touchId);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return GetGyroscopeValueRaw();
		}

		internal void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			if (TDDNWUzJKMwhkWMQvgSgckxbIHat && base.enabled)
			{
				AMMeAhkLwOBFGwkLSkKJbpphoqDmc();
			}
		}

		internal void LPEqqRVtBurlVfmUZLbHuUeFxrWN(IControllerExtensionSource P_0)
		{
			vPTVBGMeTSLLhqcGnbvGjLFkMncb = P_0 as sBCtbNQyQdHotAeHEOHNDdKYqVfu;
			TDDNWUzJKMwhkWMQvgSgckxbIHat = vPTVBGMeTSLLhqcGnbvGjLFkMncb != null && vPTVBGMeTSLLhqcGnbvGjLFkMncb.HASpVVHfbqNxqOWsgCqNVQzLcYFw != null;
		}

		internal Controller.Extension whghpXSUuKbFknTBkNmxaxTkkihX()
		{
			return new DualShock4Extension(this);
		}

		private void AMMeAhkLwOBFGwkLSkKJbpphoqDmc()
		{
			if (!TDDNWUzJKMwhkWMQvgSgckxbIHat || !vPTVBGMeTSLLhqcGnbvGjLFkMncb.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return;
			}
			for (int i = 0; i < vPTVBGMeTSLLhqcGnbvGjLFkMncb.TvfyCOtyYKIlzJHUmJzZBRLesBkj; i++)
			{
				if (RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void xUiySGACDBhDcbetVeBYjAQZgkWMA(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				RmnWiflzWOKoiXCnMcRZqWFvqDq[num].Clear();
			}
			else
			{
				RmnWiflzWOKoiXCnMcRZqWFvqDq[num].Start(P_2);
			}
		}
	}
}
