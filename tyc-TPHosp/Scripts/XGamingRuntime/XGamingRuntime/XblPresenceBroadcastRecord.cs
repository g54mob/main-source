using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceBroadcastRecord
	{
		public string BroadcastId { get; }

		public string Session { get; }

		public XblPresenceBroadcastProvider Provider { get; }

		public uint ViewerCount { get; }

		public DateTime StartTime { get; }

		internal XblPresenceBroadcastRecord(XGamingRuntime.Interop.XblPresenceBroadcastRecord interopRecord)
		{
			BroadcastId = interopRecord.broadcastId.GetString();
			Session = Converters.ByteArrayToString(interopRecord.session);
			Provider = interopRecord.provider;
			ViewerCount = interopRecord.viewerCount;
			StartTime = interopRecord.startTime.DateTime;
		}
	}
}
