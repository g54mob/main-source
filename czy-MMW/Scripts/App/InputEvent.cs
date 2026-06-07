using System;
using Factory;
using Factory.Pools;
using UnityEngine;

[Factory.Serializable(1)]
public class InputEvent : IComparable<InputEvent>, IReusable
{
	protected int _source = -1;

	protected int _buttonState = -1;

	protected Vector2 _pointerPosition;

	public const int TouchInputActionId = -1;

	public InputEventSource Source => (InputEventSource)_source;

	public int SourceIndex { get; protected set; }

	public int InputAction { get; protected set; }

	public InputEventButtonState ButtonState => (InputEventButtonState)_buttonState;

	public Vector2 PointerPosition => _pointerPosition;

	public virtual void Reset()
	{
		_source = -1;
		SourceIndex = -1;
		InputAction = -1;
		_buttonState = -1;
		_pointerPosition = Vector2.zero;
	}

	public static InputEvent CreateTouchEvent(IScope scope, int touchIndex, InputEventButtonState touchState, Vector2 touchPosition)
	{
		InputEvent inputEvent = scope.Get<InputEvent>();
		inputEvent._source = 1;
		inputEvent.SourceIndex = touchIndex;
		inputEvent.InputAction = -1;
		inputEvent._buttonState = (int)touchState;
		inputEvent._pointerPosition = touchPosition;
		return inputEvent;
	}

	public static InputEvent CreateMouseEvent(IScope scope, int rewiredInput, InputEventButtonState buttonState, Vector2 mousePosition)
	{
		InputEvent inputEvent = scope.Get<InputEvent>();
		inputEvent._source = 0;
		inputEvent.InputAction = rewiredInput;
		inputEvent._buttonState = (int)buttonState;
		inputEvent._pointerPosition = mousePosition;
		return inputEvent;
	}

	public static InputEvent CreateEvent(IScope scope, int rewiredInput, InputEventButtonState buttonState, InputEventSource source)
	{
		InputEvent inputEvent = scope.Get<InputEvent>();
		inputEvent._source = (int)source;
		inputEvent.InputAction = rewiredInput;
		inputEvent._buttonState = (int)buttonState;
		return inputEvent;
	}

	public virtual int CompareTo(InputEvent otherEvent)
	{
		if (_source != otherEvent._source)
		{
			return otherEvent._source - _source;
		}
		if (SourceIndex != otherEvent.SourceIndex)
		{
			return otherEvent.SourceIndex - SourceIndex;
		}
		if (InputAction != otherEvent.InputAction)
		{
			return otherEvent.InputAction - InputAction;
		}
		if (_buttonState != otherEvent._buttonState)
		{
			return otherEvent._buttonState - _buttonState;
		}
		if (!Mathf.Approximately(_pointerPosition.x, otherEvent._pointerPosition.x))
		{
			if (!(_pointerPosition.x < otherEvent._pointerPosition.x))
			{
				return 1;
			}
			return -1;
		}
		if (!Mathf.Approximately(_pointerPosition.y, otherEvent._pointerPosition.y))
		{
			if (!(_pointerPosition.y < otherEvent._pointerPosition.y))
			{
				return 1;
			}
			return -1;
		}
		return 0;
	}

	public override string ToString()
	{
		return $"{Source.ToString()} {SourceIndex.ToString()} -> Button {InputAction.ToString()} {ButtonState.ToString()} -- {PointerPosition.ToString()}";
	}
}
