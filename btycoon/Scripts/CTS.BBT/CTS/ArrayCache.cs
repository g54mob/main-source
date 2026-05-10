using System;

namespace CTS
{
	public static class ArrayCache<T>
	{
		private static T[] _array = Array.Empty<T>();

		public static T[] Get(int minCount)
		{
			if (_array.Length < minCount)
			{
				_array = new T[minCount + 5];
			}
			return _array;
		}
	}
}
