using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreSubscriptionInfo
	{
		[MarshalAs(UnmanagedType.U1)]
		internal bool hasTrialPeriod;

		internal XStoreDurationUnit trialPeriodUnit;

		internal uint trialPeriod;

		internal XStoreDurationUnit billingPeriodUnit;

		internal uint billingPeriod;
	}
}
