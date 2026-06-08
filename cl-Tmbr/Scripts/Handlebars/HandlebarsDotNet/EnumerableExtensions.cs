using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using HandlebarsDotNet.Collections;

namespace HandlebarsDotNet
{
	internal static class EnumerableExtensions
	{
		internal struct SequenceOfOneClass<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			private readonly T _value;

			private bool _enumerated;

			public T Current { get; private set; }

			object IEnumerator.Current => Current;

			public SequenceOfOneClass(T value)
			{
				_value = value;
				_enumerated = false;
				Current = default(T);
			}

			public SequenceOfOneClass<T> GetEnumerator()
			{
				return this;
			}

			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public bool MoveNext()
			{
				if (_enumerated)
				{
					Current = default(T);
					return false;
				}
				_enumerated = true;
				Current = _value;
				return true;
			}

			public void Reset()
			{
				_enumerated = false;
			}

			public void Dispose()
			{
			}
		}

		public static bool Any(this IEnumerable builder)
		{
			return builder.GetEnumerator().MoveNext();
		}

		public static bool IsOneOf<TSource, TExpected>(this IEnumerable<TSource> source) where TExpected : TSource
		{
			using IEnumerator<TSource> enumerator = source.GetEnumerator();
			enumerator.MoveNext();
			return enumerator.Current is TExpected && !enumerator.MoveNext();
		}

		public static bool IsMultiple<T>(this IEnumerable<T> source)
		{
			using IEnumerator<T> enumerator = source.GetEnumerator();
			return enumerator.MoveNext() && enumerator.MoveNext();
		}

		public static IEnumerable<T> ApplyOn<T, TV>(this IEnumerable<T> source, Action<TV> mutator) where T : class where TV : T
		{
			foreach (T item in source)
			{
				if (item is TV obj)
				{
					mutator(obj);
				}
				yield return item;
			}
		}

		public static IEnumerable<T> Append<TEnumerable, T>(this TEnumerable source, T item) where TEnumerable : IEnumerable<T>
		{
			using IEnumerator<T> enumerator = source.GetEnumerator();
			while (enumerator.MoveNext())
			{
				yield return enumerator.Current;
			}
			yield return item;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void AddOrUpdate<TK, TV, TO>(this IDictionary<TK, TV> to, TK at, Func<TO, TV> add, Action<TO, TV> update, TO context)
		{
			if (to.TryGetValue(at, out var value))
			{
				update(context, value);
			}
			else
			{
				to.Add(at, add(context));
			}
		}

		public static IIndexed<TKey, TValue> ToIndexed<T, TKey, TValue, TComparer>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector, Func<T, TValue> valueSelector, TComparer comparer) where TComparer : IEqualityComparer<TKey>
		{
			DictionarySlim<TKey, TValue, TComparer> dictionarySlim = new DictionarySlim<TKey, TValue, TComparer>(comparer);
			foreach (T item in enumerable)
			{
				dictionarySlim.AddOrReplace(keySelector(item), valueSelector(item));
			}
			return dictionarySlim;
		}

		public static TValue Optional<TKey, TValue>(this IReadOnlyIndexed<TKey, TValue> indexed, in TKey key)
		{
			indexed.TryGetValue(in key, out var value);
			return value;
		}

		public static SequenceOfOneClass<T> SequenceOfOne<T>(this T value)
		{
			return new SequenceOfOneClass<T>(value);
		}

		public static TList AddMany<T, TList>(this TList list, IEnumerable<T> items) where TList : IAppendOnlyList<T>
		{
			foreach (T item in items)
			{
				list.Add(item);
			}
			return list;
		}
	}
}
