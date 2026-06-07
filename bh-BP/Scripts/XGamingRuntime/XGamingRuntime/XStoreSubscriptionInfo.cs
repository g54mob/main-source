using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreSubscriptionInfo
	{
		public bool HasTrialPeriod { get; private set; }

		public XStoreDurationUnit TrialPeriodUnit { get; private set; }

		public uint TrialPeriod { get; private set; }

		public XStoreDurationUnit BillingPeriodUnit { get; private set; }

		public uint BillingPeriod { get; private set; }

		internal XStoreSubscriptionInfo(XGamingRuntime.Interop.XStoreSubscriptionInfo interopStruct)
		{
		}
	}
}
