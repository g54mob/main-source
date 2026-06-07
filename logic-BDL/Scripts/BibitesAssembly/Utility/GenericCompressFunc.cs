using System;

namespace Utility
{
	public static class GenericCompressFunc
	{
		public static T Oldest<T>(T[] array, Func<int, int> remap, int n)
		{
			return array[remap(n - 1)];
		}

		public static T Latest<T>(T[] array, Func<int, int> remap, int n)
		{
			return array[remap(0)];
		}
	}
}
