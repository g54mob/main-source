using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblSocialManagerPresenceTitleRecord
	{
		public uint TitleId { get; }

		public bool IsTitleActive { get; }

		public string PresenceText { get; }

		public bool IsBroadcasting { get; }

		public XblPresenceDeviceType DeviceType { get; }

		public bool IsPrimary { get; }

		internal XblSocialManagerPresenceTitleRecord(XGamingRuntime.Interop.XblSocialManagerPresenceTitleRecord interopRecord)
		{
			TitleId = interopRecord.titleId;
			IsTitleActive = interopRecord.isTitleActive;
			PresenceText = Converters.ByteArrayToString(interopRecord.presenceText);
			IsBroadcasting = interopRecord.isBroadcasting;
			DeviceType = interopRecord.deviceType;
			IsPrimary = interopRecord.isPrimary;
		}
	}
}
