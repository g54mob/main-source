using System.Collections.Generic;

public interface IMarketable : ILossable, IReferenceFix
{
	SoftwareCategory SWCat { get; }

	string GetName();

	string GetTypeName();

	SDateTime GetReleaseDate();

	IList<FeatureBase> GetFeatures();

	float GetLastMonthIncome();

	float GetLastDayIncome(bool gross);

	float GetAwareness();

	float GetRealQuality();

	void AddToMarketing(float amount);

	bool IsMarketable();

	int GetSalesMonths();
}
