using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	public sealed class EcomInterface : Handle
	{
		public const int CatalogitemApiLatest = 1;

		public const int CatalogitemEntitlementendtimestampUndefined = -1;

		public const int CatalogofferApiLatest = 2;

		public const int CatalogofferExpirationtimestampUndefined = -1;

		public const int CatalogreleaseApiLatest = 1;

		public const int CheckoutApiLatest = 1;

		public const int CheckoutMaxEntries = 10;

		public const int CheckoutentryApiLatest = 1;

		public const int CopyentitlementbyidApiLatest = 2;

		public const int CopyentitlementbyindexApiLatest = 1;

		public const int CopyentitlementbynameandindexApiLatest = 1;

		public const int CopyitembyidApiLatest = 1;

		public const int CopyitemimageinfobyindexApiLatest = 1;

		public const int CopyitemreleasebyindexApiLatest = 1;

		public const int CopyofferbyidApiLatest = 1;

		public const int CopyofferbyindexApiLatest = 1;

		public const int CopyofferimageinfobyindexApiLatest = 1;

		public const int CopyofferitembyindexApiLatest = 1;

		public const int CopytransactionbyidApiLatest = 1;

		public const int CopytransactionbyindexApiLatest = 1;

		public const int EntitlementApiLatest = 2;

		public const int EntitlementEndtimestampUndefined = -1;

		public const int GetentitlementsbynamecountApiLatest = 1;

		public const int GetentitlementscountApiLatest = 1;

		public const int GetitemimageinfocountApiLatest = 1;

		public const int GetitemreleasecountApiLatest = 1;

		public const int GetoffercountApiLatest = 1;

		public const int GetofferimageinfocountApiLatest = 1;

		public const int GetofferitemcountApiLatest = 1;

		public const int GettransactioncountApiLatest = 1;

		public const int ItemownershipApiLatest = 1;

		public const int KeyimageinfoApiLatest = 1;

		public const int QueryentitlementsApiLatest = 2;

		public const int QueryentitlementsMaxEntitlementIds = 32;

		public const int QueryoffersApiLatest = 1;

		public const int QueryownershipApiLatest = 2;

		public const int QueryownershipMaxCatalogIds = 32;

		public const int QueryownershiptokenApiLatest = 2;

		public const int QueryownershiptokenMaxCatalogitemIds = 32;

		public const int RedeementitlementsApiLatest = 1;

		public const int RedeementitlementsMaxIds = 32;

		public const int TransactionidMaximumLength = 64;

		public EcomInterface()
		{
		}

		public EcomInterface(IntPtr innerHandle)
		{
		}

		public void Checkout(CheckoutOptions options, object clientData, OnCheckoutCallback completionDelegate)
		{
		}

		public Result CopyEntitlementById(CopyEntitlementByIdOptions options, out Entitlement outEntitlement)
		{
			outEntitlement = null;
			return default(Result);
		}

		public Result CopyEntitlementByIndex(CopyEntitlementByIndexOptions options, out Entitlement outEntitlement)
		{
			outEntitlement = null;
			return default(Result);
		}

		public Result CopyEntitlementByNameAndIndex(CopyEntitlementByNameAndIndexOptions options, out Entitlement outEntitlement)
		{
			outEntitlement = null;
			return default(Result);
		}

		public Result CopyItemById(CopyItemByIdOptions options, out CatalogItem outItem)
		{
			outItem = null;
			return default(Result);
		}

		public Result CopyItemImageInfoByIndex(CopyItemImageInfoByIndexOptions options, out KeyImageInfo outImageInfo)
		{
			outImageInfo = null;
			return default(Result);
		}

		public Result CopyItemReleaseByIndex(CopyItemReleaseByIndexOptions options, out CatalogRelease outRelease)
		{
			outRelease = null;
			return default(Result);
		}

		public Result CopyOfferById(CopyOfferByIdOptions options, out CatalogOffer outOffer)
		{
			outOffer = null;
			return default(Result);
		}

		public Result CopyOfferByIndex(CopyOfferByIndexOptions options, out CatalogOffer outOffer)
		{
			outOffer = null;
			return default(Result);
		}

		public Result CopyOfferImageInfoByIndex(CopyOfferImageInfoByIndexOptions options, out KeyImageInfo outImageInfo)
		{
			outImageInfo = null;
			return default(Result);
		}

		public Result CopyOfferItemByIndex(CopyOfferItemByIndexOptions options, out CatalogItem outItem)
		{
			outItem = null;
			return default(Result);
		}

		public Result CopyTransactionById(CopyTransactionByIdOptions options, out Transaction outTransaction)
		{
			outTransaction = null;
			return default(Result);
		}

		public Result CopyTransactionByIndex(CopyTransactionByIndexOptions options, out Transaction outTransaction)
		{
			outTransaction = null;
			return default(Result);
		}

		public uint GetEntitlementsByNameCount(GetEntitlementsByNameCountOptions options)
		{
			return 0u;
		}

		public uint GetEntitlementsCount(GetEntitlementsCountOptions options)
		{
			return 0u;
		}

		public uint GetItemImageInfoCount(GetItemImageInfoCountOptions options)
		{
			return 0u;
		}

		public uint GetItemReleaseCount(GetItemReleaseCountOptions options)
		{
			return 0u;
		}

		public uint GetOfferCount(GetOfferCountOptions options)
		{
			return 0u;
		}

		public uint GetOfferImageInfoCount(GetOfferImageInfoCountOptions options)
		{
			return 0u;
		}

		public uint GetOfferItemCount(GetOfferItemCountOptions options)
		{
			return 0u;
		}

		public uint GetTransactionCount(GetTransactionCountOptions options)
		{
			return 0u;
		}

		public void QueryEntitlements(QueryEntitlementsOptions options, object clientData, OnQueryEntitlementsCallback completionDelegate)
		{
		}

		public void QueryOffers(QueryOffersOptions options, object clientData, OnQueryOffersCallback completionDelegate)
		{
		}

		public void QueryOwnership(QueryOwnershipOptions options, object clientData, OnQueryOwnershipCallback completionDelegate)
		{
		}

		public void QueryOwnershipToken(QueryOwnershipTokenOptions options, object clientData, OnQueryOwnershipTokenCallback completionDelegate)
		{
		}

		public void RedeemEntitlements(RedeemEntitlementsOptions options, object clientData, OnRedeemEntitlementsCallback completionDelegate)
		{
		}

		internal static void OnCheckoutCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryEntitlementsCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryOffersCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryOwnershipCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnQueryOwnershipTokenCallbackInternalImplementation(IntPtr data)
		{
		}

		internal static void OnRedeemEntitlementsCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern void EOS_Ecom_Checkout(IntPtr handle, IntPtr options, IntPtr clientData, OnCheckoutCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyEntitlementById(IntPtr handle, IntPtr options, ref IntPtr outEntitlement);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyEntitlementByIndex(IntPtr handle, IntPtr options, ref IntPtr outEntitlement);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyEntitlementByNameAndIndex(IntPtr handle, IntPtr options, ref IntPtr outEntitlement);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyItemById(IntPtr handle, IntPtr options, ref IntPtr outItem);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyItemImageInfoByIndex(IntPtr handle, IntPtr options, ref IntPtr outImageInfo);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyItemReleaseByIndex(IntPtr handle, IntPtr options, ref IntPtr outRelease);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyOfferById(IntPtr handle, IntPtr options, ref IntPtr outOffer);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyOfferByIndex(IntPtr handle, IntPtr options, ref IntPtr outOffer);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyOfferImageInfoByIndex(IntPtr handle, IntPtr options, ref IntPtr outImageInfo);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyOfferItemByIndex(IntPtr handle, IntPtr options, ref IntPtr outItem);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyTransactionById(IntPtr handle, IntPtr options, ref IntPtr outTransaction);

		[PreserveSig]
		internal static extern Result EOS_Ecom_CopyTransactionByIndex(IntPtr handle, IntPtr options, ref IntPtr outTransaction);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetEntitlementsByNameCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetEntitlementsCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetItemImageInfoCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetItemReleaseCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetOfferCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetOfferImageInfoCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetOfferItemCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern uint EOS_Ecom_GetTransactionCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_Ecom_QueryEntitlements(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryEntitlementsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Ecom_QueryOffers(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryOffersCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Ecom_QueryOwnership(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryOwnershipCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Ecom_QueryOwnershipToken(IntPtr handle, IntPtr options, IntPtr clientData, OnQueryOwnershipTokenCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Ecom_RedeemEntitlements(IntPtr handle, IntPtr options, IntPtr clientData, OnRedeemEntitlementsCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern void EOS_Ecom_Entitlement_Release(IntPtr entitlement);

		[PreserveSig]
		internal static extern void EOS_Ecom_CatalogItem_Release(IntPtr catalogItem);

		[PreserveSig]
		internal static extern void EOS_Ecom_CatalogOffer_Release(IntPtr catalogOffer);

		[PreserveSig]
		internal static extern void EOS_Ecom_KeyImageInfo_Release(IntPtr keyImageInfo);

		[PreserveSig]
		internal static extern void EOS_Ecom_CatalogRelease_Release(IntPtr catalogRelease);
	}
}
