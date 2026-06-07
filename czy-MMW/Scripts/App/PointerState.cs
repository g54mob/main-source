using System.Collections.Generic;
using Factory;
using UnityEngine;

public class PointerState : IPointerState
{
	private Vector2 _position;

	private Vector2 _delta;

	private float _deltaTimestep;

	private readonly Dictionary<int, ButtonState> _buttons = new Dictionary<int, ButtonState>();

	private IScope _scope;

	private static readonly ButtonState DummyButtonState = new ButtonState();

	public Vector2 Position => _position;

	public Vector2 PositionDelta => _delta;

	public void Initialize(IScope scope)
	{
		_scope = scope;
	}

	public void Tick(float appTime)
	{
		if (appTime > _deltaTimestep)
		{
			_delta = Vector2.zero;
		}
		foreach (ButtonState value in _buttons.Values)
		{
			value.Tick(appTime);
		}
	}

	public void MoveTo(float appTime, Vector2 position, PointerMoveToDeltaBehaviour deltaBehaviour = PointerMoveToDeltaBehaviour.CalculateDelta)
	{
		if (deltaBehaviour == PointerMoveToDeltaBehaviour.CalculateDelta)
		{
			_delta = position - _position;
		}
		else
		{
			_delta = Vector2.zero;
		}
		_position = position;
		_deltaTimestep = appTime;
	}

	public ButtonState GetButtonState(int rewiredIndex)
	{
		if (_buttons.ContainsKey(rewiredIndex))
		{
			return _buttons[rewiredIndex];
		}
		return DummyButtonState;
	}

	public void SetButtonState(float appTime, int rewiredIndex, InputEventButtonState newState)
	{
		if (!_buttons.TryGetValue(rewiredIndex, out var value))
		{
			value = _scope.Get<ButtonState>();
			_buttons.Add(rewiredIndex, value);
		}
		value.SetState(appTime, newState);
	}

	public Touch ToUnityTouch()
	{
		Touch result = default(Touch);
		InputEventButtonState currentState = GetButtonState(0).CurrentState;
		result.position = _position;
		result.deltaPosition = _delta;
		switch (currentState)
		{
		case InputEventButtonState.Down:
			if (_delta.sqrMagnitude > 0f)
			{
				result.phase = TouchPhase.Moved;
			}
			else
			{
				result.phase = TouchPhase.Stationary;
			}
			break;
		case InputEventButtonState.JustDown:
			result.phase = TouchPhase.Began;
			break;
		case InputEventButtonState.JustUp:
			result.phase = TouchPhase.Ended;
			break;
		case InputEventButtonState.Up:
			result.phase = TouchPhase.Canceled;
			result.type = TouchType.Indirect;
			break;
		}
		return result;
	}
}
