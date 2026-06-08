using System;
using System.Collections.Generic;
using UnityEngine.Purchasing;

public class InAppPurchaseController : UnityServicesInitializer.SSRPGService, IStoreListener
{
	[Serializable]
	public struct ProductInfo
	{
		public string id;

		public ProductType type;
	}

	public ProductInfo[] allProducts;

	private IStoreController storeController;

	private IExtensionProvider storeExtensionProvider;

	private IAppleExtensions m_AppleExtensions;

	private int pendingPurchaseCount;

	private List<Product> pendingDeliveries = new List<Product>();

	private List<Product> pendingCleanUp = new List<Product>();

	private IGooglePlayStoreExtensions googlePlayStoreExtensions;

	public static InAppPurchaseController singleton { get; private set; }

	public override bool IsInitialized()
	{
		if (storeController != null)
		{
			return storeExtensionProvider != null;
		}
		return false;
	}

	public override void Initialize()
	{
		ConfigurationBuilder configurationBuilder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
		configurationBuilder.Configure<IGooglePlayConfiguration>().SetDeferredPurchaseListener(OnDeferredPurchase);
		for (int i = 0; i < allProducts.Length; i++)
		{
			configurationBuilder.AddProduct(allProducts[i].id, allProducts[i].type);
		}
		SubscriptionController.singleton.AddProducts(configurationBuilder);
		UnityPurchasing.Initialize(this, configurationBuilder);
	}

	public void BuyProduct(string productId)
	{
		if (ExceptionHandlingUI.HasErrors())
		{
			GameplayActionMessages.SetMessage("\n\n\n\n\nPurchase prevented by critical error.\nPlease reboot game.", ColorConstants.yellow, 30f);
		}
		else
		{
			if (pendingPurchaseCount > 0)
			{
				return;
			}
			if (IsInitialized())
			{
				Product product = storeController.products.WithID(productId);
				if (product != null && product.availableToPurchase)
				{
					Utils.Log("InAppPurchaseController::BuyProduct() " + product.definition.id.ToString());
					pendingPurchaseCount++;
					storeController.InitiatePurchase(productId);
				}
				else
				{
					Utils.LogError("InAppPurchaseController::BuyProduct() failed for " + productId + ". Not purchasing product, either is not found or is not available for purchase");
				}
			}
			else
			{
				Utils.LogError("InAppPurchaseController::BuyProduct() failed. Not initialized.");
			}
		}
	}

	public decimal GetLocalizedPrice(string productId)
	{
		if (storeController != null)
		{
			Product product = storeController.products.WithID(productId);
			if (product != null)
			{
				return product.metadata.localizedPrice;
			}
		}
		return 0m;
	}

	public string GetLocalizedPriceString(string productId)
	{
		if (storeController != null)
		{
			Product product = storeController.products.WithID(productId);
			if (product != null && product.metadata != null)
			{
				string localizedPriceString = product.metadata.localizedPriceString;
				if (!string.IsNullOrEmpty(localizedPriceString))
				{
					if (localizedPriceString.EndsWith(".00"))
					{
						return localizedPriceString.Substring(0, localizedPriceString.Length - 3);
					}
					return localizedPriceString;
				}
				return "$?.00";
			}
		}
		return "$?.??";
	}

	public string GetLocalizedCurrencyCode()
	{
		if (allProducts.Length == 0 || storeController == null)
		{
			return "$";
		}
		string id = allProducts[0].id;
		Product product = storeController.products.WithID(id);
		if (product != null)
		{
			return product.metadata.isoCurrencyCode;
		}
		return "$";
	}

	public Product GetProductWithID(string productId)
	{
		return storeController.products.WithID(productId);
	}

	public bool HasPendingPurchases()
	{
		return pendingPurchaseCount > 0;
	}

	public bool HasPurchasesToDeliver()
	{
		return pendingDeliveries.Count > 0;
	}

	public List<Product> GetPendingDeliveries()
	{
		return pendingDeliveries;
	}

	public void MarkPurchaseAsDelivered(Product product)
	{
		if (pendingDeliveries.Contains(product))
		{
			pendingDeliveries.Remove(product);
			pendingCleanUp.Add(product);
		}
	}

	public void CleanupAllPurchases()
	{
		for (int i = 0; i < pendingCleanUp.Count; i++)
		{
			Product product = pendingCleanUp[i];
			if (product != null && product.definition != null)
			{
				string id = product.definition.id;
				if (product.transactionID != null)
				{
					Utils.Log("Confirming purchase: " + product.transactionID);
				}
				storeController.ConfirmPendingPurchase(product);
				decimal localizedPrice = GetLocalizedPrice(id);
				AnalyticsMacros.ShopPurchase(id, localizedPrice);
			}
		}
		pendingCleanUp.Clear();
	}

	private void OnDeferredPurchase(Product product)
	{
		Utils.Log("Purchase of " + product.definition.id + " is deferred");
	}

	public void RestorePurchases()
	{
		storeExtensionProvider.GetExtension<IAppleExtensions>().RestoreTransactions(delegate(bool result, string str)
		{
			if (result)
			{
				Utils.Log("Restore purchases succeeded.");
			}
			else
			{
				Utils.LogError("Restore purchases failed.");
			}
		});
	}

	private void Awake()
	{
		singleton = this;
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		Utils.LogIfEditor("InAppPurchaseController::OnInitialized()");
		storeController = controller;
		storeExtensionProvider = extensions;
		m_AppleExtensions = extensions.GetExtension<IAppleExtensions>();
		Dictionary<string, string> introductoryPriceDictionary = m_AppleExtensions.GetIntroductoryPriceDictionary();
		SubscriptionController.singleton.OnInitialized(controller, introductoryPriceDictionary);
	}

	public void OnInitializeFailed(InitializationFailureReason reason)
	{
		OnInitializeFailed(reason, "<no message>");
	}

	public void OnInitializeFailed(InitializationFailureReason reason, string message)
	{
		string text = "In-App purchase initialization failed: " + reason.ToString() + ", " + message;
		Utils.LogError(text);
		GameplayActionMessages.SetMessage(text, ColorConstants.yellow, 30f);
	}

	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		Utils.LogError($"InAppPurchaseController::OnPurchaseFailed() Product: '{product.definition.storeSpecificId}', Reason: {failureReason}");
		pendingPurchaseCount--;
	}

	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
	{
		Product purchasedProduct = args.purchasedProduct;
		if (true)
		{
			pendingDeliveries.Add(purchasedProduct);
		}
		else
		{
			GameplayActionMessages.SetMessage("Invalid purchase.", ColorConstants.red, 11f);
		}
		pendingPurchaseCount--;
		if (pendingPurchaseCount < 0)
		{
			pendingPurchaseCount = 0;
		}
		Dictionary<string, string> introductoryPriceDictionary = m_AppleExtensions.GetIntroductoryPriceDictionary();
		SubscriptionController.singleton.ProcessPurchase(purchasedProduct, introductoryPriceDictionary);
		Utils.LogIfEditor(purchasedProduct.receipt);
		Utils.Log(string.Format("InAppPurchaseController::ProcessPurchase() Complete. Product:" + purchasedProduct.definition.id + " - " + purchasedProduct.transactionID.ToString()));
		return PurchaseProcessingResult.Pending;
	}
}
