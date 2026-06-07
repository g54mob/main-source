namespace Motorways
{
	public class MotorwaysUIInputEventFilter : InputEventFilter
	{
		private readonly GameUIButtonType _uiButtonType;

		private MotorwaysUIInputEventFilter(InputEventSource source, int sourceIndex, int rewiredAction, int buttonState, GameUIButtonType uiButtonType)
			: base(source, sourceIndex, rewiredAction, buttonState)
		{
			_uiButtonType = uiButtonType;
		}

		public static InputEventFilter CreateMouseUIEventFilter(int rewiredAction, GameUIButtonType uiButtonType, InputEventButtonState mouseButtonState)
		{
			return new MotorwaysUIInputEventFilter(InputEventSource.Mouse, 0, rewiredAction, (int)mouseButtonState, uiButtonType);
		}

		public static InputEventFilter CreateTouchUIEventFilter(int touchIndex, GameUIButtonType uiButtonType, InputEventButtonState buttonState)
		{
			return new MotorwaysUIInputEventFilter(InputEventSource.Touch, touchIndex, -1, (int)buttonState, uiButtonType);
		}

		public static InputEventFilter CreateGenericUIEventFilter(int rewiredAction, GameUIButtonType uiButtonType, InputEventButtonState mouseButtonState)
		{
			return new MotorwaysUIInputEventFilter(InputEventSource.Generic, 0, rewiredAction, (int)mouseButtonState, uiButtonType);
		}

		public static InputEventFilter CreateRemoteUIEventFilter(int rewiredAction, GameUIButtonType uiButtonType, InputEventButtonState mouseButtonState)
		{
			return new MotorwaysUIInputEventFilter(InputEventSource.Remote, 0, rewiredAction, (int)mouseButtonState, uiButtonType);
		}

		public override bool MatchesEvent(InputEvent inputEvent)
		{
			if (!base.MatchesEvent(inputEvent))
			{
				return false;
			}
			MotorwaysUIInputEvent motorwaysUIInputEvent = inputEvent as MotorwaysUIInputEvent;
			if (_uiButtonType != GameUIButtonType.None && (motorwaysUIInputEvent == null || _uiButtonType != motorwaysUIInputEvent.UIButtonType))
			{
				return false;
			}
			return true;
		}

		public override int CompareTo(InputEventFilter otherFilter)
		{
			int num = base.CompareTo(otherFilter);
			if (num != 0)
			{
				return num;
			}
			MotorwaysUIInputEventFilter motorwaysUIInputEventFilter = otherFilter as MotorwaysUIInputEventFilter;
			if (_uiButtonType != GameUIButtonType.None && motorwaysUIInputEventFilter._uiButtonType != _uiButtonType)
			{
				return motorwaysUIInputEventFilter._uiButtonType - _uiButtonType;
			}
			return 0;
		}

		public override bool Equals(object obj)
		{
			if (!(obj is InputEventFilter otherFilter))
			{
				return false;
			}
			return CompareTo(otherFilter) == 0;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode() | (int)_uiButtonType;
		}
	}
}
