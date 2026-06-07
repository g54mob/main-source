using System;
using System.Collections.Generic;
using System.Linq;
using MiscUtil.Collections;
using MiscUtil.Collections.Extensions;
using MiscUtil.Extensions;

namespace MiscUtil.Linq.Extensions
{
	public static class DataProducerExt
	{
		public static IFuture<int> Count<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<int> ret = new Future<int>();
			int count = 0;
			source.DataProduced += delegate
			{
				count++;
			};
			source.EndOfData += delegate
			{
				ret.Value = count;
			};
			return ret;
		}

		public static IFuture<int> Count<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<int> ret = new Future<int>();
			int count = 0;
			source.DataProduced += delegate(TSource t)
			{
				if (predicate(t))
				{
					count++;
				}
			};
			source.EndOfData += delegate
			{
				ret.Value = count;
			};
			return ret;
		}

		public static IFuture<long> LongCount<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<long> ret = new Future<long>();
			int count = 0;
			source.DataProduced += delegate
			{
				count++;
			};
			source.EndOfData += delegate
			{
				ret.Value = count;
			};
			return ret;
		}

		public static IFuture<long> LongCount<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<long> ret = new Future<long>();
			int count = 0;
			source.DataProduced += delegate(TSource t)
			{
				if (predicate(t))
				{
					count++;
				}
			};
			source.EndOfData += delegate
			{
				ret.Value = count;
			};
			return ret;
		}

		public static IFuture<TSource> First<TSource>(this IDataProducer<TSource> source)
		{
			return source.First((TSource x) => true);
		}

		public static IFuture<TSource> First<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			Action completion = delegate
			{
				throw new InvalidOperationException("Sequence is empty");
			};
			Action<TSource> production = null;
			production = delegate(TSource t)
			{
				if (predicate(t))
				{
					ret.Value = t;
					source.EndOfData -= completion;
					source.DataProduced -= production;
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<TSource> Last<TSource>(this IDataProducer<TSource> source)
		{
			return source.Last((TSource x) => true);
		}

		public static IFuture<TSource> Last<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			bool gotData = false;
			TSource prev = default(TSource);
			source.DataProduced += delegate(TSource value)
			{
				if (predicate(value))
				{
					prev = value;
					gotData = true;
				}
			};
			source.EndOfData += delegate
			{
				if (!gotData)
				{
					throw new InvalidOperationException("Sequence is empty");
				}
				ret.Value = prev;
			};
			return ret;
		}

		public static IFuture<TSource> FirstOrDefault<TSource>(this IDataProducer<TSource> source)
		{
			return source.FirstOrDefault((TSource x) => true);
		}

		public static IFuture<TSource> FirstOrDefault<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			Action completion = delegate
			{
				ret.Value = default(TSource);
			};
			Action<TSource> production = null;
			production = delegate(TSource t)
			{
				if (predicate(t))
				{
					ret.Value = t;
					source.EndOfData -= completion;
					source.DataProduced -= production;
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<TSource> LastOrDefault<TSource>(this IDataProducer<TSource> source)
		{
			return source.LastOrDefault((TSource x) => true);
		}

		public static IFuture<TSource> LastOrDefault<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			TSource prev = default(TSource);
			source.DataProduced += delegate(TSource value)
			{
				if (predicate(value))
				{
					prev = value;
				}
			};
			source.EndOfData += delegate
			{
				ret.Value = prev;
			};
			return ret;
		}

		public static IFuture<TSource> Single<TSource>(this IDataProducer<TSource> source)
		{
			return source.Single((TSource x) => true);
		}

		public static IFuture<TSource> Single<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			TSource output = default(TSource);
			bool gotValue = false;
			source.DataProduced += delegate(TSource value)
			{
				if (predicate(value))
				{
					if (gotValue)
					{
						throw new InvalidOperationException("More than one element in source data");
					}
					output = value;
					gotValue = true;
				}
			};
			source.EndOfData += delegate
			{
				if (!gotValue)
				{
					throw new InvalidOperationException("No elements in source data");
				}
				ret.Value = output;
			};
			return ret;
		}

		public static IFuture<TSource> SingleOrDefault<TSource>(this IDataProducer<TSource> source)
		{
			return source.SingleOrDefault((TSource x) => true);
		}

		public static IFuture<TSource> SingleOrDefault<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<TSource> ret = new Future<TSource>();
			TSource output = default(TSource);
			bool gotValue = false;
			source.DataProduced += delegate(TSource value)
			{
				if (predicate(value))
				{
					if (gotValue)
					{
						throw new InvalidOperationException("More than one element in source data");
					}
					output = value;
					gotValue = true;
				}
			};
			source.EndOfData += delegate
			{
				ret.Value = output;
			};
			return ret;
		}

		public static IFuture<TSource> ElementAt<TSource>(this IDataProducer<TSource> source, int index)
		{
			source.ThrowIfNull("source");
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Future<TSource> ret = new Future<TSource>();
			Action completion = delegate
			{
				throw new ArgumentOutOfRangeException("Specified index never reached");
			};
			Action<TSource> production = null;
			production = delegate(TSource value)
			{
				if (index == 0)
				{
					ret.Value = value;
					source.DataProduced -= production;
					source.EndOfData -= completion;
				}
				else
				{
					index--;
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<TSource> ElementAtOrDefault<TSource>(this IDataProducer<TSource> source, int index)
		{
			source.ThrowIfNull("source");
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			Future<TSource> ret = new Future<TSource>();
			Action completion = delegate
			{
				ret.Value = default(TSource);
			};
			Action<TSource> production = null;
			production = delegate(TSource value)
			{
				if (index == 0)
				{
					ret.Value = value;
					source.DataProduced -= production;
					source.EndOfData -= completion;
				}
				else
				{
					index--;
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<bool> All<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			predicate.ThrowIfNull("predicate");
			return FutureProxy<bool>.FromFuture(source.Any((TSource value) => !predicate(value)), (bool value) => !value);
		}

		public static IFuture<bool> Any<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<bool> ret = new Future<bool>();
			Action<TSource> production = null;
			Action completion = delegate
			{
				ret.Value = false;
			};
			production = delegate
			{
				ret.Value = true;
				source.DataProduced -= production;
				source.EndOfData -= completion;
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<bool> Any<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			Future<bool> ret = new Future<bool>();
			Action<TSource> production = null;
			Action completion = delegate
			{
				ret.Value = false;
			};
			production = delegate(TSource value)
			{
				if (predicate(value))
				{
					ret.Value = true;
					source.DataProduced -= production;
					source.EndOfData -= completion;
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IFuture<bool> Contains<TSource>(this IDataProducer<TSource> source, TSource value)
		{
			return source.Contains(value, EqualityComparer<TSource>.Default);
		}

		public static IFuture<bool> Contains<TSource>(this IDataProducer<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
		{
			source.ThrowIfNull("source");
			comparer.ThrowIfNull("comparer");
			return source.Any((TSource element) => comparer.Equals(value, element));
		}

		public static IFuture<TSource> Aggregate<TSource>(this IDataProducer<TSource> source, Func<TSource, TSource, TSource> func)
		{
			source.ThrowIfNull("source");
			func.ThrowIfNull("func");
			Future<TSource> ret = new Future<TSource>();
			bool first = true;
			TSource current = default(TSource);
			source.DataProduced += delegate(TSource value)
			{
				if (first)
				{
					first = false;
					current = value;
				}
				else
				{
					current = func(current, value);
				}
			};
			source.EndOfData += delegate
			{
				ret.Value = current;
			};
			return ret;
		}

		public static IFuture<TAccumulate> Aggregate<TSource, TAccumulate>(this IDataProducer<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
		{
			return source.Aggregate(seed, func, (TAccumulate x) => x);
		}

		public static IFuture<TResult> Aggregate<TSource, TAccumulate, TResult>(this IDataProducer<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
		{
			source.ThrowIfNull("source");
			func.ThrowIfNull("func");
			resultSelector.ThrowIfNull("resultSelector");
			Future<TResult> result = new Future<TResult>();
			TAccumulate current = seed;
			source.DataProduced += delegate(TSource value)
			{
				current = func(current, value);
			};
			source.EndOfData += delegate
			{
				result.Value = resultSelector(current);
			};
			return result;
		}

		public static IDataProducer<IProducerGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.GroupBy(keySelector, (Func<TSource, TSource>)((TSource elt) => elt), (Func<TKey, IDataProducer<TSource>, IProducerGrouping<TKey, TSource>>)((TKey key, IDataProducer<TSource> elements) => new ProducerGrouping<TKey, TSource>(key, elements)), (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default);
		}

		public static IDataProducer<IProducerGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return source.GroupBy(keySelector, (Func<TSource, TSource>)((TSource elt) => elt), (Func<TKey, IDataProducer<TSource>, IProducerGrouping<TKey, TSource>>)((TKey key, IDataProducer<TSource> elements) => new ProducerGrouping<TKey, TSource>(key, elements)), comparer);
		}

		public static IDataProducer<IProducerGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return source.GroupBy(keySelector, elementSelector, (Func<TKey, IDataProducer<TElement>, IProducerGrouping<TKey, TElement>>)((TKey key, IDataProducer<TElement> elements) => new ProducerGrouping<TKey, TElement>(key, elements)), (IEqualityComparer<TKey>)EqualityComparer<TKey>.Default);
		}

		public static IDataProducer<TResult> GroupBy<TSource, TKey, TResult>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IDataProducer<TSource>, TResult> resultSelector)
		{
			return source.GroupBy(keySelector, (TSource elt) => elt, resultSelector, EqualityComparer<TKey>.Default);
		}

		public static IDataProducer<IProducerGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			return source.GroupBy(keySelector, elementSelector, (Func<TKey, IDataProducer<TElement>, IProducerGrouping<TKey, TElement>>)((TKey key, IDataProducer<TElement> elements) => new ProducerGrouping<TKey, TElement>(key, elements)), comparer);
		}

		public static IDataProducer<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IDataProducer<TElement>, TResult> resultSelector)
		{
			return source.GroupBy(keySelector, elementSelector, resultSelector, EqualityComparer<TKey>.Default);
		}

		public static IDataProducer<TResult> GroupBy<TSource, TKey, TResult>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IDataProducer<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			return source.GroupBy(keySelector, (TSource elt) => elt, resultSelector, comparer);
		}

		public static IDataProducer<TResult> GroupBy<TSource, TKey, TElement, TResult>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IDataProducer<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)
		{
			source.ThrowIfNull("source");
			keySelector.ThrowIfNull("keySelector");
			elementSelector.ThrowIfNull("elementSelector");
			resultSelector.ThrowIfNull("resultSelector");
			comparer.ThrowIfNull("comparer");
			DataProducer<TResult> ret = new DataProducer<TResult>();
			Dictionary<TKey, DataProducer<TElement>> dictionary = new Dictionary<TKey, DataProducer<TElement>>(comparer);
			source.DataProduced += delegate(TSource value)
			{
				TKey val = keySelector(value);
				if (!dictionary.TryGetValue(val, out var value2))
				{
					value2 = new DataProducer<TElement>();
					dictionary[val] = value2;
					ret.Produce(resultSelector(val, value2));
				}
				value2.Produce(elementSelector(value));
			};
			source.EndOfData += delegate
			{
				foreach (DataProducer<TElement> value3 in dictionary.Values)
				{
					value3.End();
				}
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> Where<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			predicate.ThrowIfNull("predicate");
			return source.Where((TSource x, int index) => predicate(x));
		}

		public static IDataProducer<TSource> Where<TSource>(this IDataProducer<TSource> source, Func<TSource, int, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			int index = 0;
			source.DataProduced += delegate(TSource value)
			{
				if (predicate(value, index++))
				{
					ret.Produce(value);
				}
			};
			source.EndOfData += delegate
			{
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> DefaultIfEmpty<TSource>(this IDataProducer<TSource> source, TSource defaultValue)
		{
			source.ThrowIfNull("source");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			bool empty = true;
			source.DataProduced += delegate(TSource value)
			{
				empty = false;
				ret.Produce(value);
			};
			source.EndOfData += delegate
			{
				if (empty)
				{
					ret.Produce(defaultValue);
				}
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> DefaultIfEmpty<TSource>(this IDataProducer<TSource> source)
		{
			return source.DefaultIfEmpty(default(TSource));
		}

		public static IDataProducer<TResult> Select<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, TResult> projection)
		{
			projection.ThrowIfNull("projection");
			return source.Select((TSource t, int index) => projection(t));
		}

		public static IDataProducer<TResult> Select<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, int, TResult> projection)
		{
			source.ThrowIfNull("source");
			projection.ThrowIfNull("projection");
			DataProducer<TResult> ret = new DataProducer<TResult>();
			int index = 0;
			source.DataProduced += delegate(TSource value)
			{
				ret.Produce(projection(value, index++));
			};
			source.EndOfData += delegate
			{
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> Take<TSource>(this IDataProducer<TSource> source, int count)
		{
			source.ThrowIfNull("source");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			Action completion = delegate
			{
				ret.End();
			};
			Action<TSource> production = null;
			production = delegate(TSource value)
			{
				if (count > 0)
				{
					ret.Produce(value);
					count--;
				}
				if (count <= 0)
				{
					source.EndOfData -= completion;
					source.DataProduced -= production;
					ret.End();
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IDataProducer<TSource> Skip<TSource>(this IDataProducer<TSource> source, int count)
		{
			source.ThrowIfNull("source");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			source.DataProduced += delegate(TSource value)
			{
				if (count > 0)
				{
					count--;
				}
				else
				{
					ret.Produce(value);
				}
			};
			source.EndOfData += delegate
			{
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> TakeWhile<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			predicate.ThrowIfNull("predicate");
			return source.TakeWhile((TSource x, int index) => predicate(x));
		}

		public static IDataProducer<TSource> TakeWhile<TSource>(this IDataProducer<TSource> source, Func<TSource, int, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			Action completion = delegate
			{
				ret.End();
			};
			Action<TSource> production = null;
			int index = 0;
			production = delegate(TSource value)
			{
				if (!predicate(value, index++))
				{
					ret.End();
					source.DataProduced -= production;
					source.EndOfData -= completion;
				}
				else
				{
					ret.Produce(value);
				}
			};
			source.DataProduced += production;
			source.EndOfData += completion;
			return ret;
		}

		public static IDataProducer<TSource> SkipWhile<TSource>(this IDataProducer<TSource> source, Func<TSource, bool> predicate)
		{
			predicate.ThrowIfNull("predicate");
			return source.SkipWhile((TSource t, int index) => predicate(t));
		}

		public static IDataProducer<TSource> SkipWhile<TSource>(this IDataProducer<TSource> source, Func<TSource, int, bool> predicate)
		{
			source.ThrowIfNull("source");
			predicate.ThrowIfNull("predicate");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			Action value = delegate
			{
				ret.End();
			};
			bool skipping = true;
			int index = 0;
			source.DataProduced += delegate(TSource val)
			{
				if (skipping)
				{
					skipping = predicate(val, index++);
				}
				if (!skipping)
				{
					ret.Produce(val);
				}
			};
			source.EndOfData += value;
			return ret;
		}

		public static IDataProducer<TSource> Distinct<TSource>(this IDataProducer<TSource> source)
		{
			return source.Distinct(EqualityComparer<TSource>.Default);
		}

		public static IDataProducer<TSource> Distinct<TSource>(this IDataProducer<TSource> source, IEqualityComparer<TSource> comparer)
		{
			source.ThrowIfNull("source");
			comparer.ThrowIfNull("comparer");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			HashSet<TSource> set = new HashSet<TSource>(comparer);
			source.DataProduced += delegate(TSource value)
			{
				if (set.Add(value))
				{
					ret.Produce(value);
				}
			};
			source.EndOfData += delegate
			{
				ret.End();
			};
			return ret;
		}

		public static IDataProducer<TSource> Reverse<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			DataProducer<TSource> ret = new DataProducer<TSource>();
			List<TSource> results = new List<TSource>();
			source.DataProduced += delegate(TSource item)
			{
				results.Add(item);
			};
			source.EndOfData += delegate
			{
				List<TSource> list = new List<TSource>(results);
				list.Reverse();
				ret.ProduceAndEnd(list);
			};
			return ret;
		}

		public static IOrderedDataProducer<TSource> ThenBy<TSource, TKey>(this IOrderedDataProducer<TSource> source, Func<TSource, TKey> selector)
		{
			return ThenBy(source, selector, Comparer<TKey>.Default, descending: false);
		}

		public static IOrderedDataProducer<TSource> ThenBy<TSource, TKey>(this IOrderedDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return ThenBy(source, selector, comparer, descending: false);
		}

		public static IOrderedDataProducer<TSource> ThenByDescending<TSource, TKey>(this IOrderedDataProducer<TSource> source, Func<TSource, TKey> selector)
		{
			return ThenBy(source, selector, Comparer<TKey>.Default, descending: true);
		}

		public static IOrderedDataProducer<TSource> ThenByDescending<TSource, TKey>(this IOrderedDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return ThenBy(source, selector, comparer, descending: true);
		}

		public static IOrderedDataProducer<TSource> OrderBy<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> selector)
		{
			return OrderBy(source, selector, Comparer<TKey>.Default, descending: false);
		}

		public static IOrderedDataProducer<TSource> OrderBy<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return OrderBy(source, selector, comparer, descending: false);
		}

		public static IOrderedDataProducer<TSource> OrderByDescending<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> selector)
		{
			return OrderBy(source, selector, Comparer<TKey>.Default, descending: true);
		}

		public static IOrderedDataProducer<TSource> OrderByDescending<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer)
		{
			return OrderBy(source, selector, comparer, descending: true);
		}

		private static IOrderedDataProducer<TSource> OrderBy<TSource, TKey>(IDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer, bool descending)
		{
			source.ThrowIfNull("source");
			comparer.ThrowIfNull("comparer");
			IComparer<TSource> comparer2 = new ProjectionComparer<TSource, TKey>(selector, comparer);
			if (descending)
			{
				comparer2 = comparer2.Reverse();
			}
			bool flag = true;
			while (source is IOrderedDataProducer<TSource> orderedDataProducer)
			{
				if (flag)
				{
					comparer2 = new LinkedComparer<TSource>(comparer2, orderedDataProducer.Comparer);
					flag = false;
				}
				source = orderedDataProducer.BaseProducer;
			}
			return new OrderedDataProducer<TSource>(source, comparer2);
		}

		private static IOrderedDataProducer<TSource> ThenBy<TSource, TKey>(IOrderedDataProducer<TSource> source, Func<TSource, TKey> selector, IComparer<TKey> comparer, bool descending)
		{
			comparer.ThrowIfNull("comparer");
			IComparer<TSource> comparer2 = new ProjectionComparer<TSource, TKey>(selector, comparer);
			if (descending)
			{
				comparer2 = comparer2.Reverse();
			}
			comparer2 = new LinkedComparer<TSource>(source.Comparer, comparer2);
			return new OrderedDataProducer<TSource>(source, comparer2);
		}

		public static IFuture<IEnumerable<TSource>> AsFutureEnumerable<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<IEnumerable<TSource>> ret = new Future<IEnumerable<TSource>>();
			List<TSource> list = new List<TSource>();
			source.DataProduced += delegate(TSource value)
			{
				list.Add(value);
			};
			source.EndOfData += delegate
			{
				ret.Value = list;
			};
			return ret;
		}

		public static IEnumerable<TSource> AsEnumerable<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			return source.ToList();
		}

		public static List<TSource> ToList<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			List<TSource> list = new List<TSource>();
			source.DataProduced += delegate(TSource value)
			{
				list.Add(value);
			};
			return list;
		}

		public static IFuture<TSource[]> ToFutureArray<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<TSource[]> ret = new Future<TSource[]>();
			List<TSource> list = source.ToList();
			source.EndOfData += delegate
			{
				ret.Value = list.ToArray();
			};
			return ret;
		}

		public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> keyComparer)
		{
			source.ThrowIfNull("source");
			keySelector.ThrowIfNull("keySelector");
			elementSelector.ThrowIfNull("elementSelector");
			keyComparer.ThrowIfNull("keyComparer");
			EditableLookup<TKey, TElement> lookup = new EditableLookup<TKey, TElement>(keyComparer);
			source.DataProduced += delegate(TSource t)
			{
				lookup.Add(keySelector(t), elementSelector(t));
			};
			source.EndOfData += delegate
			{
				lookup.TrimExcess();
			};
			return lookup;
		}

		public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.ToLookup(keySelector, (TSource t) => t, EqualityComparer<TKey>.Default);
		}

		public static ILookup<TKey, TSource> ToLookup<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
		{
			return source.ToLookup(keySelector, (TSource t) => t, keyComparer);
		}

		public static ILookup<TKey, TElement> ToLookup<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return source.ToLookup(keySelector, elementSelector, EqualityComparer<TKey>.Default);
		}

		public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> keyComparer)
		{
			source.ThrowIfNull("source");
			keySelector.ThrowIfNull("keySelector");
			elementSelector.ThrowIfNull("elementSelector");
			keyComparer.ThrowIfNull("keyComparer");
			Dictionary<TKey, TElement> dict = new Dictionary<TKey, TElement>(keyComparer);
			source.DataProduced += delegate(TSource t)
			{
				dict.Add(keySelector(t), elementSelector(t));
			};
			return dict;
		}

		public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.ToDictionary(keySelector, (TSource t) => t, EqualityComparer<TKey>.Default);
		}

		public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> keyComparer)
		{
			return source.ToDictionary(keySelector, (TSource t) => t, keyComparer);
		}

		public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IDataProducer<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			return source.ToDictionary(keySelector, elementSelector, EqualityComparer<TKey>.Default);
		}

		public static IFuture<TResult> Sum<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, TResult> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			Future<TResult> ret = new Future<TResult>();
			TResult sum = Operator<TResult>.Zero;
			source.DataProduced += delegate(TSource item)
			{
				Operator.AddIfNotNull(ref sum, selector(item));
			};
			source.EndOfData += delegate
			{
				ret.Value = sum;
			};
			return ret;
		}

		public static IFuture<TSource> Sum<TSource>(this IDataProducer<TSource> source)
		{
			return source.Sum((TSource x) => x);
		}

		public static IFuture<TResult> Average<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, TResult> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			Future<TResult> ret = new Future<TResult>();
			TResult sum = Operator<TResult>.Zero;
			int count = 0;
			source.DataProduced += delegate(TSource item)
			{
				if (Operator.AddIfNotNull(ref sum, selector(item)))
				{
					count++;
				}
			};
			source.EndOfData += delegate
			{
				if (count == 0)
				{
					sum = default(TResult);
					if (sum != null)
					{
						throw new InvalidOperationException("Cannot perform non-nullable average over an empty series");
					}
					ret.Value = sum;
				}
				else
				{
					ret.Value = Operator.DivideInt32(sum, count);
				}
			};
			return ret;
		}

		public static IFuture<TSource> Average<TSource>(this IDataProducer<TSource> source)
		{
			return source.Average((TSource x) => x);
		}

		public static IFuture<double> Average(this IDataProducer<int> source)
		{
			return source.Average((Func<int, double>)((int x) => x));
		}

		public static IFuture<double?> Average(this IDataProducer<int?> source)
		{
			return source.Average((Func<int?, double?>)((int? x) => x));
		}

		public static IFuture<double> Average(this IDataProducer<long> source)
		{
			return source.Average((Func<long, double>)((long x) => x));
		}

		public static IFuture<double?> Average(this IDataProducer<long?> source)
		{
			return source.Average((Func<long?, double?>)((long? x) => x));
		}

		public static IFuture<double> Average<TSource>(this IDataProducer<TSource> source, Func<TSource, int> selector)
		{
			selector.ThrowIfNull("selector");
			return source.Average((Func<TSource, double>)((TSource x) => selector(x)));
		}

		public static IFuture<double?> Average<TSource>(this IDataProducer<TSource> source, Func<TSource, int?> selector)
		{
			selector.ThrowIfNull("selector");
			return source.Average((Func<TSource, double?>)((TSource x) => selector(x)));
		}

		public static IFuture<double> Average<TSource>(this IDataProducer<TSource> source, Func<TSource, long> selector)
		{
			selector.ThrowIfNull("selector");
			return source.Average((Func<TSource, double>)((TSource x) => selector(x)));
		}

		public static IFuture<double?> Average<TSource>(this IDataProducer<TSource> source, Func<TSource, long?> selector)
		{
			selector.ThrowIfNull("selector");
			return source.Average((Func<TSource, double?>)((TSource x) => selector(x)));
		}

		public static IFuture<TResult> Max<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, TResult> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			return source.Select(selector).Max();
		}

		public static IFuture<TSource> Max<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<TSource> ret = new Future<TSource>();
			IComparer<TSource> comparer = Comparer<TSource>.Default;
			TSource current = default(TSource);
			bool empty = true;
			bool canBeNull = !Operator.HasValue(current);
			source.DataProduced += delegate(TSource value)
			{
				if (!canBeNull || Operator.HasValue(value))
				{
					if (empty)
					{
						current = value;
						empty = false;
					}
					else if (comparer.Compare(value, current) > 0)
					{
						current = value;
					}
				}
			};
			source.EndOfData += delegate
			{
				if (empty && current != null)
				{
					throw new InvalidOperationException("Empty sequence");
				}
				ret.Value = current;
			};
			return ret;
		}

		public static IFuture<TResult> Min<TSource, TResult>(this IDataProducer<TSource> source, Func<TSource, TResult> selector)
		{
			source.ThrowIfNull("source");
			selector.ThrowIfNull("selector");
			return source.Select(selector).Min();
		}

		public static IFuture<TSource> Min<TSource>(this IDataProducer<TSource> source)
		{
			source.ThrowIfNull("source");
			Future<TSource> ret = new Future<TSource>();
			IComparer<TSource> comparer = Comparer<TSource>.Default;
			TSource current = default(TSource);
			bool empty = true;
			bool canBeNull = !Operator.HasValue(current);
			source.DataProduced += delegate(TSource value)
			{
				if (!canBeNull || Operator.HasValue(value))
				{
					if (empty)
					{
						current = value;
						empty = false;
					}
					else if (comparer.Compare(value, current) < 0)
					{
						current = value;
					}
				}
			};
			source.EndOfData += delegate
			{
				if (empty && current != null)
				{
					throw new InvalidOperationException("Empty sequence");
				}
				ret.Value = current;
			};
			return ret;
		}
	}
}
