using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreGameLicense
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		internal byte[] skuStoreId;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isActive;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isTrialOwnedByThisUser;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isDiscLicense;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isTrial;

		internal uint trialTimeRemainingInSeconds;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] trialUniqueId;

		internal TimeT expirationDate;
	}
}
