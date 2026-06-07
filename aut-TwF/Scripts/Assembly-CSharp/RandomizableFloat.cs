using System;
using UnityEngine;

[Serializable]
public struct RandomizableFloat
{
	[SerializeField]
	private float constantValue;

	[SerializeField]
	private Vector2 randomRange;

	[SerializeField]
	private EValueMode valueMode;

	private bool IsConstant => ValueMode == EValueMode.Constant;

	private bool IsRandom => ValueMode == EValueMode.Random;

	public float Value
	{
		get
		{
			if (ValueMode == EValueMode.Constant)
			{
				return ConstantValue;
			}
			return UnityEngine.Random.Range(Mathf.Min(RandomRange.x, RandomRange.y), Mathf.Max(RandomRange.x, RandomRange.y));
		}
	}

	public float ConstantValue
	{
		get
		{
			return constantValue;
		}
		set
		{
			constantValue = value;
		}
	}

	public Vector2 RandomRange
	{
		get
		{
			return randomRange;
		}
		set
		{
			randomRange = value;
		}
	}

	public float RandomRangeX
	{
		get
		{
			return randomRange.x;
		}
		set
		{
			randomRange.x = value;
		}
	}

	public float RandomRangeY
	{
		get
		{
			return randomRange.y;
		}
		set
		{
			randomRange.y = value;
		}
	}

	public EValueMode ValueMode
	{
		get
		{
			return valueMode;
		}
		set
		{
			valueMode = value;
		}
	}

	public RandomizableFloat(float constantValue, Vector2 randomRange, EValueMode valueMode)
	{
		this.constantValue = constantValue;
		this.randomRange = randomRange;
		this.valueMode = valueMode;
	}
}
