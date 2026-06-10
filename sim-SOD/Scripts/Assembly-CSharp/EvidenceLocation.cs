using System.Collections.Generic;

public class EvidenceLocation : Evidence
{
	public NewGameLocation locationController;

	public EvidenceLocation(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void Compile()
	{
	}

	public override void MergeDataKeys(DataKey keyOne, DataKey keyTwo)
	{
	}

	public void OnPlayerArrival()
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

	public override string GetNameForDataKey(List<DataKey> inputKeys)
	{
		return null;
	}

	public override string GetNote(List<DataKey> keys)
	{
		return null;
	}
}
