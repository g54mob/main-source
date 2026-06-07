using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionInfo
	{
		public uint ContractVersion { get; private set; }

		public string Branch { get; private set; }

		public ulong ChangeNumber { get; private set; }

		public string CorrelationId { get; private set; }

		public DateTime StartTime { get; private set; }

		public DateTime NextTimer { get; private set; }

		public string SearchHandleId { get; private set; }

		internal XblMultiplayerSessionInfo(XGamingRuntime.Interop.XblMultiplayerSessionInfo interopStruct)
		{
		}
	}
}
