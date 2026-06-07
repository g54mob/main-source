using System.Runtime.CompilerServices;
using Unity.Collections;

namespace MagicaCloth2
{
	internal static class NativeReferenceExtensions
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int MC2InterlockedStartIndex(this ref NativeReference<int> counter, int dataCount)
		{
			return 0;
		}
	}
}
