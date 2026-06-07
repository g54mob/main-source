using System.Collections.Generic;
using VoxelBusters.CoreLibrary.NativePlugins;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public abstract class BillingProductBase : NativeObjectBase, IBillingProduct
	{
		public string Id { get; private set; }

		public string PlatformId { get; private set; }

		public BillingProductType Type { get; private set; }

		public string LocalizedTitle => null;

		public string LocalizedDescription => null;

		public BillingPrice Price => null;

		public string LocalizedPrice => null;

		public string PriceCurrencyCode => null;

		public bool IsAvailable { get; private set; }

		public IEnumerable<BillingProductPayoutDefinition> Payouts { get; private set; }

		public object Tag => null;

		public string PriceCurrencySymbol => null;

		public BillingProductSubscriptionInfo SubscriptionInfo => null;

		public IEnumerable<BillingProductOffer> Offers => null;

		protected BillingProductBase(string id, string platformId, BillingProductType type, IEnumerable<BillingProductPayoutDefinition> payouts, bool isAvailable = true)
		{
		}

		~BillingProductBase()
		{
		}

		protected abstract string GetLocalizedTitleInternal();

		protected abstract string GetLocalizedDescriptionInternal();

		protected abstract BillingPrice GetPriceInternal();

		protected abstract BillingProductSubscriptionInfo GetSubscriptionInfoInternal();

		protected abstract IEnumerable<BillingProductOffer> GetOffersInternal();

		public override string ToString()
		{
			return null;
		}
	}
}
