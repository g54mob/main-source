using System;

public static class EnumExtensions
{
	public static bool IsFlagSet(this Enum flags, Enum flag)
	{
		ulong num = Convert.ToUInt64(flags);
		ulong num2 = Convert.ToUInt64(flag);
		return (num & num2) == num2;
	}
}
