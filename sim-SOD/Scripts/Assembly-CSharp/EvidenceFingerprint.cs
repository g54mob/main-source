using System.Collections.Generic;

public class EvidenceFingerprint : Evidence
{
	public EvidenceFingerprint(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}

	public override void OnDiscovery()
	{
	}

	public override void BuildDataSources()
	{
	}

	public void UpdateSummary()
	{
	}

	public override string GetNameForDataKey(List<DataKey> inputKeys)
	{
		return null;
	}

	public void OnCitizensDataKeyChange()
	{
	}

	public override string GetNoteComposed(List<DataKey> keys, bool useLinks = true)
	{
		return null;
	}

	public override string GetNote(List<DataKey> keys)
	{
		return null;
	}
}
