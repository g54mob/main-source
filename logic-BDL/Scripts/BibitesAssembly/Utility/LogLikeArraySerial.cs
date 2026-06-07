using System;
using UnityEngine;

namespace Utility
{
	public class LogLikeArraySerial<T> : LogLikeArray<T>
	{
		public LogLikeArraySerial(LogLikeConfig logLikeConfig, Func<T[], Func<int, int>, int, T> compressFunc = null)
			: base(logLikeConfig, compressFunc ?? new Func<T[], Func<int, int>, int, T>(GenericCompressFunc.Oldest), true)
		{
		}

		public TimeFormat TimeFormatOfPoint(int i)
		{
			return config.TimeOfPointInSerialConfig(i);
		}

		public override void Push(T val)
		{
			int num = 0;
			T val2 = val;
			beforeDataPushedToScale.Invoke(val2, 0);
			for (int i = 0; i < nScales; i++)
			{
				if (isInfinite && i == nScales - 1)
				{
					break;
				}
				int scaleSize = scaleSizes[i];
				int num2 = dataSizes[i];
				T arg = base[i, num2 - 1];
				int num3 = indexOffsets[i] - 1;
				if (num3 < 0)
				{
					num3 = scaleSize - 1;
				}
				int scaleOffset = scaleOffsets[i];
				indexOffsets[i] = num3;
				data[scaleOffset + num3] = val2;
				if (nDataAtScale[i] >= num2)
				{
					onDataPushedOutOfScale.Invoke(arg, i);
				}
				onDataPushedToScale.Invoke(val2, i);
				num += scaleSize;
				if (nPoints < num)
				{
					nPoints++;
				}
				if (nDataAtScale[i] < num2)
				{
					nDataAtScale[i]++;
					nData++;
					return;
				}
				if (i >= nScales - 1)
				{
					return;
				}
				int num4 = feedRatios[i];
				pushCounters[i]++;
				if (pushCounters[i] < num4)
				{
					return;
				}
				pushCounters[i] = 0;
				int accOffset = num3 + dataSizes[i];
				val2 = compressFunc(data, RemapFunc, num4);
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
			int num = (includeAccumulators ? nPoints : nData);
			T[] array = new T[num];
			int num2 = 0;
			for (int i = 0; i < nScales; i++)
			{
				int num3 = Mathf.Min(includeAccumulators ? scaleSizes[i] : dataSizes[i], num - num2);
				for (int j = 0; j < num3; j++)
				{
					array[num2++] = base[i, j];
				}
			}
			return array;
		}

		public void LoadData(T[] values, int nValues, byte[] pushCounts)
		{
			for (int i = 0; i < values.Length; i++)
			{
				data[i] = values[i];
			}
			for (int j = 0; j < Mathf.Min(pushCounts.Length, pushCounters.Length); j++)
			{
				pushCounters[j] = pushCounts[j];
			}
			nPoints = values.Length;
			nData = nValues;
			for (int k = 0; k < nScales; k++)
			{
				if (nValues >= dataSizes[k])
				{
					nDataAtScale[k] = (byte)dataSizes[k];
					nValues -= dataSizes[k];
					continue;
				}
				nDataAtScale[k] = (byte)nValues;
				break;
			}
		}

		public void LoadDataWithoutAcc(T[] values, byte[] pushCounts)
		{
			for (int i = 0; i < values.Length; i++)
			{
				base[i] = values[i];
			}
			for (int j = 0; j < Mathf.Min(pushCounts.Length, pushCounters.Length); j++)
			{
				pushCounters[j] = pushCounts[j];
			}
			nData = values.Length;
			int num = nData;
			for (int k = 0; k < nScales - 1; k++)
			{
				if (num < 0)
				{
					break;
				}
				int num2 = dataSizes[k];
				nDataAtScale[k] = (byte)Mathf.Min(num, num2);
				int i2 = Mathf.Min(num, dataSizes[k]) - 1;
				byte b = pushCounters[k];
				for (int l = num2; l < num2 + b; l++)
				{
					base[k, l] = base[k, i2];
				}
				num -= num2;
			}
		}
	}
}
