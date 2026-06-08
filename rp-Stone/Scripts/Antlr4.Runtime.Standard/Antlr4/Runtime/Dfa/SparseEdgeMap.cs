using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Antlr4.Runtime.Sharpen;

namespace Antlr4.Runtime.Dfa
{
	public sealed class SparseEdgeMap<T> : AbstractEdgeMap<T> where T : class
	{
		private const int DefaultMaxSize = 5;

		private readonly int[] keys;

		private readonly List<T> values;

		public int[] Keys => keys;

		public IList<T> Values => values;

		public int MaxSparseSize => keys.Length;

		public override int Count => values.Count;

		public override bool IsEmpty => values.Count == 0;

		public override T this[int key]
		{
			get
			{
				int num = Array.BinarySearch(keys, 0, Count, key);
				if (num < 0)
				{
					return null;
				}
				return values[num];
			}
		}

		public SparseEdgeMap(int minIndex, int maxIndex)
			: this(minIndex, maxIndex, 5)
		{
		}

		public SparseEdgeMap(int minIndex, int maxIndex, int maxSparseSize)
			: base(minIndex, maxIndex)
		{
			keys = new int[maxSparseSize];
			values = new List<T>(maxSparseSize);
		}

		private SparseEdgeMap(SparseEdgeMap<T> map, int maxSparseSize)
			: base(map.minIndex, map.maxIndex)
		{
			lock (map)
			{
				if (maxSparseSize < map.values.Count)
				{
					throw new ArgumentException();
				}
				keys = Arrays.CopyOf(map.keys, maxSparseSize);
				values = new List<T>(maxSparseSize);
				values.AddRange(map.Values);
			}
		}

		public override bool ContainsKey(int key)
		{
			return this[key] != null;
		}

		public override AbstractEdgeMap<T> Put(int key, T value)
		{
			if (key < minIndex || key > maxIndex)
			{
				return this;
			}
			if (value == null)
			{
				return Remove(key);
			}
			lock (this)
			{
				int num = Array.BinarySearch(keys, 0, Count, key);
				if (num >= 0)
				{
					values[num] = value;
					return this;
				}
				int num2 = -num - 1;
				if (Count < MaxSparseSize && num2 == Count)
				{
					keys[num2] = key;
					values.Add(value);
					return this;
				}
				int num3 = ((Count >= MaxSparseSize) ? (MaxSparseSize * 2) : MaxSparseSize);
				int num4 = maxIndex - minIndex + 1;
				if (num3 >= num4 / 2)
				{
					ArrayEdgeMap<T> obj = (ArrayEdgeMap<T>)new ArrayEdgeMap<T>(minIndex, maxIndex).PutAll(this);
					obj.Put(key, value);
					return obj;
				}
				SparseEdgeMap<T> sparseEdgeMap = new SparseEdgeMap<T>(this, num3);
				Array.Copy(sparseEdgeMap.keys, num2, sparseEdgeMap.keys, num2 + 1, Count - num2);
				sparseEdgeMap.keys[num2] = key;
				sparseEdgeMap.values.Insert(num2, value);
				return sparseEdgeMap;
			}
		}

		public override AbstractEdgeMap<T> Remove(int key)
		{
			lock (this)
			{
				int num = Array.BinarySearch(keys, 0, Count, key);
				if (num < 0)
				{
					return this;
				}
				SparseEdgeMap<T> sparseEdgeMap = new SparseEdgeMap<T>(this, MaxSparseSize);
				Array.Copy(sparseEdgeMap.keys, num + 1, sparseEdgeMap.keys, num, Count - num - 1);
				sparseEdgeMap.values.RemoveAt(num);
				return sparseEdgeMap;
			}
		}

		public override AbstractEdgeMap<T> Clear()
		{
			if (IsEmpty)
			{
				return this;
			}
			return new EmptyEdgeMap<T>(minIndex, maxIndex);
		}

		public override IReadOnlyDictionary<int, T> ToMap()
		{
			if (IsEmpty)
			{
				return Collections.EmptyMap<int, T>();
			}
			lock (this)
			{
				IDictionary<int, T> dictionary = new SortedDictionary<int, T>();
				for (int i = 0; i < Count; i++)
				{
					dictionary[keys[i]] = values[i];
				}
				return new ReadOnlyDictionary<int, T>(dictionary);
			}
		}
	}
}
