using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Jundroo.Services.Purchasing.Events;
using UnityEngine;

namespace Jundroo.Services.Purchasing
{
	public static class PurchasingService
	{
		public delegate void RegisterProductDelegate(string productID, ProductType productType);

		public delegate void RegisterProductsDelegate(RegisterProductDelegate registerProductDelegate);

		public class InitializationParameters
		{
			public PurchasingManagerBase PurchasingManager { get; set; }

			public InitializationParameters()
			{
			}

			public InitializationParameters(PurchasingManagerBase purchasingManager)
			{
				PurchasingManager = purchasingManager;
			}
		}

		public static bool CanMakePayments { get; private set; }

		public static bool EnabledInBuild => false;

		public static InitializationState InitializationState { get; private set; }

		public static bool Initialized
		{
			get
			{
				if (EnabledInBuild)
				{
					return InitializationState == InitializationState.Initialized;
				}
				return false;
			}
		}

		public static event EventHandler<InitializationFailedEventArgs> InitializationFailed;

		public static event EventHandler<InitializationSucceededEventArgs> InitializationSucceeded;

		public static event EventHandler<ProductPurchaseCompletedEventArgs> PurchaseCompleted;

		public static event EventHandler<ProductPurchaseFailedEventArgs> PurchaseFailed;

		public static event EventHandler<ProductPurchaseSucceededEventArgs> PurchaseSucceeded;

		public static void ConfirmPendingPurchase(string id)
		{
			throw new InvalidOperationException("Attempting to confirm a purchase of an in-app product when purchasing as been fully disabled in the build.");
		}

		public static Product GetProductById(string id)
		{
			Debug.LogError("Attempting to get an in-app purchase product when purchasing as been fully disabled in the build.");
			return null;
		}

		public static List<Product> GetProducts()
		{
			Debug.LogError("Attempting to retrieve the list of purchasable products when purchasing as been fully disabled in the build.");
			return new List<Product>(0);
		}

		public static async Task Initialize(InitializationParameters initParams)
		{
			if (InitializationState != InitializationState.Uninitialized)
			{
				Debug.LogError("The purchasing service has already been initialized");
				return;
			}
			InitializationState = InitializationState.Initializing;
			await Task.CompletedTask;
		}

		public static bool? IsProductAvailable(string id)
		{
			return false;
		}

		public static bool? IsProductOwned(string id)
		{
			return true;
		}

		public static void PurchaseProduct(string id)
		{
			throw new InvalidOperationException("Attempting to purchase an in-app product when purchasing as been fully disabled in the build.");
		}

		public static void RestorePurchases(Action<bool, string> callback)
		{
			throw new InvalidOperationException("Attempting to restore purchases when purchasing as been fully disabled in the build.");
		}

		private static PurchaseProcessingResult ProcessPurchase(Product product)
		{
			if (ValidateReceipt(product, out var receiptProducts))
			{
				foreach (Product item in receiptProducts)
				{
					RaisePurchaseSucceededEvent(item);
				}
			}
			RaisePurchaseCompletedEvent(product, null, null);
			if (product.Definition.Type != ProductType.NonConsumable)
			{
				return PurchaseProcessingResult.Pending;
			}
			return PurchaseProcessingResult.Complete;
		}

		private static void RaiseInitializationSucceededEvent()
		{
			PurchasingService.InitializationSucceeded?.Invoke(null, new InitializationSucceededEventArgs());
		}

		private static void RaiseInitializeFailedEvent(InitializationFailureReason failureReason, string message)
		{
			PurchasingService.InitializationFailed?.Invoke(null, new InitializationFailedEventArgs(failureReason, message));
		}

		private static void RaisePurchaseCompletedEvent(Product product, PurchaseFailureReason? failureReason, string failureMessage)
		{
			PurchasingService.PurchaseCompleted?.Invoke(null, new ProductPurchaseCompletedEventArgs(product, failureReason, failureMessage));
		}

		private static void RaisePurchaseFailedEvent(Product product, PurchaseFailureReason failureReason, string message)
		{
			PurchasingService.PurchaseFailed?.Invoke(null, new ProductPurchaseFailedEventArgs(product, failureReason, message));
		}

		private static void RaisePurchaseSucceededEvent(Product product)
		{
			PurchasingService.PurchaseSucceeded?.Invoke(null, new ProductPurchaseSucceededEventArgs(product));
		}

		private static bool ValidateReceipt(Product purchasedProduct, out List<Product> receiptProducts)
		{
			receiptProducts = new List<Product>(1) { purchasedProduct };
			return true;
		}
	}
}
