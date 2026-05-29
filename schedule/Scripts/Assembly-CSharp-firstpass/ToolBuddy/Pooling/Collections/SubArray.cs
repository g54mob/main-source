using JetBrains.Annotations;
using ToolBuddy.Pooling.Pools;

namespace ToolBuddy.Pooling.Collections
{
	public readonly struct SubArray<T>
	{
		public readonly T[] Array;

		public readonly int Count;

		public T this[int index]
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public SubArray([NotNull] T[] array)
		{
			Array = null;
			Count = 0;
		}

		public SubArray(T[] array, int count)
		{
			Array = null;
			Count = 0;
		}

		public T[] CopyToArray(ArrayPool<T> arrayPool)
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(SubArray<T> obj)
		{
			return false;
		}

		public static bool operator ==(SubArray<T> a, SubArray<T> b)
		{
			return false;
		}

		public static bool operator !=(SubArray<T> a, SubArray<T> b)
		{
			return false;
		}
	}
}
