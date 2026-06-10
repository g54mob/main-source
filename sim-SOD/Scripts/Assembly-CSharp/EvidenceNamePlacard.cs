using System.Collections.Generic;

public class EvidenceNamePlacard : Evidence
{
	public EvidenceNamePlacard(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void Compile()
	{
	}

	public override string GenerateName()
	{
		return null;
	}
}
