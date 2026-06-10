using System.Collections.Generic;

public class EvidenceWound : Evidence
{
	public EvidenceWound(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void BuildDataSources()
	{
	}
}
