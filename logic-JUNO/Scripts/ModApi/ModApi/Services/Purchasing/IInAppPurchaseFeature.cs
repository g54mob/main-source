using System.Collections.Generic;

namespace ModApi.Services.Purchasing
{
	public interface IInAppPurchaseFeature
	{
		IReadOnlyCollection<string> AllProductIds { get; }

		string ProductId { get; }

		string ProductName { get; }

		bool Unlocked { get; }
	}
}
