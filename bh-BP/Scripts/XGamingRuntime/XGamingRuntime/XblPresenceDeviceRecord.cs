using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceDeviceRecord
	{
		public XblPresenceDeviceType DeviceType { get; private set; }

		public XblPresenceTitleRecord[] TitleRecords { get; private set; }

		internal XblPresenceDeviceRecord(XGamingRuntime.Interop.XblPresenceDeviceRecord interopRecord)
		{
		}
	}
}
