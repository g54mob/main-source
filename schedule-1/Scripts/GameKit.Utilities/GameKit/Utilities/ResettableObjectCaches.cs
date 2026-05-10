using System.Runtime.CompilerServices;

namespace GameKit.Utilities
{
	public static class ResettableObjectCaches<T> where T : IResettable
	{
		public static T Retrieve()
		{
			return default(T);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref T value)
		{
		}

		public static void Store(T value)
		{
		}
	}
}
