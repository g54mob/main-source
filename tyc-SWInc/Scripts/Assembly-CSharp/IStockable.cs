using System.Collections.Generic;

public interface IStockable : ILossable, IReferenceFix
{
	uint PhysicalCopies { get; set; }

	int HardwareMask { get; set; }

	int HardwareInputMask { get; set; }

	uint CopiesPerBox { get; }

	float HardwarePrice { get; set; }

	bool StockNotifications { get; }

	IStockable DeferStock { get; }

	SoftwareType SWType { get; }

	SoftwareCategory SWCat { get; }

	IManufacturable Manufacturing { get; }

	IList<FeatureBase> FeaturesBases { get; }

	bool IsReadOnlyJob { get; }

	string GetName();

	string GetIdentifyingName();

	string GetCompanyName();

	float GetPrintPrice(bool isAI = false);

	int GetLastPhysicalSales();

	uint GetTotalPhysicalSales();

	int GetSalesMonths();

	int GetLastMissedPhysicalSales();

	uint GetReach();

	float GetRealQuality();

	uint GetFollowers();

	uint GetMaxPhysicalCopies(out IStockable limiter);

	void ChangeAllPhysicalStock(int change);

	IList<uint> GetFeaturesFactors();

	IProductOrder PromoteHardware(uint copies);
}
