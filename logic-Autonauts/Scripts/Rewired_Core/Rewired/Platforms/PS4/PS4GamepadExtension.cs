using Rewired.ControllerExtensions;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Platforms.PS4
{
	public sealed class PS4GamepadExtension : PS4ControllerExtension, IControllerVibrator, IDualShock4Extension
	{
		private IPS4GamepadExtensionSource Source
		{
			get
			{
				return (GetSource() as tMnjgiHHTTrIlevqvfMwMIodhrI).pjmDqcGcEdmXbvnkITKNjUFiEooD as IPS4GamepadExtensionSource;
			}
		}

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
				while (true)
				{
					int num = 767516028;
					while (true)
					{
						switch (num ^ 0x2DBF5D7E)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							position = Vector2.zero;
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = 767516031;
					}
				}
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
			return GetVibration(fhSMQyiqXduDIfOvsPVkRbGYLTX(motor));
		}

		public void SetVibration(PS4GamepadMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, false);
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
				while (true)
				{
					switch (0x38E73E1F ^ 0x38E73E1E)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			SetVibration(fhSMQyiqXduDIfOvsPVkRbGYLTX(motor), motorLevel, duration, stopOtherMotors);
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
			SetVibration(fhSMQyiqXduDIfOvsPVkRbGYLTX(PS4GamepadMotorType.LeftMotor), leftMotorLevel, leftMotorDuration, false);
			SetVibration(fhSMQyiqXduDIfOvsPVkRbGYLTX(PS4GamepadMotorType.RightMotor), rightMotorLevel, rightMotorDuration, false);
		}

		Vector3 IDualShock4Extension.GetGyroscopeValue()
		{
			return GetLastGyroscopeValue();
		}

		Vector3 IDualShock4Extension.GetGyroscopeValueRaw()
		{
			return GetLastGyroscopeValueRaw();
		}

		internal override Controller.Extension Clone()
		{
			return new PS4GamepadExtension(this);
		}

		private static int fhSMQyiqXduDIfOvsPVkRbGYLTX(PS4GamepadMotorType P_0)
		{
			return (int)P_0;
		}
	}
}
