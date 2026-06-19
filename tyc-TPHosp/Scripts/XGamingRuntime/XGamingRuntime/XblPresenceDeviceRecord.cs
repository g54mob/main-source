using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceDeviceRecord
	{
		public XblPresenceDeviceType DeviceType { get; }

		public XblPresenceTitleRecord[] TitleRecords { get; }

		internal XblPresenceDeviceRecord(XGamingRuntime.Interop.XblPresenceDeviceRecord interopRecord)
		{
			DeviceType = interopRecord.deviceType;
			TitleRecords = interopRecord.GetTitleRecords((XGamingRuntime.Interop.XblPresenceTitleRecord tr) => new XblPresenceTitleRecord(tr));
		}
	}
}
