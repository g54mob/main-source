namespace PInvokeSerialPort
{
	public struct QueueStatus
	{
		private uint status;

		private uint inQueue;

		private uint outQueue;

		private uint inQueueSize;

		private uint outQueueSize;

		public bool ctsHold => false;

		public bool dsrHold => false;

		public bool rlsdHold => false;

		public bool xoffHold => false;

		public bool xoffSent => false;

		public bool immediateWaiting => false;

		public long InQueue => 0L;

		public long OutQueue => 0L;

		public long InQueueSize => 0L;

		public long OutQueueSize => 0L;

		internal QueueStatus(uint stat, uint inQ, uint outQ, uint inQs, uint outQs)
		{
			status = 0u;
			inQueue = 0u;
			outQueue = 0u;
			inQueueSize = 0u;
			outQueueSize = 0u;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
