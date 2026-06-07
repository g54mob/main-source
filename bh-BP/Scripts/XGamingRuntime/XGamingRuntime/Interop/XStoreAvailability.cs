namespace XGamingRuntime.Interop
{
	internal struct XStoreAvailability
	{
		internal readonly UTF8StringPtr availabilityId;

		internal readonly XStorePrice price;

		internal readonly TimeT endDate;

		internal XStoreAvailability(XGamingRuntime.XStoreAvailability publicObject, DisposableCollection disposableCollection)
		{
			availabilityId = default(UTF8StringPtr);
			price = default(XStorePrice);
			endDate = default(TimeT);
		}
	}
}
