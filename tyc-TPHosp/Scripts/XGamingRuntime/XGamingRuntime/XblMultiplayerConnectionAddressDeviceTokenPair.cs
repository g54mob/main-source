using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerConnectionAddressDeviceTokenPair
	{
		public string ConnectionAddress { get; }

		public XblDeviceToken DeviceToken { get; }

		internal XblMultiplayerConnectionAddressDeviceTokenPair(XGamingRuntime.Interop.XblMultiplayerConnectionAddressDeviceTokenPair interopStruct)
		{
			ConnectionAddress = interopStruct.connectionAddress.GetString();
			DeviceToken = new XblDeviceToken(interopStruct.deviceToken);
		}
	}
}
