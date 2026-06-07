using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MathNet.Numerics.Threading
{
	internal static class CommonParallel
	{
		private static ParallelOptions CreateParallelOptions()
		{
			return new ParallelOptions
			{
				MaxDegreeOfParallelism = Control.MaxDegreeOfParallelism,
				TaskScheduler = Control.TaskScheduler
			};
		}

		public static void For(int fromInclusive, int toExclusive, Action<int, int> body)
		{
			For(fromInclusive, toExclusive, Math.Max(1, (toExclusive - fromInclusive) / Control.MaxDegreeOfParallelism), body);
		}

		public static void For(int fromInclusive, int toExclusive, int rangeSize, Action<int, int> body)
		{
			if (body == null)
			{
				throw new ArgumentNullException("body");
			}
			if (fromInclusive < 0)
			{
				throw new ArgumentOutOfRangeException("fromInclusive");
			}
			if (fromInclusive > toExclusive)
			{
				throw new ArgumentOutOfRangeException("toExclusive");
			}
			if (rangeSize < 1)
			{
				throw new ArgumentOutOfRangeException("rangeSize");
			}
			int num = toExclusive - fromInclusive;
			if (num <= 0)
			{
				return;
			}
			if (Control.MaxDegreeOfParallelism < 2 || rangeSize * 2 > num)
			{
				body(fromInclusive, toExclusive);
				return;
			}
			Parallel.ForEach(Partitioner.Create(fromInclusive, toExclusive, rangeSize), CreateParallelOptions(), delegate(Tuple<int, int> range)
			{
				body(range.Item1, range.Item2);
			});
		}

		public static void Invoke(params Action[] actions)
		{
			if (actions.Length == 0)
			{
				return;
			}
			if (actions.Length == 1)
			{
				actions[0]();
			}
			else if (Control.MaxDegreeOfParallelism < 2)
			{
				for (int i = 0; i < actions.Length; i++)
				{
					actions[i]();
				}
			}
			else
			{
				Parallel.Invoke(CreateParallelOptions(), actions);
			}
		}

		public static T Aggregate<T>(int fromInclusive, int toExclusive, Func<int, T> select, Func<T[], T> reduce)
		{
			if (select == null)
			{
				throw new ArgumentNullException("select");
			}
			if (reduce == null)
			{
				throw new ArgumentNullException("reduce");
			}
			if (fromInclusive >= toExclusive)
			{
				return reduce(Array.Empty<T>());
			}
			if (fromInclusive == toExclusive - 1)
			{
				return reduce(new T[1] { select(fromInclusive) });
			}
			if (Control.MaxDegreeOfParallelism < 2)
			{
				T[] array = new T[toExclusive - fromInclusive];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = select(i + fromInclusive);
				}
				return reduce(array);
			}
			List<T> intermediateResults = new List<T>();
			object syncLock = new object();
			Parallel.ForEach(Partitioner.Create(fromInclusive, toExclusive), CreateParallelOptions(), () => new List<T>(), delegate(Tuple<int, int> range, ParallelLoopState _, List<T> localData)
			{
				T[] array2 = new T[range.Item2 - range.Item1];
				for (int j = 0; j < array2.Length; j++)
				{
					array2[j] = select(j + range.Item1);
				}
				localData.Add(reduce(array2));
				return localData;
			}, delegate(List<T> localResult)
			{
				lock (syncLock)
				{
					intermediateResults.Add(reduce(localResult.ToArray()));
				}
			});
			return reduce(intermediateResults.ToArray());
		}

		public static TOut Aggregate<T, TOut>(T[] array, Func<int, T, TOut> select, Func<TOut[], TOut> reduce)
		{
			if (select == null)
			{
				throw new ArgumentNullException("select");
			}
			if (reduce == null)
			{
				throw new ArgumentNullException("reduce");
			}
			if (array == null || array.Length == 0)
			{
				return reduce(Array.Empty<TOut>());
			}
			if (array.Length == 1)
			{
				return reduce(new TOut[1] { select(0, array[0]) });
			}
			if (Control.MaxDegreeOfParallelism < 2)
			{
				TOut[] array2 = new TOut[array.Length];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = select(i, array[i]);
				}
				return reduce(array2);
			}
			List<TOut> intermediateResults = new List<TOut>();
			object syncLock = new object();
			Parallel.ForEach(Partitioner.Create(0, array.Length), CreateParallelOptions(), () => new List<TOut>(), delegate(Tuple<int, int> range, ParallelLoopState _, List<TOut> localData)
			{
				TOut[] array3 = new TOut[range.Item2 - range.Item1];
				for (int j = 0; j < array3.Length; j++)
				{
					array3[j] = select(j + range.Item1, array[j + range.Item1]);
				}
				localData.Add(reduce(array3));
				return localData;
			}, delegate(List<TOut> localResult)
			{
				lock (syncLock)
				{
					intermediateResults.Add(reduce(localResult.ToArray()));
				}
			});
			return reduce(intermediateResults.ToArray());
		}

		public static T Aggregate<T>(int fromInclusive, int toExclusive, Func<int, T> select, Func<T, T, T> reducePair, T reduceDefault)
		{
			return Aggregate(fromInclusive, toExclusive, select, delegate(T[] results)
			{
				if (results == null || results.Length == 0)
				{
					return reduceDefault;
				}
				if (results.Length == 1)
				{
					return results[0];
				}
				T val = results[0];
				for (int i = 1; i < results.Length; i++)
				{
					val = reducePair(val, results[i]);
				}
				return val;
			});
		}

		public static TOut Aggregate<T, TOut>(T[] array, Func<int, T, TOut> select, Func<TOut, TOut, TOut> reducePair, TOut reduceDefault)
		{
			return Aggregate(array, select, delegate(TOut[] results)
			{
				if (results == null || results.Length == 0)
				{
					return reduceDefault;
				}
				if (results.Length == 1)
				{
					return results[0];
				}
				TOut val = results[0];
				for (int i = 1; i < results.Length; i++)
				{
					val = reducePair(val, results[i]);
				}
				return val;
			});
		}
	}
}
