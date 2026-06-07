using System;
using UnityEngine;

[Serializable]
public struct RandomInRange
{
	public float Min;

	public float Max;

	[NonSerialized]
	private float _value;

	public float Value
	{
		get
		{
			if (_value < Min || Max < _value)
			{
				_value = UnityEngine.Random.Range(Min, Max);
			}
			return _value;
		}
	}

	public RandomInRange(float min, float max)
	{
		Min = min;
		Max = max;
		_value = float.NegativeInfinity;
	}

	public void NextValue()
	{
		_value = UnityEngine.Random.Range(Min, Max);
	}

	public float ReturnRandomValue()
	{
		return UnityEngine.Random.Range(Min, Max);
	}

	public static implicit operator float(RandomInRange range)
	{
		return range.Value;
	}
}
