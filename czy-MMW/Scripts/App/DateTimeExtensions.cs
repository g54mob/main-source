using System;

public static class DateTimeExtensions
{
	public static void ToInts(this DateTime fromDateTime, out int lowBits, out int highBits)
	{
		long num = fromDateTime.ToBinary();
		lowBits = (int)num;
		highBits = (int)(num >> 32);
	}

	public static DateTime FromInts(int lowBits, int highBits)
	{
		return DateTime.FromBinary(((long)highBits << 32) | (uint)lowBits);
	}
}
