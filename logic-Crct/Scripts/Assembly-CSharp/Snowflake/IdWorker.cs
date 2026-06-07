namespace Snowflake
{
	public class IdWorker
	{
		public const long Twepoch = 1288834974657L;

		private const int WorkerIdBits = 5;

		private const int DatacenterIdBits = 5;

		private const int SequenceBits = 12;

		private const long MaxWorkerId = 31L;

		private const long MaxDatacenterId = 31L;

		private const int WorkerIdShift = 12;

		private const int DatacenterIdShift = 17;

		public const int TimestampLeftShift = 22;

		private const long SequenceMask = 4095L;

		private long _sequence;

		private long _lastTimestamp;

		private readonly object _lock;

		public long WorkerId { get; protected set; }

		public long DatacenterId { get; protected set; }

		public long Sequence
		{
			get
			{
				return 0L;
			}
			internal set
			{
			}
		}

		public IdWorker(long workerId, long datacenterId, long sequence = 0L)
		{
		}

		public virtual long NextId()
		{
			return 0L;
		}

		protected virtual long TilNextMillis(long lastTimestamp)
		{
			return 0L;
		}

		protected virtual long TimeGen()
		{
			return 0L;
		}
	}
}
