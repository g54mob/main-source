using UnityEngine;

public class NeedBase : MonoBehaviour
{
	protected float currentValue;

	protected bool locked;

	protected bool frozen;

	protected DoggyBrain brainRef;

	protected virtual float startValue => 0f;

	protected virtual float maxValue => 0f;

	protected virtual float minValue => 0f;

	protected virtual float decayValue => 0f;

	protected virtual float idealValue => 0f;

	public void SetDoggyBrain(DoggyBrain newRef)
	{
		brainRef = newRef;
	}

	public void LockNeed()
	{
		locked = true;
	}

	public void UnlockNeed()
	{
		locked = false;
	}

	public void SetFrozen(bool val)
	{
		frozen = val;
	}

	public float GetMaxValue()
	{
		return maxValue;
	}

	public float GetMinValue()
	{
		return minValue;
	}

	public virtual bool DoesValueSolveForNeed(float val)
	{
		return true;
	}

	public virtual bool IsValuePositiveForNeed(float val)
	{
		return true;
	}

	private void Awake()
	{
		currentValue = startValue;
	}

	public void Decay()
	{
		if (!locked)
		{
			currentValue = Mathf.Clamp(currentValue + decayValue * Time.deltaTime, minValue, maxValue);
		}
	}

	public float GetValue()
	{
		return currentValue;
	}

	public void SetValue(float newValue)
	{
		if (!frozen)
		{
			currentValue = newValue;
		}
	}

	public virtual float GetPercentageValue()
	{
		return (currentValue - minValue) / (maxValue - minValue);
	}

	public virtual float GetNeedScore()
	{
		return GetCurvedScore(idealValue, currentValue);
	}

	public virtual float GetPotentialNeedScore(float updateAmount)
	{
		return GetCurvedScore(idealValue, GetUpdatedValue(updateAmount));
	}

	private float GetCurvedScore(float idealValue, float currentValue)
	{
		return Mathf.Pow(Mathf.Abs(idealValue - currentValue), 2f);
	}

	public void UpdateValue(float updateAmount)
	{
		if (!frozen)
		{
			currentValue = GetUpdatedValue(updateAmount);
		}
	}

	protected float GetUpdatedValue(float updateAmount)
	{
		return Mathf.Clamp(currentValue + updateAmount, minValue, maxValue);
	}
}
