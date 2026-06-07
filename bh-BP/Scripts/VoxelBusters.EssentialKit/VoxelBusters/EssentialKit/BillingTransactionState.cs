using System;

namespace VoxelBusters.EssentialKit
{
	public enum BillingTransactionState
	{
		Unknown = 0,
		Purchasing = 1,
		Purchased = 2,
		Failed = 3,
		[Obsolete("This state is deprecated. Instead, just use OnRestorePurchasesComplete event with Purchased status to identify restored/past purchases.", true)]
		Restored = 4,
		Deferred = 5,
		Refunded = 6
	}
}
