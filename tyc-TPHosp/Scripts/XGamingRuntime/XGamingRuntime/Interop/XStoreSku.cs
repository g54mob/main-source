using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreSku
	{
		internal UTF8StringPtr skuId;

		internal UTF8StringPtr title;

		internal UTF8StringPtr description;

		internal UTF8StringPtr language;

		internal XStorePrice price;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isTrial;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isInUserCollection;

		internal XStoreCollectionData collectionData;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isSubscription;

		internal XStoreSubscriptionInfo subscriptionInfo;

		private uint bundledSkusCount;

		private IntPtr bundledSkus;

		private uint imagesCount;

		private IntPtr images;

		private uint videosCount;

		private IntPtr videos;

		private uint availabilitiesCount;

		private IntPtr availabilities;

		internal string[] GetBundledSkus()
		{
			return Converters.PtrToClassArray(bundledSkus, bundledSkusCount, (UTF8StringPtr s) => s.GetString());
		}

		internal T[] GetImages<T>(Func<XStoreImage, T> ctor)
		{
			return Converters.PtrToClassArray(images, imagesCount, ctor);
		}

		internal T[] GetVideos<T>(Func<XStoreVideo, T> ctor)
		{
			return Converters.PtrToClassArray(videos, videosCount, ctor);
		}

		internal T[] GetAvailabilities<T>(Func<XStoreAvailability, T> ctor)
		{
			return Converters.PtrToClassArray(availabilities, availabilitiesCount, ctor);
		}
	}
}
