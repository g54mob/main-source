using System;
using System.Runtime.CompilerServices;
using VoxelBusters.CoreLibrary;
using VoxelBusters.EssentialKit.BillingServicesCore;

namespace VoxelBusters.EssentialKit
{
	public static class BillingServices
	{
		internal const string kNullProductId = "null";

		[ClearOnReload]
		private static INativeBillingServicesInterface s_nativeInterface;

		public static BillingServicesUnitySettings UnitySettings { get; private set; }

		public static BillingProductDefinition[] ProductDefinitions { get; private set; }

		public static IBillingProduct[] Products { get; private set; }

		internal static IBillingProduct[] InactiveProducts { get; private set; }

		public static event EventCallback<BillingServicesInitializeStoreResult> OnInitializeStoreComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Callback<BillingServicesTransactionStateChangeResult> OnTransactionStateChange
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventCallback<BillingServicesRestorePurchasesResult> OnRestorePurchasesComplete
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsAvailable()
		{
			return false;
		}

		public static void Initialize(BillingServicesUnitySettings settings)
		{
		}

		internal static BillingProductDefinition FindProductDefinitionWithId(string id, bool returnObjectOnFail = false)
		{
			return null;
		}

		internal static BillingProductDefinition FindProductDefinitionWithPlatformId(string platformId, bool returnObjectOnFail = false)
		{
			return null;
		}

		public static void InitializeStore()
		{
		}

		public static void InitializeStore(BillingProductDefinition[] productDefinitions)
		{
		}

		private static IBillingProduct[] ConvertToProductArray(BillingProductDefinition[] inctiveDefinitions)
		{
			return null;
		}

		public static IBillingProduct GetProductWithId(string id, bool includeInactive = false)
		{
			return null;
		}

		public static bool CanMakePayments()
		{
			return false;
		}

		public static bool IsProductPurchased(string productId)
		{
			return false;
		}

		public static bool IsProductPurchased(IBillingProduct product)
		{
			return false;
		}

		public static void BuyProduct(string productId, BuyProductOptions options = null)
		{
		}

		public static void BuyProduct(IBillingProduct product, BuyProductOptions options = null)
		{
		}

		public static IBillingTransaction[] GetTransactions()
		{
			return null;
		}

		public static void FinishTransactions(IBillingTransaction[] transactions)
		{
		}

		public static void RestorePurchases(bool forceRefresh = false, string tag = null)
		{
		}

		[Obsolete("This method is deprecated. Use BuyProduct with BuyProductOptions parameter", true)]
		public static bool BuyProduct(string productId, int quantity = 1, string applicationUsername = null)
		{
			return false;
		}

		[Obsolete("This method is deprecated. Use BuyProduct with BuyProductOptions parameter", true)]
		public static bool BuyProduct(IBillingProduct product, int quantity = 1, string applicationUsername = null)
		{
			return false;
		}

		[Obsolete("This method is obsolete. Use RestorePurchases with forceRefresh parameter", true)]
		public static void RestorePurchases(string tag = null)
		{
		}

		private static void RegisterForEvents()
		{
		}

		private static void UnregisterFromEvents()
		{
		}

		private static void HandleOnRetrieveProductsComplete(IBillingProduct[] products, string[] invalidProductIds, Error error)
		{
		}

		private static void HandleOnTransactionStateChange(IBillingTransaction[] transactions)
		{
		}

		private static void HandleOnRestorePurchasesComplete(IBillingTransaction[] transactions, Error error)
		{
		}
	}
}
