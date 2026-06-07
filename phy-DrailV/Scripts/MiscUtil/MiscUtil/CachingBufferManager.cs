using System;
using System.Collections.Generic;
using MiscUtil.Threading;

namespace MiscUtil
{
	public sealed class CachingBufferManager : IBufferManager
	{
		public sealed class Options : ICloneable
		{
			public enum BufferUnavailableAction
			{
				UseBigger = 0,
				ReturnUncached = 1,
				ThrowException = 2
			}

			private int maxBuffersPerSizeBand = 16;

			private int minBufferSize = 1024;

			private bool clearAfterUse = true;

			private double scalingFactor = 2.0;

			private int maxBufferSize = int.MaxValue;

			private BufferUnavailableAction actionOnBufferUnavailable = BufferUnavailableAction.ReturnUncached;

			public int MaxBuffersPerSizeBand
			{
				get
				{
					return maxBuffersPerSizeBand;
				}
				set
				{
					if (value < 1)
					{
						throw new ArgumentOutOfRangeException("Must have at least 1 buffer per size band");
					}
					maxBuffersPerSizeBand = value;
				}
			}

			public int MinBufferSize
			{
				get
				{
					return minBufferSize;
				}
				set
				{
					if (value < 1)
					{
						throw new ArgumentOutOfRangeException("Minimum buffer size must be at least 1");
					}
					minBufferSize = value;
				}
			}

			public bool ClearAfterUse
			{
				get
				{
					return clearAfterUse;
				}
				set
				{
					clearAfterUse = value;
				}
			}

			public double ScalingFactor
			{
				get
				{
					return scalingFactor;
				}
				set
				{
					if (value < 1.25)
					{
						throw new ArgumentOutOfRangeException("Scaling factor must be at least 1.25.");
					}
					scalingFactor = value;
				}
			}

			public int MaxBufferSize
			{
				get
				{
					return maxBufferSize;
				}
				set
				{
					if (value <= 0)
					{
						throw new ArgumentOutOfRangeException("Maximum buffer size must be non-negative");
					}
					maxBufferSize = value;
				}
			}

			public BufferUnavailableAction ActionOnBufferUnavailable
			{
				get
				{
					return actionOnBufferUnavailable;
				}
				set
				{
					if (!Enum.IsDefined(typeof(BufferUnavailableAction), value))
					{
						throw new ArgumentOutOfRangeException("Only defined in BufferUnavailableAction are permitted");
					}
					actionOnBufferUnavailable = value;
				}
			}

			public Options Clone()
			{
				return (Options)MemberwiseClone();
			}

			object ICloneable.Clone()
			{
				return Clone();
			}
		}

		private readonly Options options;

		private readonly List<CachedBuffer[]> bufferBands = new List<CachedBuffer[]>();

		private readonly SyncLock padlock = new SyncLock("Lock for CachingBufferManager", 5000);

		public CachingBufferManager()
		{
			using (padlock.Lock())
			{
				options = new Options();
			}
		}

		public CachingBufferManager(Options options)
		{
			using (padlock.Lock())
			{
				this.options = options.Clone();
				if (options.MaxBufferSize < options.MinBufferSize)
				{
					throw new ArgumentException("MaxBufferSize must be at least as big as MinBufferSize");
				}
			}
		}

		public IBuffer GetBuffer(int minimumSize)
		{
			if (minimumSize < 0)
			{
				throw new ArgumentOutOfRangeException("minimumSize must be greater than or equal to 0");
			}
			if (minimumSize > options.MaxBufferSize)
			{
				throw new BufferAcquisitionException("Requested buffer " + minimumSize + " is larger than maximum buffer size " + options.MaxBufferSize);
			}
			int num = 0;
			int num2 = options.MinBufferSize;
			while (num2 < minimumSize)
			{
				num2 = CalculateNextSizeBand(num2);
				num++;
			}
			CachedBuffer cachedBuffer;
			while (true)
			{
				cachedBuffer = FindAvailableBuffer(num, num2);
				if (cachedBuffer != null)
				{
					break;
				}
				switch (options.ActionOnBufferUnavailable)
				{
				case Options.BufferUnavailableAction.ReturnUncached:
					return new CachedBuffer(minimumSize, options.ClearAfterUse);
				case Options.BufferUnavailableAction.ThrowException:
					throw new BufferAcquisitionException("No buffers available");
				}
				if (num2 == options.MaxBufferSize)
				{
					return new CachedBuffer(minimumSize, options.ClearAfterUse);
				}
				num2 = CalculateNextSizeBand(num2);
				num++;
			}
			return cachedBuffer;
		}

		private int CalculateNextSizeBand(int size)
		{
			return (int)Math.Ceiling(Math.Min(options.MaxBufferSize, (double)size * options.ScalingFactor));
		}

		private CachedBuffer FindAvailableBuffer(int listIndex, int size)
		{
			using (padlock.Lock())
			{
				while (listIndex >= bufferBands.Count)
				{
					bufferBands.Add(null);
				}
				CachedBuffer[] array = bufferBands[listIndex];
				if (array == null)
				{
					array = new CachedBuffer[options.MaxBuffersPerSizeBand];
					bufferBands[listIndex] = array;
				}
				for (int i = 0; i < array.Length; i++)
				{
					if (array[i] == null)
					{
						array[i] = new CachedBuffer(size, options.ClearAfterUse);
						return array[i];
					}
					if (array[i].Available)
					{
						array[i].Available = false;
						return array[i];
					}
				}
				return null;
			}
		}
	}
}
