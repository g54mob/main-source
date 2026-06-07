using System.Collections.Generic;
using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public static class IAPManager
	{
		private enum InternalState
		{
			NotInitialized = 0,
			Initializing = 1,
			Initialized = 2
		}

		private static IBillingProduct[] s_cachedProducts;

		private static Dictionary<string, IBillingProduct> s_cachedProductsMap;

		private static InternalState s_currentState;

		private static bool s_isPurchasing;

		private static bool s_isRestoring;

		private static EventCallback<IBillingProduct[]> s_getProductsObservers;

		private static EventCallback<IBillingTransaction> s_buyProductObserver;

		private static EventCallback<IBillingTransaction[]> s_restorePurchasesObservers;

		public static event EventCallback<BillingServicesInitializeStoreResult> OnInitializeStoreComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event Callback<BillingServicesTransactionStateChangeResult> OnTransactionStateChange
		{
			add
			{
			}
			remove
			{
			}
		}

		public static event EventCallback<BillingServicesRestorePurchasesResult> OnRestorePurchasesComplete
		{
			add
			{
			}
			remove
			{
			}
		}

		static IAPManager()
		{
		}

		public static void SetDirty()
		{
		}

		public static void GetBillingProducts(EventCallback<IBillingProduct[]> callback)
		{
		}

		public static void BuyProduct(string productId, EventCallback<IBillingTransaction> callback, string tag = null)
		{
		}

		public static void RestorePurchases(EventCallback<IBillingTransaction[]> callback, bool forceRefresh, string tag = null)
		{
		}

		private static void RegisterForCallbacks()
		{
		}

		private static void InitializeStore()
		{
		}

		private static bool TryInitializeStore(EventCallback<IBillingProduct[]> callback)
		{
			return false;
		}

		private static bool IsStoreAvailable()
		{
			return false;
		}

		private static void HandleOnInitializeStore(BillingServicesInitializeStoreResult result, Error error)
		{
		}

		private static void HandleOnTransactionStateChange(BillingServicesTransactionStateChangeResult result)
		{
		}

		private static void HandleOnRestorePurchasesComplete(BillingServicesRestorePurchasesResult result, Error error)
		{
		}
	}
}
