using System.Runtime.CompilerServices;

namespace MemoryPack.Internal
{
	internal static class MemoryMarshalEx
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static ref T GetArrayDataReference<T>(T[] array) where T : notnull
		{
			throw null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] AllocateUninitializedArray<T>(int length, bool pinned = false) where T : notnull
		{
			return null;
		}
	}
}
