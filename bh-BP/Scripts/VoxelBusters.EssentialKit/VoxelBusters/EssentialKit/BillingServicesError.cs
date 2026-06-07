using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	public static class BillingServicesError
	{
		public const string kDomain = "[Essential Kit] Billing Services";

		public static Error Unknown(string description = null)
		{
			return null;
		}

		public static Error NetworkError(string description = null)
		{
			return null;
		}

		public static Error SystemError(string description = null)
		{
			return null;
		}

		public static Error StoreNotInitialized(string description = null)
		{
			return null;
		}

		public static Error StoreIsBusy(string description = null)
		{
			return null;
		}

		public static Error UserCancelled(string description = null)
		{
			return null;
		}

		public static Error OfferNotApplicable(string description = null)
		{
			return null;
		}

		public static Error OfferNotValid(string description = null)
		{
			return null;
		}

		public static Error QuantityNotValid(string description = null)
		{
			return null;
		}

		public static Error ProductNotAvailable(string description = null)
		{
			return null;
		}

		public static Error ProductOwned(string description = null)
		{
			return null;
		}

		public static Error FeatureNotAvailable(string description = null)
		{
			return null;
		}

		private static Error CreateError(int code, string description)
		{
			return null;
		}
	}
}
