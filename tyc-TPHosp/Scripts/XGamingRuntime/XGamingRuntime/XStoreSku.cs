using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreSku
	{
		public string SkuId { get; }

		public string Title { get; }

		public string Description { get; }

		public string Language { get; }

		public XStorePrice Price { get; }

		public bool IsTrial { get; }

		public bool IsInUserCollection { get; }

		public XStoreCollectionData CollectionData { get; }

		public bool IsSubscription { get; }

		public XStoreSubscriptionInfo SubscriptionInfo { get; }

		public string[] BundledSkus { get; }

		public XStoreImage[] Images { get; }

		public XStoreVideo[] Videos { get; }

		public XStoreAvailability[] Availabilities { get; }

		internal XStoreSku(XGamingRuntime.Interop.XStoreSku rawSku)
		{
			SkuId = rawSku.skuId.GetString();
			Title = rawSku.title.GetString();
			Description = rawSku.description.GetString();
			Language = rawSku.language.GetString();
			Price = new XStorePrice(rawSku.price);
			IsTrial = rawSku.isTrial;
			IsInUserCollection = rawSku.isInUserCollection;
			CollectionData = new XStoreCollectionData(rawSku.collectionData);
			IsSubscription = rawSku.isSubscription;
			SubscriptionInfo = new XStoreSubscriptionInfo(rawSku.subscriptionInfo);
			BundledSkus = rawSku.GetBundledSkus();
			Images = rawSku.GetImages((XGamingRuntime.Interop.XStoreImage x) => new XStoreImage(x));
			Videos = rawSku.GetVideos((XGamingRuntime.Interop.XStoreVideo x) => new XStoreVideo(x));
			Availabilities = rawSku.GetAvailabilities((XGamingRuntime.Interop.XStoreAvailability x) => new XStoreAvailability(x));
		}
	}
}
