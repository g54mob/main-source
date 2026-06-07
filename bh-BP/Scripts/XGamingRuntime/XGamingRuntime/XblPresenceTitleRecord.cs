using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceTitleRecord
	{
		public uint TitleId { get; private set; }

		public string TitleName { get; private set; }

		public DateTime LastModified { get; private set; }

		public bool TitleActive { get; private set; }

		public string RichPresenceString { get; private set; }

		public XblPresenceTitleViewState ViewState { get; private set; }

		public XblPresenceBroadcastRecord BroadcastRecord { get; private set; }

		internal XblPresenceTitleRecord(XGamingRuntime.Interop.XblPresenceTitleRecord interopRecord)
		{
		}
	}
}
