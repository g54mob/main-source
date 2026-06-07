using System;

namespace XGamingRuntime.Interop
{
	internal struct XStoreSku
	{
		internal readonly UTF8StringPtr skuId;

		internal readonly UTF8StringPtr title;

		internal readonly UTF8StringPtr description;

		internal readonly UTF8StringPtr language;

		internal readonly XStorePrice price;

		internal readonly NativeBool isTrial;

		internal readonly NativeBool isInUserCollection;

		internal readonly XStoreCollectionData collectionData;

		internal readonly NativeBool isSubscription;

		internal readonly XStoreSubscriptionInfo subscriptionInfo;

		internal readonly uint bundledSkusCount;

		private unsafe readonly UTF8StringPtr* bundledSkus;

		internal readonly uint imagesCount;

		private unsafe readonly XStoreImage* images;

		internal readonly uint videosCount;

		private unsafe readonly XStoreVideo* videos;

		internal readonly uint availabilitiesCount;

		private unsafe readonly XStoreAvailability* availabilities;

		internal T[] GetBundledSkus<T>(Func<UTF8StringPtr, T> ctor)
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

		internal T[] GetAvailabilities<T>(Func<XStoreAvailability, T> ctor)
		{
			return null;
		}

		internal unsafe XStoreSku(XGamingRuntime.XStoreSku publicObject, DisposableCollection disposableCollection)
		{
			skuId = default(UTF8StringPtr);
			title = default(UTF8StringPtr);
			description = default(UTF8StringPtr);
			language = default(UTF8StringPtr);
			price = default(XStorePrice);
			isTrial = default(NativeBool);
			isInUserCollection = default(NativeBool);
			collectionData = default(XStoreCollectionData);
			isSubscription = default(NativeBool);
			subscriptionInfo = default(XStoreSubscriptionInfo);
			bundledSkusCount = 0u;
			bundledSkus = null;
			imagesCount = 0u;
			images = null;
			videosCount = 0u;
			videos = null;
			availabilitiesCount = 0u;
			availabilities = null;
		}
	}
}
