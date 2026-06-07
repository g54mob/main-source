using UnityEngine;

public class ProgressValueCounter : Progress
{
	public delegate void OnChanged();

	public delegate void OnCompleted(ProgressValueCounter sender);

	private int _currentValue;

	private bool _isComplete;

	public int minValue;

	public int maxValue;

	public OnChanged onChangedDelegate;

	public OnCompleted onCompletedDelegate;

	public int currentValue => _currentValue;

	public override float GetProgress()
	{
		if ((float)minValue > 0f)
		{
			return Mathf.InverseLerp(minValue, maxValue, currentValue);
		}
		if (maxValue > 0)
		{
			return Mathf.Clamp01((float)currentValue / (float)maxValue);
		}
		return currentValue;
	}

	public float RemainingCapacity()
	{
		return maxValue - currentValue;
	}

	public bool IsFull()
	{
		return currentValue >= maxValue;
	}

	public void InitializeValue(int v)
	{
		_currentValue = v;
		_isComplete = IsFull();
	}

	public void SetValue(int amount)
	{
		if (_currentValue != amount)
		{
			_currentValue = amount;
			onChangedDelegate?.Invoke();
			UpdateCompletedState();
		}
	}

	public void ModifyValue(int amount)
	{
		_currentValue = Mathf.Clamp(_currentValue + amount, 0, maxValue);
		onChangedDelegate?.Invoke();
		UpdateCompletedState();
	}

	private void UpdateCompletedState()
	{
		if (!_isComplete && IsFull())
		{
			_isComplete = true;
			onCompletedDelegate?.Invoke(this);
		}
	}
}
