using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public sealed class PS4GamepadExtension : PS4ControllerExtension, IControllerVibrator, IDualShock4Extension
	{
		private IPS4GamepadExtensionSource Source => null;

		public int connectionType => 0;

		public int maxTouches => 0;

		public float touchpadPixelDensity => 0f;

		public Vector2 touchpadResolution => default(Vector2);

		public int touchpadResolutionX => 0;

		public int touchpadResolutionY => 0;

		public int touchCount => 0;

		internal PS4GamepadExtension(IPS4GamepadExtensionSource source)
			: base((IPS4ControllerExtensionSource)null)
		{
		}

		private PS4GamepadExtension(PS4GamepadExtension source)
			: base((IPS4ControllerExtensionSource)null)
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

		public float GetVibration(PS4GamepadMotorType motor)
		{
			return 0f;
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel)
		{
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
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

		internal override Controller.Extension Clone()
		{
			return null;
		}

		private static int wGPcqZCoXQuUudPejucceTqcIIQp(PS4GamepadMotorType P_0)
		{
			return 0;
		}
	}
}
