using System.Collections.Generic;

namespace Rewired
{
	public struct InputActionEventData
	{
		private JFPLbaXaWTBaMNutJnKxMUyCgIl yLNvWkXQxJILKGhZPwrZjKEsUYg;

		private InputActionEventType eugdtEsLYPbwHDSQvWvxkFyiUov;

		public readonly int playerId;

		public readonly int actionId;

		public readonly UpdateLoopType updateLoop;

		public InputActionEventType eventType
		{
			get
			{
				return default(InputActionEventType);
			}
			internal set
			{
			}
		}

		public Player player => null;

		public string actionName => null;

		public string actionDescriptiveName => null;

		public float GetAxis()
		{
			return 0f;
		}

		public float GetAxisPrev()
		{
			return 0f;
		}

		public float GetAxisDelta()
		{
			return 0f;
		}

		public double GetAxisTimeActive()
		{
			return 0.0;
		}

		public double GetAxisTimeInactive()
		{
			return 0.0;
		}

		public float GetAxisRaw()
		{
			return 0f;
		}

		public float GetAxisRawDelta()
		{
			return 0f;
		}

		public float GetAxisRawPrev()
		{
			return 0f;
		}

		public double GetAxisRawTimeActive()
		{
			return 0.0;
		}

		public double GetAxisRawTimeInactive()
		{
			return 0.0;
		}

		public AxisCoordinateMode GetAxisCoordinateMode()
		{
			return default(AxisCoordinateMode);
		}

		public AxisCoordinateMode GetAxisCoordinateModePrev()
		{
			return default(AxisCoordinateMode);
		}

		public AxisCoordinateMode GetAxisRawCoordinateMode()
		{
			return default(AxisCoordinateMode);
		}

		public AxisCoordinateMode GetAxisRawCoordinateModePrev()
		{
			return default(AxisCoordinateMode);
		}

		public bool GetButton()
		{
			return false;
		}

		public bool GetButtonPrev()
		{
			return false;
		}

		public bool GetButtonDown()
		{
			return false;
		}

		public bool GetButtonUp()
		{
			return false;
		}

		public bool GetButtonSinglePressHold()
		{
			return false;
		}

		public bool GetButtonSinglePressDown()
		{
			return false;
		}

		public bool GetButtonSinglePressUp()
		{
			return false;
		}

		public bool GetButtonDoublePressDown()
		{
			return false;
		}

		public bool GetButtonDoublePressDown(float speed)
		{
			return false;
		}

		public bool GetButtonDoublePressHold()
		{
			return false;
		}

		public bool GetButtonDoublePressHold(float speed)
		{
			return false;
		}

		public bool GetButtonDoublePressUp()
		{
			return false;
		}

		public bool GetButtonDoublePressUp(float speed)
		{
			return false;
		}

		public bool GetButtonTimedPress(float time)
		{
			return false;
		}

		public bool GetButtonTimedPress(float time, float expireIn)
		{
			return false;
		}

		public bool GetButtonTimedPressDown(float time)
		{
			return false;
		}

		public bool GetButtonTimedPressUp(float time)
		{
			return false;
		}

		public bool GetButtonTimedPressUp(float time, float expireIn)
		{
			return false;
		}

		public bool GetButtonShortPress()
		{
			return false;
		}

		public bool GetButtonShortPressDown()
		{
			return false;
		}

		public bool GetButtonShortPressUp()
		{
			return false;
		}

		public bool GetButtonLongPress()
		{
			return false;
		}

		public bool GetButtonLongPressDown()
		{
			return false;
		}

		public bool GetButtonLongPressUp()
		{
			return false;
		}

		public bool GetButtonRepeating()
		{
			return false;
		}

		public double GetButtonTimePressed()
		{
			return 0.0;
		}

		public double GetButtonTimeUnpressed()
		{
			return 0.0;
		}

		public bool GetNegativeButton()
		{
			return false;
		}

		public bool GetNegativeButtonPrev()
		{
			return false;
		}

		public bool GetNegativeButtonDown()
		{
			return false;
		}

		public bool GetNegativeButtonUp()
		{
			return false;
		}

		public bool GetNegativeButtonSinglePressHold()
		{
			return false;
		}

		public bool GetNegativeButtonSinglePressDown()
		{
			return false;
		}

		public bool GetNegativeButtonSinglePressUp()
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressDown()
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressDown(float speed)
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressHold()
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressHold(float speed)
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressUp()
		{
			return false;
		}

		public bool GetNegativeButtonDoublePressUp(float speed)
		{
			return false;
		}

		public bool GetNegativeButtonTimedPress(float time)
		{
			return false;
		}

		public bool GetNegativeButtonTimedPress(float time, float expireIn)
		{
			return false;
		}

		public bool GetNegativeButtonTimedPressDown(float time)
		{
			return false;
		}

		public bool GetNegativeButtonTimedPressUp(float time)
		{
			return false;
		}

		public bool GetNegativeButtonTimedPressUp(float time, float expireIn)
		{
			return false;
		}

		public bool GetNegativeButtonShortPress()
		{
			return false;
		}

		public bool GetNegativeButtonShortPressDown()
		{
			return false;
		}

		public bool GetNegativeButtonShortPressUp()
		{
			return false;
		}

		public bool GetNegativeButtonLongPress()
		{
			return false;
		}

		public bool GetNegativeButtonLongPressDown()
		{
			return false;
		}

		public bool GetNegativeButtonLongPressUp()
		{
			return false;
		}

		public bool GetNegativeButtonRepeating()
		{
			return false;
		}

		public double GetNegativeButtonTimePressed()
		{
			return 0.0;
		}

		public double GetNegativeButtonTimeUnpressed()
		{
			return 0.0;
		}

		public IList<InputActionSourceData> GetCurrentInputSources()
		{
			return null;
		}

		public bool IsCurrentInputSource(ControllerType controllerType)
		{
			return false;
		}

		public bool IsCurrentInputSource(ControllerType controllerType, int controllerId)
		{
			return false;
		}

		public bool IsCurrentInputSource(Controller controller)
		{
			return false;
		}

		internal InputActionEventData(JFPLbaXaWTBaMNutJnKxMUyCgIl vc, int playerId, int actionId, UpdateLoopType updateLoop)
		{
			yLNvWkXQxJILKGhZPwrZjKEsUYg = null;
			eugdtEsLYPbwHDSQvWvxkFyiUov = default(InputActionEventType);
			this.playerId = 0;
			this.actionId = 0;
			this.updateLoop = default(UpdateLoopType);
		}
	}
}
