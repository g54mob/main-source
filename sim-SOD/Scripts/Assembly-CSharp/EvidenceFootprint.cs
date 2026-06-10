using System.Collections.Generic;

public class EvidenceFootprint : Evidence
{
	public EvidenceFootprint(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void OnDiscovery()
	{
	}

	public override void BuildDataSources()
	{
	}

	public void UpdateSummary()
	{
	}

	public override string GetNameForDataKey(List<DataKey> inputKeys)
	{
		return null;
	}
}
