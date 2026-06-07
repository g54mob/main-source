using System;
using System.Collections;
using System.Collections.Generic;

namespace Wintellect.PowerCollections
{
	public static class Algorithms
	{
		[Serializable]
		private class ListRange<T> : ListBase<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly IList<T> wrappedList;

			private readonly int start;

			private int count;

			public override int Count => 0;

			public override T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			bool ICollection<T>.IsReadOnly => false;

			public ListRange(IList<T> wrappedList, int start, int count)
			{
			}

			public override void Clear()
			{
			}

			public override void Insert(int index, T item)
			{
			}

			public override void RemoveAt(int index)
			{
			}

			public override bool Remove(T item)
			{
				return false;
			}
		}

		[Serializable]
		private class ArrayRange<T> : ListBase<T>
		{
			private readonly T[] wrappedArray;

			private readonly int start;

			private int count;

			public override int Count => 0;

			public override T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public ArrayRange(T[] wrappedArray, int start, int count)
			{
			}

			public override void Clear()
			{
			}

			public override void Insert(int index, T item)
			{
			}

			public override void RemoveAt(int index)
			{
			}
		}

		[Serializable]
		private class ReadOnlyCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly ICollection<T> wrappedCollection;

			public int Count => 0;

			public bool IsReadOnly => false;

			public ReadOnlyCollection(ICollection<T> wrappedCollection)
			{
			}

			private static void MethodModifiesCollection()
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

			public bool Contains(T item)
			{
				return false;
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

			public bool Remove(T item)
			{
				return false;
			}
		}

		[Serializable]
		private class ReadOnlyList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly IList<T> wrappedList;

			public int Count => 0;

			public bool IsReadOnly => false;

			public T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public ReadOnlyList(IList<T> wrappedList)
			{
			}

			private static void MethodModifiesCollection()
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

			public int IndexOf(T item)
			{
				return 0;
			}

			public bool Contains(T item)
			{
				return false;
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

			public void Insert(int index, T item)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public bool Remove(T item)
			{
				return false;
			}
		}

		[Serializable]
		private class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, ICollection<KeyValuePair<TKey, TValue>>, IEnumerable<KeyValuePair<TKey, TValue>>, IEnumerable
		{
			private readonly IDictionary<TKey, TValue> wrappedDictionary;

			public ICollection<TKey> Keys => null;

			public ICollection<TValue> Values => null;

			public TValue Item
			{
				get
				{
					return default(TValue);
				}
				set
				{
				}
			}

			public int Count => 0;

			public bool IsReadOnly => false;

			public ReadOnlyDictionary(IDictionary<TKey, TValue> wrappedDictionary)
			{
			}

			private static void MethodModifiesCollection()
			{
			}

			public void Add(TKey key, TValue value)
			{
			}

			public bool ContainsKey(TKey key)
			{
				return false;
			}

			public bool Remove(TKey key)
			{
				return false;
			}

			public bool TryGetValue(TKey key, out TValue value)
			{
				value = default(TValue);
				return false;
			}

			public void Add(KeyValuePair<TKey, TValue> item)
			{
			}

			public void Clear()
			{
			}

			public bool Contains(KeyValuePair<TKey, TValue> item)
			{
				return false;
			}

			public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
			{
			}

			public bool Remove(KeyValuePair<TKey, TValue> item)
			{
				return false;
			}

			public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Serializable]
		private class TypedEnumerator<T> : IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly IEnumerator wrappedEnumerator;

			T IEnumerator<T>.Current => default(T);

			object IEnumerator.Current => null;

			public TypedEnumerator(IEnumerator wrappedEnumerator)
			{
			}

			void IDisposable.Dispose()
			{
			}

			bool IEnumerator.MoveNext()
			{
				return false;
			}

			void IEnumerator.Reset()
			{
			}
		}

		[Serializable]
		private class TypedEnumerable<T> : IEnumerable<T>, IEnumerable
		{
			private readonly IEnumerable wrappedEnumerable;

			public TypedEnumerable(IEnumerable wrappedEnumerable)
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

		[Serializable]
		private class TypedCollection<T> : ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly ICollection wrappedCollection;

			public int Count => 0;

			public bool IsReadOnly => false;

			public TypedCollection(ICollection wrappedCollection)
			{
			}

			private static void MethodModifiesCollection()
			{
			}

			public void Add(T item)
			{
			}

			public void Clear()
			{
			}

			public bool Remove(T item)
			{
				return false;
			}

			public bool Contains(T item)
			{
				return false;
			}

			public void CopyTo(T[] array, int arrayIndex)
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

		[Serializable]
		private class TypedList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private readonly IList wrappedList;

			public T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			public int Count => 0;

			public bool IsReadOnly => false;

			public TypedList(IList wrappedList)
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

			public int IndexOf(T item)
			{
				return 0;
			}

			public void Insert(int index, T item)
			{
			}

			public void RemoveAt(int index)
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
				return false;
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
			}

			public bool Remove(T item)
			{
				return false;
			}
		}

		[Serializable]
		private class UntypedCollection<T> : ICollection, IEnumerable
		{
			private readonly ICollection<T> wrappedCollection;

			public int Count => 0;

			public bool IsSynchronized => false;

			public object SyncRoot => null;

			public UntypedCollection(ICollection<T> wrappedCollection)
			{
			}

			public void CopyTo(Array array, int index)
			{
			}

			public IEnumerator GetEnumerator()
			{
				return null;
			}
		}

		[Serializable]
		private class UntypedList<T> : IList, ICollection, IEnumerable
		{
			private readonly IList<T> wrappedList;

			public bool IsFixedSize => false;

			public bool IsReadOnly => false;

			public object Item
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public int Count => 0;

			public bool IsSynchronized => false;

			public object SyncRoot => null;

			public UntypedList(IList<T> wrappedList)
			{
			}

			private static T ConvertToItemType(string name, object value)
			{
				return default(T);
			}

			public int Add(object value)
			{
				return 0;
			}

			public void Clear()
			{
			}

			public bool Contains(object value)
			{
				return false;
			}

			public int IndexOf(object value)
			{
				return 0;
			}

			public void Insert(int index, object value)
			{
			}

			public void Remove(object value)
			{
			}

			public void RemoveAt(int index)
			{
			}

			public void CopyTo(Array array, int index)
			{
			}

			public IEnumerator GetEnumerator()
			{
				return null;
			}
		}

		[Serializable]
		private class ArrayWrapper<T> : ListBase<T>, IList, ICollection, IEnumerable
		{
			private readonly T[] wrappedArray;

			public override int Count => 0;

			public override T Item
			{
				get
				{
					return default(T);
				}
				set
				{
				}
			}

			bool IList.IsFixedSize => false;

			public ArrayWrapper(T[] wrappedArray)
			{
			}

			public override void Clear()
			{
			}

			public override void Insert(int index, T item)
			{
			}

			public override void RemoveAt(int index)
			{
			}

			public override void CopyTo(T[] array, int arrayIndex)
			{
			}

			public override IEnumerator<T> GetEnumerator()
			{
				return null;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[Serializable]
		private class LexicographicalComparerClass<T> : IComparer<IEnumerable<T>>
		{
			private readonly IComparer<T> itemComparer;

			public LexicographicalComparerClass(IComparer<T> itemComparer)
			{
			}

			public int Compare(IEnumerable<T> x, IEnumerable<T> y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class ReverseComparerClass<T> : IComparer<T>
		{
			private readonly IComparer<T> comparer;

			public ReverseComparerClass(IComparer<T> comparer)
			{
			}

			public int Compare(T x, T y)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class IdentityComparer<T> : IEqualityComparer<T> where T : class
		{
			public bool Equals(T x, T y)
			{
				return false;
			}

			public int GetHashCode(T obj)
			{
				return 0;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		[Serializable]
		private class CollectionEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
		{
			private readonly IEqualityComparer<T> equalityComparer;

			public CollectionEqualityComparer(IEqualityComparer<T> equalityComparer)
			{
			}

			public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
			{
				return false;
			}

			public int GetHashCode(IEnumerable<T> obj)
			{
				return 0;
			}
		}

		[Serializable]
		private class SetEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
		{
			private readonly IEqualityComparer<T> equalityComparer;

			public SetEqualityComparer(IEqualityComparer<T> equalityComparer)
			{
			}

			public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
			{
				return false;
			}

			public int GetHashCode(IEnumerable<T> obj)
			{
				return 0;
			}
		}

		private static Random myRandomGenerator;

		public static IList<T> Range<T>(IList<T> list, int start, int count)
		{
			return null;
		}

		public static IList<T> Range<T>(T[] array, int start, int count)
		{
			return null;
		}

		public static ICollection<T> ReadOnly<T>(ICollection<T> collection)
		{
			return null;
		}

		public static IList<T> ReadOnly<T>(IList<T> list)
		{
			return null;
		}

		public static IDictionary<TKey, TValue> ReadOnly<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			return null;
		}

		public static IEnumerable<T> TypedAs<T>(IEnumerable untypedCollection)
		{
			return null;
		}

		public static ICollection<T> TypedAs<T>(ICollection untypedCollection)
		{
			return null;
		}

		public static IList<T> TypedAs<T>(IList untypedList)
		{
			return null;
		}

		public static ICollection Untyped<T>(ICollection<T> typedCollection)
		{
			return null;
		}

		public static IList Untyped<T>(IList<T> typedList)
		{
			return null;
		}

		public static IList<T> ReadWriteList<T>(T[] array)
		{
			return null;
		}

		public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, T itemFind, T replaceWith)
		{
			return null;
		}

		public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, T itemFind, T replaceWith, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<T> Replace<T>(IEnumerable<T> collection, Predicate<T> predicate, T replaceWith)
		{
			return null;
		}

		public static void ReplaceInPlace<T>(IList<T> list, T itemFind, T replaceWith)
		{
		}

		public static void ReplaceInPlace<T>(IList<T> list, T itemFind, T replaceWith, IEqualityComparer<T> equalityComparer)
		{
		}

		public static void ReplaceInPlace<T>(IList<T> list, Predicate<T> predicate, T replaceWith)
		{
		}

		public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<T> RemoveDuplicates<T>(IEnumerable<T> collection, BinaryPredicate<T> predicate)
		{
			return null;
		}

		public static void RemoveDuplicatesInPlace<T>(IList<T> list)
		{
		}

		public static void RemoveDuplicatesInPlace<T>(IList<T> list, IEqualityComparer<T> equalityComparer)
		{
		}

		public static void RemoveDuplicatesInPlace<T>(IList<T> list, BinaryPredicate<T> predicate)
		{
		}

		public static int FirstConsecutiveEqual<T>(IList<T> list, int count)
		{
			return 0;
		}

		public static int FirstConsecutiveEqual<T>(IList<T> list, int count, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static int FirstConsecutiveEqual<T>(IList<T> list, int count, BinaryPredicate<T> predicate)
		{
			return 0;
		}

		public static int FirstConsecutiveWhere<T>(IList<T> list, int count, Predicate<T> predicate)
		{
			return 0;
		}

		public static T FindFirstWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return default(T);
		}

		public static bool TryFindFirstWhere<T>(IEnumerable<T> collection, Predicate<T> predicate, out T foundItem)
		{
			foundItem = default(T);
			return false;
		}

		public static T FindLastWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return default(T);
		}

		public static bool TryFindLastWhere<T>(IEnumerable<T> collection, Predicate<T> predicate, out T foundItem)
		{
			foundItem = default(T);
			return false;
		}

		public static IEnumerable<T> FindWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return null;
		}

		public static int FindFirstIndexWhere<T>(IList<T> list, Predicate<T> predicate)
		{
			return 0;
		}

		public static int FindLastIndexWhere<T>(IList<T> list, Predicate<T> predicate)
		{
			return 0;
		}

		public static IEnumerable<int> FindIndicesWhere<T>(IList<T> list, Predicate<T> predicate)
		{
			return null;
		}

		public static int FirstIndexOf<T>(IList<T> list, T item)
		{
			return 0;
		}

		public static int FirstIndexOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static int LastIndexOf<T>(IList<T> list, T item)
		{
			return 0;
		}

		public static int LastIndexOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static IEnumerable<int> IndicesOf<T>(IList<T> list, T item)
		{
			return null;
		}

		public static IEnumerable<int> IndicesOf<T>(IList<T> list, T item, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
		{
			return 0;
		}

		public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static int FirstIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
		{
			return 0;
		}

		public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
		{
			return 0;
		}

		public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static int LastIndexOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
		{
			return 0;
		}

		public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor)
		{
			return null;
		}

		public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<int> IndicesOfMany<T>(IList<T> list, IEnumerable<T> itemsToLookFor, BinaryPredicate<T> predicate)
		{
			return null;
		}

		public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern)
		{
			return 0;
		}

		public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern, BinaryPredicate<T> predicate)
		{
			return 0;
		}

		public static int SearchForSubsequence<T>(IList<T> list, IEnumerable<T> pattern, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static bool IsSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return false;
		}

		public static bool IsSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return false;
		}

		public static bool IsProperSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return false;
		}

		public static bool IsProperSubsetOf<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return false;
		}

		public static bool DisjointSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return false;
		}

		public static bool DisjointSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return false;
		}

		public static bool EqualSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return false;
		}

		public static bool EqualSets<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return false;
		}

		public static IEnumerable<T> SetIntersection<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return null;
		}

		public static IEnumerable<T> SetIntersection<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<T> SetUnion<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return null;
		}

		public static IEnumerable<T> SetUnion<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<T> SetDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return null;
		}

		public static IEnumerable<T> SetDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<T> SetSymmetricDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return null;
		}

		public static IEnumerable<T> SetSymmetricDifference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEnumerable<Pair<TFirst, TSecond>> CartesianProduct<TFirst, TSecond>(IEnumerable<TFirst> first, IEnumerable<TSecond> second)
		{
			return null;
		}

		public static string ToString<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public static string ToString<T>(IEnumerable<T> collection, bool recursive, string start, string separator, string end)
		{
			return null;
		}

		public static string ToString<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			return null;
		}

		private static Random GetRandomGenerator()
		{
			return null;
		}

		public static T[] RandomShuffle<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public static T[] RandomShuffle<T>(IEnumerable<T> collection, Random randomGenerator)
		{
			return null;
		}

		public static void RandomShuffleInPlace<T>(IList<T> list)
		{
		}

		public static void RandomShuffleInPlace<T>(IList<T> list, Random randomGenerator)
		{
		}

		public static T[] RandomSubset<T>(IEnumerable<T> collection, int count)
		{
			return null;
		}

		public static T[] RandomSubset<T>(IEnumerable<T> collection, int count, Random randomGenerator)
		{
			return null;
		}

		public static IEnumerable<T[]> GeneratePermutations<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection) where T : IComparable<T>
		{
			return null;
		}

		public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection, IComparer<T> comparer)
		{
			return null;
		}

		public static IEnumerable<T[]> GenerateSortedPermutations<T>(IEnumerable<T> collection, Comparison<T> comparison)
		{
			return null;
		}

		public static T Maximum<T>(IEnumerable<T> collection) where T : IComparable<T>
		{
			return default(T);
		}

		public static T Maximum<T>(IEnumerable<T> collection, IComparer<T> comparer)
		{
			return default(T);
		}

		public static T Maximum<T>(IEnumerable<T> collection, Comparison<T> comparison)
		{
			return default(T);
		}

		public static T Minimum<T>(IEnumerable<T> collection) where T : IComparable<T>
		{
			return default(T);
		}

		public static T Minimum<T>(IEnumerable<T> collection, IComparer<T> comparer)
		{
			return default(T);
		}

		public static T Minimum<T>(IEnumerable<T> collection, Comparison<T> comparison)
		{
			return default(T);
		}

		public static int IndexOfMaximum<T>(IList<T> list) where T : IComparable<T>
		{
			return 0;
		}

		public static int IndexOfMaximum<T>(IList<T> list, IComparer<T> comparer)
		{
			return 0;
		}

		public static int IndexOfMaximum<T>(IList<T> list, Comparison<T> comparison)
		{
			return 0;
		}

		public static int IndexOfMinimum<T>(IList<T> list) where T : IComparable<T>
		{
			return 0;
		}

		public static int IndexOfMinimum<T>(IList<T> list, IComparer<T> comparer)
		{
			return 0;
		}

		public static int IndexOfMinimum<T>(IList<T> list, Comparison<T> comparison)
		{
			return 0;
		}

		public static T[] Sort<T>(IEnumerable<T> collection) where T : IComparable<T>
		{
			return null;
		}

		public static T[] Sort<T>(IEnumerable<T> collection, IComparer<T> comparer)
		{
			return null;
		}

		public static T[] Sort<T>(IEnumerable<T> collection, Comparison<T> comparison)
		{
			return null;
		}

		public static void SortInPlace<T>(IList<T> list) where T : IComparable<T>
		{
		}

		public static void SortInPlace<T>(IList<T> list, IComparer<T> comparer)
		{
		}

		public static void SortInPlace<T>(IList<T> list, Comparison<T> comparison)
		{
		}

		public static T[] StableSort<T>(IEnumerable<T> collection) where T : IComparable<T>
		{
			return null;
		}

		public static T[] StableSort<T>(IEnumerable<T> collection, IComparer<T> comparer)
		{
			return null;
		}

		public static T[] StableSort<T>(IEnumerable<T> collection, Comparison<T> comparison)
		{
			return null;
		}

		public static void StableSortInPlace<T>(IList<T> list) where T : IComparable<T>
		{
		}

		public static void StableSortInPlace<T>(IList<T> list, IComparer<T> comparer)
		{
		}

		public static void StableSortInPlace<T>(IList<T> list, Comparison<T> comparison)
		{
		}

		public static int BinarySearch<T>(IList<T> list, T item, out int index) where T : IComparable<T>
		{
			index = default(int);
			return 0;
		}

		public static int BinarySearch<T>(IList<T> list, T item, IComparer<T> comparer, out int index)
		{
			index = default(int);
			return 0;
		}

		public static int BinarySearch<T>(IList<T> list, T item, Comparison<T> comparison, out int index)
		{
			index = default(int);
			return 0;
		}

		public static IEnumerable<T> MergeSorted<T>(params IEnumerable<T>[] collections) where T : IComparable<T>
		{
			return null;
		}

		public static IEnumerable<T> MergeSorted<T>(IComparer<T> comparer, params IEnumerable<T>[] collections)
		{
			return null;
		}

		public static IEnumerable<T> MergeSorted<T>(Comparison<T> comparison, params IEnumerable<T>[] collections)
		{
			return null;
		}

		public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2) where T : IComparable<T>
		{
			return 0;
		}

		public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2, Comparison<T> comparison)
		{
			return 0;
		}

		public static int LexicographicalCompare<T>(IEnumerable<T> sequence1, IEnumerable<T> sequence2, IComparer<T> comparer)
		{
			return 0;
		}

		public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>() where T : IComparable<T>
		{
			return null;
		}

		public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>(IComparer<T> comparer)
		{
			return null;
		}

		public static IComparer<IEnumerable<T>> GetLexicographicalComparer<T>(Comparison<T> comparison)
		{
			return null;
		}

		public static IComparer<T> GetReverseComparer<T>(IComparer<T> comparer)
		{
			return null;
		}

		public static IEqualityComparer<T> GetIdentityComparer<T>() where T : class
		{
			return null;
		}

		public static Comparison<T> GetReverseComparison<T>(Comparison<T> comparison)
		{
			return null;
		}

		public static IComparer<T> GetComparerFromComparison<T>(Comparison<T> comparison)
		{
			return null;
		}

		public static Comparison<T> GetComparisonFromComparer<T>(IComparer<T> comparer)
		{
			return null;
		}

		public static IEqualityComparer<IEnumerable<T>> GetCollectionEqualityComparer<T>()
		{
			return null;
		}

		public static IEqualityComparer<IEnumerable<T>> GetCollectionEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static IEqualityComparer<IEnumerable<T>> GetSetEqualityComparer<T>()
		{
			return null;
		}

		public static IEqualityComparer<IEnumerable<T>> GetSetEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
		{
			return null;
		}

		public static bool Exists<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return false;
		}

		public static bool TrueForAll<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return false;
		}

		public static int CountWhere<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			return 0;
		}

		public static ICollection<T> RemoveWhere<T>(ICollection<T> collection, Predicate<T> predicate)
		{
			return null;
		}

		public static IEnumerable<TDest> Convert<TSource, TDest>(IEnumerable<TSource> sourceCollection, Converter<TSource, TDest> converter)
		{
			return null;
		}

		public static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
		{
			return null;
		}

		public static Converter<TKey, TValue> GetDictionaryConverter<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue defaultValue)
		{
			return null;
		}

		public static void ForEach<T>(IEnumerable<T> collection, Action<T> action)
		{
		}

		public static int Partition<T>(IList<T> list, Predicate<T> predicate)
		{
			return 0;
		}

		public static int StablePartition<T>(IList<T> list, Predicate<T> predicate)
		{
			return 0;
		}

		public static IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] collections)
		{
			return null;
		}

		public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
		{
			return false;
		}

		public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, IEqualityComparer<T> equalityComparer)
		{
			return false;
		}

		public static bool EqualCollections<T>(IEnumerable<T> collection1, IEnumerable<T> collection2, BinaryPredicate<T> predicate)
		{
			return false;
		}

		public static T[] ToArray<T>(IEnumerable<T> collection)
		{
			return null;
		}

		public static int Count<T>(IEnumerable<T> collection)
		{
			return 0;
		}

		public static int CountEqual<T>(IEnumerable<T> collection, T find)
		{
			return 0;
		}

		public static int CountEqual<T>(IEnumerable<T> collection, T find, IEqualityComparer<T> equalityComparer)
		{
			return 0;
		}

		public static IEnumerable<T> NCopiesOf<T>(int n, T item)
		{
			return null;
		}

		public static void Fill<T>(IList<T> list, T value)
		{
		}

		public static void Fill<T>(T[] array, T value)
		{
		}

		public static void FillRange<T>(IList<T> list, int start, int count, T value)
		{
		}

		public static void FillRange<T>(T[] array, int start, int count, T value)
		{
		}

		public static void Copy<T>(IEnumerable<T> source, IList<T> dest, int destIndex)
		{
		}

		public static void Copy<T>(IEnumerable<T> source, T[] dest, int destIndex)
		{
		}

		public static void Copy<T>(IEnumerable<T> source, IList<T> dest, int destIndex, int count)
		{
		}

		public static void Copy<T>(IEnumerable<T> source, T[] dest, int destIndex, int count)
		{
		}

		public static void Copy<T>(IList<T> source, int sourceIndex, IList<T> dest, int destIndex, int count)
		{
		}

		public static void Copy<T>(IList<T> source, int sourceIndex, T[] dest, int destIndex, int count)
		{
		}

		public static IEnumerable<T> Reverse<T>(IList<T> source)
		{
			return null;
		}

		public static void ReverseInPlace<T>(IList<T> list)
		{
		}

		public static IEnumerable<T> Rotate<T>(IList<T> source, int amountToRotate)
		{
			return null;
		}

		public static void RotateInPlace<T>(IList<T> list, int amountToRotate)
		{
		}
	}
}
