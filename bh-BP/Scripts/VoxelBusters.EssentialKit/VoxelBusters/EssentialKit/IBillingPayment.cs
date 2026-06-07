using System;

namespace VoxelBusters.EssentialKit
{
	public interface IBillingPayment
	{
		[Obsolete("This property is deprecated. Please use Product.Id(IBillingProduct.Id) in IBillingTransaction interface", true)]
		string ProductId { get; }

		[Obsolete("This property is deprecated. Please use Product.PlatformId(IBillingProduct.PlatformId) in IBillingTransaction interface", true)]
		string ProductPlatformId { get; }

		[Obsolete("This property is deprecated. Please use RequestedQuantity in IBillingTransaction interface", true)]
		int Quantity { get; }

		[Obsolete("This property is deprecated. Please use Tag in IBillingTransaction interface", true)]
		string Tag { get; }
	}
}
