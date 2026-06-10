using System.Collections.Generic;

public class EvidenceBuilding : Evidence
{
	public NewBuilding building;

	public EvidenceBuilding(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GetNoteComposed(List<DataKey> keys, bool useLinks = true)
	{
		return null;
	}

	public override string GetSummary(List<DataKey> keys)
	{
		return null;
	}

	public override string GenerateName()
	{
		return null;
	}

	public override string GetNote(List<DataKey> keys)
	{
		return null;
	}
}
