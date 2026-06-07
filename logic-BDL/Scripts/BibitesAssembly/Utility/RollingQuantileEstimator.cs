using System;
using System.Linq;
using ScriptHelpers;

namespace Utility
{
	public abstract class RollingQuantileEstimator<TEstimator, T> : ISaveableBin where TEstimator : GKQuantileEstimator<T> where T : IComparable<T>
	{
		protected TEstimator[] estimators;

		protected readonly int nEstimator;

		private readonly int rollPeriod;

		private int rollCounter;

		private int oldestEstimator;

		public TEstimator this[int i] => estimators[(oldestEstimator + i) % nEstimator];

		public RollingQuantileEstimator(int nEstimator, int rollPeriod, float epsilon)
		{
			this.rollPeriod = rollPeriod;
			this.nEstimator = nEstimator;
			oldestEstimator = 0;
			estimators = new TEstimator[nEstimator];
			InitEstimators(epsilon);
		}

		protected abstract void InitEstimators(float epsilon);

		public void Add(T val)
		{
			for (int i = 0; i < nEstimator; i++)
			{
				estimators[i].Add(val);
			}
		}

		public T GetQuantile(float p)
		{
			return estimators[oldestEstimator].GetQuantile(p);
		}

		public void IncrementRollCounter()
		{
			rollCounter++;
			if (rollCounter >= nEstimator * rollPeriod)
			{
				rollCounter -= rollPeriod;
				estimators[oldestEstimator].Reset();
				oldestEstimator = (oldestEstimator + 1) % nEstimator;
			}
		}

		public int BytesSpace()
		{
			return 4 + estimators.Sum((TEstimator e) => e.BytesSpace() + 4);
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(rollCounter), 0, bytes, offset, 4);
			offset += 4;
			for (int i = 0; i < nEstimator; i++)
			{
				int num = this[i].BytesSpace();
				Buffer.BlockCopy(BitConverter.GetBytes(num), 0, bytes, offset, 4);
				this[i].SaveStateBin(bytes, offset + 4);
				offset += 4 + num;
			}
			return bytes;
		}

		public void LoadStateBin(byte[] bytes, Version version, int offset = 0, int nBytes = -1)
		{
			rollCounter = BitConverter.ToInt32(bytes, offset);
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			int num = offset + nBytes;
			offset += 4;
			for (int i = 0; i < nEstimator; i++)
			{
				if (offset >= num)
				{
					break;
				}
				int num2 = BitConverter.ToInt32(bytes, offset);
				this[i].LoadStateBin(bytes, version, offset + 4, num2);
				offset += 4 + num2;
			}
		}
	}
}
