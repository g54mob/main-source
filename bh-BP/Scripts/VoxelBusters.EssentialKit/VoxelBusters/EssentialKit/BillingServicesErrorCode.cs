using VoxelBusters.CoreLibrary;

namespace VoxelBusters.EssentialKit
{
	[IncludeInDocs]
	public enum BillingServicesErrorCode
	{
		Unknown = 0,
		NetworkError = 1,
		SystemError = 2,
		BillingNotAvailable = 3,
		StoreNotInitialized = 4,
		StoreIsBusy = 5,
		UserCancelled = 6,
		OfferNotApplicable = 7,
		OfferNotValid = 8,
		QuantityNotValid = 9,
		ProductNotAvailable = 10,
		ProductOwned = 11,
		FeatureNotAvailable = 12
	}
}
