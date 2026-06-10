using System.Collections.Generic;

public class EvidenceRetailItem : Evidence
{
	public Company soldHere;

	public RetailItemPreset retailItem;

	public EvidenceTime purchaseTimeEvidence;

	public float purchaseTime;

	public bool isAbstract;

	public Fact soldAtFact;

	public EvidenceRetailItem(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void BuildDataSources()
	{
	}

	public override string GetSummary(List<DataKey> keys)
	{
		return null;
	}

	public override string GenerateName()
	{
		return null;
	}

	public override void OnDiscovery()
	{
	}
}
