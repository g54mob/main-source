namespace BCnEncoder.Shared
{
	internal static class InternalUtils
	{
		public static void Swap<T>(ref T lhs, ref T rhs)
		{
			T val = lhs;
			lhs = rhs;
			rhs = val;
		}
	}
}
