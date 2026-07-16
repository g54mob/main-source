using System;
using UnityEngine;

[Serializable]
public class Resource
{
	[SerializeField]
	private float currentValue;

	public FloatEvent OnValueChangedTo;

	[field: SerializeField]
	public ResourceTypes ResourceType { get; private set; }

	[field: SerializeField]
	public float MaxValue { get; set; }

	[SerializeField]
	public float ModifierAdd { get; set; }

	[SerializeField]
	public float ModifierMult { get; set; } = 1f;

	[field: SerializeField]
	public bool DebugIsInfinite { get; set; }

	public float Value
	{
		get
		{
			if (DebugIsInfinite)
			{
				return 9999f;
			}
			return currentValue;
		}
		private set
		{
			if (!DebugIsInfinite)
			{
				float arg = (currentValue = Mathf.Clamp(value, 0f, MaxValue));
				OnValueChangedTo?.Invoke(arg);
			}
		}
	}

	public event Action OnCoresSpent;

	public event Action<float> OnValueAdded;

	public void SetValue(float newValue)
	{
		Value = newValue;
	}

	public void AddValue(float value, bool ignoreModifiers = false)
	{
		if (!ignoreModifiers)
		{
			value += ModifierAdd;
			value *= ModifierMult;
		}
		if (ResourceType == ResourceTypes.Scrap)
		{
			if (!ignoreModifiers)
			{
				value *= 1f + DifficultyManager.Instance.scrapGain;
			}
			value = Mathf.RoundToInt(value);
			if (value == 0f)
			{
				value = 1f;
			}
		}
		this.OnValueAdded?.Invoke(Value + value - currentValue);
		Value += value;
	}

	public bool TrySpend(float amountToSpend)
	{
		if (DebugIsInfinite)
		{
			return true;
		}
		if (Value < amountToSpend)
		{
			return false;
		}
		if (ResourceType == ResourceTypes.Scrap)
		{
			foreach (MilestoneScrapSpent scrapSpentMilestone in MilestoneManager.Instance.ScrapSpentMilestones)
			{
				if (!scrapSpentMilestone.Completed)
				{
					scrapSpentMilestone.AddProgress(amountToSpend);
				}
			}
		}
		Value -= amountToSpend;
		if (ResourceType == ResourceTypes.Cores)
		{
			this.OnCoresSpent?.Invoke();
		}
		return true;
	}

	public bool TrySpendAmmo(float amountToSpend)
	{
		if (DebugIsInfinite)
		{
			return true;
		}
		if (Value < amountToSpend)
		{
			return false;
		}
		if (Value - amountToSpend < Cannon.Instance.AmmoReservedByCannon)
		{
			Value -= amountToSpend;
		}
		this.OnCoresSpent?.Invoke();
		return true;
	}
}
