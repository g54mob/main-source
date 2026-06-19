using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreCollectionData
	{
		internal TimeT acquiredDate;

		internal TimeT startDate;

		internal TimeT endDate;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isTrial;

		internal uint trialTimeRemainingInSeconds;

		internal uint quantity;

		internal UTF8StringPtr campaignId;

		internal UTF8StringPtr developerOfferId;
	}
}
