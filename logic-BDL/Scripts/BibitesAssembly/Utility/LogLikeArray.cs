using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Utility
{
	public abstract class LogLikeArray<T>
	{
		[ItemCanBeNull]
		public readonly T[] data;

		public LogLikeConfig config;

		protected readonly int[] scaleSizes;

		public readonly int[] scaleOffsets;

		protected readonly int[] dataSizes;

		protected readonly int[] scaleDataSum;

		protected readonly int[] feedRatios;

		public readonly byte[] scaleSteps;

		protected readonly int[] indexOffsets;

		public readonly byte[] pushCounters;

		public readonly byte[] nDataAtScale;

		protected Func<T[], Func<int, int>, int, T> compressFunc;

		public int nPoints;

		public int nData;

		public readonly int nScales;

		public bool isInfinite;

		public List<T> infiniteData;

		public UnityEvent<T, int> beforeDataPushedToScale = new UnityEvent<T, int>();

		public UnityEvent<T, int> onDataPushedToScale = new UnityEvent<T, int>();

		public UnityEvent<T, int> onDataPushedOutOfScale = new UnityEvent<T, int>();

		public UnityEvent onDataPushedDone = new UnityEvent();

		public int nDataInfinite => infiniteData.Count;

		public T this[int scale, int i]
		{
			get
			{
				if (!isInfinite || scale != nScales - 1)
				{
					return data[ToCircularIndexOfScale(scale, i)];
				}
				return infiniteData[i];
			}
			protected set
			{
				if (isInfinite && scale == nScales - 1)
				{
					if (i < nDataInfinite)
					{
						infiniteData[i] = value;
						return;
					}
					if (i != nDataInfinite)
					{
						throw new IndexOutOfRangeException("Index is out of range of infinite data array");
					}
					infiniteData.Add(value);
				}
				else
				{
					data[ToCircularIndexOfScale(scale, i)] = value;
				}
			}
		}

		public T this[int i]
		{
			get
			{
				if (!isInfinite || i < scaleDataSum[nScales - 1])
				{
					return data[ToCircularIndexData(i)];
				}
				return infiniteData[i - scaleDataSum[nScales - 1]];
			}
			protected set
			{
				if (isInfinite && i > scaleOffsets[nScales - 1])
				{
					i -= scaleOffsets[nScales - 1];
					if (i < nDataInfinite)
					{
						infiniteData[i] = value;
						return;
					}
					if (i != nDataInfinite)
					{
						throw new IndexOutOfRangeException("Index is out of range of infinite data array");
					}
					infiniteData.Add(value);
				}
				else
				{
					data[ToCircularIndexData(i)] = value;
				}
			}
		}

		public int ToCircularIndexOfScale(int scale, int i)
		{
			return scaleOffsets[scale] + (indexOffsets[scale] + i) % scaleSizes[scale];
		}

		public void SetPointAtGlobalIndex(int i, T point)
		{
			data[ToCircularGlobalIndex(i)] = point;
		}

		public int ToCircularIndexData(int i, int scale = 0)
		{
			if (i >= ((isInfinite && scale == nScales - 1) ? nDataInfinite : dataSizes[scale]))
			{
				return ToCircularIndexData(i - dataSizes[scale], scale + 1);
			}
			return ToCircularIndexOfScale(scale, i);
		}

		public int ToCircularGlobalIndex(int i, int scale = 0)
		{
			if (i >= ((isInfinite && scale == nScales - 1) ? nDataInfinite : (dataSizes[scale] + feedRatios[scale])))
			{
				return ToCircularGlobalIndex(i - dataSizes[scale] - feedRatios[scale], scale + 1);
			}
			return ToCircularIndexOfScale(scale, i);
		}

		public bool ScaleHasData(int scale)
		{
			return NDataAtScale(scale) > 0;
		}

		public int NDataAtScale(int scale)
		{
			if (!isInfinite || scale != nScales - 1)
			{
				return nDataAtScale[scale];
			}
			return nDataInfinite;
		}

		public int DataSizeAtScale(int scale)
		{
			if (!isInfinite || scale != nScales - 1)
			{
				return dataSizes[scale];
			}
			return Mathf.Max(nDataInfinite, dataSizes[scale - 1]);
		}

		protected LogLikeArray(LogLikeConfig logLikeConfig, Func<T[], Func<int, int>, int, T> compressFunc = null, bool needsAccumulation = false)
		{
			config = logLikeConfig;
			LogLikeFormat[] formats = config.formats;
			nScales = config.formats.Length;
			this.compressFunc = compressFunc;
			dataSizes = new int[nScales];
			scaleSizes = new int[nScales];
			pushCounters = new byte[nScales];
			feedRatios = new int[nScales];
			scaleOffsets = new int[nScales];
			indexOffsets = new int[nScales];
			nDataAtScale = new byte[nScales];
			scaleSteps = new byte[nScales];
			scaleDataSum = new int[nScales];
			int num = 0;
			scaleSteps[0] = 1;
			for (int i = 0; i < nScales; i++)
			{
				dataSizes[i] = formats[i].size;
				scaleSizes[i] = formats[i].size + (needsAccumulation ? formats[i].feedRatio : 0);
				feedRatios[i] = formats[i].feedRatio;
				scaleDataSum[i] = dataSizes[i];
				num += scaleSizes[i];
				if (i > 0)
				{
					scaleOffsets[i] = scaleOffsets[i - 1] + scaleSizes[i - 1];
					scaleSteps[i] = (byte)(scaleSteps[i - 1] * feedRatios[i - 1]);
					scaleDataSum[i] += scaleDataSum[i - 1];
				}
			}
			if (scaleSizes[nScales - 1] == 0)
			{
				isInfinite = true;
				infiniteData = new List<T>();
				beforeDataPushedToScale.AddListener(CheckForPushToInfinite);
			}
			data = new T[num];
		}

		public abstract void Push(T point);

		private void CheckForPushToInfinite(T point, int scale)
		{
			if (scale == nScales - 1)
			{
				PushToInfiniteScale(point);
			}
		}

		private void PushToInfiniteScale(T point)
		{
			infiniteData.Insert(0, point);
			nData++;
			nPoints++;
			onDataPushedToScale.Invoke(point, nScales - 1);
		}

		public abstract T[] GetAllData(bool includeAccumulators = false);

		public int GetByteSpace(int bytesPerPoint)
		{
			return 6 + nPoints * bytesPerPoint + nScales * 2 - 1;
		}
	}
}
