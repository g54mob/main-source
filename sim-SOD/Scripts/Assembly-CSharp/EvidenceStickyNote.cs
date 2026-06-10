using System.Collections.Generic;

public class EvidenceStickyNote : Evidence
{
	public EvidenceStickyNote(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GenerateName()
	{
		return null;
	}
}
