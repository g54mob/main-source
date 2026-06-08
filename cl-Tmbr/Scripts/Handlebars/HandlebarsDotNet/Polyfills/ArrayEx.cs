using System.Runtime.CompilerServices;

namespace HandlebarsDotNet.Polyfills
{
	internal static class ArrayEx
	{
		private static class EmptyArray<T>
		{
			public static readonly T[] Value = new T[0];
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static T[] Empty<T>()
		{
			return EmptyArray<T>.Value;
		}
	}
}
