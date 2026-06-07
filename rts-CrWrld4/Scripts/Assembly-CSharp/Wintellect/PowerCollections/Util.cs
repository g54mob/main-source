using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	internal static class Util
	{
		[Serializable]
		private class WrapEnumerable<T> : IEnumerable<T>, IEnumerable
		{
			private IEnumerable<T> wrapped;

			public WrapEnumerable(IEnumerable<T> wrapped)
			{
			}

			public IEnumerator<T> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static bool IsCloneableType(Type type, out bool isValue)
		{
			isValue = default(bool);
			return false;
		}

		public static string SimpleClassName(Type type)
		{
			return null;
		}

		public static IEnumerable<T> CreateEnumerableWrapper<T>(IEnumerable<T> wrapped)
		{
			return null;
		}

		public static int GetHashCode<T>(T item, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}
	}
}
