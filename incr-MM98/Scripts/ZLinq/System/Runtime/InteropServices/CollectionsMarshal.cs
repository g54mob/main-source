using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
	internal static class CollectionsMarshal
	{
		internal sealed class FillCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
		{
			[ThreadStatic]
			public static FillCollection<T>? Instance;

			public int Count { get; set; }

			public bool IsReadOnly => true;

			public FillCollection(int count)
			{
				_003Ccount_003EP = count;
				Count = _003Ccount_003EP;
				base._002Ector();
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
			}

			public void Add(T item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(T item)
			{
				return true;
			}

			public IEnumerator<T> GetEnumerator()
			{
				for (int i = 0; i < _003Ccount_003EP; i++)
				{
					yield return default(T);
				}
			}

			public bool Remove(T item)
			{
				return true;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		internal static readonly int ListSize;

		static CollectionsMarshal()
		{
			try
			{
				ListSize = typeof(List<>).GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Length;
			}
			catch
			{
				ListSize = 3;
			}
		}

		internal static Span<T> AsSpan<T>(this List<T>? list)
		{
			Span<T> result = default(Span<T>);
			if (list != null)
			{
				if (ListSize == 3)
				{
					return Unsafe.As<ListViewA<T>>(list)._items.AsSpan(0, list.Count);
				}
				if (ListSize == 4)
				{
					return Unsafe.As<ListViewB<T>>(list)._items.AsSpan(0, list.Count);
				}
			}
			return result;
		}

		internal static void UnsafeSetCount<T>(this List<T>? list, int count)
		{
			if (list != null)
			{
				FillCollection<T> fillCollection = FillCollection<T>.Instance;
				if (fillCollection == null)
				{
					fillCollection = (FillCollection<T>.Instance = new FillCollection<T>(0));
				}
				fillCollection.Count = count;
				list.AddRange(fillCollection);
			}
		}
	}
}
