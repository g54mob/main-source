using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerPerformQoSMeasurementsArgs
	{
		public XblMultiplayerConnectionAddressDeviceTokenPair[] RemoteClients { get; }

		internal XblMultiplayerPerformQoSMeasurementsArgs(XGamingRuntime.Interop.XblMultiplayerPerformQoSMeasurementsArgs interopStruct)
		{
			RemoteClients = interopStruct.GetRemoteClients((XGamingRuntime.Interop.XblMultiplayerConnectionAddressDeviceTokenPair x) => new XblMultiplayerConnectionAddressDeviceTokenPair(x));
		}
	}
}
