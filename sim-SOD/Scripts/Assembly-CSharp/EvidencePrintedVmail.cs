using System.Collections.Generic;

public class EvidencePrintedVmail : Evidence
{
	public int threadID;

	public int msgIndexID;

	public StateSaveData.MessageThreadSave thread;

	public EvidencePrintedVmail(EvidencePreset newPreset, string evID, Controller newController, List<object> newPassedObjects)
		: base(null, null, null, null)
	{
	}
}
