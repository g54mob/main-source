using System;
using UnityEngine;

namespace Utility
{
	public class LogLikeArrayParallel<T> : LogLikeArray<T>
	{
		public LogLikeArrayParallel(LogLikeConfig logLikeConfig, Func<T[], Func<int, int>, int, T> compressFunc = null)
			: base(logLikeConfig, compressFunc ?? new Func<T[], Func<int, int>, int, T>(GenericCompressFunc.Oldest), false)
		{
		}

		public override void Push(T val)
		{
			T val2 = val;
			beforeDataPushedToScale.Invoke(val2, 0);
			for (int i = 0; i < nScales; i++)
			{
				if (isInfinite && i == nScales - 1)
				{
					break;
				}
				int scaleSize = scaleSizes[i];
				int num = indexOffsets[i] - 1;
				if (num < 0)
				{
					num = scaleSize - 1;
				}
				int scaleOffset = scaleOffsets[i];
				indexOffsets[i] = num;
				data[scaleOffset + num] = val2;
				onDataPushedToScale.Invoke(val2, i);
				if (nDataAtScale[i] < scaleSize)
				{
					nDataAtScale[i]++;
					nData++;
					nPoints++;
				}
				if (i >= nScales - 1)
				{
					return;
				}
				int num2 = feedRatios[i];
				pushCounters[i]++;
				if (pushCounters[i] < num2)
				{
					return;
				}
				pushCounters[i] = 0;
				int accOffset = num + dataSizes[i];
				val2 = compressFunc(data, RemapFunc, num2);
				beforeDataPushedToScale.Invoke(val2, i + 1);
				int RemapFunc(int o)
				{
					return scaleOffset + (accOffset + o) % scaleSize;
				}
			}
			onDataPushedDone.Invoke();
		}

		public override T[] GetAllData(bool includeAccumulators = false)
		{
			T[] array = new T[nData];
			int num = 0;
			for (int i = 0; i < nScales; i++)
			{
				byte b = nDataAtScale[i];
				for (int j = 0; j < b; j++)
				{
					array[num++] = base[i, j];
				}
			}
			return array;
		}

		public void LoadData(T[] values, byte[] ns, byte[] pushCounts)
		{
			for (int i = 0; i < Mathf.Min(pushCounts.Length, pushCounters.Length); i++)
			{
				pushCounters[i] = pushCounts[i];
			}
			for (int j = 0; j < Mathf.Min(ns.Length, nDataAtScale.Length); j++)
			{
				nDataAtScale[j] = ns[j];
			}
			nData = values.Length;
			nPoints = nData;
			for (int k = 0; k < nScales; k++)
			{
				int num = dataSizes[k];
				int num2 = 0;
				for (int l = 0; l < num; l++)
				{
					if (num2 >= nData)
					{
						break;
					}
					base[k, l] = values[num2++];
				}
			}
		}
	}
}
