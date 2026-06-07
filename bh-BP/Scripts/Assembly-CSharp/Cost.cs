using System;

[Serializable]
public class Cost
{
	[NamedArray(typeof(ResourceType))]
	public int[] Num;

	public int this[int i]
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int this[ResourceType rt]
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public int Length => 0;

	public static Cost operator *(Cost c, int num)
	{
		return null;
	}

	public static Cost operator /(Cost c, int num)
	{
		return null;
	}

	public static Cost operator *(Cost c, float num)
	{
		return null;
	}

	public static Cost operator +(Cost c, Cost c2)
	{
		return null;
	}

	public Cost()
	{
	}

	public Cost(Cost c)
	{
	}

	public Cost(int gold, int wheat = 0, int wood = 0, int stone = 0)
	{
	}

	public bool IsEmpty()
	{
		return false;
	}

	public void Clear()
	{
	}

	public void AddResource(ResourceType t, int amt)
	{
	}

	public bool CanAfford()
	{
		return false;
	}

	public void Spend()
	{
	}

	public void Refund()
	{
	}

	public int GetTotalAmount()
	{
		return 0;
	}

	public int GetNumUnique()
	{
		return 0;
	}

	public string ToString(string separator)
	{
		return null;
	}

	public override string ToString()
	{
		return null;
	}

	public static string ToString(int[] num, string separator)
	{
		return null;
	}

	public string GetColorizedStr(string separator = "   ")
	{
		return null;
	}
}
