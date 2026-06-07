using System;
using System.Collections.Generic;
using System.Linq;
using MiscUtil.Extensions;

namespace MiscUtil.Linq.Extensions
{
	public static class EnumerableExt
	{
		public static IEnumerable<KeyValueTuple<TKey, TResult>> GroupWithPipeline<TElement, TKey, TResult>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, Func<IDataProducer<TElement>, IFuture<TResult>> pipeline)
		{
			return source.GroupWithPipeline(keySelector, EqualityComparer<TKey>.Default, pipeline);
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult>> GroupWithPipeline<TElement, TKey, TResult>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<IDataProducer<TElement>, IFuture<TResult>> pipeline)
		{
			Dictionary<TKey, DataProducer<TElement>> keyMap = new Dictionary<TKey, DataProducer<TElement>>(comparer);
			List<KeyValueTuple<TKey, IFuture<TResult>>> results = new List<KeyValueTuple<TKey, IFuture<TResult>>>();
			foreach (TElement item in source)
			{
				TKey key = keySelector(item);
				if (!keyMap.TryGetValue(key, out var value))
				{
					value = (keyMap[key] = new DataProducer<TElement>());
					results.Add(new KeyValueTuple<TKey, IFuture<TResult>>(key, pipeline(value)));
				}
				value.Produce(item);
			}
			foreach (DataProducer<TElement> value2 in keyMap.Values)
			{
				value2.End();
			}
			foreach (KeyValueTuple<TKey, IFuture<TResult>> result in results)
			{
				KeyValueTuple<TKey, IFuture<TResult>> keyValueTuple = result;
				TKey key2 = keyValueTuple.Key;
				KeyValueTuple<TKey, IFuture<TResult>> keyValueTuple2 = result;
				yield return new KeyValueTuple<TKey, TResult>(key2, keyValueTuple2.Value.Value);
			}
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2>> GroupWithPipeline<TElement, TKey, TResult1, TResult2>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2)
		{
			return source.GroupWithPipeline(keySelector, EqualityComparer<TKey>.Default, pipeline1, pipeline2);
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2>> GroupWithPipeline<TElement, TKey, TResult1, TResult2>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2)
		{
			Dictionary<TKey, DataProducer<TElement>> keyMap = new Dictionary<TKey, DataProducer<TElement>>(comparer);
			List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>>> results = new List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>>>();
			foreach (TElement item in source)
			{
				TKey key = keySelector(item);
				if (!keyMap.TryGetValue(key, out var value))
				{
					value = (keyMap[key] = new DataProducer<TElement>());
					results.Add(new KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>>(key, pipeline1(value), pipeline2(value)));
				}
				value.Produce(item);
			}
			foreach (DataProducer<TElement> value3 in keyMap.Values)
			{
				value3.End();
			}
			foreach (KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>> result in results)
			{
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>> keyValueTuple = result;
				TKey key2 = keyValueTuple.Key;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>> keyValueTuple2 = result;
				TResult1 value2 = keyValueTuple2.Value1.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>> keyValueTuple3 = result;
				yield return new KeyValueTuple<TKey, TResult1, TResult2>(key2, value2, keyValueTuple3.Value2.Value);
			}
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2, TResult3>> GroupWithPipeline<TElement, TKey, TResult1, TResult2, TResult3>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2, Func<IDataProducer<TElement>, IFuture<TResult3>> pipeline3)
		{
			return source.GroupWithPipeline(keySelector, EqualityComparer<TKey>.Default, pipeline1, pipeline2, pipeline3);
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2, TResult3>> GroupWithPipeline<TElement, TKey, TResult1, TResult2, TResult3>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2, Func<IDataProducer<TElement>, IFuture<TResult3>> pipeline3)
		{
			Dictionary<TKey, DataProducer<TElement>> keyMap = new Dictionary<TKey, DataProducer<TElement>>(comparer);
			List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>>> results = new List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>>>();
			foreach (TElement item in source)
			{
				TKey key = keySelector(item);
				if (!keyMap.TryGetValue(key, out var value))
				{
					value = (keyMap[key] = new DataProducer<TElement>());
					results.Add(new KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>>(key, pipeline1(value), pipeline2(value), pipeline3(value)));
				}
				value.Produce(item);
			}
			foreach (DataProducer<TElement> value4 in keyMap.Values)
			{
				value4.End();
			}
			foreach (KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>> result in results)
			{
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>> keyValueTuple = result;
				TKey key2 = keyValueTuple.Key;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>> keyValueTuple2 = result;
				TResult1 value2 = keyValueTuple2.Value1.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>> keyValueTuple3 = result;
				TResult2 value3 = keyValueTuple3.Value2.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>> keyValueTuple4 = result;
				yield return new KeyValueTuple<TKey, TResult1, TResult2, TResult3>(key2, value2, value3, keyValueTuple4.Value3.Value);
			}
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2, TResult3, TResult4>> GroupWithPipeline<TElement, TKey, TResult1, TResult2, TResult3, TResult4>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2, Func<IDataProducer<TElement>, IFuture<TResult3>> pipeline3, Func<IDataProducer<TElement>, IFuture<TResult4>> pipeline4)
		{
			return source.GroupWithPipeline(keySelector, EqualityComparer<TKey>.Default, pipeline1, pipeline2, pipeline3, pipeline4);
		}

		public static IEnumerable<KeyValueTuple<TKey, TResult1, TResult2, TResult3, TResult4>> GroupWithPipeline<TElement, TKey, TResult1, TResult2, TResult3, TResult4>(this IEnumerable<TElement> source, Func<TElement, TKey> keySelector, IEqualityComparer<TKey> comparer, Func<IDataProducer<TElement>, IFuture<TResult1>> pipeline1, Func<IDataProducer<TElement>, IFuture<TResult2>> pipeline2, Func<IDataProducer<TElement>, IFuture<TResult3>> pipeline3, Func<IDataProducer<TElement>, IFuture<TResult4>> pipeline4)
		{
			Dictionary<TKey, DataProducer<TElement>> keyMap = new Dictionary<TKey, DataProducer<TElement>>(comparer);
			List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>>> results = new List<KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>>>();
			foreach (TElement item in source)
			{
				TKey key = keySelector(item);
				if (!keyMap.TryGetValue(key, out var value))
				{
					value = (keyMap[key] = new DataProducer<TElement>());
					results.Add(new KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>>(key, pipeline1(value), pipeline2(value), pipeline3(value), pipeline4(value)));
				}
				value.Produce(item);
			}
			foreach (DataProducer<TElement> value5 in keyMap.Values)
			{
				value5.End();
			}
			foreach (KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> result in results)
			{
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> keyValueTuple = result;
				TKey key2 = keyValueTuple.Key;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> keyValueTuple2 = result;
				TResult1 value2 = keyValueTuple2.Value1.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> keyValueTuple3 = result;
				TResult2 value3 = keyValueTuple3.Value2.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> keyValueTuple4 = result;
				TResult3 value4 = keyValueTuple4.Value3.Value;
				KeyValueTuple<TKey, IFuture<TResult1>, IFuture<TResult2>, IFuture<TResult3>, IFuture<TResult4>> keyValueTuple5 = result;
				yield return new KeyValueTuple<TKey, TResult1, TResult2, TResult3, TResult4>(key2, value2, value3, value4, keyValueTuple5.Value4.Value);
			}
		}

		public static TSource Sum<TSource>(this IEnumerable<TSource> source)
		{
			return source.Sum((TSource x) => x);
		}

		public static TValue Sum<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			TValue accumulator = Operator<TValue>.Zero;
			foreach (TSource item in source)
			{
				Operator.AddIfNotNull(ref accumulator, selector(item));
			}
			return accumulator;
		}

		public static TSource Average<TSource>(this IEnumerable<TSource> source)
		{
			return source.Average((TSource x) => x);
		}

		public static TValue Average<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			int num = 0;
			TValue accumulator = Operator<TValue>.Zero;
			foreach (TSource item in source)
			{
				if (Operator.AddIfNotNull(ref accumulator, selector(item)))
				{
					num++;
				}
			}
			if (num == 0)
			{
				accumulator = default(TValue);
				if (accumulator != null)
				{
					throw new InvalidOperationException("Cannot perform non-nullable average over an empty series");
				}
				return accumulator;
			}
			return Operator.DivideInt32(accumulator, num);
		}

		public static TSource Max<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
		{
			TSource val = default(TSource);
			bool flag = true;
			bool flag2 = !Operator.HasValue(val);
			foreach (TSource item in source)
			{
				if (!flag2 || Operator.HasValue(item))
				{
					if (flag)
					{
						val = item;
						flag = false;
					}
					else if (comparer.Compare(item, val) > 0)
					{
						val = item;
					}
				}
			}
			if (flag && val != null)
			{
				throw new InvalidOperationException("Empty sequence");
			}
			return val;
		}

		public static TValue Max<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, IComparer<TValue> comparer)
		{
			return source.Select(selector).Max(comparer);
		}

		public static TSource Min<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
		{
			TSource val = default(TSource);
			bool flag = true;
			bool flag2 = !Operator.HasValue(val);
			foreach (TSource item in source)
			{
				if (!flag2 || Operator.HasValue(item))
				{
					if (flag)
					{
						val = item;
						flag = false;
					}
					else if (comparer.Compare(item, val) < 0)
					{
						val = item;
					}
				}
			}
			if (flag && val != null)
			{
				throw new InvalidOperationException("Empty sequence");
			}
			return val;
		}

		public static TValue Min<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector, IComparer<TValue> comparer)
		{
			return source.Select(selector).Min(comparer);
		}
	}
}
