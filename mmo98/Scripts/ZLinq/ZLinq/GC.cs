namespace ZLinq
{
	internal static class GC
	{
		internal static T[] AllocateUninitializedArray<T>(int length)
		{
			return new T[length];
		}
	}
}
