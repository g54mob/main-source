public class AxisState
{
	protected float _axisValue;

	public virtual float GetAxisValue()
	{
		return _axisValue;
	}

	public virtual void SetAxisValue(float newValue)
	{
		_axisValue = newValue;
	}

	public void Tick(float appTime)
	{
	}
}
