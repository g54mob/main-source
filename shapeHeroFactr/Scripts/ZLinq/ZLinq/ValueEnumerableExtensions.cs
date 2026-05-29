using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ZLinq.Internal;
using ZLinq.Linq;

namespace ZLinq
{
	public static class ValueEnumerableExtensions
	{
		private const int StackallocCharBufferSizeLimit = 256;

		public static TSource Aggregate<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TSource, TSource> func) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TAccumulate Aggregate<TEnumerator, TSource, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TAccumulate : notnull
		{
			return default(TAccumulate);
		}

		public static TResult Aggregate<TEnumerator, TSource, TAccumulate, TResult>(this ValueEnumerable<TEnumerator, TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TAccumulate : notnull where TResult : notnull
		{
			return default(TResult);
		}

		public static ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
		{
			return default(ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>);
		}

		public static ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
		{
			return default(ValueEnumerable<AggregateBy<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>);
		}

		public static ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
		{
			return default(ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>);
		}

		public static ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>> AggregateBy<TEnumerator, TSource, TKey, TAccumulate>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TAccumulate : notnull
		{
			return default(ValueEnumerable<AggregateBy2<TEnumerator, TSource, TKey, TAccumulate>, KeyValuePair<TKey, TAccumulate>>);
		}

		public static bool All<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		public static bool All<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return false;
		}

		public static bool Any<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return false;
		}

		public static bool Any<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool Any<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return false;
		}

		public static ValueEnumerable<Append<TEnumerator, TSource>, TSource> Append<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource element) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Append<TEnumerator, TSource>, TSource>);
		}

		public static float Average<TEnumerator>(this ValueEnumerable<TEnumerator, float> source) where TEnumerator : struct, IValueEnumerator<float>
		{
			return 0f;
		}

		public static float? Average<TEnumerator>(this ValueEnumerable<TEnumerator, float?> source) where TEnumerator : struct, IValueEnumerator<float?>
		{
			return null;
		}

		public static float Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, float> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return 0f;
		}

		public static float? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, float?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static decimal Average<TEnumerator>(this ValueEnumerable<TEnumerator, decimal> source) where TEnumerator : struct, IValueEnumerator<decimal>
		{
			return default(decimal);
		}

		public static decimal? Average<TEnumerator>(this ValueEnumerable<TEnumerator, decimal?> source) where TEnumerator : struct, IValueEnumerator<decimal?>
		{
			return null;
		}

		public static decimal Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, decimal> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(decimal);
		}

		public static decimal? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, decimal?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static double Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : struct
		{
			return 0.0;
		}

		public static double? Average<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource?> source) where TEnumerator : struct, IValueEnumerator<TSource?> where TSource : struct
		{
			return null;
		}

		public static double Average<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			return 0.0;
		}

		public static double? Average<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			return null;
		}

		public static ValueEnumerable<Chunk<TEnumerator, TSource>, TSource[]> Chunk<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int size) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Chunk<TEnumerator, TSource>, TSource[]>);
		}

		public static ValueEnumerable<Concat<TEnumerator1, TEnumerator2, TSource>, TSource> Concat<TEnumerator1, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator1, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator1 : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Concat<TEnumerator1, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Concat<TEnumerator1, FromEnumerable<TSource>, TSource>, TSource> Concat<TEnumerator1, TSource>(this ValueEnumerable<TEnumerator1, TSource> source, IEnumerable<TSource> second) where TEnumerator1 : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Concat<TEnumerator1, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromEnumerable<TSource>, TSource> source, TSource value) where TSource : notnull
		{
			return false;
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromHashSet<TSource>, TSource> source, TSource value) where TSource : notnull
		{
			return false;
		}

		public static bool Contains<TSource>(this ValueEnumerable<FromSortedSet<TSource>, TSource> source, TSource value) where TSource : notnull
		{
			return false;
		}

		public static bool Contains<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource value) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		private static bool ContainsCore<TEnumerator, TSource>(ref ValueEnumerable<TEnumerator, TSource> source, TSource value) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		public static bool Contains<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource value, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		public static int CopyTo<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Span<TSource> destination) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return 0;
		}

		public static void CopyTo<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, List<TSource> list) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return 0;
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return 0;
		}

		public static int Count<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source)
		{
			return 0;
		}

		public static int Count<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source)
		{
			return 0;
		}

		public static int Count<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static int Count<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return 0;
		}

		public static ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>> CountBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>>);
		}

		public static ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>> CountBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? keyComparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<CountBy<TEnumerator, TSource, TKey>, KeyValuePair<TKey, int>>);
		}

		public static ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource> DefaultIfEmpty<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource> DefaultIfEmpty<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<DefaultIfEmpty<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<Distinct<TEnumerator, TSource>, TSource> Distinct<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Distinct<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<Distinct<TEnumerator, TSource>, TSource> Distinct<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Distinct<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource> DistinctBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource> DistinctBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<DistinctBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static TSource ElementAt<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int index) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource ElementAt<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Index index) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource? ElementAtOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int index) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? ElementAtOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Index index) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		private static bool TryGetElementAt<TEnumerator, TSource>(ref TEnumerator source, Index index, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource> Except<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource> Except<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Except<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Except<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Except<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Except<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<ExceptBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> ExceptBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> ExceptBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<ExceptBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>);
		}

		public static TSource First<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource First<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource? FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource FirstOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		private static bool TryGetFirst<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			value = default(TSource);
			return false;
		}

		private static bool TryGetFirst<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>> GroupBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>>);
		}

		public static ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>> GroupBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<GroupBy<TEnumerator, TSource, TKey>, IGrouping<TKey, TSource>>);
		}

		public static ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>> GroupBy<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return default(ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>>);
		}

		public static ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>> GroupBy<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return default(ValueEnumerable<GroupBy2<TEnumerator, TSource, TKey, TElement>, IGrouping<TKey, TElement>>);
		}

		public static ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupBy3<TEnumerator, TSource, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TElement, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult> GroupBy<TEnumerator, TSource, TKey, TElement, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupBy4<TEnumerator, TSource, TKey, TElement, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> GroupJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, IEnumerable<TInner>, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<GroupJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<Index<TEnumerator, TSource>, (int, TSource)> Index<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Index<TEnumerator, TSource>, (int, TSource)>);
		}

		public static ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource> Intersect<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource> Intersect<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Intersect<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Intersect<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Intersect<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Intersect<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TKey> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<IntersectBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> IntersectBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource> IntersectBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TKey> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<IntersectBy<TEnumerator, FromEnumerable<TKey>, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Join<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> Join<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Join<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		private static string FastAllocateString(string _, int length)
		{
			return null;
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, string separator) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, char separator) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ReadOnlySpan<char> separator) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return null;
		}

		private static string JoinToString(ReadOnlySpan<string> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, string separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, char separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, string separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, char separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, string separator) where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, char separator)
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, string separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, char separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, string separator) where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, char separator)
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, string separator) where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, char separator)
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, string separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, char separator) where TSource : notnull
		{
			return null;
		}

		public static string JoinToString<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static string JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, string separator) where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, char separator)
		{
			return null;
		}

		public static string? JoinToString<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source, ReadOnlySpan<char> separator)
		{
			return null;
		}

		public static TSource Last<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource Last<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource? LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource LastOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		private static bool TryGetLast<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			value = default(TSource);
			return false;
		}

		private static bool TryGetLast<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<LeftJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> LeftJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter, TInner?, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<LeftJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static long LongCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return 0L;
		}

		public static long LongCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return 0L;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static long LongCount<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return 0L;
		}

		public static TResult? Max<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TResult);
		}

		public static TSource? Max<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? Max<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? MaxBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? MaxBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TResult? Min<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TResult);
		}

		public static TSource? Min<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? Min<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? MinBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource? MinBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> Order<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> Order<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> OrderDescending<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource> OrderDescending<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSource>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderByDescending<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> OrderByDescending<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator?, TSource?, TSecondKey?>, TSource?> ThenBy<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator?, TSource?, TSecondKey?>, TSource?> ThenBy<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator?, TSource?, TSecondKey?>, TSource?> ThenByDescending<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>);
		}

		public static ValueEnumerable<OrderBy<TEnumerator?, TSource?, TSecondKey?>, TSource?> ThenByDescending<TEnumerator, TSource, TKey, TSecondKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, Func<TSource, TSecondKey> keySelector, IComparer<TSecondKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBy<TEnumerator, TSource, TSecondKey>, TSource>);
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator?, TSource?, TKey?>, TSource?> Skip<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator?, TSource?, TKey?>, TSource?> Take<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBy<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator?, TSource?, TKey?>, TSource?> Skip<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<OrderBySkipTake<TEnumerator?, TSource?, TKey?>, TSource?> Take<TEnumerator, TSource, TKey>(this ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(ValueEnumerable<OrderBySkipTake<TEnumerator, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<Prepend<TEnumerator, TSource>, TSource> Prepend<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource element) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Prepend<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<Reverse<TEnumerator, TSource>, TSource> Reverse<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Reverse<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, ValueEnumerable<TEnumerator2, TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TEnumerator2 : struct, IValueEnumerator<TInner> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<RightJoin<TEnumerator, TEnumerator2, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult> RightJoin<TEnumerator, TOuter, TInner, TKey, TResult>(this ValueEnumerable<TEnumerator, TOuter> source, IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<TOuter?, TInner, TResult> resultSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TOuter> where TOuter : notnull where TInner : notnull where TKey : notnull where TResult : notnull
		{
			return default(ValueEnumerable<RightJoin<TEnumerator, FromEnumerable<TInner>, TOuter, TInner, TKey, TResult>, TResult>);
		}

		public static ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<Select2<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Select2<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<RangeSelect<TResult>, TResult> Select<TResult>(this ValueEnumerable<FromRange, int> source, Func<int, TResult> selector)
		{
			return default(ValueEnumerable<RangeSelect<TResult>, TResult>);
		}

		public static ValueEnumerable<SelectWhere<TEnumerator, TSource, TResult>, TResult> Where<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source, Func<TResult, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectWhere<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ArraySelect<TSource?, TResult?>, TResult?> Select<TSource, TResult>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return default(ValueEnumerable<ArraySelect<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ArraySelectWhere<TSource?, TResult?>, TResult?> Where<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source, Func<TResult, bool> predicate)
		{
			return default(ValueEnumerable<ArraySelectWhere<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ListSelect<TSource?, TResult?>, TResult?> Select<TSource, TResult>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return default(ValueEnumerable<ListSelect<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ListSelectWhere<TSource?, TResult?>, TResult?> Where<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source, Func<TResult, bool> predicate)
		{
			return default(ValueEnumerable<ListSelectWhere<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany<TEnumerator, TEnumerator2, TSource, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, ValueEnumerable<TEnumerator2, TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
		{
			return default(ValueEnumerable<SelectMany<TEnumerator, TEnumerator2, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany2<TEnumerator, TEnumerator2, TSource, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, ValueEnumerable<TEnumerator2, TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TResult>
		{
			return default(ValueEnumerable<SelectMany2<TEnumerator, TEnumerator2, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection> where TSource : notnull where TCollection : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany3<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TEnumerator2, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, ValueEnumerable<TEnumerator2, TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TCollection> where TSource : notnull where TCollection : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany4<TEnumerator, TEnumerator2, TSource, TCollection, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany<TEnumerator, TSource, TResult>, TResult> SelectMany<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, IEnumerable<TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany2<TEnumerator, TSource, TResult>, TResult> SelectMany<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, IEnumerable<TResult>> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany2<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany3<TEnumerator, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TCollection : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany3<TEnumerator, TSource, TCollection, TResult>, TResult>);
		}

		public static ValueEnumerable<SelectMany4<TEnumerator, TSource, TCollection, TResult>, TResult> SelectMany<TEnumerator, TSource, TCollection, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TCollection : notnull where TResult : notnull
		{
			return default(ValueEnumerable<SelectMany4<TEnumerator, TSource, TCollection, TResult>, TResult>);
		}

		public static bool SequenceEqual<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		public static bool SequenceEqual<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return false;
		}

		public static bool SequenceEqual<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return false;
		}

		public static bool SequenceEqual<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return false;
		}

		public static ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> Shuffle<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> TakeLast<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource> SkipLast<TEnumerator, TSource>(this ValueEnumerable<Shuffle<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<ShuffleSkipTake<TEnumerator, TSource>, TSource>);
		}

		public static TSource Single<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource Single<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource? SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource?>?
		{
			return default(TSource);
		}

		public static TSource SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		public static TSource SingleOrDefault<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate, TSource defaultValue) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(TSource);
		}

		private static bool TryGetSingle<TEnumerator, TSource>(ref TEnumerator source, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			value = default(TSource);
			return false;
		}

		private static bool TryGetSingle<TEnumerator, TSource>(ref TEnumerator source, Func<TSource, bool> predicate, out TSource value) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			value = default(TSource);
			return false;
		}

		public static ValueEnumerable<Skip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Skip<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<SkipLast<TEnumerator, TSource>, TSource> SkipLast<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<SkipLast<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<SkipWhile<TEnumerator, TSource>, TSource> SkipWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<SkipWhile<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<SkipWhile2<TEnumerator, TSource>, TSource> SkipWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<SkipWhile2<TEnumerator, TSource>, TSource>);
		}

		public static TResult Sum<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			return default(TResult);
		}

		public static TResult? Sum<TEnumerator, TSource, TResult>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TResult?> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TResult : struct
		{
			return null;
		}

		public static TSource? Sum<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource?> source) where TEnumerator : struct, IValueEnumerator<TSource?> where TSource : struct
		{
			return null;
		}

		public static TSource Sum<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : struct
		{
			return default(TSource);
		}

		public static ValueEnumerable<Take<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Take<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeRange<TEnumerator, TSource>, TSource> Take<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Range range) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<TakeRange<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<Take<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> Skip<TEnumerator, TSource>(this ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<TakeSkip<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeLast<TEnumerator, TSource>, TSource> TakeLast<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<TakeLast<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeWhile<TEnumerator, TSource>, TSource> TakeWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<TakeWhile<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<TakeWhile2<TEnumerator, TSource>, TSource> TakeWhile<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<TakeWhile2<TEnumerator, TSource>, TSource>);
		}

		public static TSource[] ToArray<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static TResult[] ToArray<TResult>(this ValueEnumerable<RangeSelect<TResult>, TResult> source) where TResult : notnull
		{
			return null;
		}

		public static TResult?[]? ToArray<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source)
		{
			return null;
		}

		public static TSource[] ToArray<TEnumerator, TSource>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static TSource[] ToArray<TSource>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source) where TSource : notnull
		{
			return null;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static TResult?[]? ToArray<TSource, TResult>(this ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult> source)
		{
			return null;
		}

		public static TSource[] ToArray<TSource>(this ValueEnumerable<ListWhere<TSource>, TSource> source) where TSource : notnull
		{
			return null;
		}

		public static TResult?[]? ToArray<TSource, TResult>(this ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult> source)
		{
			return null;
		}

		public static TResult[] ToArray<TEnumerator, TSource, TResult>(this ValueEnumerable<OfType<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static PooledArray<TSource> ToArrayPool<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			return default(PooledArray<TSource>);
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, KeyValuePair<TKey, TValue>> source) where TEnumerator : struct, IValueEnumerator<KeyValuePair<TKey, TValue>> where TKey : notnull where TValue : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<KeyValuePair<TKey, TValue>> where TKey : notnull where TValue : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, (TKey Key, TValue Value)> source) where TEnumerator : struct, IValueEnumerator<(TKey, TValue)> where TKey : notnull where TValue : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TValue> ToDictionary<TEnumerator, TKey, TValue>(this ValueEnumerable<TEnumerator, (TKey Key, TValue Value)> source, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<(TKey, TValue)> where TKey : notnull where TValue : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TSource> ToDictionary<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TSource> ToDictionary<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TElement> ToDictionary<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return null;
		}

		public static Dictionary<TKey, TElement> ToDictionary<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return null;
		}

		public static HashSet<TSource> ToHashSet<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static HashSet<TSource> ToHashSet<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		internal static HashSetSlim<TSource> ToHashSetSlim<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static List<TSource> ToList<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return null;
		}

		public static List<TResult> ToList<TEnumerator, TSource, TResult>(this ValueEnumerable<Select<TEnumerator, TSource, TResult>, TResult> source) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return null;
		}

		public static List<TResult> ToList<TResult>(this ValueEnumerable<RangeSelect<TResult>, TResult> source) where TResult : notnull
		{
			return null;
		}

		public static List<TResult?>? ToList<TSource, TResult>(this ValueEnumerable<ArraySelect<TSource, TResult>, TResult> source)
		{
			return null;
		}

		public static List<TResult?>? ToList<TSource, TResult>(this ValueEnumerable<ListSelect<TSource, TResult>, TResult> source)
		{
			return null;
		}

		public static ILookup<TKey, TSource> ToLookup<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return null;
		}

		public static ILookup<TKey, TSource> ToLookup<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return null;
		}

		public static ILookup<TKey, TElement> ToLookup<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return null;
		}

		public static ILookup<TKey, TElement> ToLookup<TEnumerator, TSource, TKey, TElement>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull where TElement : notnull
		{
			return null;
		}

		public static bool TryGetNonEnumeratedCount<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, out int count) where TEnumerator : struct, IValueEnumerator<TSource>
		{
			count = default(int);
			return false;
		}

		public static ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource> Union<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource> Union<TEnumerator, TEnumerator2, TSource>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource>
		{
			return default(ValueEnumerable<Union<TEnumerator, TEnumerator2, TSource>, TSource>);
		}

		public static ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Union<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource> Union<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, IEqualityComparer<TSource>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Union<TEnumerator, FromEnumerable<TSource>, TSource>, TSource>);
		}

		public static ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource> UnionBy<TEnumerator, TEnumerator2, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, ValueEnumerable<TEnumerator2, TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TEnumerator2 : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<UnionBy<TEnumerator, TEnumerator2, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource> UnionBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, Func<TSource, TKey> keySelector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource> UnionBy<TEnumerator, TSource, TKey>(this ValueEnumerable<TEnumerator, TSource> source, IEnumerable<TSource> second, Func<TSource, TKey> keySelector, IEqualityComparer<TKey>? comparer) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TKey : notnull
		{
			return default(ValueEnumerable<UnionBy<TEnumerator, FromEnumerable<TSource>, TSource, TKey>, TSource>);
		}

		public static ValueEnumerable<Where<TEnumerator, TSource>, TSource> Where<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Where<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<Where2<TEnumerator, TSource>, TSource> Where<TEnumerator, TSource>(this ValueEnumerable<TEnumerator, TSource> source, Func<TSource, int, bool> predicate) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull
		{
			return default(ValueEnumerable<Where2<TEnumerator, TSource>, TSource>);
		}

		public static ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult> Select<TEnumerator, TSource, TResult>(this ValueEnumerable<Where<TEnumerator, TSource>, TSource> source, Func<TSource, TResult> selector) where TEnumerator : struct, IValueEnumerator<TSource> where TSource : notnull where TResult : notnull
		{
			return default(ValueEnumerable<WhereSelect<TEnumerator, TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ArrayWhere<TSource>, TSource> Where<TSource>(this ValueEnumerable<FromArray<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return default(ValueEnumerable<ArrayWhere<TSource>, TSource>);
		}

		public static ValueEnumerable<ArrayWhereSelect<TSource?, TResult?>, TResult?> Select<TSource, TResult>(this ValueEnumerable<ArrayWhere<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return default(ValueEnumerable<ArrayWhereSelect<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<ListWhere<TSource>, TSource> Where<TSource>(this ValueEnumerable<FromList<TSource>, TSource> source, Func<TSource, bool> predicate) where TSource : notnull
		{
			return default(ValueEnumerable<ListWhere<TSource>, TSource>);
		}

		public static ValueEnumerable<ListWhereSelect<TSource?, TResult?>, TResult?> Select<TSource, TResult>(this ValueEnumerable<ListWhere<TSource>, TSource> source, Func<TSource, TResult> selector)
		{
			return default(ValueEnumerable<ListWhereSelect<TSource, TResult>, TResult>);
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond>, (TFirst, TSecond)> Zip<TEnumerator, TEnumerator2, TFirst, TSecond>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond>
		{
			return default(ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond>, (TFirst, TSecond)>);
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)> Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second, ValueEnumerable<TEnumerator3, TThird> third) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond> where TEnumerator3 : struct, IValueEnumerator<TThird>
		{
			return default(ValueEnumerable<Zip<TEnumerator, TEnumerator2, TEnumerator3, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)>);
		}

		public static ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>, TResult> Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>(this ValueEnumerable<TEnumerator, TFirst> source, ValueEnumerable<TEnumerator2, TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TFirst> where TEnumerator2 : struct, IValueEnumerator<TSecond> where TFirst : notnull where TSecond : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Zip<TEnumerator, TEnumerator2, TFirst, TSecond, TResult>, TResult>);
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond>, (TFirst, TSecond)> Zip<TEnumerator, TFirst, TSecond>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second) where TEnumerator : struct, IValueEnumerator<TFirst> where TFirst : notnull where TSecond : notnull
		{
			return default(ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond>, (TFirst, TSecond)>);
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, FromEnumerable<TThird>, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)> Zip<TEnumerator, TFirst, TSecond, TThird>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second, IEnumerable<TThird> third) where TEnumerator : struct, IValueEnumerator<TFirst> where TFirst : notnull where TSecond : notnull where TThird : notnull
		{
			return default(ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, FromEnumerable<TThird>, TFirst, TSecond, TThird>, (TFirst, TSecond, TThird)>);
		}

		public static ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond, TResult>, TResult> Zip<TEnumerator, TFirst, TSecond, TResult>(this ValueEnumerable<TEnumerator, TFirst> source, IEnumerable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector) where TEnumerator : struct, IValueEnumerator<TFirst> where TFirst : notnull where TSecond : notnull where TResult : notnull
		{
			return default(ValueEnumerable<Zip<TEnumerator, FromEnumerable<TSecond>, TFirst, TSecond, TResult>, TResult>);
		}

		public static ValueEnumerator<TEnumerator, T> GetEnumerator<TEnumerator, T>(this in ValueEnumerable<TEnumerator, T> valueEnumerable) where TEnumerator : struct, IValueEnumerator<T>
		{
			return default(ValueEnumerator<TEnumerator, T>);
		}
	}
}
