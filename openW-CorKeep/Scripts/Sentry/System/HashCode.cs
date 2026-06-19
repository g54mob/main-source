namespace System
{
	internal static class HashCode
	{
		public static int Combine<T1, T2>(T1 value1, T2 value2)
		{
			return (value1, value2).GetHashCode();
		}

		public static int Combine<T1, T2, T3>(T1 value1, T2 value2, T3 value3)
		{
			return (value1, value2, value3).GetHashCode();
		}
	}
}
