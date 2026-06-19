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
		private class QgaAoydMLJLRwaQfRFdgwPorcLiD : IControllerExtensionSource
		{
			public readonly IDriver_DualSense dyKYGRpafBLeBoCSSijQzhOhFYt;

			public readonly bool swbwxminWkIfPLDNkfAOLJChHuv;

			public readonly int hFnuhMXoYvgyCariIlYOShuWnqMq;

			public QgaAoydMLJLRwaQfRFdgwPorcLiD(IDriver_DualSense driver, bool supportsVibration, int vibrationMotorCount)
			{
				dyKYGRpafBLeBoCSSijQzhOhFYt = driver;
				swbwxminWkIfPLDNkfAOLJChHuv = supportsVibration;
				hFnuhMXoYvgyCariIlYOShuWnqMq = vibrationMotorCount;
			}
		}

		private QgaAoydMLJLRwaQfRFdgwPorcLiD NsRIQHseimotuEJGoIuiBqmlsEN;

		private bool xhFJJGDiKvRiLmguDLDnIgIPLnO;

		private TimerAbs[] xZuKFmRpvbeqPEKkNilOfJfximjg;

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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					return 0;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.hFnuhMXoYvgyCariIlYOShuWnqMq;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return 0f;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorR;
			}
			set
			{
				if (xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorR = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return 0f;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorG;
			}
			set
			{
				if (xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorG = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return 0f;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorB;
			}
			set
			{
				if (xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorB = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return DualSenseMicrophoneLightMode.Off;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.microphoneLightMode;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.microphoneLightMode = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return DualSenseOtherLightBrightness.High;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.otherLightBrightness;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.otherLightBrightness = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
				{
					return DualSensePlayerLightFlags.None;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.playerLights;
			}
			set
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
				}
				else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
				{
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.playerLights = value;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					return 0;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.MaxTouches;
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
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchCount();
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					return 0f;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.BatteryLevel;
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO)
				{
					return false;
				}
				return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.BatteryCharging;
			}
		}

		internal DualSenseExtension(IDriver_DualSense driver)
			: base(new QgaAoydMLJLRwaQfRFdgwPorcLiD(driver, driver.VibrationMotorCount > 0, driver.VibrationMotorCount))
		{
			xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[driver.VibrationMotorCount];
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
		}

		private DualSenseExtension(DualSenseExtension source)
			: base(source)
		{
			try
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[source.vibrationMotorCount];
			}
			catch
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[0];
			}
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
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
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled && motorIndex >= 0 && motorIndex < NsRIQHseimotuEJGoIuiBqmlsEN.hFnuhMXoYvgyCariIlYOShuWnqMq)
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
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
			{
				return 0f;
			}
			if (!NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LeftMotor, 
				1 => NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.RightMotor, 
				_ => 0f, 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled && NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				for (int i = 0; i < NsRIQHseimotuEJGoIuiBqmlsEN.hFnuhMXoYvgyCariIlYOShuWnqMq; i++)
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
				}
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.StopVibration();
			}
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled)
			{
				return 0f;
			}
			if (!NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return 0f;
			}
			return (int)motor switch
			{
				0 => NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LeftMotor, 
				1 => NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.RightMotor, 
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
				if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
				{
					return;
				}
				if (stopOtherMotors)
				{
					for (int i = 0; i < NsRIQHseimotuEJGoIuiBqmlsEN.hFnuhMXoYvgyCariIlYOShuWnqMq; i++)
					{
						xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
					}
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.StopVibration();
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch ((int)motor)
				{
				case 0:
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LeftMotor = motorLevel;
					break;
				case 1:
					NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.RightMotor = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				PrmctIckVmyxTVxTdzKFusfbJqiG(motor, motorLevel, duration);
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
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled && NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LeftMotor = MathTools.Clamp01(leftMotorLevel);
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.RightMotor = MathTools.Clamp01(rightMotorLevel);
				PrmctIckVmyxTVxTdzKFusfbJqiG(DualShock4MotorType.LeftMotor, leftMotorLevel, leftMotorDuration);
				PrmctIckVmyxTVxTdzKFusfbJqiG(DualShock4MotorType.RightMotor, rightMotorLevel, rightMotorDuration);
			}
		}

		public Color GetLightColor()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return default(Color);
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO)
			{
				return default(Color);
			}
			return new Color(NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorR, NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorG, NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorB, 1f);
		}

		public void SetLightColor(Color color)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
			{
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorR = color.r * color.a;
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorG = color.g * color.a;
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorB = color.b * color.a;
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
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
			{
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorR = red * intensity;
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorG = green * intensity;
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LightColorB = blue * intensity;
			}
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.AccelerometerValueRaw;
		}

		public Vector3 GetAccelerometerValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.AccelerometerValue;
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LastGyroscopeValueRaw;
		}

		public Vector3 GetLastGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.LastGyroscopeValue;
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GyroscopeValueRaw;
		}

		public Vector3 GetGyroscopeValue()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Vector3.zero;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return Vector3.zero;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GyroscopeValue;
		}

		public Quaternion GetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return Quaternion.identity;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return default(Quaternion);
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.Orientation;
		}

		public void ResetOrientation()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (xhFJJGDiKvRiLmguDLDnIgIPLnO)
			{
				NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.ResetOrientation();
			}
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return -1;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchIdAtIndex(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByIndex = NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchPositionAbsoluteByIndex(index, out positionX, out positionY);
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
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				position = Vector2.zero;
				return false;
			}
			int positionX;
			int positionY;
			bool touchPositionAbsoluteByTouchId = NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.GetTouchPositionAbsoluteByTouchId(touchId, out positionX, out positionY);
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
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.IsTouchingAtIndex(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !base.enabled || !ReInput.IsInputAllowed(ControllerType.Joystick))
			{
				return false;
			}
			return NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt.IsTouchingAtTouchId(touchId);
		}

		private Vector3 sDaNYLHkGqfObQFeCKkiPFyFLS()
		{
			return GetGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in sDaNYLHkGqfObQFeCKkiPFyFLS
			return this.sDaNYLHkGqfObQFeCKkiPFyFLS();
		}

		private Vector3 OXIEXITERiruAdwweFThBblIqkl()
		{
			return GetGyroscopeValueRaw();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OXIEXITERiruAdwweFThBblIqkl
			return this.OXIEXITERiruAdwweFThBblIqkl();
		}

		internal void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			if (xhFJJGDiKvRiLmguDLDnIgIPLnO && base.enabled)
			{
				iqIALhjYezdflYrpgSZUFTUYBiz();
			}
		}

		internal void tmEnLTdHsRVxaDmExqmMETendBa(IControllerExtensionSource P_0)
		{
			NsRIQHseimotuEJGoIuiBqmlsEN = P_0 as QgaAoydMLJLRwaQfRFdgwPorcLiD;
			xhFJJGDiKvRiLmguDLDnIgIPLnO = NsRIQHseimotuEJGoIuiBqmlsEN != null && NsRIQHseimotuEJGoIuiBqmlsEN.dyKYGRpafBLeBoCSSijQzhOhFYt != null;
		}

		internal Controller.Extension AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return new DualSenseExtension(this);
		}

		private void iqIALhjYezdflYrpgSZUFTUYBiz()
		{
			if (!xhFJJGDiKvRiLmguDLDnIgIPLnO || !NsRIQHseimotuEJGoIuiBqmlsEN.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return;
			}
			for (int i = 0; i < NsRIQHseimotuEJGoIuiBqmlsEN.hFnuhMXoYvgyCariIlYOShuWnqMq; i++)
			{
				if (xZuKFmRpvbeqPEKkNilOfJfximjg[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void PrmctIckVmyxTVxTdzKFusfbJqiG(DualShock4MotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				DualShock4MotorType.LeftMotor => 0, 
				DualShock4MotorType.RightMotor => 1, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg[num].Clear();
			}
			else
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg[num].Start(P_2);
			}
		}
	}
}
