using System;
using System.Threading.Tasks;
using Jundroo.Services.Purchasing.Events;
using UnityEngine;

namespace Jundroo.Services.Purchasing
{
	public abstract class PurchasingManagerBase : MonoBehaviour
	{
		private TaskCompletionSource<PurchaseProductResult> _activePurchaseTaskCompletionSource;

		private bool _productsRegistered;

		public bool Initialized => PurchasingService.Initialized;

		protected (InitializationFailureReason Reason, string Message) InitializationFailureInfo { get; private set; }

		public bool IsProductAvailable(string productId)
		{
			return (Initialized ? PurchasingService.IsProductAvailable(productId) : ((bool?)null)) == true;
		}

		public bool IsProductOwned(string productId)
		{
			if (!PurchasingService.EnabledInBuild)
			{
				return true;
			}
			bool? flag = (Initialized ? PurchasingService.IsProductOwned(productId) : ((bool?)null));
			if (!flag.HasValue)
			{
				flag = GetPurchasesLocalCache(productId);
			}
			return flag.Value;
		}

		public Task<PurchaseProductResult> PurchaseProductAsync(string productId)
		{
			TaskCompletionSource<PurchaseProductResult> taskCompletionSource = new TaskCompletionSource<PurchaseProductResult>();
			try
			{
				_activePurchaseTaskCompletionSource = taskCompletionSource;
				PurchasingService.PurchaseProduct(productId);
			}
			catch (Exception exception)
			{
				taskCompletionSource.SetException(exception);
			}
			return taskCompletionSource.Task;
		}

		internal void RegisterProducts(PurchasingService.RegisterProductDelegate registerProduct)
		{
			if (_productsRegistered)
			{
				throw new Exception("Unable to register products: Products have already been registered this session.");
			}
			if (!PurchasingService.EnabledInBuild)
			{
				throw new Exception("Unable to register products: Purchasing is fully disabled in this build.");
			}
			if (PurchasingService.InitializationState != InitializationState.Initializing)
			{
				throw new Exception("Unable to register products: Products may only be registered when the service is initializing.");
			}
			_productsRegistered = true;
			OnRegisterProducts(registerProduct);
		}

		protected static string GetLocalCacheKeyForPurchases(string productId)
		{
			return "InApps.Purchases." + productId;
		}

		protected static bool GetPurchasesLocalCache(string productId)
		{
			return PlayerPrefs.GetInt(GetLocalCacheKeyForPurchases(productId), 0) > 0;
		}

		protected static void UpdatePurchasesLocalCache(string productId, bool owned)
		{
			string localCacheKeyForPurchases = GetLocalCacheKeyForPurchases(productId);
			if (owned)
			{
				PlayerPrefs.SetInt(localCacheKeyForPurchases, 1);
			}
			else
			{
				PlayerPrefs.DeleteKey(localCacheKeyForPurchases);
			}
			PlayerPrefs.Save();
		}

		protected virtual void Awake()
		{
			PurchasingService.InitializationSucceeded += OnInitialized;
			PurchasingService.InitializationFailed += OnInitializationFailed;
			PurchasingService.PurchaseSucceeded += OnPurchaseSucceeded;
			PurchasingService.PurchaseFailed += OnPurchaseFailed;
			PurchasingService.PurchaseCompleted += OnPurchaseCompleted;
		}

		protected virtual void OnInitializationFailed(InitializationFailureReason failureReason, string message)
		{
		}

		protected virtual void OnInitialized()
		{
		}

		protected virtual void OnPurchaseCompleted(Product product, PurchaseProductResult purchaseProductResult)
		{
		}

		protected virtual void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason, string message)
		{
		}

		protected virtual void OnPurchaseSucceeded(Product product)
		{
		}

		protected abstract void OnRegisterProducts(PurchasingService.RegisterProductDelegate registerProduct);

		protected virtual void OnUpdateNonConsumableProductInfo(Product product)
		{
		}

		private void OnInitializationFailed(object sender, InitializationFailedEventArgs e)
		{
			Debug.LogError($"Purchasing service initialization failed: {e.FailureReason}: {e.Message}");
			InitializationFailureInfo = (Reason: e.FailureReason, Message: e.Message);
			OnInitializationFailed(e.FailureReason, e.Message);
		}

		private void OnInitialized(object sender, InitializationSucceededEventArgs e)
		{
			Debug.Log("Purchasing service initialization succeeded.");
			foreach (Product product in PurchasingService.GetProducts())
			{
				if (product.Definition.Type == ProductType.NonConsumable)
				{
					UpdateNonConsumableProductInfo(product);
				}
			}
			OnInitialized();
		}

		private void OnPurchaseCompleted(object sender, ProductPurchaseCompletedEventArgs e)
		{
			Debug.Log("Purchase Completed (" + (e.Success ? "Success" : "Failure") + ") for product '" + e.Product.Definition.Id + "'");
			PurchaseProductResult purchaseProductResult = new PurchaseProductResult(e.Product, e.FailureReason, e.FailureMessage);
			OnPurchaseCompleted(e.Product, purchaseProductResult);
			if (_activePurchaseTaskCompletionSource != null)
			{
				_activePurchaseTaskCompletionSource.SetResult(purchaseProductResult);
				_activePurchaseTaskCompletionSource = null;
			}
			else
			{
				Debug.LogError("The active task completion source was null in the OnPurchaseCompleted callback.");
			}
		}

		private void OnPurchaseFailed(object sender, ProductPurchaseFailedEventArgs e)
		{
			Debug.LogError($"Purchase failed for product '{e.Product.Definition.Id}': {e.FailureReason}: {e.Message}");
			OnPurchaseFailed(e.Product, e.FailureReason, e.Message);
		}

		private void OnPurchaseSucceeded(object sender, ProductPurchaseSucceededEventArgs e)
		{
			Debug.Log("Purchase succeeded for product '" + e.Product.Definition.Id + "'");
			UpdateNonConsumableProductInfo(e.Product);
			OnPurchaseSucceeded(e.Product);
		}

		private void UpdateNonConsumableProductInfo(Product product)
		{
			UpdatePurchasesLocalCache(product.Definition.Id, product.HasReceipt);
			OnUpdateNonConsumableProductInfo(product);
		}
	}
}
