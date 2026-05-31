namespace ExitGames.Client.Photon
{
	public class TrafficStats
	{
		public int PackageHeaderSize { get; internal set; }

		public int ReliableCommandCount { get; internal set; }

		public int UnreliableCommandCount { get; internal set; }

		public int FragmentCommandCount { get; internal set; }

		public int ControlCommandCount { get; internal set; }

		public int TotalPacketCount { get; internal set; }

		public int TotalCommandsInPackets { get; internal set; }

		public int ReliableCommandBytes { get; internal set; }

		public int UnreliableCommandBytes { get; internal set; }

		public int FragmentCommandBytes { get; internal set; }

		public int ControlCommandBytes { get; internal set; }

		public int TotalCommandCount => 0;

		public int TotalCommandBytes => 0;

		public int TotalPacketBytes => 0;

		public int TimestampOfLastAck { get; set; }

		public int TimestampOfLastReliableCommand { get; set; }

		internal TrafficStats(int packageHeaderSize)
		{
		}

		internal void CountControlCommand(int size)
		{
		}

		internal void CountReliableOpCommand(int size)
		{
		}

		internal void CountUnreliableOpCommand(int size)
		{
		}

		internal void CountFragmentOpCommand(int size)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
