namespace VoxelBusters.EssentialKit.RateMyAppCore
{
	public class NullRateMyAppInterface : NativeRateMyAppInterfaceBase
	{
		public NullRateMyAppInterface()
			: base(isAvailable: false)
		{
		}

		private static void LogNotSupported()
		{
		}

		public override void RequestStoreReview(string storeId = null)
		{
		}
	}
}
