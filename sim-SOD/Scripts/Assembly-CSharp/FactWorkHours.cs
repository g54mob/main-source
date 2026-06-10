using System.Collections.Generic;

public class FactWorkHours : Fact
{
	public FactWorkHours(FactPreset newPreset, List<Evidence> newFromEvidence, List<Evidence> newToEvidence, List<object> newPassedObjects, List<Evidence.DataKey> overrideFromKeys, List<Evidence.DataKey> overrideToKeys, bool isCustomFact)
		: base(null, null, null, null, null, null, isCustomFact: false)
	{
	}

	public override string GetName(Evidence.FactLink specificLink = null)
	{
		return null;
	}
}
