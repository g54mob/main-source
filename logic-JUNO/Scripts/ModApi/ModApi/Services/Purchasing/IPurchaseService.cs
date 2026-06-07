using System.Threading.Tasks;
using Jundroo.Services.Purchasing;

namespace ModApi.Services.Purchasing
{
	public interface IPurchaseService
	{
		bool EnabledInBuild => PurchasingService.EnabledInBuild;

		IInAppPurchaseFeatures<IInAppPurchaseFeature> Features { get; }

		bool Initialized { get; }

		void CreatePurchaseDialog(string initialProductId);

		(bool available, string price, bool purchased) GetProductStatus(string productId);

		Task<PurchaseProductResult> PurchaseProductAsync(string productId);
	}
}
