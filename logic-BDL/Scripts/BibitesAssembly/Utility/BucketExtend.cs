using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
	public static class BucketExtend
	{
		public static int[] LogTimesOfConfig(this LogLikeConfig config, int minIndex, int maxIndex, bool includeFedPoints, bool pre06a10 = false)
		{
			int num = config.acquisitionFactor;
			int num2 = (includeFedPoints ? num : 0);
			int num3 = 0;
			int num4 = 0;
			if (pre06a10)
			{
				minIndex--;
				maxIndex--;
			}
			int[] array = new int[Mathf.Max(maxIndex - minIndex, 0) + 1];
			LogLikeFormat[] formats = config.formats;
			for (int i = 0; i < formats.Length; i++)
			{
				LogLikeFormat logLikeFormat = formats[i];
				int num5 = logLikeFormat.size + (includeFedPoints ? logLikeFormat.feedRatio : 0);
				for (int j = 0; j < num5 || logLikeFormat.isInfinite; j++)
				{
					if (!includeFedPoints || j > 0)
					{
						num2 += num;
					}
					if (num3 >= minIndex)
					{
						array[num4++] = num2;
					}
					if (++num3 > maxIndex)
					{
						break;
					}
				}
				if (num3 > maxIndex)
				{
					break;
				}
				num *= logLikeFormat.feedRatio;
			}
			return array;
		}

		public static int[] OldLogTimesOfConfig(this LogLikeConfig config, int minIndex, int maxIndex)
		{
			int num = config.acquisitionFactor;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int[] array = new int[Mathf.Max(maxIndex - minIndex, 0) + 1];
			LogLikeFormat[] formats = config.formats;
			for (int i = 0; i < formats.Length; i++)
			{
				LogLikeFormat logLikeFormat = formats[i];
				int size = logLikeFormat.size;
				for (int j = 0; j < size || logLikeFormat.isInfinite; j++)
				{
					if (num3 >= minIndex)
					{
						array[num4++] = num2;
					}
					num2 += num;
					if (++num3 > maxIndex)
					{
						break;
					}
				}
				if (num3 > maxIndex)
				{
					break;
				}
				num *= logLikeFormat.feedRatio;
			}
			return array;
		}

		public static (int, int[]) IndexAndLogTimesOfSpan(this LogLikeConfig config, int minTimeIncluded, int maxTimeIncluded, bool includeFedPoints)
		{
			int num = config.acquisitionFactor;
			int num2 = (includeFedPoints ? num : 0);
			int num3 = 0;
			int item = 0;
			List<int> list = new List<int>();
			LogLikeFormat[] formats = config.formats;
			for (int i = 0; i < formats.Length; i++)
			{
				LogLikeFormat logLikeFormat = formats[i];
				int num4 = logLikeFormat.size + (includeFedPoints ? logLikeFormat.feedRatio : 0);
				for (int j = 0; j < num4 || logLikeFormat.isInfinite; j++)
				{
					if (!includeFedPoints || j > 0)
					{
						num2 += num;
					}
					if (num2 > maxTimeIncluded)
					{
						break;
					}
					if (num2 + num / 2 >= minTimeIncluded)
					{
						if (list.Count < 1)
						{
							item = num3;
						}
						list.Add(num2);
					}
					num3++;
				}
				if (num2 > maxTimeIncluded)
				{
					break;
				}
				num *= logLikeFormat.feedRatio;
			}
			return (item, list.ToArray());
		}

		public static int SecondsSinceFirstLog(this LogLikeConfig config, int lastIndex, int[] pushCounters)
		{
			int num = (int)TimeFormat.FactorFromTimeScaleTo(config.acquisition, Timescale.Seconds);
			int num2 = config.acquisitionFactor;
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < config.formats.Length; i++)
			{
				LogLikeFormat logLikeFormat = config.formats[i];
				if (lastIndex > num3 + logLikeFormat.size)
				{
					num3 += logLikeFormat.size;
					num4 += (logLikeFormat.size + pushCounters[i]) * num2;
					num2 *= logLikeFormat.feedRatio;
					continue;
				}
				num4 += (lastIndex - num3) * num2;
				break;
			}
			return num4 * num;
		}

		public static DataLoggerBucket<T> InsertZero<T>(this DataLoggerBucket<T> bucket, T val)
		{
			if (bucket.serialFeeding)
			{
				bucket.Push(val);
			}
			else
			{
				DataLoggerBucket<T> dataLoggerBucket = bucket;
				dataLoggerBucket.Push(val);
				while (dataLoggerBucket.feedingBucket != null)
				{
					dataLoggerBucket = dataLoggerBucket.feedingBucket;
					dataLoggerBucket.Push(val);
				}
			}
			return bucket;
		}
	}
}
