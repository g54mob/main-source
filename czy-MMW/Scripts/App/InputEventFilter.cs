using System;
using Motorways;

public class InputEventFilter : IComparable<InputEventFilter>
{
	public static int AnySourceIndex = -1;

	public static int AnyRewiredAction = -1;

	private readonly int _source;

	private readonly int _sourceIndex;

	private readonly int _rewiredAction;

	private readonly int _buttonState;

	public int RewiredAction => _rewiredAction;

	public InputEventButtonState ExpectedButtonState => (InputEventButtonState)_buttonState;

	protected InputEventFilter(InputEventSource source, int sourceIndex, int rewiredAction, int buttonState)
	{
		_source = (int)source;
		_sourceIndex = sourceIndex;
		_rewiredAction = rewiredAction;
		_buttonState = buttonState;
	}

	public static InputEventFilter CreateMouseEventFilter(int rewiredAction, InputEventButtonState buttonState)
	{
		return new InputEventFilter(InputEventSource.Mouse, AnySourceIndex, rewiredAction, (int)buttonState);
	}

	public static InputEventFilter CreateTouchEventFilter(int touchIndex, InputEventButtonState touchState)
	{
		return new InputEventFilter(InputEventSource.Touch, touchIndex, -1, (int)touchState);
	}

	public static InputEventFilter CreateKeyboardEventFilter(int rewiredAction, InputEventButtonState buttonState)
	{
		return CreateEventFilter(InputEventSource.Keyboard, rewiredAction, buttonState);
	}

	public static InputEventFilter CreateGenericEventFilter(int rewiredAction, InputEventButtonState buttonState)
	{
		return CreateEventFilter(InputEventSource.Generic, rewiredAction, buttonState);
	}

	public static InputEventFilter CreateRemoteEventFilter(int rewiredAction, InputEventButtonState buttonState)
	{
		return CreateEventFilter(InputEventSource.Remote, rewiredAction, buttonState);
	}

	public static InputEventFilter CreateEventFilter(InputEventSource source, int rewiredAction, InputEventButtonState buttonState)
	{
		int anySourceIndex = AnySourceIndex;
		return new InputEventFilter(source, anySourceIndex, rewiredAction, (int)buttonState);
	}

	public virtual bool MatchesEvent(InputEvent inputEvent)
	{
		if (inputEvent is MotorwaysUIInputEvent && !(this is MotorwaysUIInputEventFilter))
		{
			return false;
		}
		if (_source != 5 && _source != (int)inputEvent.Source)
		{
			return false;
		}
		if (_sourceIndex != AnySourceIndex && _sourceIndex != inputEvent.SourceIndex)
		{
			return false;
		}
		if (_rewiredAction != AnyRewiredAction && _rewiredAction != inputEvent.InputAction)
		{
			return false;
		}
		if (_buttonState != -1 && _buttonState != (int)inputEvent.ButtonState)
		{
			return false;
		}
		return true;
	}

	public virtual int CompareTo(InputEventFilter otherFilter)
	{
		if (_source != otherFilter._source)
		{
			return otherFilter._source - _source;
		}
		if (_sourceIndex != otherFilter._sourceIndex)
		{
			return otherFilter._sourceIndex - _sourceIndex;
		}
		if (_rewiredAction != otherFilter._rewiredAction)
		{
			return otherFilter._rewiredAction - _rewiredAction;
		}
		if (_buttonState != otherFilter._buttonState)
		{
			return otherFilter._buttonState - _buttonState;
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
		return (_source << 16) | (_sourceIndex << 12) | (_rewiredAction << 8) | (_buttonState << 4);
	}
}
