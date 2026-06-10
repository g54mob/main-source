using Rewired.Drivers.Interfaces;
using Rewired.Interfaces;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired.ControllerExtensions
{
	public sealed class DualShock4Extension : Controller.Extension, IControllerVibrator, IDualShock4Extension
	{
		private class oOUWkKWqURMkFSSlXFjCAXdDeksj : IControllerExtensionSource
		{
			public readonly IDriver_DualShock4 RoGyCOLKdQfbMICWzOACeDQIYzWc;

			public readonly bool KTfrJbQBKhaUMbjHRbtMzWYUXDE;

			public readonly int ZHjjBLxDSwIULZUgnbCMHwanPkf;

			public oOUWkKWqURMkFSSlXFjCAXdDeksj(IDriver_DualShock4 driver, bool supportsVibration, int vibrationMotorCount)
			{
			}
		}

		private oOUWkKWqURMkFSSlXFjCAXdDeksj tfTCEMKNedpBjaNONhTolgkIZhi;

		private bool ZsZyPFdVWepsAMegkdwtgzGwOgz;

		private TimerAbs[] PycTVpjFjwfCGsowmeMWFpbIOXU;

		private Joystick joystick => null;

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

		public int maxTouches => 0;

		public int touchCount => 0;

		public float batteryLevel => 0f;

		internal DualShock4Extension(IDriver_DualShock4 driver)
			: base((IControllerExtensionSource)null)
		{
		}

		private DualShock4Extension(DualShock4Extension source)
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

		public void SetLightFlash(float onDuration, float offDuration)
		{
		}

		public void StopLightFlash()
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

		private Vector3 SQNcDJGjcXNJJZLLVYdseONVRmhU()
		{
			return default(Vector3);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in SQNcDJGjcXNJJZLLVYdseONVRmhU
			return this.SQNcDJGjcXNJJZLLVYdseONVRmhU();
		}

		private Vector3 yNIMWTtrRxPFXZLcZXgnjPbroFQ()
		{
			return default(Vector3);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in yNIMWTtrRxPFXZLcZXgnjPbroFQ
			return this.yNIMWTtrRxPFXZLcZXgnjPbroFQ();
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

		private void QWIjVqDTqkbRucBdBwaMftUrGTU()
		{
		}

		private void byElLAxPlbLAnuFUvRVYXfGZFF(DualShock4MotorType P_0, float P_1, float P_2)
		{
		}
	}
}
