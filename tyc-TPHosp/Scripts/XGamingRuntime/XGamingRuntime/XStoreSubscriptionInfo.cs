using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreSubscriptionInfo
	{
		public bool HasTrialPeriod { get; }

		public XStoreDurationUnit TrialPeriodUnit { get; }

		public uint TrialPeriod { get; }

		public XStoreDurationUnit BillingPeriodUnit { get; }

		public uint BillingPeriod { get; }

		internal XStoreSubscriptionInfo(XGamingRuntime.Interop.XStoreSubscriptionInfo rawSubscriptionInfo)
		{
			HasTrialPeriod = rawSubscriptionInfo.hasTrialPeriod;
			TrialPeriodUnit = rawSubscriptionInfo.trialPeriodUnit;
			TrialPeriod = rawSubscriptionInfo.trialPeriod;
			BillingPeriodUnit = rawSubscriptionInfo.billingPeriodUnit;
			BillingPeriod = rawSubscriptionInfo.billingPeriod;
		}
	}
}
