namespace XGamingRuntime.Interop
{
	internal struct XStoreCollectionData
	{
		internal readonly TimeT acquiredDate;

		internal readonly TimeT startDate;

		internal readonly TimeT endDate;

		internal readonly NativeBool isTrial;

		internal readonly uint trialTimeRemainingInSeconds;

		internal readonly uint quantity;

		internal readonly UTF8StringPtr campaignId;

		internal readonly UTF8StringPtr developerOfferId;

		internal XStoreCollectionData(XGamingRuntime.XStoreCollectionData publicObject, DisposableCollection disposableCollection)
		{
			acquiredDate = default(TimeT);
			startDate = default(TimeT);
			endDate = default(TimeT);
			isTrial = default(NativeBool);
			trialTimeRemainingInSeconds = 0u;
			quantity = 0u;
			campaignId = default(UTF8StringPtr);
			developerOfferId = default(UTF8StringPtr);
		}
	}
}
