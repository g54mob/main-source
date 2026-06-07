using System.Collections.Generic;

namespace Assets.Scripts.Multiplayer.Utils
{
	public class TickData
	{
		public List<MessageData> InboundMessages { get; set; } = new List<MessageData>();

		public bool IsMatch { get; set; }

		public List<MessageData> OutboundMessages { get; set; } = new List<MessageData>();

		public uint Tick { get; set; }

		public ulong TotalInboundBytes { get; set; }

		public ulong TotalOutboundBytes { get; set; }
	}
}
