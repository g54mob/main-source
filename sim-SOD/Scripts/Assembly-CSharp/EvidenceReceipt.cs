using System.Collections.Generic;

public class EvidenceReceipt : Evidence
{
	public Company soldHere;

	public float purchasedTime;

	public EvidenceTime purchaseTimeEvidence;

	public Fact fromFact;

	public List<InteractablePreset> purchased;

	public EvidenceReceipt(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void BuildDataSources()
	{
	}

	public override string GenerateName()
	{
		return null;
	}

	public override void OnDiscovery()
	{
	}
}
