using System.Collections.Generic;

public class FactPurchased : Fact
{
	public Company.SalesRecord sale;

	public FactPurchased(FactPreset newPreset, List<Evidence> newFromEvidence, List<Evidence> newToEvidence, List<object> newPassedObjects, List<Evidence.DataKey> overrideFromKeys, List<Evidence.DataKey> overrideToKeys, bool isCustomFact)
		: base(null, null, null, null, null, null, isCustomFact: false)
	{
	}

	public override string GenerateNameSuffix()
	{
		return null;
	}
}
