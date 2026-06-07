using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assets.Scripts.Ui.Purchase;
using Jundroo.Services.Purchasing;
using ModApi.Services.Purchasing;
using UnityEngine;

namespace Assets.Scripts.Services.Purchasing
{
	public class PurchasingManagerScript : PurchasingManagerBase, IPurchaseService
	{
		private InAppFeatures _features;

		public IInAppPurchaseFeatures<IInAppPurchaseFeature> Features => _features;

		bool IPurchaseService.Initialized => base.Initialized;

		public static IPurchaseService Create(GameObject parentGameObject)
		{
			PurchasingManagerScript purchasingManagerScript = new GameObject("PurchasingManager").AddComponent<PurchasingManagerScript>();
			purchasingManagerScript.gameObject.transform.SetParent(parentGameObject.transform, worldPositionStays: false);
			return purchasingManagerScript;
		}

		public void CreatePurchaseDialog(string initialProductId)
		{
			PurchaseDialogScript.Create(this, Game.Instance.UserInterface.Transform, initialProductId);
		}

		public (bool available, string price, bool purchased) GetProductStatus(string productId)
		{
			Product productById = PurchasingService.GetProductById(productId);
			return (available: productById.AvailableToPurchase, price: productById.Metadata.LocalizedPriceString, purchased: productById.HasReceipt);
		}

		Task<PurchaseProductResult> IPurchaseService.PurchaseProductAsync(string productId)
		{
			return PurchaseProductAsync(productId);
		}

		protected override void Awake()
		{
			base.Awake();
			_features = new InAppFeatures();
			UpdateFeatures(updateNames: false);
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdateFeatures(updateNames: true);
		}

		protected override void OnPurchaseSucceeded(Product product)
		{
			base.OnPurchaseSucceeded(product);
			UpdateFeatures(updateNames: false);
		}

		protected override void OnRegisterProducts(PurchasingService.RegisterProductDelegate registerProduct)
		{
			foreach (InAppPurchaseProduct allProduct in InAppPurchaseProduct.AllProducts)
			{
				registerProduct(allProduct.Id, (!allProduct.Consumable) ? ProductType.NonConsumable : ProductType.Consumable);
			}
		}

		private void UpdateFeatures(bool updateNames)
		{
			Dictionary<string, bool> dictionary = InAppPurchaseProduct.AllNonConsumableProducts.ToDictionary((InAppPurchaseProduct x) => x.Id, (InAppPurchaseProduct x) => IsProductOwned(x.Id));
			foreach (InAppPurchaseFeature item in _features.All)
			{
				bool unlocked = false;
				foreach (string allProductId in item.AllProductIds)
				{
					if (dictionary.TryGetValue(allProductId, out var value) && value)
					{
						unlocked = true;
						break;
					}
				}
				item.UpdateStatus(unlocked);
				if (!updateNames)
				{
					continue;
				}
				Product productById = PurchasingService.GetProductById(item.ProductId);
				if (productById == null)
				{
					continue;
				}
				string text = productById.Metadata.LocalizedTitle;
				if (Game.Instance.Device.IsAndroidBuild)
				{
					int num = text?.IndexOf("(com.jundroo.", StringComparison.OrdinalIgnoreCase) ?? (-1);
					if (num > 0)
					{
						text = text.Remove(num).Trim();
					}
				}
				item.UpdateProductInfo(text);
			}
		}
	}
}
