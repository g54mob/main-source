using System;
using System.Collections.Generic;
using System.Linq;
using Jundroo.Services.Purchasing;
using ModApi.Services.Purchasing;

namespace Assets.Scripts.Services.Purchasing
{
	public class InAppPurchaseFeature : IInAppPurchaseFeature
	{
		public static readonly InAppPurchaseFeature DefaultUnlocked = new InAppPurchaseFeature(string.Empty, string.Empty, unlocked: true, readOnly: true, new List<string>(1) { string.Empty });

		private bool _isReadOnly;

		public IReadOnlyCollection<string> AllProductIds { get; }

		public string ProductId { get; }

		public string ProductName { get; private set; }

		public bool Unlocked { get; private set; }

		public InAppPurchaseFeature(params InAppPurchaseProduct[] products)
		{
			ProductId = products[0].Id;
			ProductName = products[0].NonLocalizedName;
			Unlocked = !PurchasingService.EnabledInBuild;
			AllProductIds = new List<string>(products.Select((InAppPurchaseProduct x) => x.Id));
			_isReadOnly = false;
		}

		private InAppPurchaseFeature(string productId, string productName, bool unlocked, bool readOnly, List<string> allProductIds)
		{
			ProductId = productId;
			ProductName = productName;
			Unlocked = unlocked;
			AllProductIds = new List<string>(1) { productId };
			_isReadOnly = readOnly;
		}

		public void UpdateProductInfo(string productName)
		{
			if (_isReadOnly)
			{
				throw new InvalidOperationException("InAppPurchaseFeature with id '" + ProductId + "' is marked as read only. Unable to perform the update.");
			}
			ProductName = productName;
		}

		public void UpdateStatus(bool unlocked)
		{
			if (_isReadOnly)
			{
				throw new InvalidOperationException("InAppPurchaseFeature with id '" + ProductId + "' is marked as read only. Unable to perform the update.");
			}
			Unlocked = unlocked;
		}
	}
}
