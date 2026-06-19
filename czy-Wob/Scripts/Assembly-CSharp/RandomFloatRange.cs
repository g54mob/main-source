using UnityEngine;

public class RandomFloatRange
{
	private float _min;

	private float _max;

	private float _baseChance;

	private float _defaultValue;

	public RandomFloatRange(float min, float max, float baseChance = 1f, float defaultValue = 0f)
	{
		_min = min;
		_max = max;
		_baseChance = baseChance;
		_defaultValue = defaultValue;
	}

	public float GetValue()
	{
		if (Random.value > _baseChance)
		{
			return _defaultValue;
		}
		return Random.Range(_min, _max);
	}
}
