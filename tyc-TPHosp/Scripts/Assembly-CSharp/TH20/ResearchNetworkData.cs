using System.Collections.Generic;
using FullSerializerSave;

namespace TH20
{
	public class ResearchNetworkData
	{
		[fsProperty("compTime")]
		public Dictionary<int, uint> CompletedNodeTimestamps = new Dictionary<int, uint>();

		[fsProperty("act")]
		public int ActiveNode;

		[fsProperty("actTime")]
		public uint ActiveNodeTimestamp;
	}
}
