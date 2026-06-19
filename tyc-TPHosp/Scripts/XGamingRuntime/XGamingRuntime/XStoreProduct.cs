using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreProduct
	{
		public string StoreId { get; }

		public string Title { get; }

		public string Description { get; }

		public string Language { get; }

		public string InAppOfferToken { get; }

		public string LinkUri { get; }

		public XStoreProductKind ProductKind { get; }

		public XStorePrice Price { get; }

		public bool HasDigitalDownload { get; }

		public bool IsInUserCollection { get; }

		public string[] Keywords { get; }

		public XStoreSku[] Skus { get; }

		public XStoreImage[] Images { get; }

		public XStoreVideo[] Videos { get; }

		internal XStoreProduct(XGamingRuntime.Interop.XStoreProduct rawProduct)
		{
			StoreId = rawProduct.storeId.GetString();
			Title = rawProduct.title.GetString();
			Description = rawProduct.description.GetString();
			Language = rawProduct.language.GetString();
			InAppOfferToken = rawProduct.inAppOfferToken.GetString();
			LinkUri = rawProduct.linkUri.GetString();
			ProductKind = rawProduct.productKind;
			Price = new XStorePrice(rawProduct.price);
			HasDigitalDownload = rawProduct.hasDigitalDownload;
			IsInUserCollection = rawProduct.isInUserCollection;
			Keywords = rawProduct.GetKeywords();
			Skus = rawProduct.GetSkus((XGamingRuntime.Interop.XStoreSku x) => new XStoreSku(x));
			Images = rawProduct.GetImages((XGamingRuntime.Interop.XStoreImage x) => new XStoreImage(x));
			Videos = rawProduct.GetVideos((XGamingRuntime.Interop.XStoreVideo x) => new XStoreVideo(x));
		}
	}
}
