using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceTitleRecord
	{
		public uint TitleId { get; }

		public string TitleName { get; }

		public DateTime LastModified { get; }

		public bool TitleActive { get; }

		public string RichPresenceString { get; }

		public XblPresenceTitleViewState ViewState { get; }

		public XblPresenceBroadcastRecord BroadcastRecord { get; }

		internal XblPresenceTitleRecord(XGamingRuntime.Interop.XblPresenceTitleRecord interopRecord)
		{
			TitleId = interopRecord.titleId;
			TitleName = interopRecord.titleName.GetString();
			LastModified = interopRecord.lastModified.DateTime;
			TitleActive = interopRecord.titleActive;
			RichPresenceString = interopRecord.richPresenceString.GetString();
			ViewState = interopRecord.viewState;
			BroadcastRecord = interopRecord.GetBroadcastRecord((XGamingRuntime.Interop.XblPresenceBroadcastRecord br) => new XblPresenceBroadcastRecord(br));
		}
	}
}
