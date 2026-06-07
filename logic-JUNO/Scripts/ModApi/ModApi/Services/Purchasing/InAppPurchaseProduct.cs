using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace ModApi.Services.Purchasing
{
	public class InAppPurchaseProduct
	{
		public const string SandboxBundleId = "com.jundroo.junoneworigins.sandboxbundle";

		public static ReadOnlyCollection<InAppPurchaseProduct> AllConsumableProducts { get; }

		public static ReadOnlyCollection<InAppPurchaseProduct> AllNonConsumableProducts { get; }

		public static ReadOnlyCollection<InAppPurchaseProduct> AllProducts { get; }

		public static InAppPurchaseProduct CareerBundle { get; }

		public static InAppPurchaseProduct EngineerBundle { get; }

		public static InAppPurchaseProduct RemoveAds { get; }

		public static InAppPurchaseProduct SandboxBundle { get; }

		public bool Consumable { get; }

		public string Id { get; }

		public string NonLocalizedName { get; }

		static InAppPurchaseProduct()
		{
			CareerBundle = new InAppPurchaseProduct("com.jundroo.junoneworigins.careerbundle", "Career Bundle", consumable: false);
			EngineerBundle = new InAppPurchaseProduct("com.jundroo.junoneworigins.engineerbundle", "Engineer Bundle", consumable: false);
			RemoveAds = new InAppPurchaseProduct("com.jundroo.junoneworigins.removeads", "Remove Ads", consumable: false);
			SandboxBundle = new InAppPurchaseProduct("com.jundroo.junoneworigins.sandboxbundle", "Sandbox Bundle", consumable: false);
			AllProducts = (from x in typeof(InAppPurchaseProduct).GetProperties(BindingFlags.Static | BindingFlags.Public)
				where x.PropertyType == typeof(InAppPurchaseProduct)
				select (InAppPurchaseProduct)x.GetValue(null)).ToList().AsReadOnly();
			AllNonConsumableProducts = AllProducts.Where((InAppPurchaseProduct x) => !x.Consumable).ToList().AsReadOnly();
			AllConsumableProducts = AllProducts.Where((InAppPurchaseProduct x) => x.Consumable).ToList().AsReadOnly();
		}

		public InAppPurchaseProduct(string id, string nonLocalizedName, bool consumable)
		{
			Id = id;
			NonLocalizedName = nonLocalizedName;
			Consumable = consumable;
		}

		public static InAppPurchaseProduct GetById(string productId)
		{
			return AllProducts.FirstOrDefault((InAppPurchaseProduct x) => x.Id == productId);
		}
	}
}
