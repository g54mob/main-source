public class ProgressValueAbsorbWater : ProgressValue
{
	public float rate;

	public void UpdateProgress(float amount)
	{
		if (_currentValue < 1f)
		{
			SetValue(_currentValue + amount * rate);
		}
	}

	public void Absorb()
	{
		SetValue(_currentValue - 1f);
	}
}
