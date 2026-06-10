using System.Collections.Generic;

public class FactJob : Fact
{
	public FactJob(FactPreset newPreset, List<Evidence> newFromEvidence, List<Evidence> newToEvidence, List<object> newPassedObjects, List<Evidence.DataKey> overrideFromKeys, List<Evidence.DataKey> overrideToKeys, bool isCustomFact)
		: base(null, null, null, null, null, null, isCustomFact: false)
	{
	}

	public override void OnDiscovery()
	{
	}
}
