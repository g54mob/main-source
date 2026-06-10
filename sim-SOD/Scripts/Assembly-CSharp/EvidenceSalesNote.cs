using System.Collections.Generic;

public class EvidenceSalesNote : Evidence
{
	public NewAddress forSale;

	public EvidenceSalesNote(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}
}
