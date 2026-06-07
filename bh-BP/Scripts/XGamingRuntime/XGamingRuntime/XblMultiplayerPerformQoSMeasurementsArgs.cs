using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerPerformQoSMeasurementsArgs
	{
		public XblMultiplayerConnectionAddressDeviceTokenPair[] RemoteClients { get; private set; }

		internal XblMultiplayerPerformQoSMeasurementsArgs(XGamingRuntime.Interop.XblMultiplayerPerformQoSMeasurementsArgs interopStruct)
		{
		}
	}
}
