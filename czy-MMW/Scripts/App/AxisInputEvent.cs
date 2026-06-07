using Factory;

public class AxisInputEvent : InputEvent
{
	public float AxisValue { get; private set; }

	public static AxisInputEvent CreateAxisEvent(IScope scope, int rewiredActionAxis, float newValue, InputEventSource source)
	{
		AxisInputEvent axisInputEvent = scope.Get<AxisInputEvent>();
		axisInputEvent._source = (int)source;
		axisInputEvent._buttonState = 5;
		axisInputEvent.InputAction = rewiredActionAxis;
		axisInputEvent.AxisValue = newValue;
		return axisInputEvent;
	}

	public override void Reset()
	{
		base.Reset();
		AxisValue = 0f;
	}
}
