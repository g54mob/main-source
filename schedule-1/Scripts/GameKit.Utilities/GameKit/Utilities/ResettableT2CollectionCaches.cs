using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace GameKit.Utilities
{
	public static class ResettableT2CollectionCaches<T1, T2> where T2 : IResettable
	{
		public static Dictionary<T1, T2> RetrieveDictionary()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void StoreAndDefault(ref Dictionary<T1, T2> value)
		{
		}

		public static void Store(Dictionary<T1, T2> value)
		{
		}
	}
}
