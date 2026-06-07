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
		private class gqcFjjHzhLbQAxeTbApXzsAWDSd : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 LvmafjUzQGqiDnMiZfdFizbRjGJh;

			public readonly bool GkLKAMFRzbMjZIZtziMXVcnFggPj;

			public readonly int HSFfOkgYdavTAaqGDaWBzgNaSgu;

			public gqcFjjHzhLbQAxeTbApXzsAWDSd(IDriver_DualShock4 driver, bool supportsVibration, int vibrationMotorCount)
			{
				LvmafjUzQGqiDnMiZfdFizbRjGJh = driver;
				GkLKAMFRzbMjZIZtziMXVcnFggPj = supportsVibration;
				HSFfOkgYdavTAaqGDaWBzgNaSgu = vibrationMotorCount;
			}
		}

		private gqcFjjHzhLbQAxeTbApXzsAWDSd fzzXbvFoZzdAqHDolrszRhFTkOz;

		private bool XunqwswVrwsPPbJKQLruGBplRnw;

		private TimerAbs[] ZmIYmGkyAuhZVDRUIGpXvAIJRaR;

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
				if (!XunqwswVrwsPPbJKQLruGBplRnw)
				{
					return 0;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.HSFfOkgYdavTAaqGDaWBzgNaSgu;
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled)
				{
					return 0f;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorR;
			}
			set
			{
				if (XunqwswVrwsPPbJKQLruGBplRnw)
				{
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorR = value;
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled)
				{
					return 0f;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorG;
			}
			set
			{
				if (XunqwswVrwsPPbJKQLruGBplRnw)
				{
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorG = value;
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled)
				{
					return 0f;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorB;
			}
			set
			{
				if (XunqwswVrwsPPbJKQLruGBplRnw)
				{
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorB = value;
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw)
				{
					return 0;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.MaxTouches;
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
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchCount();
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw)
				{
					return 0f;
				}
				return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.BatteryLevel;
			}
		}

		internal DualShock4Extension(IDriver_DualShock4 driver)
			: base(new gqcFjjHzhLbQAxeTbApXzsAWDSd(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
		}

		private DualShock4Extension(DualShock4Extension source)
			: base(source)
		{
			try
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[0];
			}
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
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
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled && motorIndex >= 0 && motorIndex < fzzXbvFoZzdAqHDolrszRhFTkOz.HSFfOkgYdavTAaqGDaWBzgNaSgu)
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
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled)
			{
				return 0f;
			}
			if (!fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LeftMotor, 
				1 => fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.RightMotor, 
				_ => 0f, 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled && fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				for (int i = 0; i < fzzXbvFoZzdAqHDolrszRhFTkOz.HSFfOkgYdavTAaqGDaWBzgNaSgu; i++)
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
				}
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.StopVibration();
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled)
			{
				return 0f;
			}
			if (!fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LeftMotor, 
				1 => fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.RightMotor, 
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
				if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < fzzXbvFoZzdAqHDolrszRhFTkOz.HSFfOkgYdavTAaqGDaWBzgNaSgu; i++)
					{
						ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
					}
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LeftMotor = motorLevel;
					break;
				case 1:
					fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				vAQoCgVfelQQROodmbOGmxKBFeC(motor, motorLevel, duration);
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
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled && fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.RightMotor = MathTools.Clamp01(rightMotorLevel);
				vAQoCgVfelQQROodmbOGmxKBFeC(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				vAQoCgVfelQQROodmbOGmxKBFeC(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw)
			{
				return default(Color);
			}
			return new Color(fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorR, fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorG, fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorR = color.r * color.a;
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorG = color.g * color.a;
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorB = color.b * color.a;
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
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorR = red * intensity;
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorG = green * intensity;
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightColorB = blue * intensity;
			}
		}

		public void SetLightFlash(float onDuration, float offDuration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightFlashOnDuration = onDuration;
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LightFlashOffDuration = offDuration;
			}
		}

		public void StopLightFlash()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.StopLightFlash();
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.AccelerometerValueRaw;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.AccelerometerValue;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.Orientation;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (XunqwswVrwsPPbJKQLruGBplRnw)
			{
				fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.ResetOrientation();
			}
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.IsTouchingAtIndex(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh.IsTouchingAtTouchId(touchId);
		}

		private Vector3 ELloHaaTLBGcWecvfIUdaAgEAZy()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ELloHaaTLBGcWecvfIUdaAgEAZy
			return this.ELloHaaTLBGcWecvfIUdaAgEAZy();
		}

		private Vector3 ulebigmgMtWMDaYSfVmCVETqgJg()
		{
			return GetGyroscopeValueRaw();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in ulebigmgMtWMDaYSfVmCVETqgJg
			return this.ulebigmgMtWMDaYSfVmCVETqgJg();
		}

		internal void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			if (XunqwswVrwsPPbJKQLruGBplRnw && base.enabled)
			{
				AdgerJOJHeELnHnJdXbVLfbiaXX();
			}
		}

		internal void FIsQjdAAyWEysCgIuJuNAowHchI(IControllerExtensionSource P_0)
		{
			fzzXbvFoZzdAqHDolrszRhFTkOz = P_0 as gqcFjjHzhLbQAxeTbApXzsAWDSd;
			XunqwswVrwsPPbJKQLruGBplRnw = fzzXbvFoZzdAqHDolrszRhFTkOz != null && fzzXbvFoZzdAqHDolrszRhFTkOz.LvmafjUzQGqiDnMiZfdFizbRjGJh != null;
		}

		internal Controller.Extension cGSBTlPoJoSUBEuZRjRzMJDgwjh()
		{
			return new DualShock4Extension(this);
		}

		private void AdgerJOJHeELnHnJdXbVLfbiaXX()
		{
			if (!XunqwswVrwsPPbJKQLruGBplRnw || !fzzXbvFoZzdAqHDolrszRhFTkOz.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return;
			}
			for (int i = 0; i < fzzXbvFoZzdAqHDolrszRhFTkOz.HSFfOkgYdavTAaqGDaWBzgNaSgu; i++)
			{
				if (ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void vAQoCgVfelQQROodmbOGmxKBFeC(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[num].Clear();
			}
			else
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[num].Start(P_2);
			}
		}
	}
}
