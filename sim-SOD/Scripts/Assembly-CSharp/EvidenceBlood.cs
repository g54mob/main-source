using System.Collections.Generic;

public class EvidenceBlood : Evidence
{
	public Citizen citizenController;

	public EvidenceBlood(EvidencePreset newPreset, string newID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GenerateNameSuffix()
	{
		return null;
	}
}
