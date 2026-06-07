using System;

public sealed class ValueType_TEnum : ValueType
{
	public readonly System.Type e;

	public ValueType_TEnum(System.Type e)
		: base(0)
	{
	}

	public override Array getParams()
	{
		return null;
	}

	public override string getTag()
	{
		return null;
	}

	public override int GetHashCode()
	{
		return 0;
	}

	public override bool Equals(object other)
	{
		return false;
	}

	public override string toString()
	{
		return null;
	}
}
