using System.Collections.Generic;

public class EvidenceKey : Evidence
{
	public NewRoom keyTo;

	public EvidenceKey(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}
}
