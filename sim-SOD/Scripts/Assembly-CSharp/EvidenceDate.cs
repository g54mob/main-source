using System.Collections.Generic;

public class EvidenceDate : Evidence
{
	public string date;

	public EvidenceDate(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
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
}
