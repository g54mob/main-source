using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	public sealed class DualSenseExtension : Controller.Extension, IControllerVibrator, IDualShock4Extension
	{
		private class cwwBxqgtNctnHyfLdAwngzRTxXIbA : IControllerExtensionSource
		{
			public readonly IDriver_DualSense HASpVVHfbqNxqOWsgCqNVQzLcYFw;

			public readonly bool QgfiOqAqKFgNutFnAbZVtqhHbmPt;

			public readonly int TvfyCOtyYKIlzJHUmJzZBRLesBkj;

			public cwwBxqgtNctnHyfLdAwngzRTxXIbA(IDriver_DualSense P_0, bool P_1, int P_2)
			{
			}
		}

		private cwwBxqgtNctnHyfLdAwngzRTxXIbA vPTVBGMeTSLLhqcGnbvGjLFkMncb;

		private bool TDDNWUzJKMwhkWMQvgSgckxbIHat;

		private TimerAbs[] RmnWiflzWOKoiXCnMcRZqWFvqDq;

		private Joystick ncRBPRILXKISRDXTTSTeRKtkNzpTA => null;

		public int vibrationMotorCount => 0;

		public float lightColorRed
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float lightColorGreen
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float lightColorBlue
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public DualSenseMicrophoneLightMode microphoneLightMode
		{
			get
			{
				return default(DualSenseMicrophoneLightMode);
			}
			set
			{
			}
		}

		public DualSenseOtherLightBrightness otherLightBrightness
		{
			get
			{
				return default(DualSenseOtherLightBrightness);
			}
			set
			{
			}
		}

		public DualSensePlayerLightFlags playerLights
		{
			get
			{
				return default(DualSensePlayerLightFlags);
			}
			set
			{
			}
		}

		public int maxTouches => 0;

		public int touchCount => 0;

		public float batteryLevel => 0f;

		public bool batteryCharging => false;

		internal DualSenseExtension(IDriver_DualSense P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		private DualSenseExtension(DualSenseExtension P_0)
			: base((IControllerExtensionSource)null)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public float GetVibration(int motorIndex)
		{
			return 0f;
		}

		public void StopVibration()
		{
		}

		public float GetVibration(DualShock4MotorType motor)
		{
			return 0f;
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel)
		{
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration)
		{
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(DualShock4MotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
		}

		public Color GetLightColor()
		{
			return default(Color);
		}

		public void SetLightColor(Color color)
		{
		}

		public void SetLightColor(float red, float green, float blue)
		{
		}

		public void SetLightColor(float red, float green, float blue, float intensity)
		{
		}

		public Vector3 GetAccelerometerValueRaw()
		{
			return default(Vector3);
		}

		public Vector3 GetAccelerometerValue()
		{
			return default(Vector3);
		}

		public Vector3 GetLastGyroscopeValueRaw()
		{
			return default(Vector3);
		}

		public Vector3 GetLastGyroscopeValue()
		{
			return default(Vector3);
		}

		public Vector3 GetGyroscopeValueRaw()
		{
			return default(Vector3);
		}

		public Vector3 GetGyroscopeValue()
		{
			return default(Vector3);
		}

		public Quaternion GetOrientation()
		{
			return default(Quaternion);
		}

		public void ResetOrientation()
		{
		}

		public int GetTouchId(int index)
		{
			return 0;
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			position = default(Vector2);
			return false;
		}

		public bool IsTouching(int index)
		{
			return false;
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			return false;
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return default(Vector3);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return default(Vector3);
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
		}

		internal override void SourceUpdated(IControllerExtensionSource P_0)
		{
		}

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private void AMMeAhkLwOBFGwkLSkKJbpphoqDmc()
		{
		}

		private void xUiySGACDBhDcbetVeBYjAQZgkWMA(DualShock4MotorType P_0, float P_1, float P_2)
		{
		}
	}
}
