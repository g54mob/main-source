namespace XGamingRuntime.Interop
{
	internal struct XStoreSubscriptionInfo
	{
		internal readonly NativeBool hasTrialPeriod;

		internal readonly XStoreDurationUnit trialPeriodUnit;

		internal readonly uint trialPeriod;

		internal readonly XStoreDurationUnit billingPeriodUnit;

		internal readonly uint billingPeriod;

		internal XStoreSubscriptionInfo(XGamingRuntime.XStoreSubscriptionInfo publicObject)
		{
			hasTrialPeriod = default(NativeBool);
			trialPeriodUnit = default(XStoreDurationUnit);
			trialPeriod = 0u;
			billingPeriodUnit = default(XStoreDurationUnit);
			billingPeriod = 0u;
		}
	}
}
