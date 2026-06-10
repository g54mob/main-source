using System.Collections.Generic;

public class EvidenceTime : Evidence
{
	public float timeFrom;

	public float timeTo;

	public string duration;

	public EvidenceTime(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
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
