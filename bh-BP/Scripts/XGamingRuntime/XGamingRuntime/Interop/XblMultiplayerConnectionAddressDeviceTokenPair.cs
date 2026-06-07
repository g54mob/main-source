namespace XGamingRuntime.Interop
{
	internal struct XblMultiplayerConnectionAddressDeviceTokenPair
	{
		internal readonly UTF8StringPtr connectionAddress;

		internal readonly XblDeviceToken deviceToken;

		internal XblMultiplayerConnectionAddressDeviceTokenPair(XGamingRuntime.XblMultiplayerConnectionAddressDeviceTokenPair publicObject, DisposableCollection disposableCollection)
		{
			connectionAddress = default(UTF8StringPtr);
			deviceToken = default(XblDeviceToken);
		}
	}
}
