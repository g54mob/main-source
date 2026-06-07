using System;
using UnityEngine;

[Serializable]
public struct RandomizableInt
{
	[SerializeField]
	private int constantValue;

	[SerializeField]
	private Vector2Int randomRange;

	[SerializeField]
	private EValueMode valueMode;

	private bool IsConstant => ValueMode == EValueMode.Constant;

	private bool IsRandom => ValueMode == EValueMode.Random;

	public int Value
	{
		get
		{
			if (ValueMode == EValueMode.Constant)
			{
				return ConstantValue;
			}
			return UnityEngine.Random.Range(Mathf.Min(RandomRange.x, RandomRange.y), Mathf.Max(RandomRange.x, RandomRange.y) + 1);
		}
	}

	public int ConstantValue
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

	public Vector2Int RandomRange
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

	public int RandomRangeX
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

	public int RandomRangeY
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

	public RandomizableInt(int constantValue, Vector2Int randomRange, EValueMode valueMode)
	{
		this.constantValue = constantValue;
		this.randomRange = randomRange;
		this.valueMode = valueMode;
	}
}
