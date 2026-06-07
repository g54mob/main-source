using UnityEngine;

public class ProgressValue : Progress
{
	public delegate void OnChanged();

	public delegate void OnValueFlipped(ProgressValue sender);

	protected float _currentValue;

	public OnChanged onChangedDelegate;

	public OnValueFlipped onValueFlippedDelegate;

	public bool hasAnyFill;

	public float currentValue => _currentValue;

	protected ProgressValue()
	{
	}

	public ProgressValue(ItemType type)
	{
		progressType = type;
		_currentValue = 0f;
	}

	public void InitializeValue(float v)
	{
		_currentValue = v;
		hasAnyFill = _currentValue > 0f;
	}

	public override float GetProgress()
	{
		return currentValue;
	}

	public void SetValue(float amount)
	{
		if (!GameUtility.NearlyEquals(_currentValue, amount))
		{
			_currentValue = amount;
			onChangedDelegate?.Invoke();
			UpdateFillValue();
		}
	}

	public virtual void ModifyValue(float amount)
	{
		_currentValue = Mathf.Clamp01(_currentValue + amount);
		UpdateFillValue();
		onChangedDelegate?.Invoke();
	}

	protected void UpdateFillValue()
	{
		if (hasAnyFill && _currentValue <= 0f)
		{
			hasAnyFill = false;
			onValueFlippedDelegate?.Invoke(this);
		}
		else if (!hasAnyFill && _currentValue > 0f)
		{
			hasAnyFill = true;
			onValueFlippedDelegate?.Invoke(this);
		}
	}
}
