using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit.BillingServicesCore
{
	public delegate void RetrieveProductsInternalCallback(IBillingProduct[] products, string[] invalidIds, Error error);
}
