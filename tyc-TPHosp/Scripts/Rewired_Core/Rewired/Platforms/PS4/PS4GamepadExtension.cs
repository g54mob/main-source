using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public sealed class PS4GamepadExtension : PS4ControllerExtension, IControllerVibrator, IDualShock4Extension
	{
		private IPS4GamepadExtensionSource Source => (GetSource() as UWcfTIdEHroICcszHTlgcXEeRHe).UdjCSEOPIRsTIjnUgCiPBbbzKWS as IPS4GamepadExtensionSource;

		public int connectionType
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return Source.GetConnectionType();
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
				return Source.maxTouches;
			}
		}

		public float touchpadPixelDensity
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0f;
				}
				return Source.GetTouchPixelDensity();
			}
		}

		public Vector2 touchpadResolution
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Vector2.zero;
				}
				return new Vector2(Source.GetTouchpadResolutionX(), Source.GetTouchpadResolutionY());
			}
		}

		public int touchpadResolutionX
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return Source.GetTouchpadResolutionX();
			}
		}

		public int touchpadResolutionY
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return Source.GetTouchpadResolutionY();
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
				return Source.GetTouchCount();
			}
		}

		internal PS4GamepadExtension(IPS4GamepadExtensionSource source)
			: base(source)
		{
		}

		private PS4GamepadExtension(PS4GamepadExtension source)
			: base(source)
		{
		}

		public int GetTouchId(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return -1;
			}
			return Source.GetTouchId(index);
		}

		public bool GetTouchPosition(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			return Source.GetTouchPositionByIndex(index, out position);
		}

		public bool GetTouchPositionByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			return Source.GetTouchPositionByTouchId(touchId, out position);
		}

		public bool GetTouchPositionAbsolute(int index, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			return Source.GetTouchPositionAbsByIndex(index, out position);
		}

		public bool GetTouchPositionAbsoluteByTouchId(int touchId, out Vector2 position)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				position = Vector2.zero;
				return false;
			}
			return Source.GetTouchPositionAbsByTouchId(touchId, out position);
		}

		public bool IsTouching(int index)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return Source.IsTouchingByIndex(index);
		}

		public bool IsTouchingByTouchId(int touchId)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return false;
			}
			return Source.IsTouchingByTouchId(touchId);
		}

		public float GetVibration(PS4GamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			return GetVibration(GNxaAfUTRUgbCngIeFcZxkFblrr(motor));
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				SetVibration(GNxaAfUTRUgbCngIeFcZxkFblrr(motor), motorLevel, duration, stopOtherMotors);
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
				return;
			}
			SetVibration(GNxaAfUTRUgbCngIeFcZxkFblrr(PS4GamepadMotorType.LeftMotor), leftMotorLevel, leftMotorDuration, stopOtherMotors: false);
			SetVibration(GNxaAfUTRUgbCngIeFcZxkFblrr(PS4GamepadMotorType.RightMotor), rightMotorLevel, rightMotorDuration, stopOtherMotors: false);
		}

		private Vector3 sDaNYLHkGqfObQFeCKkiPFyFLS()
		{
			return GetLastGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			//ILSpy generated this explicit interface implementation from .override directive in sDaNYLHkGqfObQFeCKkiPFyFLS
			return this.sDaNYLHkGqfObQFeCKkiPFyFLS();
		}

		private Vector3 OXIEXITERiruAdwweFThBblIqkl()
		{
			return GetLastGyroscopeValueRaw();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			//ILSpy generated this explicit interface implementation from .override directive in OXIEXITERiruAdwweFThBblIqkl
			return this.OXIEXITERiruAdwweFThBblIqkl();
		}

		internal override Controller.Extension AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return new PS4GamepadExtension(this);
		}

		private static int GNxaAfUTRUgbCngIeFcZxkFblrr(PS4GamepadMotorType P_0)
		{
			return (int)P_0;
		}
	}
}
