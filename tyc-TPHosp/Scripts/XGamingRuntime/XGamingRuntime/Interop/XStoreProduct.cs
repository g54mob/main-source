using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreProduct
	{
		internal UTF8StringPtr storeId;

		internal UTF8StringPtr title;

		internal UTF8StringPtr description;

		internal UTF8StringPtr language;

		internal UTF8StringPtr inAppOfferToken;

		internal UTF8StringPtr linkUri;

		internal XStoreProductKind productKind;

		internal XStorePrice price;

		[MarshalAs(UnmanagedType.U1)]
		internal bool hasDigitalDownload;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isInUserCollection;

		private uint keywordsCount;

		private IntPtr keywords;

		private uint skusCount;

		private IntPtr skus;

		private uint imagesCount;

		private IntPtr images;

		private uint videosCount;

		private IntPtr videos;

		internal string[] GetKeywords()
		{
			return Converters.PtrToClassArray(keywords, keywordsCount, (UTF8StringPtr str) => str.GetString());
		}

		internal T[] GetSkus<T>(Func<XStoreSku, T> ctor)
		{
			return Converters.PtrToClassArray(skus, skusCount, ctor);
		}

		internal T[] GetImages<T>(Func<XStoreImage, T> ctor)
		{
			return Converters.PtrToClassArray(images, imagesCount, ctor);
		}

		internal T[] GetVideos<T>(Func<XStoreVideo, T> ctor)
		{
			return Converters.PtrToClassArray(videos, videosCount, ctor);
		}
	}
}
