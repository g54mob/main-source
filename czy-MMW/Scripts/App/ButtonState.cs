public class ButtonState
{
	private InputEventButtonState _currentState;

	private float _stateChangeTime;

	public InputEventButtonState CurrentState => _currentState;

	public float StateChangeTime => _stateChangeTime;

	public bool IsDown
	{
		get
		{
			if (CurrentState != InputEventButtonState.Down)
			{
				return CurrentState == InputEventButtonState.JustDown;
			}
			return true;
		}
	}

	public bool IsUp => !IsDown;

	public void SetState(float stateTime, InputEventButtonState newState)
	{
		_stateChangeTime = stateTime;
		_currentState = newState;
	}

	public void Tick(float appTime)
	{
		if (appTime > StateChangeTime)
		{
			if (CurrentState == InputEventButtonState.JustUp)
			{
				SetState(appTime, InputEventButtonState.Up);
			}
			if (CurrentState == InputEventButtonState.JustDown)
			{
				SetState(appTime, InputEventButtonState.Down);
			}
		}
	}
}
