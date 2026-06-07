using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Assets.Scripts.Ui.Purchase;
using Jundroo.Services.Purchasing;
using ModApi.Services.Purchasing;
using UnityEngine;

namespace Assets.Scripts.Services.Purchasing
{
	public class FakePurchasingManagerScript : PurchasingManagerBase, IPurchaseService
	{
		protected enum PurchaseResultType
		{
			Success = 0,
			Failure = 1,
			Cancelled = 2,
			Exception = 3
		}

		private InAppFeatures _features;

		[SerializeField]
		private float _purchaseDelay = 0.5f;

		private List<string> _purchasedProducts = new List<string>();

		[SerializeField]
		private PurchaseResultType _purchaseResultType;

		public IInAppPurchaseFeatures<IInAppPurchaseFeature> Features => _features;

		bool IPurchaseService.Initialized => base.Initialized;

		public void CreatePurchaseDialog(string initialProductId)
		{
			PurchaseDialogScript.Create(this, Game.Instance.UserInterface.Transform, initialProductId);
		}

		public (bool available, string price, bool purchased) GetProductStatus(string productId)
		{
			bool item = _purchasedProducts.Contains(productId);
			string item2 = "unknown";
			if (productId == InAppPurchaseProduct.RemoveAds.Id)
			{
				item2 = "$1.99";
			}
			else if (productId == InAppPurchaseProduct.EngineerBundle.Id)
			{
				item2 = "¥0.99";
			}
			else if (productId == InAppPurchaseProduct.SandboxBundle.Id)
			{
				item2 = "€2.99";
			}
			else if (productId == InAppPurchaseProduct.CareerBundle.Id)
			{
				item2 = "£4.99";
			}
			return (available: true, price: item2, purchased: item);
		}

		Task<PurchaseProductResult> IPurchaseService.PurchaseProductAsync(string productId)
		{
			return Task.Run(delegate
			{
				Thread.Sleep((int)(_purchaseDelay * 1000f));
				switch (_purchaseResultType)
				{
				case PurchaseResultType.Success:
					AddPurchase(productId);
					return new PurchaseProductResult(null, null, null);
				case PurchaseResultType.Failure:
					return new PurchaseProductResult(null, PurchaseFailureReason.PurchasingUnavailable, "The purchasing service is not enabled in this build.");
				case PurchaseResultType.Cancelled:
					return new PurchaseProductResult(null, PurchaseFailureReason.UserCancelled, "The operation could not be completed.");
				default:
					throw new InvalidOperationException("The purchasing service is not enabled in this build.");
				}
			});
		}

		protected override void Awake()
		{
			base.Awake();
			_features = new InAppFeatures();
			foreach (InAppPurchaseFeature item in _features.All)
			{
				InAppPurchaseProduct byId = InAppPurchaseProduct.GetById(item.ProductId);
				if (byId == null)
				{
					throw new Exception("In-App purchasable product not found: " + item.ProductId);
				}
				item.UpdateProductInfo(byId.NonLocalizedName);
				item.UpdateStatus(unlocked: false);
			}
		}

		protected override void OnRegisterProducts(PurchasingService.RegisterProductDelegate registerProduct)
		{
			foreach (InAppPurchaseProduct allProduct in InAppPurchaseProduct.AllProducts)
			{
				registerProduct(allProduct.Id, (!allProduct.Consumable) ? ProductType.NonConsumable : ProductType.Consumable);
			}
		}

		private void AddPurchase(string productId)
		{
			_purchasedProducts.Add(productId);
			foreach (InAppPurchaseFeature item in _features.All)
			{
				if (item.AllProductIds.Contains(productId))
				{
					item.UpdateStatus(unlocked: true);
				}
			}
		}
	}
}
