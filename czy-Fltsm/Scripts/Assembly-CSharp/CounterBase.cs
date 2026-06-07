using UnityEngine;
using UnityEngine.Events;

public abstract class CounterBase : MonoBehaviour
{
	public int Count { get; private set; }

	public int Min { get; private set; }

	public int Max { get; private set; }

	public UnityEvent<int> OnValueChanged { get; private set; } = new UnityEvent<int>();

	public void Initialize(int min, int max, int count)
	{
		Min = Mathf.Min(min, max);
		Max = Mathf.Max(min, max);
		Count = Mathf.Clamp(count, Min, Max);
		UpdateState();
	}

	public void Decrease()
	{
		SetCount(Count - 1);
	}

	public void Increase()
	{
		SetCount(Count + 1);
	}

	protected virtual void SetCount(int countToSet)
	{
		countToSet = Mathf.Clamp(countToSet, Min, Max);
		if (Count != countToSet)
		{
			Count = countToSet;
			UpdateState();
			OnValueChanged.Invoke(Count);
		}
	}

	protected abstract void UpdateState();
}
