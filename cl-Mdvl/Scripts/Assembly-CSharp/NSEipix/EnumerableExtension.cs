using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NSMedieval.Utils.Pool;
using NSMedieval.Utils.Pool.Janitors;
using Unity.Mathematics;
using UnityEngine;

namespace NSEipix
{
	public static class EnumerableExtension
	{
		private static System.Random rnd;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void OnDomainReload()
		{
			rnd = new System.Random();
		}

		public static void AddRange<T>(this ISet<T> set, IEnumerable<T> items)
		{
			foreach (T item in items)
			{
				set.Add(item);
			}
		}

		public static List<T> ToPooledList<T>(this IEnumerable<T> source)
		{
			List<T> list = ListPool<T>.Get();
			foreach (T item in source)
			{
				list.Add(item);
			}
			return list;
		}

		public static List<T> ToPooledList<T>(this IEnumerable<T> source, Func<T, bool> condition)
		{
			List<T> list = ListPool<T>.Get();
			foreach (T item in source)
			{
				if (condition(item))
				{
					list.Add(item);
				}
			}
			return list;
		}

		[MustDisposeResource]
		public static PooledList<T> ToPooledListJanitor<T>(this IEnumerable<T> source, Predicate<T> filter = null)
		{
			return ListPool<T>.GetJanitor(source, filter);
		}

		[MustDisposeResource]
		public static PooledDictionary<TKey, TValue> ToPooledDictionaryJanitor<TKey, TValue>(this Dictionary<TKey, TValue> source)
		{
			return DictionaryPool<TKey, TValue>.GetJanitor(source);
		}

		[MustDisposeResource]
		public static PooledList<TOutput> ToPooledListJanitorSelect<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, TOutput> selector)
		{
			return ListPool<TOutput>.GetJanitor(source, selector);
		}

		public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
		{
			HashSet<T> hashSet = new HashSet<T>();
			foreach (T item in source)
			{
				hashSet.Add(item);
			}
			return hashSet;
		}

		public static HashSet<T> ToPooledHashSet<T>(this IEnumerable<T> source)
		{
			HashSet<T> hashSet = HashSetPool<T>.Get();
			foreach (T item in source)
			{
				hashSet.Add(item);
			}
			return hashSet;
		}

		[MustDisposeResource]
		public static PooledHashSet<T> ToPooledHashSetJanitor<T>(this IEnumerable<T> source)
		{
			return HashSetPool<T>.GetJanitor(source);
		}

		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			foreach (T item in source)
			{
				action(item);
			}
		}

		public static void Remove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dict, TKey key)
		{
			dict.Remove(key, out var _);
		}

		public static void SetRandom(System.Random random)
		{
			rnd = random;
		}

		public static T PickRandom<T>(this IEnumerable<T> source, System.Random rndOverride = null)
		{
			if (rndOverride == null)
			{
				rndOverride = rnd;
			}
			return source.ElementAtOrDefault(rndOverride.Next(0, source.Count()));
		}

		public static T PickRandom<T>(this IEnumerable<T> source, ref Unity.Mathematics.Random rnd)
		{
			return source.ElementAtOrDefault(rnd.NextInt(0, source.Count()));
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
		{
			return source.OrderBy((T x) => Guid.NewGuid());
		}

		public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, System.Random random)
		{
			return source.OrderBy((T x) => random.Next());
		}

		public static T PickRandom<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			return source.Where(predicate).PickRandom();
		}

		public static T PickRandom<T>(this IList<T> source, uint randomSeed)
		{
			if (source.Count == 0)
			{
				return default(T);
			}
			if (randomSeed == 0)
			{
				randomSeed = 1u;
			}
			Unity.Mathematics.Random random = new Unity.Mathematics.Random(randomSeed);
			random.NextInt();
			int index = random.NextInt(source.Count);
			return source[index];
		}

		public static void RemoveRandom<T>(this IList<T> source)
		{
			if (source.Count != 0)
			{
				source.RemoveAt(rnd.Next(source.Count));
			}
		}

		[MustDisposeResource]
		public static PooledList<T> WherePooled<T>(this IEnumerable<T> source, Func<T, bool> predicate)
		{
			PooledList<T> janitor = ListPool<T>.GetJanitor();
			foreach (T item in source)
			{
				if (predicate == null || predicate(item))
				{
					janitor.Add(item);
				}
			}
			return janitor;
		}

		[MustDisposeResource]
		public static PooledList<TOutput> WherePooledCast<TInput, TOutput>(this IEnumerable<TInput> source, Func<TOutput, bool> predicate = null) where TOutput : class
		{
			PooledList<TOutput> janitor = ListPool<TOutput>.GetJanitor();
			foreach (TInput item in source)
			{
				if (item is TOutput val && (predicate == null || predicate(val)))
				{
					janitor.Add(val);
				}
			}
			return janitor;
		}

		public static void RemoveWhere<T>(this ICollection<T> collection, Predicate<T> filter)
		{
			using PooledList<T> pooledList = collection.ToPooledListJanitor();
			foreach (T item in pooledList)
			{
				if (filter(item))
				{
					collection.Remove(item);
				}
			}
		}

		[MustDisposeResource]
		public static PooledList<T> OfTypePooled<T>(this IEnumerable<object> source) where T : class
		{
			PooledList<T> janitor = ListPool<T>.GetJanitor();
			foreach (object item in source)
			{
				if (item is T)
				{
					janitor.Add(item as T);
				}
			}
			return janitor;
		}

		public static IEnumerable<T> IterateInReverseDynamic<T>(this IList<T> source)
		{
			for (int i = source.Count - 1; i >= 0; i--)
			{
				if (i < source.Count)
				{
					yield return source[i];
				}
			}
		}

		public static IEnumerable<(T, int)> IterateInReverseDynamicWithIndex<T>(this IList<T> source)
		{
			for (int i = source.Count - 1; i >= 0; i--)
			{
				if (i < source.Count)
				{
					yield return (source[i], i);
				}
			}
		}

		[MustDisposeResource]
		public static PooledList<TResult> SelectPooled<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, Predicate<TResult> filter = null)
		{
			PooledList<TResult> janitor = ListPool<TResult>.GetJanitor();
			foreach (TSource item in source)
			{
				TResult val = selector(item);
				if (filter == null || filter(val))
				{
					janitor.Add(val);
				}
			}
			return janitor;
		}

		public static Vector3 Average<T>(this IEnumerable<T> source, Func<T, Vector3> selector)
		{
			Vector3 zero = Vector3.zero;
			foreach (T item in source)
			{
				zero += selector(item);
			}
			return zero / source.Count();
		}

		public static T MinItem<T>(this IEnumerable<T> source, Func<T, float> scorer, Predicate<float> earlyOutCondition = null, Predicate<T> filter = null)
		{
			float num = float.MaxValue;
			T result = default(T);
			foreach (T item in source)
			{
				if (filter == null || filter(item))
				{
					float num2 = scorer(item);
					if (earlyOutCondition != null && earlyOutCondition(num2))
					{
						return item;
					}
					if (num2 < num)
					{
						num = num2;
						result = item;
					}
				}
			}
			return result;
		}

		public static T PopMinItem<T>(this IList<T> source, Func<T, float> scorer, Predicate<float> earlyOutCondition = null, Predicate<T> filter = null)
		{
			float num = float.MaxValue;
			T result = default(T);
			int index = 0;
			for (int i = 0; i < source.Count; i++)
			{
				T val = source[i];
				if (filter == null || filter(val))
				{
					float num2 = scorer(val);
					if (earlyOutCondition != null && earlyOutCondition(num2))
					{
						return val;
					}
					if (num2 < num)
					{
						index = i;
						num = num2;
						result = val;
					}
				}
			}
			source.RemoveAt(index);
			return result;
		}

		public static float MinItemScore<T>(this IEnumerable<T> source, Func<T, float> scorer, Predicate<float> earlyOutCondition = null, Predicate<T> filter = null)
		{
			float num = float.MaxValue;
			foreach (T item in source)
			{
				if (filter == null || filter(item))
				{
					float num2 = scorer(item);
					if (earlyOutCondition != null && earlyOutCondition(num2))
					{
						return num2;
					}
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			return num;
		}

		[MustDisposeResource]
		public static PooledList<T> ScoreItems<T>(this IEnumerable<T> source, Func<T, float> scorer)
		{
			PooledList<T> result = source.ToPooledListJanitor();
			result.Sort(delegate(T x, T y)
			{
				float value = scorer(x);
				return scorer(y).CompareTo(value);
			});
			return result;
		}

		public static T MaxItem<T>(this IEnumerable<T> source, Func<T, float> scorer, Predicate<float> earlyOutCondition = null, Predicate<T> filter = null)
		{
			float num = float.MinValue;
			T result = default(T);
			foreach (T item in source)
			{
				if (filter == null || filter(item))
				{
					float num2 = scorer(item);
					if (earlyOutCondition != null && earlyOutCondition(num2))
					{
						return item;
					}
					if (num2 > num)
					{
						num = num2;
						result = item;
					}
				}
			}
			return result;
		}

		public static int Count(this IEnumerable enumerable)
		{
			int num = 0;
			foreach (object item in enumerable)
			{
				_ = item;
				num++;
			}
			return num;
		}

		public static float MedianAssumeSorted(this List<float> list)
		{
			if (list.Count == 0)
			{
				return float.NaN;
			}
			if (list.Count == 1)
			{
				return list[0];
			}
			if (list.Count % 2 == 0)
			{
				int num = list.Count / 2;
				float num2 = list[num - 1];
				float num3 = list[num];
				return (num2 + num3) / 2f;
			}
			return list[list.Count / 2];
		}

		public static float UpperQuartileAverageAssumeSorted(this List<float> list)
		{
			if (list.Count == 0)
			{
				return float.NaN;
			}
			if (list.Count < 3)
			{
				return list.Last();
			}
			if (list.Count == 3)
			{
				return (list[1] + list[2]) / 2f;
			}
			int count = list.Count / 4;
			return list.TakeLast(count).Average();
		}

		public static bool AnyNonAlloc<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
		{
			foreach (T item in enumerable)
			{
				if (predicate(item))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AllNonAlloc<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
		{
			foreach (T item in enumerable)
			{
				if (!predicate(item))
				{
					return false;
				}
			}
			return true;
		}

		public static T PopFront<T>(this IList<T> list)
		{
			if (list.Count == 0)
			{
				return default(T);
			}
			T result = list[0];
			list.RemoveAt(0);
			return result;
		}

		public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable enumerable)
		{
			foreach (T item in enumerable)
			{
				queue.Enqueue(item);
			}
		}
	}
}
