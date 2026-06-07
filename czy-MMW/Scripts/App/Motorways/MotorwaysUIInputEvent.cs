using Factory;

namespace Motorways
{
	[Serializable(1)]
	public class MotorwaysUIInputEvent : InputEvent
	{
		protected GameUIButtonType _uiButtonType;

		public GameUIButtonType UIButtonType => _uiButtonType;

		public int UIButtonIndex { get; protected set; }

		public override void Reset()
		{
			base.Reset();
			_uiButtonType = GameUIButtonType.None;
			UIButtonIndex = -1;
		}

		public static MotorwaysUIInputEvent CreateMouseUIEvent(IScope scope, InputEventMouseButtonType mouseButtonType, InputEventButtonState mouseButtonState, GameUIButtonType uiButtonType, int uiButtonIndex = 0)
		{
			MotorwaysUIInputEvent motorwaysUIInputEvent = scope.Get<MotorwaysUIInputEvent>();
			motorwaysUIInputEvent._source = 0;
			motorwaysUIInputEvent.SourceIndex = 0;
			motorwaysUIInputEvent._buttonState = (int)mouseButtonState;
			motorwaysUIInputEvent.InputAction = BaseInputOverride.GetRewiredActionForMouseButtonIndex((int)mouseButtonType);
			motorwaysUIInputEvent._uiButtonType = uiButtonType;
			motorwaysUIInputEvent.UIButtonIndex = uiButtonIndex;
			return motorwaysUIInputEvent;
		}

		public static MotorwaysUIInputEvent CreateTouchUIEvent(IScope scope, int touchIndex, InputEventButtonState buttonState, GameUIButtonType uiButtonType, int uiButtonIndex = 0)
		{
			MotorwaysUIInputEvent motorwaysUIInputEvent = scope.Get<MotorwaysUIInputEvent>();
			motorwaysUIInputEvent._source = 1;
			motorwaysUIInputEvent.SourceIndex = touchIndex;
			motorwaysUIInputEvent.InputAction = -1;
			motorwaysUIInputEvent._buttonState = (int)buttonState;
			motorwaysUIInputEvent._uiButtonType = uiButtonType;
			motorwaysUIInputEvent.UIButtonIndex = uiButtonIndex;
			return motorwaysUIInputEvent;
		}

		public static MotorwaysUIInputEvent CreateGenericUIEvent(IScope scope, int rewiredAction, InputEventSource inputSource, InputEventButtonState buttonState, GameUIButtonType uiButtonType, int uiButtonIndex = 0)
		{
			MotorwaysUIInputEvent motorwaysUIInputEvent = scope.Get<MotorwaysUIInputEvent>();
			motorwaysUIInputEvent._source = (int)inputSource;
			motorwaysUIInputEvent.SourceIndex = 0;
			motorwaysUIInputEvent._buttonState = (int)buttonState;
			motorwaysUIInputEvent.InputAction = rewiredAction;
			motorwaysUIInputEvent._uiButtonType = uiButtonType;
			motorwaysUIInputEvent.UIButtonIndex = uiButtonIndex;
			return motorwaysUIInputEvent;
		}

		public override int CompareTo(InputEvent otherEvent)
		{
			int num = base.CompareTo(otherEvent);
			if (num != 0)
			{
				return num;
			}
			MotorwaysUIInputEvent motorwaysUIInputEvent = otherEvent as MotorwaysUIInputEvent;
			if (_uiButtonType != GameUIButtonType.None && motorwaysUIInputEvent._uiButtonType != _uiButtonType)
			{
				return motorwaysUIInputEvent._uiButtonType - _uiButtonType;
			}
			if (UIButtonIndex != motorwaysUIInputEvent.UIButtonIndex)
			{
				return motorwaysUIInputEvent.UIButtonIndex - UIButtonIndex;
			}
			return 0;
		}
	}
}
