using System;

namespace XGamingRuntime.Interop
{
	internal struct XStoreProduct
	{
		internal readonly UTF8StringPtr storeId;

		internal readonly UTF8StringPtr title;

		internal readonly UTF8StringPtr description;

		internal readonly UTF8StringPtr language;

		internal readonly UTF8StringPtr inAppOfferToken;

		internal readonly UTF8StringPtr linkUri;

		internal readonly XStoreProductKind productKind;

		internal readonly XStorePrice price;

		internal readonly NativeBool hasDigitalDownload;

		internal readonly NativeBool isInUserCollection;

		internal readonly uint keywordsCount;

		private unsafe readonly UTF8StringPtr* keywords;

		internal readonly uint skusCount;

		private unsafe readonly XStoreSku* skus;

		internal readonly uint imagesCount;

		private unsafe readonly XStoreImage* images;

		internal readonly uint videosCount;

		private unsafe readonly XStoreVideo* videos;

		internal T[] GetKeywords<T>(Func<UTF8StringPtr, T> ctor)
		{
			return null;
		}

		internal T[] GetSkus<T>(Func<XStoreSku, T> ctor)
		{
			return null;
		}

		internal T[] GetImages<T>(Func<XStoreImage, T> ctor)
		{
			return null;
		}

		internal T[] GetVideos<T>(Func<XStoreVideo, T> ctor)
		{
			return null;
		}

		internal unsafe XStoreProduct(XGamingRuntime.XStoreProduct publicObject, DisposableCollection disposableCollection)
		{
			storeId = default(UTF8StringPtr);
			title = default(UTF8StringPtr);
			description = default(UTF8StringPtr);
			language = default(UTF8StringPtr);
			inAppOfferToken = default(UTF8StringPtr);
			linkUri = default(UTF8StringPtr);
			productKind = default(XStoreProductKind);
			price = default(XStorePrice);
			hasDigitalDownload = default(NativeBool);
			isInUserCollection = default(NativeBool);
			keywordsCount = 0u;
			keywords = null;
			skusCount = 0u;
			skus = null;
			imagesCount = 0u;
			images = null;
			videosCount = 0u;
			videos = null;
		}
	}
}
