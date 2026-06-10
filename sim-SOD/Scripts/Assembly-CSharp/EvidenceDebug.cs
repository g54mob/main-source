using System.Collections.Generic;

public class EvidenceDebug : Evidence
{
	public static int assignID;

	public int id;

	public EvidenceDebug(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GenerateName()
	{
		return null;
	}
}
