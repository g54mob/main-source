using System;

namespace Coherence.Stats
{
	public struct SimpleStats
	{
		public int PacketCount;

		public long OctetTotalSize;

		public int MessageCount;

		public int ChangeCount;

		public int CommandCount;

		public int InputCount;

		public TimeSpan Duration;

		public int Stamp;
	}
}
