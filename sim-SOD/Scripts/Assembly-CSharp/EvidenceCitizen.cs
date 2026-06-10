using System.Collections.Generic;

public class EvidenceCitizen : EvidenceWitness
{
	public Human witnessController;

	public EvidenceCitizen(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override string GetNote(List<DataKey> keys)
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

	public override void NamePhotoMerge()
	{
	}

	public override string GetNoteComposed(List<DataKey> keys, bool useLinks = true)
	{
		return null;
	}
}
