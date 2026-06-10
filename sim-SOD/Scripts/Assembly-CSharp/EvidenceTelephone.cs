using System.Collections.Generic;

public class EvidenceTelephone : Evidence
{
	public Telephone telephone;

	public bool discoveredEverything;

	public EvidenceTelephone(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GenerateName()
	{
		return null;
	}

	public override void BuildDataSources()
	{
	}

	public override void OnConnectedFactDiscovery(CaseComponent discovered)
	{
	}

	public override void OnDiscovery()
	{
	}

	public void OnInhabitantDiscovery(Discovery disc)
	{
	}

	public void MergedDataCheck(bool displayMessage)
	{
	}
}
