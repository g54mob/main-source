using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Spine
{
	[DebuggerDisplay("Count={Count}")]
	public class ExposedList<T> : IEnumerable<T>, IEnumerable
	{
		public struct Enumerator : IEnumerator<T>, IEnumerator, IDisposable
		{
			private ExposedList<T> l;

			private int next;

			private int ver;

			private T current;

			public T Current => default(T);

			object IEnumerator.Current => null;

			internal Enumerator(ExposedList<T> l)
			{
				this.l = null;
				next = 0;
				ver = 0;
				current = default(T);
			}

			public void Dispose()
			{
			}

			private void VerifyState()
			{
			}

			public bool MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		public T[] Items;

		public int Count;

		private const int DefaultCapacity = 4;

		private static readonly T[] EmptyArray;

		private int version;

		public int Capacity
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public ExposedList()
		{
		}

		public ExposedList(IEnumerable<T> collection)
		{
		}

		public ExposedList(int capacity)
		{
		}

		internal ExposedList(T[] data, int size)
		{
		}

		public void Add(T item)
		{
		}

		public void GrowIfNeeded(int addedCount)
		{
		}

		public ExposedList<T> Resize(int newSize)
		{
			return null;
		}

		public void EnsureCapacity(int min)
		{
		}

		private void CheckRange(int index, int count)
		{
		}

		private void AddCollection(ICollection<T> collection)
		{
		}

		private void AddEnumerable(IEnumerable<T> enumerable)
		{
		}

		public void AddRange(ExposedList<T> list)
		{
		}

		public void AddRange(IEnumerable<T> collection)
		{
		}

		public int BinarySearch(T item)
		{
			return 0;
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return 0;
		}

		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			return 0;
		}

		public void Clear(bool clearArray = true)
		{
		}

		public bool Contains(T item)
		{
			return false;
		}

		public ExposedList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			return null;
		}

		public void CopyTo(T[] array)
		{
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
		}

		public bool Exists(Predicate<T> match)
		{
			return false;
		}

		public T Find(Predicate<T> match)
		{
			return default(T);
		}

		private static void CheckMatch(Predicate<T> match)
		{
		}

		public ExposedList<T> FindAll(Predicate<T> match)
		{
			return null;
		}

		private ExposedList<T> FindAllList(Predicate<T> match)
		{
			return null;
		}

		public int FindIndex(Predicate<T> match)
		{
			return 0;
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return 0;
		}

		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		private int GetIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		public T FindLast(Predicate<T> match)
		{
			return default(T);
		}

		public int FindLastIndex(Predicate<T> match)
		{
			return 0;
		}

		public int FindLastIndex(int startIndex, Predicate<T> match)
		{
			return 0;
		}

		public int FindLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		private int GetLastIndex(int startIndex, int count, Predicate<T> match)
		{
			return 0;
		}

		public void ForEach(Action<T> action)
		{
		}

		public Enumerator GetEnumerator()
		{
			return default(Enumerator);
		}

		public ExposedList<T> GetRange(int index, int count)
		{
			return null;
		}

		public int IndexOf(T item)
		{
			return 0;
		}

		public int IndexOf(T item, int index)
		{
			return 0;
		}

		public int IndexOf(T item, int index, int count)
		{
			return 0;
		}

		private void Shift(int start, int delta)
		{
		}

		private void CheckIndex(int index)
		{
		}

		public void Insert(int index, T item)
		{
		}

		private void CheckCollection(IEnumerable<T> collection)
		{
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
		}

		private void InsertCollection(int index, ICollection<T> collection)
		{
		}

		private void InsertEnumeration(int index, IEnumerable<T> enumerable)
		{
		}

		public int LastIndexOf(T item)
		{
			return 0;
		}

		public int LastIndexOf(T item, int index)
		{
			return 0;
		}

		public int LastIndexOf(T item, int index, int count)
		{
			return 0;
		}

		public bool Remove(T item)
		{
			return false;
		}

		public int RemoveAll(Predicate<T> match)
		{
			return 0;
		}

		public void RemoveAt(int index)
		{
		}

		public T Pop()
		{
			return default(T);
		}

		public void RemoveRange(int index, int count)
		{
		}

		public void Reverse()
		{
		}

		public void Reverse(int index, int count)
		{
		}

		public void Sort()
		{
		}

		public void Sort(IComparer<T> comparer)
		{
		}

		public void Sort(Comparison<T> comparison)
		{
		}

		public void Sort(int index, int count, IComparer<T> comparer)
		{
		}

		public T[] ToArray()
		{
			return null;
		}

		public void TrimExcess()
		{
		}

		public bool TrueForAll(Predicate<T> match)
		{
			return false;
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}
}
