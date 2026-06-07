using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerPresenceTitleRecord
	{
		public uint TitleId { get; private set; }

		public string TitleName { get; private set; }

		public bool IsTitleActive { get; private set; }

		public string PresenceText { get; private set; }

		public bool IsBroadcasting { get; private set; }

		public XblPresenceDeviceType DeviceType { get; private set; }

		public bool IsPrimary { get; private set; }

		internal XblSocialManagerPresenceTitleRecord(XGamingRuntime.Interop.XblSocialManagerPresenceTitleRecord interopRecord)
		{
		}
	}
}
