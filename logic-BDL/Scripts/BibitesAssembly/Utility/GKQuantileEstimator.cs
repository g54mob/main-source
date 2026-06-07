using System;
using System.Collections.Generic;
using ScriptHelpers;
using UnityEngine;

namespace Utility
{
	public abstract class GKQuantileEstimator<T> : ISaveableBin where T : IComparable<T>
	{
		private struct Tuple
		{
			public static readonly IComparer<Tuple> Comparer = Comparer<Tuple>.Create((Tuple a, Tuple b) => a.value.CompareTo(b.value));

			public T value { get; set; }

			public int gap { get; set; }

			public int delta { get; set; }
		}

		private readonly List<Tuple> tuples = new List<Tuple>();

		private readonly int compressingInterval;

		private readonly float epsilon;

		private int n;

		private int firstN;

		protected abstract int valueByteSize { get; }

		public GKQuantileEstimator(float epsilon)
		{
			this.epsilon = epsilon;
			compressingInterval = Mathf.FloorToInt(1f / (2f * epsilon));
		}

		public void Add(T v)
		{
			if (n >= compressingInterval)
			{
				Mathf.FloorToInt(2f * epsilon * (float)n);
			}
			Tuple tuple = new Tuple
			{
				value = v,
				gap = 1,
				delta = Mathf.FloorToInt(2f * epsilon * (float)n)
			};
			int insertIndex = GetInsertIndex(tuple);
			if (insertIndex == 0 || insertIndex == tuples.Count)
			{
				tuple.delta = 0;
			}
			tuples.Insert(insertIndex, tuple);
			n++;
			if (n % compressingInterval == 0)
			{
				Compress();
			}
		}

		public void Reset()
		{
			tuples.Clear();
			n = 0;
		}

		private int GetInsertIndex(Tuple v)
		{
			int num = tuples.BinarySearch(v, Tuple.Comparer);
			if (num < 0)
			{
				return ~num;
			}
			return num;
		}

		public T GetQuantile(float p)
		{
			if (tuples.Count == 0)
			{
				return default(T);
			}
			float num = p * (float)(n - 1) + 1f;
			int num2 = Mathf.CeilToInt(epsilon * (float)n);
			int num3 = -1;
			float num4 = float.MaxValue;
			int num5 = 0;
			for (int i = 0; i < tuples.Count; i++)
			{
				Tuple tuple = tuples[i];
				num5 += tuple.gap;
				int num6 = num5 + tuple.delta;
				if (num - (float)num2 <= (float)num5 && (float)num6 <= num + (float)num2)
				{
					float num7 = Mathf.Abs(num - (float)(num5 + num6) / 2f);
					if (num7 < num4)
					{
						num4 = num7;
						num3 = i;
					}
				}
			}
			if (num3 == -1)
			{
				throw new InvalidOperationException("Failed to find the requested quantile");
			}
			return tuples[num3].value;
		}

		public void Compress()
		{
			for (int num = tuples.Count - 2; num >= 1; num--)
			{
				while (num < tuples.Count - 1 && DeleteIfNeeded(num))
				{
				}
			}
		}

		private bool DeleteIfNeeded(int i)
		{
			Tuple tuple = tuples[i];
			Tuple value = tuples[i + 1];
			int num = Mathf.FloorToInt(2f * epsilon * (float)n);
			if (tuple.delta >= value.delta && tuple.gap + value.gap + value.delta < num)
			{
				value.gap += tuple.gap;
				tuples[i + 1] = value;
				tuples.RemoveAt(i);
				return true;
			}
			return false;
		}

		public int BytesSpace()
		{
			return 6 + tuples.Count * (valueByteSize + 4);
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			Compress();
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			short num = (short)tuples.Count;
			Buffer.BlockCopy(BitConverter.GetBytes(n), 0, bytes, offset, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset + 4, 2);
			T[] array = new T[num];
			short[] array2 = new short[num];
			short[] array3 = new short[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = tuples[i].value;
				array2[i] = (short)tuples[i].gap;
				array3[i] = (short)tuples[i].delta;
			}
			offset += 6;
			Buffer.BlockCopy(array, 0, bytes, offset, valueByteSize * num);
			Buffer.BlockCopy(array2, 0, bytes, offset + valueByteSize * num, 2 * num);
			Buffer.BlockCopy(array3, 0, bytes, offset + (valueByteSize + 2) * num, 2 * num);
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			Reset();
			n = BitConverter.ToInt32(bytes, offset);
			short num = BitConverter.ToInt16(bytes, offset + 4);
			T[] array = new T[num];
			short[] array2 = new short[num];
			short[] array3 = new short[num];
			offset += 6;
			Buffer.BlockCopy(bytes, offset, array, 0, valueByteSize * num);
			Buffer.BlockCopy(bytes, offset + valueByteSize * num, array2, 0, 2 * num);
			Buffer.BlockCopy(bytes, offset + (valueByteSize + 2) * num, array3, 0, 2 * num);
			for (int i = 0; i < num; i++)
			{
				tuples.Add(new Tuple
				{
					value = array[i],
					gap = array2[i],
					delta = array3[i]
				});
			}
		}
	}
}
